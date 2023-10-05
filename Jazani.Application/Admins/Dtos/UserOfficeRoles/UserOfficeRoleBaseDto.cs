namespace Jazani.Application.Admins.Dtos.UserOfficeRoles
{
    public class UserOfficeRoleBaseDto
    {
        public int UserId { get; set; } = default!;
        public int OfficeId { get; set; } = default!;
        public int RoleId { get; set; } = default!;
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
