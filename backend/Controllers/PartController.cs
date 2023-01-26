using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using backend.Models;

namespace backend.Controllers;

[Route("/api/[controller]")]
public class PartController : Controller
{
    private Hospital_DBN2 _context;
    private readonly ILogger<PartController> _logger;

    public PartController(ILogger<PartController> logger, Hospital_DBN2 ctx)
    {
        _context = ctx;
        _logger = logger;
    }

    [HttpGet("GetPart")]
    public IEnumerable<Part> GetPart()
    {
        return _context.Part;
    }

    [HttpGet("GetPartById/{id?}")]
    public IEnumerable<Part> GetPartById(int id)
    {
        return _context.Part.Where(w => w.Part_ID == id).ToList();
    }

    [HttpGet("GetPartById2/{id?}")]
    public Part GetPartById2(int id)
    {
        return _context.Part.Find(id);
    }
    // GET: api/Part/5
    //[Route("Part/GetPart/{id?}")]

    // PUT: api/Products/5
    [HttpPost("UpdatePart")]
    public async Task<IActionResult> UpdatePart([FromBody] Part in_part)
    {

        if (ModelState.IsValid)
        {

            var temp = _context.Part.Find(in_part.Part_ID);
            temp.Part_Name = in_part.Part_Name;
            temp.Comment = in_part.Comment;
            await _context.SaveChangesAsync();
            return Ok();
        }
        else
        {
            return BadRequest(ModelState);
        }

        // if (part.Part_ID == 0) {
        //   return BadRequest();
        // }

        // _context.Entry(part).State = EntityState.Modified;

        // try {
        //   part.LastModifiedOn = DateTime.Now;
        //   await _context.SaveChangesAsync();
        // } catch (DbUpdateConcurrencyException) {
        //   if (!ProductExists(part.Id)) {
        //     return NotFound();
        //   } else {
        //     throw;
        //   }
        // }
        // return NoContent();
    }

    //POST: api/Products
    [HttpPost("CreatePart")]
    public async Task<IActionResult> CreatePart([FromBody] Models.Part i_part)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Part.Add(i_part);
        await _context.SaveChangesAsync();

        //return CreatedAtAction("GetPartById2", new {Part_Id = part.Part_ID  }, part);
        return Ok();
    }
    
    // DELETE: api/Part/id
    [HttpDelete("DeletePart/{id?}")]
    public async Task < IActionResult > DeletePart(int id) {
      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }

      var part = await _context.Part.FindAsync(id);
      if (part == null) {
        return NotFound();
      }

      _context.Part.Remove(part);
      await _context.SaveChangesAsync();

      return Ok(part);
    }

    private bool PartExists(int id) {
      return _context.Part.Any(e => e.Part_ID == id);
    }
     
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


}
