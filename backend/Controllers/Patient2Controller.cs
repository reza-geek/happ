using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using backend.Models.Services;

namespace backend.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class Patient2Controller : ControllerBase
    {
        
        private readonly PatientRepository patientRepository;

        public Patient2Controller(PatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }
        [HttpGet()]
        public IActionResult Get()
        {
            var patient = patientRepository.GetAll().ToList();
            return Ok(patient);
        }
         
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var patient = patientRepository.Get(id);
            return Ok(patient);
        }

        [HttpGet("GetByName/{Name}")]
        public IActionResult GetByName(string Name)
        {
            var patient = patientRepository.GetByNamet(Name);
            return Ok(patient);
        }
        /////////////////

        // Put api/Patient/
        [HttpPut()]
        public IActionResult Put([FromBody] Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = patientRepository.Update(patient);
            return Ok(result);
        }

        // Post api/Patient
        [HttpPost]
        public IActionResult Post([FromBody] Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = patientRepository.Add(patient);
            string url = Url.Action(nameof(Get), "Part", new { Id = result.Patient_ID }, Request.Scheme);
            return Created(url, true);
        }
        // Delete api/Part/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var patient = patientRepository.GetPatientReception(id);
            if (patient != null)
                return BadRequest("part has reception");
            else
                return Ok();
        }
         

    }
}
