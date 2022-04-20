using System.Collections.Generic;
using DoctorAppointment.Entities;
using System.Linq;
using DoctorAppointment.Infrastructure.Application;
using DoctorAppointment.Services.Appointments.Contracts;
using DoctorAppointment.Services.Appointments.Exceptions;

namespace DoctorAppointment.Services.Appointments
{
    public class AppointmentAppService : AppointmentService
    {
        private readonly AppointmentRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public AppointmentAppService(AppointmentRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddAppointmentDto dto)
        {
            var appointment = new Appointment
            {
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                Date = dto.Date,
            };

            var countPatient = _repository
                .GetAppointmentByPatientById(dto.PatientId, dto.Date);


            var countDoctor = _repository
                .GetAppointmentByDoctortById(dto.DoctorId, dto.Date);

            if (countPatient == null && countDoctor == null)
            {
                _repository.Add(appointment);
                _unitOfWork.Commit();
            }
            else
            {
                throw new DoctorOrPatientCannotPermittedException();
            }
        }

        public List<GetAppointmentDto> GetAll()
        {
            return _repository.GetAll();
        }

        public GetAppointmentDto GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(int id, UpdateAppointmentDto dto)
        {
            var appionment = _repository.FindById(id);

            if (appionment == null)
            {
                throw new AppointmentNotFoundException();
            }
            else
            {
                _unitOfWork.Commit();
            }
            //Check the repository and service then controller 
        }

        public void Delete(int id)
        {
            var appointment = _repository.FindById(id);
            if (appointment != null)
            {
                _repository.Delete(id);
                _unitOfWork.Commit();
            }
            else
            {
                throw new AppointmentNotExistsException();
            }
        }
    }
}