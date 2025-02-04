using EmployeeManagementSystem.Domain.Enums;

namespace EmployeeManagementSystem.Domain.Helpers
{
    public static class RoleHelper
    {
        private static readonly Dictionary<EmployeeRole, Guid> RoleMappings = new()
        {
            { EmployeeRole.Employee, Guid.Parse("00000000-0000-0000-0000-000000000001") },
            { EmployeeRole.Manager, Guid.Parse("00000000-0000-0000-0000-000000000002") },
            { EmployeeRole.Director, Guid.Parse("00000000-0000-0000-0000-000000000003") },
            { EmployeeRole.Admin, Guid.Parse("00000000-0000-0000-0000-000000000004") }
        };

        public static Guid GetRoleIdFromEnum(EmployeeRole role)
        {
            if (RoleMappings.TryGetValue(role, out var roleId))
            {
                return roleId;
            }

            throw new ArgumentException($"Invalid role provided: {role}");
        }
    }
}
