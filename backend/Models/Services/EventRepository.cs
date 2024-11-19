using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Services
{
    public class EventRepository
    {
        private Hospital_DBN _context;

        public EventRepository(Hospital_DBN hospital_DBN)
        {
            _context = hospital_DBN;
        }

        public List<Event>GetAll()
        {
            var event_list = _context.Event.OrderBy(x=> x.Event_ID).ToList();
            return event_list;
        }

        public Event Get(int id)
        {
            var _event = _context.Event.FirstOrDefault(ev => ev.Event_ID == id);
            return _event;
        }

        public Event Add(Event v_event)
        {
            _context.Event.Add(v_event);
            _context.SaveChanges();
            return v_event;
        }
        public bool Update(Event v_event)
        {
            var _event = _context.Event.Find(v_event.Event_ID);
            _event.Event_Name = v_event.Event_Name;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var _event_count = _context.Catheter_event.Include(ev => ev.Event).Where(ev => ev.Event.Event_ID == id).Count();
            if(_event_count > 0 || _event_count == null)
            {
                return false;
            }
            var _event = _context.Event.Find(id);
            _context.Event.Remove(_event);
            _context.SaveChanges();
            return true;

        }
    }
}
