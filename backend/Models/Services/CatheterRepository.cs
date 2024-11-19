using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Services
{
    public class CatheterRepository
    {
        private Hospital_DBN _context;

        public CatheterRepository(Hospital_DBN hospital_DBN)
        {
            _context = hospital_DBN;
        }

        public List<Catheter> GetAll()
        {
            var catheter_list = _context.Catheter.ToList();
            return catheter_list;
        }

        public Catheter Get(int id)
        {
            var catheter = _context.Catheter.FirstOrDefault(ev => ev.Catheter_ID == id);
            return catheter;
        }

        public Catheter Add(Catheter catheter)
        {
            _context.Catheter.Add(catheter);
            _context.SaveChanges();
            return catheter;
        }
        public bool Update(Catheter v_Catheter)
        {
            var catheter = _context.Catheter.Find(v_Catheter.Catheter_ID);
            catheter.Catheter_Name = v_Catheter.Catheter_Name;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var catheter_count = _context.Catheterisation.Include(ev => ev).Where(ev => ev.Catheter.Catheter_ID == id).Count();
            if (catheter_count > 0 || catheter_count == null)
            {
                return false;
            }
            var _Catheter = _context.Catheter.Find(id);
            _context.Catheter.Remove(_Catheter);
            _context.SaveChanges();
            return true;

        }
    }
}
