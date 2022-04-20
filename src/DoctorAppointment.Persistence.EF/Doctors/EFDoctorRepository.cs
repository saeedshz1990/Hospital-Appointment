using System.Collections.Generic;
using DoctorAppointment.Entities;
using DoctorAppointment.Services.Doctors.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DoctorAppointment.Persistence.EF.Doctors
{
    public class EFDoctorRepository : DoctorRepository
    {
        private readonly DbSet<Doctor> _doctors;

        public EFDoctorRepository(ApplicationDbContext dbcontext)
        {
            _doctors = dbcontext.Set<Doctor>();
        }

        public void Add(Doctor doctor)
        {
            _doctors.Add(doctor);
        }

        public bool IsExistNationalCode(string nationalCode)
        {
            return _doctors.Any(_ => _.NationalCode == nationalCode);
        }

        public List<GetDoctorDto> GetAll()
        {
            return _doctors.Select(_ => new GetDoctorDto
            {
                Id = _.Id,
                FirstName = _.FirstName,
                LastName = _.LastName,
                NationalCode = _.NationalCode,
                Field = _.Field,
            }).ToList();
        }

        public GetDoctorDto GetById(int id)
        {
            return _doctors
               .Select(_ => new GetDoctorDto
               {
                   Id = _.Id,
                   FirstName = _.FirstName,
                   LastName = _.LastName,
                   NationalCode = _.NationalCode,
                   Field = _.Field,
               }).FirstOrDefault(_ => _.Id == id);
        }

        public void Delete(int id)
        {
            //_doctors.Remove( id);
            var doctor = _doctors
                .Include(_ => _.Appointments)
                .FirstOrDefault(_ => _.Id == id);
            //var doctor = _doctors.Find(id);
            _doctors.Remove(doctor);
        }

        public void Update(int id, Doctor doctor)
        {

        }

        public Doctor FindById(int id)
        {
            return _doctors.Find(id);
        }
    }
}
