using System;
using System.Collections.Generic;
using DoctorAppointment.Entities;

namespace DoctorAppointment.Services.Appointments.Contracts
{
    public interface AppointmentRepository
    {
        void Add(Appointment appointment);
        bool IsExistNationalCode(int id);
        List<GetAppointmentDto> GetAll();
        GetAppointmentDto GetById(int id);
        void Delete(int id);
        void Update(int id, Appointment appointment);
        Appointment FindById(int id);
        int GetAppointmentByPatientById(int patientId, DateTime date);
        int GetAppointmentByDoctortById(int doctorId, DateTime date);

    }
}
