namespace Jazani.Domain.Admins.Models
{
    public class OfficeRole
    {
        public int OfficeId { get; set; } = default!;
        public int RoleId { get; set; } = default!;
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
        public List<User> Users { get; } = new();
        public Role Role { get; set; } = default!;

        public virtual ICollection<OfficeRole> OfficeRoles { get; set; }
    }
}
