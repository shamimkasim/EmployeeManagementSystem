using AutoMapper;
using EmployeeManagementSystem.Application.DTOs.Requests;
using EmployeeManagementSystem.Application.DTOs.Responses;
using EmployeeManagementSystem.Domain.Entities;

namespace EmployeeManagementSystem.Application.Mappers
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<Employee, AuthResponse>();
            CreateMap<LoginRequest, Employee>();
        }
    }
}
