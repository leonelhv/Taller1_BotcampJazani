using System.ComponentModel;

namespace Jazani.Application.Admins.Dtos.Users
{
    public class UserSaveDto
    {
        [DefaultValue(null)]
        public int? RoleId { get; set; }
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;

    }
}
