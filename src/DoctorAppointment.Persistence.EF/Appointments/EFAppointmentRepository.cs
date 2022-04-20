using System;
using System.Collections.Generic;
using System.Linq;
using DoctorAppointment.Entities;
using DoctorAppointment.Services.Appointments.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.Persistence.EF.Appointments
{
    public class EFAppointmentRepository : AppointmentRepository
    {
        private readonly DbSet<Appointment> _appointments;

        public EFAppointmentRepository(ApplicationDbContext dbcontext)
        {
            _appointments = dbcontext.Set<Appointment>();
        }

        public void Add(Appointment appointment)
        {
            _appointments.Add(appointment);
        }

        public bool IsExistNationalCode(int id)
        {
            return _appointments.Any(_ => _.Id == id);
        }

        public List<GetAppointmentDto> GetAll()
        {
            return _appointments.Select(_ => new GetAppointmentDto
            {
                Id = _.Id,
               Date = _.Date,
               PatientId = _.PatientId,
               DoctorId = _.DoctorId
            }).ToList();
        }

        public GetAppointmentDto GetById(int id)
        {
            return _appointments
                .Select(_ => new GetAppointmentDto
                {
                    Id = _.Id,
                    Date = _.Date,
                    DoctorId = _.DoctorId,
                    PatientId = _.PatientId
                }).FirstOrDefault(_ => _.Id == id);
        }

        public void Delete(int id)
        {
            var doctor = _appointments.Find(id);
            _appointments.Remove(doctor);
        }

        public void Update(int id, Appointment appointment)
        {

        }

        public Appointment FindById(int id)
        {
            return _appointments.Find(id);
        }

        public List<GetAppointmentDto> GetAppointmentByPatientById(int patientId,DateTime date)
        {
            var checkedPatientById = _appointments
                .Where(_ => _.PatientId == patientId && _.Date==date)
                .Select(_ => new GetAppointmentDto
                {
                    Id = _.Id,
                    Date = _.Date.Date,
                    DoctorId = _.DoctorId,
                    PatientId = _.PatientId
                }).ToList();
            return checkedPatientById;
        }

        public List<GetAppointmentDto> GetAppointmentByDoctortById(int doctorId, DateTime date)
        {
            var checkedDoctorById = _appointments
                .Where(_ => _.DoctorId == doctorId && _.Date == date)
                .Select(_ => new GetAppointmentDto
                {
                    Id = _.Id,
                    Date = _.Date.Date,
                    DoctorId = _.DoctorId,
                    PatientId = _.PatientId
                }).ToList();
            return checkedDoctorById;

        }
    }
}
