using EmployeeManagementSystem.Application.CQRS.Commands;
using EmployeeManagementSystem.Domain.Interfaces;
using MediatR;

namespace EmployeeManagementSystem.Application.CQRS.Handlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _employeeRepository.DeleteAsync(request.EmployeeId);
            return true;

        }
    }
}
