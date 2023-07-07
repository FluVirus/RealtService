using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealtService.Application.Users.Commands;
using RealtService.Domain.Entities.Users;
using RealtService.WebApi.Controllers;
using RealtService.WebApi.Models;

namespace RealtService.WebApi.Contollers;

[Route("api/[action]")]
[ApiController]
public class AuthController : RealtServiceControllerBase
{
    public AuthController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

    [HttpPost]
    public async Task<IActionResult> SignUp([FromBody] SignUpCommand createNewUserCommand)
    {
        User user = await Mediator.Send(createNewUserCommand);
        return Ok(new { user.Id, user.Email, user.UserName });
    }


    [HttpPost]
    public async Task<IActionResult> SignIn(SignInCommand signInCommand)
    {
        string? token = await Mediator.Send(signInCommand);
        if (token is not null)
        {
            return Ok(new {token});
        }
        return Unauthorized();
    }

    [HttpPost]
    public async Task<IActionResult> SignOut(SignOutCommand signOutCommand)
    {
        await Mediator.Send(signOutCommand);
        return Ok();
    }
}