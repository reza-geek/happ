using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using backend.Models;

namespace backend.Controllers;

[Route("/api/[controller]")]
public class PartController : Controller
{
    private Hospital_DBN2 context;
    private readonly ILogger<PartController> _logger;

    public PartController(ILogger<PartController> logger, Hospital_DBN2 ctx)
    {
        context = ctx;
        _logger = logger;
    }

    [HttpGet("GetPart")]
    public IEnumerable<Part> GetPart()
    {
        return context.Part;
    }

    [HttpGet("GetPartById/{id?}")]
    public IEnumerable<Part> GetPartById(int id)
    {
        return context.Part.Where(w => w.Part_ID == id).ToList();
    }

    [HttpGet("GetPartById2/{id?}")]
    public Part GetPartById2(int id)
    {
        return context.Part.Find(id);
    }
    // GET: api/Part/5
    //[Route("Part/GetPart/{id?}")]

    // PUT: api/Products/5
    [HttpPost("UpdatePart")]
    public async Task<IActionResult> UpdatePart([FromBody] Part in_part)
    {

        if (ModelState.IsValid)
        {

            var temp = context.Part.Find(in_part.Part_ID);
            temp.Part_Name = in_part.Part_Name;
            temp.Comment = in_part.Comment;
            await context.SaveChangesAsync();
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

        context.Part.Add(i_part);
        await context.SaveChangesAsync();

        //return CreatedAtAction("GetPartById2", new {Part_Id = part.Part_ID  }, part);
        return Ok();
    }
    /*
    // DELETE: api/Products/5
    [HttpDelete("{id}")]
    public async Task < IActionResult > DeleteProduct(int id) {
      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }

      var part = await _context.Part.FindAsync(id);
      if (part == null) {
        return NotFound();
      }

      _context.part.Remove(part);
      await _context.SaveChangesAsync();

      return Ok(part);
    }

    private bool ProductExists(int id) {
      return _context.part.Any(e => e.Id == id);
    }
    */
    ///////////////////////////

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


}
