

using CleanArchitecture.Domain.Shared;

namespace CleanArchitecture.Domain.Roles
{
    public sealed class Role : Enumeration<Role>
    {
        public static Role Cliente = new(1, "Cliente");
        public static Role Admin = new(1, "Admin");
        public Role(int id, string name) : base(id, name)
        {
        }
    }
}
