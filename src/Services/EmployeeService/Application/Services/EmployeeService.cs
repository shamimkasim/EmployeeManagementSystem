using AutoMapper;
using EmployeeManagementSystem.Application.DTOs.Requests;
using EmployeeManagementSystem.Application.DTOs.Responses;
using EmployeeManagementSystem.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMediator _mediator;

        public EmployeeService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<EmployeeResponse> CreateEmployeeAsync(CreateEmployeeRequest request)
        {
            return await _mediator.Send(new CreateEmployeeCommand
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                DocumentNumber = request.DocumentNumber,
                PhoneNumbers = request.PhoneNumbers,
                DateOfBirth = request.DateOfBirth,
                Role = request.Role,
                ManagerId = request.ManagerId
            });
        }

        public Task<EmployeeResponse> CreateEmployeeAsync(CreateEmployeeRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmployeeResponse>> GetAllEmployeesAsync()
        {
            return await _mediator.Send(new GetAllEmployeesQuery());
        }

        public async Task<EmployeeResponse> GetEmployeeByIdAsync(Guid id)
        {
            return await _mediator.Send(new GetEmployeeByIdQuery { EmployeeId = id });
        }

        Task<List<EmployeeResponse>> IEmployeeService.GetAllEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        Task<EmployeeResponse> IEmployeeService.GetEmployeeByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
