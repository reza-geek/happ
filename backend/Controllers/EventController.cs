using Microsoft.AspNetCore.Mvc;

using backend.Models;
using backend.Models.Services;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    
    public class EventController : Controller
    {
        private readonly EventRepository eventRepository;
        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger , EventRepository  eventRepository)
        {            
            _logger = logger;
            this.eventRepository = eventRepository;
        }

        // Get api/Event
        [HttpGet]
        public IActionResult Get()
        {
            var event_List = eventRepository.GetAll();
            return Ok( event_List);
        }

        // Get api/Event/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var _event  = eventRepository.Get(id);
            return Ok(_event);
        }
        // Post api/Event
        [HttpPost]
        public IActionResult Post([FromBody] Event v_event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = eventRepository.Add(v_event);
            string url = Url.Action(nameof(Get), "Event", new { Id = result.Event_ID }, Request.Scheme);
            return Created(url, true);
        }
        // Put api/Event
        [HttpPut()]
        public IActionResult Put([FromBody] Event v_event)
        {
            var result = eventRepository.Update(v_event);
            return Ok(result);
        }

        // Delete api/Event/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = eventRepository.Delete(id);
            if (result)
                return Ok();
            else
                return BadRequest("Child record found!");

        }
    }
}
