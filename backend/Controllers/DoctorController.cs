using backend.Models;
using backend.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : Controller
    { 
        private readonly DoctorRepository  doctorRepository;
        private readonly ILogger<DoctorController> _logger;
        public DoctorController(ILogger<DoctorController> logger, DoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
            this._logger = logger;
        }

        // Get : /api/Doctor
        [HttpGet]
        public IActionResult  Get()
        {
            var doctor_list = doctorRepository.GetAll();
            return Ok(doctor_list);
        }
        //Get: /api/Doctor/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var doctor = doctorRepository.Get(id);
            return Ok(doctor);
        }

        //Post: /api/Doctor
        [HttpPost]
        public IActionResult Post([FromBody] Doctor doctor)
        {
            if (!ModelState.IsValid)
                return BadRequest("model state is not valid");

            var result = doctorRepository.Add(doctor);
            string url = Url.Action(nameof(Get), "Doctor", new { Id = result.Dr_ID }, Request.Scheme);
            return Created(url, true);         
        }

        // Put: /api/Doctor
        [HttpPut()]
        public IActionResult Put([FromBody] Doctor doctor)
        {
            if (!ModelState.IsValid)
                return BadRequest("model state is not valid");

            var result = doctorRepository.Update(doctor);
            return Ok(result);
        }

        // Delete: /api/Doctor/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = doctorRepository.Delete(id);
            if (result)
                return Ok(result);
            else
                return BadRequest("Child record found!");
        }
        /*
        // GET: DoctorController

        [HttpGet()]
        public IEnumerable<Doctor> GetDoctor()
        {
            var list = _context.Doctor.Include(o => o.User).ToList();            
            IQueryable<Doctor> query = _context.Doctor;
            query = query.Include(p => p.User);
            List<Doctor> data = query.ToList();
            return data;

            //list = (Microsoft.EntityFrameworkCore.DbSet<Doctor>)list.Take(10);

        }

        //[HttpGet("GetDoctorByName/{id?}")]
        [HttpGet("GetDoctorByName")]
        public IEnumerable<Doctor> GetDoctorByName(String I_Name)
        {

            IQueryable<Doctor> query = _context.Doctor;

            if (!string.IsNullOrWhiteSpace(I_Name))
            {
                query = query.Where(p => p.Dr_Name.ToLower().Contains(I_Name.ToLower()) ||
                                         p.Dr_Family.ToLower().Contains(I_Name.ToLower()) ) ;
            }
            List<Doctor> data = query.ToList();
            return data;

        }

        [HttpGet("GetDoctorByIDList/{id?}")]
        public IEnumerable<Doctor> GetDoctorByIDList(int id)
        {
            return _context.Doctor.Where(w => w.Dr_ID == id).ToList();
        }

        [HttpGet("GetDoctorByID/{id?}")]
        public Doctor GetDoctorByID(int id)
        {
            return _context.Doctor.Where(w => w.Dr_ID == id).First();
        }
        
        //POST: api/Create New Doctor 
        [HttpPost("CreateDoctor")]
        public async Task<IActionResult> CreateDoctor([FromBody] Models.Doctor i_Doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Doctor.Add(i_Doctor);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // post: DoctorController/UpdateDoctor/5
        [HttpPut("UpdateDoctor")]
        public async Task<IActionResult> UpdateDoctor([FromBody] Doctor in_Doctor)
        {
            if (ModelState.IsValid)
            {
                var temp = _context.Doctor.Find(in_Doctor.Dr_ID);
                temp.Dr_Name = in_Doctor.Dr_Name;
                temp.Dr_Family = in_Doctor.Dr_Family;
                temp.Dr_NationalCode = in_Doctor.Dr_NationalCode;
                temp.Specialty = in_Doctor.Specialty;
                

                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        // 
        

        // POST: DoctorController/DeleteDoctor/5
        [HttpDelete("DeleteDoctor/{id?}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Doctor = await _context.Doctor.FindAsync(id);
            if (Doctor == null)
            {
                return NotFound();
            }

            _context.Doctor.Remove(Doctor);
            await _context.SaveChangesAsync();

            return Ok(Doctor);
        }
        */
    }
}
