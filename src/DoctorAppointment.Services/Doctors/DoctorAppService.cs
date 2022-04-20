using System.Collections.Generic;
using System.Net;
using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using DoctorAppointment.Services.Doctors.Contracts;
using DoctorAppointment.Services.Doctors.Exceptions;

namespace DoctorAppointment.Services.Doctors
{
    public class DoctorAppService : DoctorService
    {
        private readonly DoctorRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public DoctorAppService(
            DoctorRepository repository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddDoctorDto dto)
        {
            var doctor = new Doctor
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Field = dto.Field,
                NationalCode = dto.NationalCode,
            };

            var isDoctorExist = _repository
                .IsExistNationalCode(doctor.NationalCode);

            if (isDoctorExist)
            {
                throw new DoctorAlreadyExistException();
            }

            _repository.Add(doctor);
            _unitOfWork.Commit();
        }

        public List<GetDoctorDto> GetAll()
        {
            return _repository.GetAll();
        }

        public GetDoctorDto GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(int id, UpdateDoctorDto dto)
        {
            var doctor = _repository.FindById(id);
            var isExistsNationalCode = _repository
                .IsExistNationalCode(dto.NationalCode);

            if (isExistsNationalCode == true)
            {
                throw new DoctorNationalCodeIsExistsInDatabase();
            }
            else
            {
                doctor.FirstName = dto.FirstName;
                doctor.LastName = dto.LastName;
                doctor.Field = dto.Field;
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
                throw new DoctorNotExistsException();
            }


        }
    }
}