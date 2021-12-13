using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace HostBooking.Controllers
{
    [Route("api/[controller]")]
    public class TableController : Controller
    {
        // GET: TableController
        
        [Authorize]
        [Route("login")]
		[HttpPost]
        
        public async void Login()
        {
            Console.WriteLine("TEST CONTOLLER");
             var json = JsonConvert.SerializeObject($"{User.Identity.Name}");

             await Response.Body.WriteAsync(Encoding.UTF8.GetBytes(json));
            
        }
    }
}
