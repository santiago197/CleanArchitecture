
using CleanArchitecture.Domain.Permissions;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.Infrastructure.Authentication
{
    public class HassPermissionAttribute : AuthorizeAttribute
    {
        public HassPermissionAttribute(PermissionEnum permission) : base(policy: permission.ToString())
        {
            
        }
    }
}
