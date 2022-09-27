using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Domain.Entities;

namespace ToDo.WebApi.Application.Mappers
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<CreateAccount, Account>()
                .ForMember(account => account.Created, 
                           opt => opt.MapFrom(c => DateTime.UtcNow))
                .ForMember(account => account.CreatedBy,
                           opt => opt.MapFrom(c => "System Registration"));
        }
    }
}
