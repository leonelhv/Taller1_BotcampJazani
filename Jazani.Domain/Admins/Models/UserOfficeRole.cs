namespace Jazani.Domain.Admins.Models
{
    public class UserOfficeRole
    {
        public int UserId { get; set; } = default!;
        public int OfficeId { get; set; } = default!;
        public int RoleId { get; set; } = default!;
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        public virtual User User { get; set; }
    }
}
