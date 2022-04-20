using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Patients.Contracts
{
    public interface PatientService
    {
        void Add(AddPatientDto dto);
        List<GetPatientDto> GetAll();
        GetPatientDto GetById(int id);
        void Update(int id, UpdatePatientDto dto);
        void Delete(int id);
    }
}
