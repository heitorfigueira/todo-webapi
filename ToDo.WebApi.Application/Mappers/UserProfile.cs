using AutoMapper;
using ToDo.WebApi.Domain.Entities;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Application.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Auth, User>()
                .ForMember(user => user.Id,
                           opt => opt.MapFrom(c => Guid.NewGuid()));
        }
    }
}
