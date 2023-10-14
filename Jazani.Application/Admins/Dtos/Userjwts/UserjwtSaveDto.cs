namespace Jazani.Application.Admins.Dtos.Userjwts
{
    public class UserjwtSaveDto
    {
        public string Name { get; set; } = default!;
        public string? LastName { get; set; }
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public int RoleId { get; set; }
    }
}

