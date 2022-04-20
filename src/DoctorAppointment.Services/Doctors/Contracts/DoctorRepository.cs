using DoctorAppointment.Entities;
using System.Collections.Generic;

namespace DoctorAppointment.Services.Doctors.Contracts
{
    public interface DoctorRepository 
    {
        void Add(Doctor doctor);
        
        bool IsExistNationalCode(string nationalCode);
        List<GetDoctorDto> GetAll();
        GetDoctorDto GetById(int id);
        void Delete(int id);
        void Update(int id, Doctor doctor);
        Doctor FindById(int id);
    }
}
