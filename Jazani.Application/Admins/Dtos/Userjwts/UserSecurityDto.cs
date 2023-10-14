using Jazani.Core.Securities.Entities;

namespace Jazani.Application.Admins.Dtos.Userjwts
{
    public class UserSecurityDto : UserjwtDto
    {
        public SecurityEntity Security { get; set; }
    }
}
