using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using RealtService.Application.Common.Exceptions;
using RealtService.Application.Common.JWT;
using RealtService.Application.Common.UnitOfWork;
using RealtService.Domain.Entities.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RealtService.Application.Users.Commands;

public class SignInCommandHandler : IRequestHandler<SignInCommand, string?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtTokenProvider _jwtTokenProvider;
    private readonly IJwtTokenValidationProvider _jwtTokenValidationProvider;

    public SignInCommandHandler(IUnitOfWork unitOfWork, IJwtTokenProvider jwtTokenProvider, IJwtTokenValidationProvider jwtTokenValidationProvider)
    {
        _unitOfWork = unitOfWork;
        _jwtTokenProvider = jwtTokenProvider;
        _jwtTokenValidationProvider = jwtTokenValidationProvider;
    }
    
    public async Task<string?> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        User? requestedUser = await _unitOfWork.UserManager.FindByEmailAsync(request.Email);
        if (requestedUser is null)
        {
            throw new NotFoundException(objectName: "User", keyName: $"email {request.Email}");
        }

        SignInResult result = await _unitOfWork.SignInManager.CheckPasswordSignInAsync(user: requestedUser, password: request.Password, lockoutOnFailure: false);
        if (result.Succeeded) 
        {
            IList<string> userRoles = await _unitOfWork.UserManager.GetRolesAsync(requestedUser);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, requestedUser.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (string userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            TokenValidationParameters parameters = _jwtTokenValidationProvider.Parameters;

            string token = _jwtTokenProvider.GetJwtToken
                (
                    issuer: parameters.ValidIssuer,
                    audience: parameters.ValidAudience,
                    notBefore: DateTime.Now,
                    claims: authClaims,
                    expires: DateTime.UtcNow.AddDays(1)
                );
            return token;
        }

        return null;
    }
}
