namespace Jazani.Domain.Admins.Models
{
    public class UserOfficeRole
    {

        public int UserId { get; set; }
        public int OfficeId { get; set; }
        public int RoleId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        public virtual User User { get; set; } = default!;
        public virtual Office Office { get; set; } = default!;
        public virtual Role Role { get; set; } = default!;

    }
}
