using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{

    [Route("/api/[controller]")]
    public class PatientController : Controller
    {
        private Hospital_DBN2 _context;
        private readonly ILogger<PatientController> _logger;
         
        public PatientController  (ILogger<PatientController> logger,Hospital_DBN2 context)
        {
            _context = context;
            _logger = logger;
        }
        // GET: PatientController

        [HttpGet("GetPatient")]
        public IEnumerable<Patient> GetPatient()
        {
            var list =_context.Patient;
            //list = (Microsoft.EntityFrameworkCore.DbSet<Patient>)list.Take(10);
            return list;
        }
        // GET: PatientController/Details/5
        [HttpGet("GetPatientById2/{id?}")]
        public Patient GetPatientById2(int id)
        {
            return _context.Patient.Find(id);
        }

        [HttpGet("GetPatientByID/{id?}")]
        public IEnumerable<Patient> GetPatientByID(int id)
        {
            return _context.Patient.Where(w => w.Patient_ID == id).ToList();
        }
        // GET: PatientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PatientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
