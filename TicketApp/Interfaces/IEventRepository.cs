using TicketApp.Models;

namespace TicketApp.Interfaces
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvent();
        void CreateEvent(Event events);
        Event GetEvent(Guid id);
        void DeleteEvent(Event events);
        void Save();
        
    }
}
