using Jazani.Core.Securities.Entities;

namespace Jazani.Core.Securities.Services
{
    public interface ISecurityService
    {
        string HashPassword(string userName, string hashedPassword);

        bool VerifyHashedPassword(string userName, string hashedPassword, string providedPassword);

        SecurityEntity JwtSecurity(string jwtSecrectKey);
    }
}
