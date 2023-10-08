using Jazani.Application.Admins.Dtos.Users;

namespace Jazani.Application.Admins.Dtos.UserOfficeRoles
{
    public class UserOfficeRoleDto
    {
        public UserSimpleDto User { get; set; }
        public int OfficeId { get; set; }
        public int RoleId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
