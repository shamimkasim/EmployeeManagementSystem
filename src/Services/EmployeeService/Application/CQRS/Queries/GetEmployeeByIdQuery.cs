using EmployeeManagementSystem.Application.DTOs.Responses;
using MediatR;

namespace EmployeeManagementSystem.Application.CQRS.Handlers
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeResponse>
    {
        public Guid EmployeeId { get;}

        public GetEmployeeByIdQuery(Guid employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
