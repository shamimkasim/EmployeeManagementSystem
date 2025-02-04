using AutoMapper;
using EmployeeManagementSystem.Application.CQRS.Commands;
using EmployeeManagementSystem.Application.CQRS.Handlers;
using EmployeeManagementSystem.Application.CQRS.Queries;
using EmployeeManagementSystem.Application.DTOs.Requests;
using EmployeeManagementSystem.Application.DTOs.Responses;
using EmployeeManagementSystem.Application.Interfaces;
using MediatR;

namespace EmployeeManagementSystem.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EmployeeService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<EmployeeResponse> CreateEmployeeAsync(CreateEmployeeRequest request)
        {
            var command = _mapper.Map<CreateEmployeeCommand>(request);
            return await _mediator.Send(command);
        }
        public async Task<EmployeeResponse> UpdateEmployeeAsync(UpdateEmployeeRequest request)
        {
            var command = _mapper.Map<UpdateEmployeeCommand>(request);
            return await _mediator.Send(command);
        }
        public async Task<List<EmployeeResponse>> GetAllEmployeesAsync()
        {
            return await _mediator.Send(new GetAllEmployeesQuery());
        }
        public async Task<EmployeeResponse> GetEmployeeByIdAsync(Guid id)
        {
            return await _mediator.Send(new GetEmployeeByIdQuery(id));
        }
        public async Task DeleteAsync(Guid id)
        {
            await _mediator.Send(new DeleteEmployeeCommand { EmployeeId = id });
        }
    }
}
