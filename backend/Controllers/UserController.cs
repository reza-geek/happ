using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("/api/[controller]")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetUser/}")]
        public Patient GetPatientByID(int id)
        {
            return _context.Patient.Where(w => w.Patient_ID == id).First();
        }
        // GET: PatientController/Details/5

    }
}
