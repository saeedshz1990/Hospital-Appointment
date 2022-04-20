using System.Collections.Generic;

namespace DoctorAppointment.Services.Doctors.Contracts
{
    public interface DoctorService
    {
        void Add(AddDoctorDto dto);
        List<GetDoctorDto> GetAll();
        GetDoctorDto GetById(int id);
        void Update(int id, UpdateDoctorDto dto);
        void Delete(int id);

    }
}
