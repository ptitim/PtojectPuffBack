using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service;

namespace ProjetPuff.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private EventService _eventService;


        public ValuesController()
        {
                this._eventService = new EventService();
        }
        
        // GET api/values
        [HttpGet]
        public string Get()
        {
//            var test = _eventService.GetAllEvents();
//            var json = JsonConvert.SerializeObject(test);
//            return json;
            string retour = "value1" + "value2";
            return retour;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Json(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}