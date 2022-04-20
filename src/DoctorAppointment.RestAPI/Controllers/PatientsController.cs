using System.Collections.Generic;
using DoctorAppointment.Services.Patients.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointment.RestAPI.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly PatientService _patientService;

        public PatientsController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        public void AddPatient(AddPatientDto dto)
        {
            _patientService.Add(dto);
        }

        [HttpGet]
        public List<GetPatientDto> GetAll()
        {
            return _patientService.GetAll();
        }

        [HttpGet("{id}")]
        public GetPatientDto GetDoctorById(int id)
        {
            return _patientService.GetById(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _patientService.Delete(id);
        }
        
        [HttpPut("{id}")]
        public void Update([FromRoute] int id, [FromBody] UpdatePatientDto dto)
        {
            _patientService.Update(id, dto);
        }
    }
}
