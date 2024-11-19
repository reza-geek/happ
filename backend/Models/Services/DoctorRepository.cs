using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Services
{
    public class DoctorRepository
    {
        private Hospital_DBN _context;
        
        public DoctorRepository (Hospital_DBN hospital_DBN)
        {
            this._context = hospital_DBN;
        }

        public List<Doctor> GetAll()
        {
            var doctor_list = _context.Doctor.ToList();
            return doctor_list;
        }

        public Doctor Get(int id)
        {
            var v_doctor = _context.Doctor.FirstOrDefault(d => d.Dr_ID == id);
            return v_doctor;
        }

        public Doctor Add(Doctor doctor)
        {
            _context.Doctor.Add(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public bool Update(Doctor doctor)
        {
            var v_doctor = _context.Doctor.Find(doctor.Dr_ID);
            if( v_doctor == null)
            {
                return false;
            }
            v_doctor.Dr_Name = doctor.Dr_Name;
            v_doctor.Dr_Family = doctor.Dr_Family;
            v_doctor.Dr_NationalCode = doctor.Dr_NationalCode;
            v_doctor.Dr_Mobile = doctor.Dr_Mobile;
            v_doctor.Other_Center = doctor.Other_Center;
            v_doctor.Specialty = doctor.Specialty;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var doctor_count = _context.Catheterisation.Include(ev => ev).Where(ev => ev.Doctor.Dr_ID == id).Count();
            if (doctor_count > 0 || doctor_count == null)
            {
                return false;
            }
            var v_doctor = _context.Doctor.Find(id);
            _context.Doctor.Remove(v_doctor);
            _context.SaveChanges();
            return true;

        }
    }
}
