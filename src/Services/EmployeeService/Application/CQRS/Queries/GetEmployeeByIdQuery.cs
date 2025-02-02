using EmployeeManagementSystem.Application.DTOs.Responses;
using MediatR;
using System;

namespace EmployeeManagementSystem.Application.CQRS.Queries
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeResponse>
    {
        public Guid EmployeeId { get; set; }
    }
}
