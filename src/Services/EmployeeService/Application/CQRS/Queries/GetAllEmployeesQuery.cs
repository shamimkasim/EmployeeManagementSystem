using EmployeeManagementSystem.Application.DTOs.Responses;
using MediatR;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Application.CQRS.Queries
{
    public class GetAllEmployeesQuery : IRequest<List<EmployeeResponse>>
    {
    }
}
