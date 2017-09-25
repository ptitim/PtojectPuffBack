using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Swashbuckle.AspNetCore.Swagger;

namespace ProjetPuff.Controllers
{
    /// <summary>
    /// Response helper
    /// </summary>
    public class ResponseHelper : Controller
    {

        public string RouteGet;
        
        public IActionResult SetActionFromTreatment(Treatment tr)
        {
            switch (tr.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    return new BadRequestResult();
                case HttpStatusCode.NoContent:
                    return new ContentResult();
                case HttpStatusCode.Created:
                    return new OkResult();
//                    return new CreatedAtActionResult("", new { id = tr.Objects.First().Id});
                default:
                    return new StatusCodeResult(tr.StatusCode.GetHashCode());
            }
            
        }


    }
}