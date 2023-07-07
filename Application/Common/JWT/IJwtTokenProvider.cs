using System.Security.Claims;

namespace RealtService.Application.Common.JWT;

public interface IJwtTokenProvider
{
    string GetJwtToken
    (
        string? issuer,
        string? audience,
        DateTime? notBefore,
        IEnumerable<Claim> claims,
        DateTime? expires
    );
}
