using System.Collections.Generic;
using DoctorAppointment.Services.Appointments.Contracts;
using DoctorAppointment.Services.Doctors.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointment.RestAPI.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentService _service;

        public AppointmentsController(AppointmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public void AddDoctor(AddAppointmentDto dto)
        {
            _service.Add(dto);
        }

        [HttpGet]
        public List<GetAppointmentDto> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public GetAppointmentDto GetAppointmentById(int id)
        {
            return _service.GetById(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
        [HttpPut("{id}")]
        public void Update([FromRoute] int id, [FromBody] UpdateAppointmentDto dto)
        {
            _service.Update(id, dto);
        }
    }
}
