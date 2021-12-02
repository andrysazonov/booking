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
    public class TableClickController : Controller
    {
        [HttpGet]
        public IActionResult FindTableInfo(int? idTable)
        {
            return View();
        }
    }
}