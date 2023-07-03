using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace backend.Controllers
{

    [Route("/api/[controller]")]
    [ApiController]
    public class PatientController : Controller
    {
        private Hospital_DBN _context;
       

        public PatientController( Hospital_DBN context)
        {
            _context = context;           
        }
        // GET: PatientController
      
        [HttpGet("GetPatient")]
        public IEnumerable<Patient> GetPatient()
        { 
            //var list =  _context.Patient.Include(o =>o.User).ToList();            
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
                query = query.Where(p => p.FName.ToLower().Contains(I_Name.ToLower()) || p.LName.ToLower().Contains(I_Name.ToLower())).Include(p => p.User);
            }
            List<Patient> data = query.ToList();
            return data;

            //list = (Microsoft.EntityFrameworkCore.DbSet<Patient>)list.Take(10);

        }
       
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
         
        // post: PatientController/UpdatePatient/5
        [HttpPut("UpdatePatient")]
        public async Task<IActionResult> UpdatePatient([FromBody] Patient in_patient)
        {
            if (ModelState.IsValid)
            {
                var temp = _context.Patient.Find(in_patient.Patient_ID);
                temp.FName = in_patient.FName;
                temp.LName = in_patient.LName;
                temp.Gender =  in_patient.Gender;
                temp.Birthdate = in_patient.Birthdate;
                temp.Phone = in_patient.Phone;
                temp.Mobile = in_patient.Mobile;
                temp.National_Code = in_patient.National_Code;

                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        // 
        //public bool PatientExists(long id)
        //{
        //    var cnt = _context.Patient.Find(id);
        //    if (cnt != null)
        //        return true;
        //    else
        //        return false;
        //}

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

        // GET: PatientController/Delete/5
      

        
        
    }
}
