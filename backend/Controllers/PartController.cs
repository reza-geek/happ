using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Models.Services;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers;

[Route("/api/[controller]")]
[ApiController]
[Authorize]
public class PartController : Controller
{
    private readonly PartRepository partRepository;
    private Hospital_DBN _context;
    private readonly ILogger<PartController> _logger;


    public PartController(ILogger<PartController> logger, Hospital_DBN ctx, PartRepository partRepository)
    {
        _context = ctx;
        _logger = logger;
        this.partRepository = partRepository;
    }

    // Get api/Part
    [HttpGet]
    public IActionResult Get()
    {
        var partlist = partRepository.GetAll();
        return Ok(partlist);
    }

    // Get api/Part/id
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var part = partRepository.Get(id);
        return Ok(part);
    }

    // Put api/Part
    [HttpPut()]
    public IActionResult Put([FromBody] Part part)
    {
        var result = partRepository.Update(part);
        return Ok(result);
    }

    // Post api/Part
    [HttpPost]
    public IActionResult Post([FromBody] Part part)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = partRepository.Add(part);
        string url = Url.Action(nameof(Get), "Part", new { Id = result.Part_ID }, Request.Scheme);
        return Created(url,true);
    }
    // Delete api/Part/id
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var part = partRepository.Delete(id);
        if(part == false)
            return BadRequest("part has reception");
        else
            return Ok();

    }
    //*********************************************************
    /*
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
    */

}
