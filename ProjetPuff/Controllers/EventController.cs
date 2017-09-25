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
            Treatment treatment;
            _eventService.GetEventById(id, out treatment);

            return Json(treatment);
        }

        /// <summary>
        /// Create new event
        /// </summary>
        // Post api/event
        [HttpPost]
        public IActionResult Post([FromBody] EventDto dto)
        {
            Treatment tr;
            EventDto evvent = _eventService.SaveEvent(dto, out tr);

            if (evvent == null) return BadRequest();
            
            return CreatedAtRoute("GetEvent", new {id = evvent.Id}, evvent);
        }
    }
}