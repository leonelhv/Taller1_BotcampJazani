namespace Jazani.Application.Admins.Dtos.UserOfficeRoles
{
    public class UserOfficeRoleSaveDto
    {
        public int UserId { get; set; } = default!;
        public int OfficeId { get; set; } = default!;
        public int RoleId { get; set; } = default!;

    }
}
