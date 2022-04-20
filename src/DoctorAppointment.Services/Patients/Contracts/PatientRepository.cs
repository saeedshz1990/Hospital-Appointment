using System.Collections.Generic;
using DoctorAppointment.Entities;
using DoctorAppointment.Services.Doctors.Contracts;

namespace DoctorAppointment.Services.Patients.Contracts
{
    public interface PatientRepository
    {
        void Add(Patient patient);
        bool IsExistNationalCode(string nationalCode);
        List<GetPatientDto> GetAll();
        GetPatientDto GetById(int id);
        void Delete(int id);
        void Update(int id, Patient patient);
        Patient FindById(int id);
    }
}
