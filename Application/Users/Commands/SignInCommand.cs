using MediatR;
using System.ComponentModel.DataAnnotations;

namespace RealtService.Application.Users.Commands;

public class SignInCommand: IRequest<string?>
{
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }

    [DataType(DataType.Password)]
    public required string Password { get; set; }

    public bool RememberMe { get; set; }
}
