using System.Collections.Generic;
using DoctorAppointment.Services.Doctors.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointment.RestAPI.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly DoctorService _service;

        public DoctorsController(DoctorService service)
        {
            _service = service;
        }

        [HttpPost]
        public void AddDoctor(AddDoctorDto dto)
        {
            _service.Add(dto);
        }

        [HttpGet]
        public List<GetDoctorDto> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public GetDoctorDto GetDoctorById(int id)
        {
            return _service.GetById(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
        [HttpPut("{id}")]
        public void Update([FromRoute]int id, [FromBody]UpdateDoctorDto dto)
        {
            _service.Update(id,dto);
        }
    }
}
