using Microsoft.IdentityModel.Tokens;

namespace RealtService.Application.Common.JWT;

public interface IJwtTokenValidationProvider
{
    public TokenValidationParameters Parameters { get; }
}
