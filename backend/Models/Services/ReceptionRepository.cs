using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.AspNetCore.Http;
using backend.Models.DTOS;

using Microsoft.EntityFrameworkCore;

namespace backend.Models.Services
{
    public class ReceptionRepository
    {
        private Hospital_DBN _context;

        public ReceptionRepository(Hospital_DBN Hospital_DBN)
        {
            _context = Hospital_DBN;
        }

        
        public List<PT_DTO> GetAll_DTO()
        {
            var receptionList = _context.Reception
                .Include(p => p.Part)
                .Include(p => p.Patient)
                .Select(r => new PT_DTO{
                    Reception_ID= r.Reception_ID,
                    Recognization =r.Recognization,
                    Clearance_DESC = r.Clearance_DESC,
                    Part_Name = r.Part.Part_Name,
                    Rec_DateTime = r.Rec_DateTime,
                    FName = r.Patient.FName,
                    LName = r.Patient.LName })
               //.Select(r => new Reception { 
               //    Reception_ID=  r.Reception_ID ,
               //    Recognization = r.Recognization,
               //    Clearance_DESC =r.Clearance_DESC,
               //    Clearance= r.Clearance,
               //    Part = new Part { Part_Name= r.Part.Part_Name }  ,
               //    Rec_DateTime = r.Rec_DateTime,
               //    Patient = new Patient { FName = r.Patient.FName , LName= r.Patient.LName }  
               //     })
               .ToList();
            return receptionList;
        }
        public List<Reception> GetAll()
        {
            var receptionList = _context.Reception
                .Include(p => p.Part)
                .Include(p => p.Patient)
                
               //.Select(r => new Reception { 
               //    Reception_ID=  r.Reception_ID ,
               //    Recognization = r.Recognization,
               //    Clearance_DESC =r.Clearance_DESC,
               //    Clearance= r.Clearance,
               //    Part = new Part { Part_Name= r.Part.Part_Name }  ,
               //    Rec_DateTime = r.Rec_DateTime,
               //    Patient = new Patient { FName = r.Patient.FName , LName= r.Patient.LName }  
               //     })
               .ToList();
            return receptionList;
        }

        private IActionResult Ok(List<object> receptionList)
        {
            throw new NotImplementedException();
        }

        public Reception Get(int id)
        {
            var reception = _context.Reception
                .Include(p => p.Part)
                .Include(p => p.Patient)
                .FirstOrDefault(p => p.Reception_ID == id);           
            return reception;
        }

        public Reception Add(Reception reception)
        {
            _context.Reception.Add(reception);
            _context.SaveChanges();
            return reception;
        }
        public bool Update(Reception reception)
        {
            var v_reception = _context.Reception.Find(reception.Reception_ID);
            v_reception.Part = reception.Part;
            v_reception.Recognization = reception.Recognization;
            v_reception.Clearance = reception.Clearance;
            v_reception.Clearance_DateTime = reception.Clearance_DateTime;
            v_reception.Clearance_DESC = reception.Clearance_DESC;
            v_reception.Patient = reception.Patient;
            v_reception.User = reception.User;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            int reception_count = _context.Catheterisation.Include(c => c.Reception).Where(p => p.Reception.Reception_ID == id).Count();

            var reception = _context.Reception.Find(id);

            if (reception == null || reception_count > 0)
            {
                return false;
            }
            _context.Reception.Remove(reception);
            _context.SaveChanges();
            return true;
            //var p = _context.Reception.Remove(new Reception { Reception_ID = id });
            //_context.SaveChanges();
        }
    }
}
