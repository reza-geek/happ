using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Services
{
    public class PatientRepository
    {
        private Hospital_DBN _context;

        public PatientRepository(Hospital_DBN Hospital_DBN)
        {
            _context = Hospital_DBN;
        }

        public List<Patient> GetAll()
        {
            return _context.Patient.Include(u => u.User).ToList();
        }

        public Patient Get(int id)
        {
             var patient = _context.Patient.SingleOrDefault(w => w.Patient_ID == id);
            return patient;
        }

        public List<Patient> GetByNamet(String I_Name)
        {
            //List<Patient> query = ;
            List<Patient> query = null;

            if (!string.IsNullOrWhiteSpace(I_Name))
            {
                query = _context.Patient.Where(p => p.FName.ToLower().Contains(I_Name.ToLower()) || p.LName.ToLower().Contains(I_Name.ToLower())).Include(p => p.User).ToList();
            }
            var data = query;
            return data;

        }

        public Patient Add( Patient in_patient) 
        {
            _context.Patient.Add(in_patient);
            _context.SaveChangesAsync();
            return in_patient;
        }
        public bool Update( Patient in_patient)
        {
            var temp = _context.Patient.Find(in_patient.Patient_ID);

            if ( temp == null)
            {
                return false;
            }
            temp.FName = in_patient.FName;
            temp.LName = in_patient.LName;
            temp.Gender = in_patient.Gender;
            temp.Birthdate = in_patient.Birthdate;
            temp.Phone = in_patient.Phone;
            temp.Mobile = in_patient.Mobile;
            temp.National_Code = in_patient.National_Code;
            _context.SaveChanges();
            return true;           
        }

        public void Delete(int id)
        {
            _context.Patient.Remove( new Patient { Patient_ID = id});
            _context.SaveChanges();             
        }

        public List<Reception> GetPatientReception(int id)
        {
            var patient = _context.Reception.Include(r => r.Patient).Where(p => p.Patient.Patient_ID == id).ToList();
            return patient;
        }


    }
}
