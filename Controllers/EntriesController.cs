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
        public IActionResult AddEntry(int idUser, DateTime recordTime, int whichTable)
        {
            //todo
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteEntry(int idEntry) 
        {
            //todo
            return View();
        }

        [HttpGet]
        public IActionResult SearchTableInfoByIdTable(int idTable) //id стола
        {
            var res = new List<Entry>();
            using (var dbCon = PostgresConn.GetConn())
            {
                res = EntryRepository.GetEntriesByIdTable(dbCon, idTable);
            }

            return Json(res);
        }

        [HttpGet]
        public IActionResult SearchTableInfoByIdUser(int idUser) //id юзера
        {
            var res = new List<Entry>();
            using (var dbCon = PostgresConn.GetConn())
            {
                res = EntryRepository.GetEntriesByIdUser(dbCon, idUser);
            }

            return Json(res);
        }
    }
}