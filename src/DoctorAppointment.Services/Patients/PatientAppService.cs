using System.Collections.Generic;
using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using DoctorAppointment.Services.Doctors.Contracts;
using DoctorAppointment.Services.Patients.Contracts;
using DoctorAppointment.Services.Patients.Exceptions;

namespace DoctorAppointment.Services.Patients
{
    public class PatientAppService :PatientService
    {
        private readonly PatientRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public PatientAppService(PatientRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        
        public void Add(AddPatientDto dto)
        {
            var patient = new Patient()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                NationalCode = dto.NationalCode,
            };

            var isPatientExist = _repository
                .IsExistNationalCode(patient.NationalCode);

            if (isPatientExist)
            {
                throw new PatientAlreadyExistException();
            }

            _repository.Add(patient);
            _unitOfWork.Commit();
        }

        public List<GetPatientDto> GetAll()
        {
            return _repository.GetAll();
        }

        public GetPatientDto GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(int id, UpdatePatientDto dto)
        {
            var doctor = _repository.FindById(id);
            var isExistsNationalCode = _repository
                .IsExistNationalCode(dto.NationalCode);

            if (isExistsNationalCode == true)
            {
                throw new PatientNationalCodeIsExistsInDatabase();
            }
            else
            {
                doctor.FirstName = dto.FirstName;
                doctor.LastName = dto.LastName;
                doctor.NationalCode = dto.NationalCode;
                _unitOfWork.Commit();
            }
        }

        public void Delete(int id)
        {
            var doctor = _repository.FindById(id);
            if (doctor != null)
            {
                _repository.Delete(id);
                _unitOfWork.Commit();
            }
            else
            {
                throw new PatientNotExistsException();
            }
        }
    }
}
