

namespace Jazani.Application.Admins.Dtos.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public int? UserId { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }
        public bool State { get; set; }
        public bool LdapAuthentication { get; set; }
        public string? TokenUuid { get; set; }
        public int? NotificationCount { get; set; }
        public int? IsInspector { get; set; }
    }
}
