namespace Jazani.Application.Admins.Dtos.UserOfficeRoles
{
    public class UserOfficeRoleBaseDto
    {
        public int UserId { get; set; }
        public int OfficeId { get; set; }
        public int RoleId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
