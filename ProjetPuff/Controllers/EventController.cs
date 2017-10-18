using System;
using DataAccess.Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service;
using Service.DTO;

namespace ProjetPuff.Controllers
{
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly EventService _eventService;


        public EventController()
        {
            _eventService = new EventService();
        }

        // GET api/event
        [HttpGet(Name = "GetEvents")]
        public JsonResult Index()
        {
            var events = _eventService.GetAllPublishedEvent();

            return Json(events);
        }

        [HttpGet("{id}", Name = "GetEvent")]
        public JsonResult Index(int id)
        {
            _eventService.GetEventById(id, out var treatment);

            return Json(treatment);
        }

        /// <summary>
        /// Create new event
        /// </summary>
        [HttpPost("create")]
        public IActionResult Create([FromBody] EventDto dto)
        {
            Treatment tr;
            EventDto evvent = _eventService.SaveEvent(dto, out tr);

            if (evvent == null) return BadRequest();
            
//            return CreatedAtRoute("GetEvent", new {id = evvent.Id}, tr);
            return Json(tr);
        }
    
        /// <summary>
        /// Delete event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Treatment tr;
            _eventService.DeleteEvent(id , out tr);

            return Json(tr);
        }
        
        /// <summary>
        /// update event
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult UpdateEvent([FromBody] EventDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            
            _eventService.UpdateEvent(dto, out Treatment tr);

            return Json(tr);

        }
    }
}