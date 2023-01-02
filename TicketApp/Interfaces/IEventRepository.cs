using TicketApp.Models;

namespace TicketApp.Interfaces
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvent();
        void CreateEvent(Event events);
        Event GetEvent(int id);
        void DeleteEvent(Event events);
        void Save();
        
    }
}
