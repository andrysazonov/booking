using System;
using System.Text;
using System.Threading.Tasks;
using HostBooking.Models.Repositories;
using HostBooking.Models.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HostBooking.Controllers
{
    [Route("api/[controller]")]
    public class ReservationsController : Controller
    {
        private readonly ReservationRepository reservationRepository;
        private readonly TableRepository tableRepository;

        public ReservationsController(ReservationRepository reservationRepository, TableRepository tableRepository)
        {
            this.reservationRepository = reservationRepository;
            this.tableRepository = tableRepository;
        }

        [Authorize]
        [HttpPost]
        public void Reserve([FromBody] ReserveRequest request)
        {
            if (tableRepository.IsTableAvailable(request.TimeFrom, request.TimeTo, new Table {Id = request.TableId}))
                if (request.UserName != null)
                    reservationRepository.Insert(new Reservation
                    {
                        Id = Guid.NewGuid().ToString(), TableId = request.TableId, TimeFrom = request.TimeFrom,
                        TimeTo = request.TimeTo, UserName = request.UserName
                    });

            Response.StatusCode = 200;
        }

        [Authorize]
        [HttpGet]
        public async Task GetReservations()
        {
            var reservations = reservationRepository.GetUserReservations(User.Identity.Name);
            var json = JsonConvert.SerializeObject(reservations);
            Response.StatusCode = 200;
            await Response.Body.WriteAsync(Encoding.UTF8.GetBytes(json));
        }

        [Authorize]
        [HttpDelete]
        public void Delete([FromBody] DeleteReservationRequest request)
        {
            reservationRepository.Delete(request.ReservationId, User.Identity.Name);
            Response.StatusCode = 200;
        }
    }
}