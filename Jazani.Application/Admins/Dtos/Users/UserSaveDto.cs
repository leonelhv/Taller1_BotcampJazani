using System.ComponentModel;

namespace Jazani.Application.Admins.Dtos.Users
{
    public class UsersSaveDto
    {
        [DefaultValue(null)]
        public int? RoleId { get; set; }
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;

    }
}
