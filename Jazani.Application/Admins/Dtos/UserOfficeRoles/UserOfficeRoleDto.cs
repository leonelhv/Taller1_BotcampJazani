using Jazani.Application.Admins.Dtos.Roles;
using Jazani.Application.Admins.Dtos.Users;

namespace Jazani.Application.Admins.Dtos.UserOfficeRoles
{
    public class UserOfficeRoleDto
    {
        public UserSimpleDto User { get; set; } = default!;
        public int OfficeId { get; set; } = default!;
        public RoleSimpleDto Role { get; set; } = default!;
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
