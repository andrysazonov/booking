using System;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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