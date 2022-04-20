using System.Collections.Generic;
using System.Linq;
using DoctorAppointment.Entities;
using DoctorAppointment.Services.Doctors.Contracts;
using DoctorAppointment.Services.Patients.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.Persistence.EF.Patients
{
    public class EFPatientRepository : PatientRepository
    {
        private readonly DbSet<Patient> _patients;

        public EFPatientRepository(ApplicationDbContext dbContext)
        {
            _patients = dbContext.Set<Patient>();
        }

        public void Add(Patient patient)
        {
            _patients.Add(patient);
        }

        public bool IsExistNationalCode(string nationalCode)
        {
            return _patients.Any(_ => _.NationalCode == nationalCode);
        }

        public List<GetPatientDto> GetAll()
        {
            return _patients.Select(_ => new GetPatientDto()
            {
                Id = _.Id,
                FirstName = _.FirstName,
                LastName = _.LastName,
                NationalCode = _.NationalCode,
            }).ToList();
        }

        public GetPatientDto GetById(int id)
        {
            return _patients
                .Select(_ => new GetPatientDto()
                {
                    Id = _.Id,
                    FirstName = _.FirstName,
                    LastName = _.LastName,
                    NationalCode = _.NationalCode,
                }).FirstOrDefault(_ => _.Id == id);
        }

        public void Delete(int id)
        {
            var patient = _patients
                .Include(_ => _.Appointments)
                .FirstOrDefault(_ => _.Id == id);
            _patients.Remove(patient);
        }

        public void Update(int id, Patient patient)
        {
            
        }

        public Patient FindById(int id)
        {
            return _patients.Find(id);
        }
    }
}
