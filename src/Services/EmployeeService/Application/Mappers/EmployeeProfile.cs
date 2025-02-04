using AutoMapper;
using EmployeeManagementSystem.Application.CQRS.Commands;
using EmployeeManagementSystem.Application.CQRS.Handlers;
using EmployeeManagementSystem.Application.DTOs.Requests;
using EmployeeManagementSystem.Domain.ValueObjects;

namespace EmployeeManagementSystem.Application.Mappings
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CreateEmployeeRequest, CreateEmployeeCommand>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => new PhoneNumber(src.PhoneNumber)));

            CreateMap<UpdateEmployeeRequest, UpdateEmployeeCommand>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => new PhoneNumber(src.PhoneNumber)));
        }
    }
}
