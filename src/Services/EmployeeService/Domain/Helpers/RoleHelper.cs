using EmployeeManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Domain.Helpers;

public static class RoleHelper
{
    private static readonly Dictionary<EmployeeRole, Guid> RoleMappings = new()
    {
        { EmployeeRole.Employee, new Guid("00000000-0000-0000-0000-000000000001") },
        { EmployeeRole.Manager, new Guid("00000000-0000-0000-0000-000000000002") },
        { EmployeeRole.Director, new Guid("00000000-0000-0000-0000-000000000003") },
        { EmployeeRole.Admin, new Guid("00000000-0000-0000-0000-000000000004") }
    };

    public static Guid GetRoleIdFromEnum(EmployeeRole role)
    {
        if (!RoleMappings.ContainsKey(role))
            throw new ArgumentException("Invalid role provided");

        return RoleMappings[role];
    }
}
