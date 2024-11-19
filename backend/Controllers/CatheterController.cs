using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Models.Services;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class CatheterController : ControllerBase
    {
        private readonly CatheterRepository  catheterRepository;
        private readonly ILogger<CatheterController> _logger;

        public CatheterController(ILogger<CatheterController> logger, CatheterRepository catheterRepository)
        {
            _logger = logger;
            this.catheterRepository = catheterRepository;
        }
        
        /////////////////////////
        ///
        // Get api/Catheter
        [HttpGet]
        public IActionResult Get()
        {
            var catheter_List = catheterRepository.GetAll();
            return Ok(catheter_List );
        }

        // Get api/Catheter/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var catheter = catheterRepository.Get(id);
            return Ok(catheter);
        }
        // Post api/Catheter
        [HttpPost]
        public IActionResult Post([FromBody] Catheter catheter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = catheterRepository.Add(catheter);
            string url = Url.Action(nameof(Get), "Catheter", new { Id = result.Catheter_ID }, Request.Scheme);
            return Created(url, true);
        }
        // Put api/Catheter
        [HttpPut()]
        public IActionResult Put([FromBody] Catheter i_catheter)
        {
            var result = catheterRepository.Update(i_catheter);
            return Ok(result);
        }

        // Delete api/catheter/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = catheterRepository.Delete(id);
            if (result)
                return Ok();
            else
                return BadRequest("Child record found!");

        }
    }
}
