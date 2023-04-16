using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using backend.App_start;
using Microsoft.AspNetCore.Authorization;
//using System.Data.Entity.Core.Objects;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace backend.Controllers
{
    [Route("/api/[controller]")]
   // [Authorize]
    public class UserController : Controller
    {
        private Hospital_DBN2 _context;
        private readonly ILogger<UserController> _logger;

        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly JwtHandler _jwtHandler;


        //public UserController(ILogger<PatientController> logger, Hospital_DBN2 context )
        //{
        //    _context = context;
        //    _logger = logger;            
        //}

        public UserController(ILogger<UserController> logger, Hospital_DBN2 context,
           UserManager<User> userManager,
           IMapper mapper,
           JwtHandler jwtHandler)
        {
            _context = context;
            _logger = logger;

            _userManager = userManager;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetUser")]
        public User GetPatientByID(int id)
        {
            return _context.User_tbl.First();
        }

        [HttpPost("Login")]        
        public  ActionResult Login([FromBody] User i_user)
        {
            try
            {
                    if (i_user != null)
                {
                    if (string.IsNullOrWhiteSpace(i_user.Username) || string.IsNullOrWhiteSpace(i_user.Password))
                        //return new HttpUnauthorizedResult("Please enter username and password");
                        return BadRequest(ModelState);

                    var user = _context.User_tbl.FirstOrDefault(x => x.Username == i_user.Username.Trim() && x.Password == i_user.Password && x.Is_Active == true);
                    if( user ==null) 
                    {
                        return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
                    }
                    var signingCredentials = _jwtHandler.GetSigningCredentials();
                    var claims = _jwtHandler.GetClaims(new IdentityUser { UserName = user.Username });
                    var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
                    var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                    return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });

                    //    query = query.Where(p => p.Username.ToLower().Contains(username.ToLower()) &&
                    //                     p.Password.ToLower().Contains(password.ToLower()));

                    //List<User> data = await query.ToList();

                    //  return  data;

                    //return Ok(user != null ? user : "کاربر یافت نشد");
                }
                else
                    return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
            }
            catch (Exception ex)
            {
                return Json(new { error = Helper.getErrorMessage(ex) });
            }
        }

        [HttpPost("Login2")]
        public async Task<IActionResult> Login2([FromBody] User userForAuthentication)
        {
            var user = await _userManager.FindByNameAsync(userForAuthentication.Username);

            if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });

            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(new IdentityUser { UserName = user.Username });
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
        }
        // GET:  
        //[HttpPost("Login1")]
        //Route("app/Home/Login")]
        //[CustomAudit(IncludeResponseBody = true, IncludeHeaders = true)]
        /*
        public ActionResult Login1(string username, string password, bool loadWithPermissions = false, string guid = "", string captcha = "", string param = "", string param2 = "")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                    //return new HttpUnauthorizedResult("Please enter username and password");
                    return BadRequest(ModelState);

                //if (!string.IsNullOrEmpty(guid))
                //{
                //    var userCap = userCaptcha.FirstOrDefault(f => f.Guid == guid);
                //    if (userCap == null || userCap.Captcha != captcha)
                //        return new HttpUnauthorizedResult("Please enter captcha");
                //}

                //var hashedPass = Helper.GetSha256FromString(password);
                var user = users.AsNoTracking()
                    .Include(x => x.UserRegions.Select(up => up.Region))
                    .Include(x => x.UserRoles.Select(up => up.Role))
                    .Include(x => x.OwnedCustomers)
                    .Include(x => x.UserRoles.Select(ur => ur.Role.Domains))
                    .FirstOrDefault(x => x.UserName == username.Trim() && x.Password == hashedPass && x.IsActive == 1);
                if (user == null)
                    return new HttpUnauthorizedResult();
               
                var token = "";
                var login = new UserLogin
                {
                    ExpireOn = DateTime.Now.AddDays(1).Date,
                    LoginOn = DateTime.Now,
                    User = user,
                    UserId = user.Id
                };

                if (user.Position == UserPosition.webService)
                {
                    userCaptcha.RemoveRange(userCaptcha.Where(w => w.UserId == user.Id));
                    userCaptcha.Add(new UserCaptcha
                    {
                        UserId = user.Id,
                        Counter = 0
                    });

                    token = JwtTokenHelper.GetToken(login, int.Parse(ConfigurationManager.AppSettings["TokenTimeToLiveInMinute"]));
                }
                else
                {
                    token = JwtTokenHelper.GetToken(login);
                }

                userLogins.RemoveRange(userLogins.Where(x => x.UserId == user.Id));
                login.JwtToken = token;
                login.User = null;
                userLogins.Add(login);
                _uowProfile.SaveChanges();

                var Role = user.UserRoles.FirstOrDefault(w => w.DefualtRole == 1);

                //چک کردن ادرس درخواستها
                var url = Request != null ? (Request.UrlReferrer == null ? "" : Request.UrlReferrer.Authority.ToLower()) : (param == null ? "" : param);
                //چک کردن دسترسی به ادرسها
                var url2 = Request != null ? Request.Url.Authority.ToLower() : param2;

                if (Role == null ||
                    (!Role.Role.Domains.Any(w => w.Domain.Url.ToLower().Contains(url)) &&
                    !Role.Role.Domains.Any(w => w.Domain.Url.ToLower().Contains(url2))))
                    return new HttpUnauthorizedResult();

                if (loadWithPermissions)
                {
                    url = "/" + Role.Role.Domains.FirstOrDefault(w => w.Domain.Url.ToLower().Contains(url)).Domain.Url.Split('/')[1];

                    var data = roleApiPermission
                        .Include(i => i.ActionType)
                        .Where(w => w.RoleId == Role.RoleId)
                        .Select(s => new actTemp
                        {
                            desc = s.ActionType.Description,
                            action_id = s.ActionType.Id
                        })
                        .ToList();

                    //اضافه کردن دسترسی های ویژه
                    if (Role.SpecialAccess != null)
                    {
                        var spOpt = Role.SpecialAccess.Split(',').ToList();
                        var exc = spOpt.Where(w => !data.Select(s => s.action_id.ToString()).ToList().Contains(w)).ToList();
                        var excActs = actionMethodType.ToList().Where(f => exc.Contains(f.Id.ToString())).ToList();

                        foreach (var act in excActs)
                        {
                            data.Add(new actTemp
                            {
                                action_id = act.Id,
                                desc = act.Description
                            });
                        }
                    }

                    var controllers = data.Select(x => new
                    {
                        x.desc
                    })
                    .ToList();

                    return Json(new { token, controllers, url });
                }
                else
                {
                    return Json(token);
                }
            }
            catch (Exception ex)
            {
                return Json(new { error = Helper.getErrorMessage(ex) });
            }

        }
        */

    }

    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
    }
}
