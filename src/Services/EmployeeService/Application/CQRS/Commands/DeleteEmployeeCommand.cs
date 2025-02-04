using MediatR;
using System;

namespace EmployeeManagementSystem.Application.CQRS.Commands
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public Guid EmployeeId { get; set; }
    }
}
