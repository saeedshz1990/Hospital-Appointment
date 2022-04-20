using System;
using DoctorAppointment.Entities;

namespace DoctorAppointment.Services.Appointments.Contracts
{
    public class AddAppointmentDto
    {
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

    }
}
