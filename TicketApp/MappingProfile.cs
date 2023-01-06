using AutoMapper;
using TicketApp.Models;

namespace TicketApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, Users>();
        }
    }
}
