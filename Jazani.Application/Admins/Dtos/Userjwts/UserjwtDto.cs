namespace Jazani.Application.Admins.Dtos.Userjwts
{
    public class UserjwtDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? LastName { get; set; }
        public string Email { get; set; } = default!;
        public int RoleId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}

