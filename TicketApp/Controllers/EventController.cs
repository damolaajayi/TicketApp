using Microsoft.AspNetCore.Mvc;
using TicketApp.Interfaces;
using TicketApp.Models;

namespace TicketApp.Controllers
{
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }


        [HttpGet]
        public IActionResult GetEvents()
        {
            try
            {
                var events = _eventRepository.GetAllEvent();
                return Ok(events);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpGet("{id}", Name = "EventById")]
        public IActionResult GetEvent(Guid Id)
        {
            try
            {
                var events = _eventRepository.GetEvent(Id);
                return Ok(events);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateEvent(Event events)
        {
            try
            {
                _eventRepository.CreateEvent(events);
                _eventRepository.Save();
                return CreatedAtRoute("Event", new { id = events.Id }, events);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public IActionResult UpdateEvent(Guid id, Event events) 
        {
            try
            {
                if(events == null)
                {
                    return BadRequest();
                }
                if(!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                var eventsss = _eventRepository.GetEvent(id);
                if(eventsss == null)
                {
                    return NotFound();
                }
                _eventRepository.Save();
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id")]
        public IActionResult DeleteEvent(Guid id) 
        {
            var eventssss = _eventRepository.GetEvent(id);
            if(eventssss == null)
            {
                return NotFound();
            }
            _eventRepository.DeleteEvent(eventssss);
            _eventRepository.Save();
            return NoContent();
        }
    }
}
