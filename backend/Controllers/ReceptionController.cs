using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[Route("/api/[controller]")]
public class ReceptionController : Controller
{
    private Hospital_DBN _context;
    private readonly ILogger<ReceptionController> _logger;

    public ReceptionController(ILogger<ReceptionController> logger, Hospital_DBN ctx)
    {
        _context = ctx;
        _logger = logger;
    }

    //[HttpGet("GetReception")]
    //public IEnumerable<Reception> GetReception()
    //{
    //    IQueryable<Reception> qry=  _context.Reception;
    //    qry= qry.Include(p  =>p.Part).Include(p => p.Patient).Include(p => p.User);
    //    return qry.Select(r => new { r.Part.Part_Name, r.Patient.FName,r.Patient.LName}).ToList();
    //}
/*
    [HttpGet("GetReceptionById/{id?}")]
    public IEnumerable<Reception> GetReceptionById(int id)
    {
        return _context.Reception.Where(w => w.Reception_ID == id).ToList();
    }

    [HttpGet("GetReceptionById2/{id?}")]
    public Reception GetReceptionById2(int id)
    {
        return _context.Reception.Find(id);
    }
    // GET: api/Reception/5
    //[Route("Reception/GetReception/{id?}")]

    // PUT: api/Products/5
    [HttpPost("UpdateReception")]
    public async Task<IActionResult> UpdateReception([FromBody] Reception in_Reception)
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
