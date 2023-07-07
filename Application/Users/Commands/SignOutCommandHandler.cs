using MediatR;
using RealtService.Application.Common.UnitOfWork;

namespace RealtService.Application.Users.Commands;

public class SignOutCommandHandler : IRequestHandler<SignOutCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public SignOutCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(SignOutCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.SignInManager.SignOutAsync();
    }
}
