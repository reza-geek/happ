using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using backend.Models.Services;
using Newtonsoft.Json;

namespace backend.Controllers;

[Route("/api/[controller]")]
public class ReceptionController : Controller
{
    private Hospital_DBN _context;
    private readonly ILogger<ReceptionController> _logger;
    private readonly ReceptionRepository receptionRepository;

    public ReceptionController(ILogger<ReceptionController> logger, ReceptionRepository  receptionRepository, Hospital_DBN ctx)
    {
        _logger = logger;
        _context = ctx;
        this.receptionRepository = receptionRepository;
    } 

    [HttpGet]
    public IActionResult Get()
    {
        var qry = receptionRepository.GetAll_DTO();
        string jsonData = JsonConvert.SerializeObject(qry);

             //            .FromSqlRaw(
             //            " SELECT Reception.Reception_ID	" + 
             //" 	,Reception.Recognization " +
             //" 	,Part.Part_Name " +
             //" 	,Patient.FName " +
             //" 	,Patient.LName " +
             //" 	,Reception.Rec_DateTime ,Reception.Clearance_DESC,Reception.Clearance_DateTime,Reception.User_ID,Reception.Part_ID,Reception.Clearance_ID,Reception.Patient_ID" +
             //" FROM Reception " +
             //" INNER JOIN Part ON Reception.Part_ID = Part.Part_ID " +
             //" INNER JOIN Patient ON Reception.Patient_ID = Patient.Patient_ID " +
             //" where Reception.Clearance_ID is null ")          
             //.Include(p => p.Part)
             //.Include(p => p.Patient)
             //  .Select(r => new { r.Part.Part_Name, r.Rec_DateTime, r.Patient.FName, r.Patient.LName })
             //  .ToList();
         return Ok( jsonData  );
    }
    //[HttpGet()]
    //public IActionResult Get_PATIENT_INFO(int id)
    //{
    //    var qry = receptionRepository.GetAll();
    //    return Ok(qry);
    //}
    // GET: api/Reception/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var qry = receptionRepository.Get(id);
        return  Ok(qry);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Reception reception)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = receptionRepository.Add(reception);
        string url = Url.Action(nameof(Get), "Reception", new { Id = result.Reception_ID }, Request.Scheme);
        return Created(url, true);
    }

    // PUT: api/Reception/5
    [HttpPut()]
    public IActionResult Update([FromBody] Reception reception)
    {
        var v_reception = receptionRepository.Update(reception);
        return Ok(v_reception);
    }
    // Delete api/Reception/id
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = receptionRepository.Delete(id);
        if (result)
            return Ok();
        else
            return BadRequest("Child record found!");
    }
    /*
        public async Task<IActionResult> UpdateReception([FromBody] Reception  reception)
        {

            if (ModelState.IsValid)
            {

                var temp = _context.Reception.Find(in_Reception.Reception_ID);
                temp.Reception_Name = in_Reception.Reception_Name;
                temp.Comment = in_Reception.Comment;
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }

            // if (Reception.Reception_ID == 0) {
            //   return BadRequest();
            // }

            // _context.Entry(Reception).State = EntityState.Modified;

            // try {
            //   Reception.LastModifiedOn = DateTime.Now;
            //   await _context.SaveChangesAsync();
            // } catch (DbUpdateConcurrencyException) {
            //   if (!ProductExists(Reception.Id)) {
            //     return NotFound();
            //   } else {
            //     throw;
            //   }
            // }
            // return NoContent();
        }

        //POST: api/Products
        [HttpPost("CreateReception")]
        public async Task<IActionResult> CreateReception([FromBody] Models.Reception i_Reception)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Reception.Add(i_Reception);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetReceptionById2", new {Reception_Id = Reception.Reception_ID  }, Reception);
            return Ok();
        }

        // DELETE: api/Reception/id
        [HttpDelete("DeleteReception/{id?}")]
        public async Task < IActionResult > DeleteReception(int id) {
          if (!ModelState.IsValid) {
            return BadRequest(ModelState);
          }

          var Reception = await _context.Reception.FindAsync(id);
          if (Reception == null) {
            return NotFound();
          }

          _context.Reception.Remove(Reception);
          await _context.SaveChangesAsync();

          return Ok(Reception);
        }

        private bool ReceptionExists(int id) {
          return _context.Reception.Any(e => e.Reception_ID == id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    */
}
