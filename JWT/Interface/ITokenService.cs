using JWTCommons;
using System.Security.Claims;

namespace JWT.Interface
{
    public interface ITokenService
    {
        string BuildToken(IEnumerable<Claim> claims, JWTOptions options);
    }
}
