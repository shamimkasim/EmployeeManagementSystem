namespace EmployeeManagementSystem.Domain.Entities
{
    public class Role
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private Role() { } 

        public Role(string name)
        {
            Name = name;
        }
    }
}
