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
//            var json = JsonConvert.SerializeObject(events);

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
        /// <param name="name"></param>
        /// <param name="date"></param>
        /// <param name="isPublished"></param>
        /// <param name="nbmax"></param>
        /// <returns></returns>
        // Post api/event
        [HttpPost]
        public IActionResult Post([FromBody] EventDto dto)
        {
//            DateTime parsedDate;
//            DateTime.TryParse(date, out parsedDate);
//            var parsedDate = DateTime.UtcNow;
//            var nbmax = 12;
//            var isPublished = true;
//            
//            Event evvent = _eventService.CreateEvent(name, parsedDate, nbmax, isPublished);
            EventDto evvent = _eventService.SaveEvent(dto);
            
            if (evvent != null)
                return CreatedAtRoute("Get", new {id = evvent.Id });
            else
                return BadRequest();
            return Json(dto);

        }
        
        
    }
}