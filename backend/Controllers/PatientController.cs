using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace backend.Controllers
{

    [Route("/api/[controller]")]
    public class PatientController : Controller
    {
        private Hospital_DBN2 _context;
        private readonly ILogger<PatientController> _logger;

        public PatientController(ILogger<PatientController> logger, Hospital_DBN2 context)
        {
            _context = context;
            _logger = logger;
        }
        // GET: PatientController
      
                [HttpGet("GetPatient")]
                public IEnumerable<Patient> GetPatient()
                { 
                    var list =  _context.Patient.Include(o =>o.User).ToList();
                    //   .Select(S => new { S.Patient_ID, S.FName, S.LName, S.User.Name, S.User.Family }).ToList();  
                    IQueryable<Patient> query = _context.Patient;
                    query = query.Include(p => p.User);
                    List<Patient> data = query.ToList();
                    return data;

                    //list = (Microsoft.EntityFrameworkCore.DbSet<Patient>)list.Take(10);

                }
        
        //[HttpGet("GetPatientByName/{id?}")]
        [HttpGet("GetPatientByName")]
        public IEnumerable<Patient> GetPatientByName(String I_Name)
        {

            IQueryable<Patient> query = _context.Patient;

            if (!string.IsNullOrWhiteSpace(I_Name))
            {
                query = query.Where(p => p.FName.ToLower().Contains(I_Name.ToLower())).Include(p => p.User);
            }
            List<Patient> data = query.ToList();
            return data;

            //list = (Microsoft.EntityFrameworkCore.DbSet<Patient>)list.Take(10);

        }
        /*
        [HttpGet("GetPatient")]
        public IEnumerable<Patient> GetPatient()
        {
            var list = _context.Patient.Include(o => o.User).ToList();
            //   .Select(S => new { S.Patient_ID, S.FName, S.LName, S.User.Name, S.User.Family }).ToList();  
            IQueryable<Patient> query = _context.Patient;
            query = query.Include(p => p.User);
            List<Patient> data = query.ToList();
            return data;

            //list = (Microsoft.EntityFrameworkCore.DbSet<Patient>)list.Take(10);

        }
        /*
         var query = classifications
                    .Where(x => (x.Domains.Any(m => data.Contains(m.ProvinceId)) || !x.Domains.Any()) && x.Status == 1)
                    .AsNoTracking()
                    .Select(s => new { s.Id, s.Name, s.Abbreviation, s.ParentId })
                    .ToList();
        */

        [HttpGet("GetPatientByIDList/{id?}")]
        public IEnumerable<Patient> GetPatientByIDList(int id)
        {
            return _context.Patient.Where(w => w.Patient_ID == id).ToList();
        }

        [HttpGet("GetPatientByID/{id?}")]
        public Patient GetPatientByID(int id)
        {
            return  _context.Patient.Where(w => w.Patient_ID == id).First();
        }
        // GET: PatientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //POST: api/Create New Patient 
        [HttpPost("CreatePatient")]
        public async Task<IActionResult> CreatePatient([FromBody] Models.Patient i_Patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Patient.Add(i_Patient);
            await _context.SaveChangesAsync();
            return Ok();
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

        // post: PatientController/UpdatePatient/5
        [HttpPut("UpdatePatient")]
        public async Task<IActionResult> UpdatePatient([FromBody] Patient in_patient)
        {
            if (ModelState.IsValid)
            {
                var temp = _context.Patient.Find(in_patient.Patient_ID);
                temp.FName = in_patient.FName;
                temp.LName = in_patient.LName;
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        // 
        public bool PatientExists(long id)
        {
            var cnt = _context.Patient.Find(id);
            if (cnt != null)
                return true;
            else
                return false;
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

        // DELETE: api/Patient/id
        [HttpDelete("DeletePatient/{id?}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Patient = await _context.Patient.FindAsync(id);
            if (Patient == null)
            {
                return NotFound();
            }

            _context.Patient.Remove(Patient);
            await _context.SaveChangesAsync();

            return Ok(Patient);
        }

        private bool PatientExists(int id)
        { 
            return _context.Patient.Any(e => e.Patient_ID == id);
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
