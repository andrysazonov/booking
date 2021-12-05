using HostBooking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HostBooking.Controllers
{
    [Route("api/[controller]")]
    public class EntriesController : Controller
    {
        [HttpPut]
        public IActionResult AddEntry() // на вход хз что
        {
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteEntry() // на вход хз что
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchTableInfo() // на вход хз что
        {
            var res = new List<string>();
            try
            {
                using (var dbCon = PostgresConn.GetConn())
                {
                    res = EntryRepository.GetEntriesByIdTable(dbCon, 1);
                }
            }
                catch (Exception e)
            {

            }

            var list = JsonConvert.SerializeObject(res,
            Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });

        return Content(list, "application/json");
        }
    }
}