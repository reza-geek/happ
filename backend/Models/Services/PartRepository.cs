using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Services
{
 
    public class PartRepository 
    {
        private Hospital_DBN _context;

        public PartRepository  (Hospital_DBN Hospital_DBN)
        {
            _context = Hospital_DBN;
        }

        public List<Part> GetAll()
        {
            var partList = _context.Part.ToList();
            return partList;
        }
        
        public Part Get(int id)
        {
            var part = _context.Part.FirstOrDefault(p => p.Part_ID==id);
            // p = _context.Part.
            return part;
        }
           
        public Part Add(Part part)
        {
            _context.Part.Add(part);
            _context.SaveChanges();
            return part;
        }
        public bool Update(Part part)
        {
            var _part = _context.Part.Find(part.Part_ID);
            _part.Part_Name = part.Part_Name;
            _context.SaveChanges();
            return true;
        }
        
        public bool Delete(int id)
            { 
            int part_count = _context.Reception.Include(u => u.Part).Where(p => p.Part.Part_ID == id).Count();
            
            var part =  _context.Part.Find(id);
            
            if (part == null || part_count > 0 )
            {
                return false;
            }
            _context.Part.Remove(part);
            _context.SaveChanges();
            return true;
            //var p = _context.Part.Remove(new Part { Part_ID = id });
            //_context.SaveChanges();
        }
    }
}
