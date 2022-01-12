using System;
using System.Linq;
using System.Text;
using HostBooking.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HostBooking.Controllers
{
    [Route("api/[controller]")]
    public class TablesController : Controller
    {
        private readonly TableRepository tableRepository;

        public TablesController(TableRepository tableRepository)
        {
            this.tableRepository = tableRepository;
        }

        [Authorize]
        [HttpGet]
        public async void GetTables([FromQuery] DateTime timeFrom, [FromQuery] DateTime timeTo)
        {
            var tablesWithStatus = tableRepository.GetAllTablesWithStatus(timeFrom, timeTo).ToArray();
            var json = JsonConvert.SerializeObject(tablesWithStatus);
            Response.StatusCode = 200;
            await Response.Body.WriteAsync(Encoding.UTF8.GetBytes(json));
        }
    }
}