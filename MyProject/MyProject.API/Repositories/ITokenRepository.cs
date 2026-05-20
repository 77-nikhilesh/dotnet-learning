using Microsoft.AspNetCore.Identity;

namespace MyProject.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
