using TicketApp.Interfaces;
using TicketApp.Models;

namespace TicketApp.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public EventRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void CreateEvent(Event events) => _repositoryContext.Events.Add(events);

        public void DeleteEvent(Event events) => _repositoryContext.Events.Remove(events);

        public IEnumerable<Event> GetAllEvent() => _repositoryContext.Events.OrderBy(p => p.Id);

        public Event GetEvent(Guid id) => _repositoryContext.Set<Event>().Where(p => p.Id.Equals(id)).SingleOrDefault();

        public void Save() => _repositoryContext.SaveChanges();
    }
}
