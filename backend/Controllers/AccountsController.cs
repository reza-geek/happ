using AutoMapper;
using backend.App_start;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    
    public class AccountsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly JwtHandler _jwtHandler;

        public AccountsController(UserManager<User> userManager, IMapper mapper, JwtHandler jwtHandler)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
