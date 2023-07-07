using MediatR;
using RealtService.Application.Common.UnitOfWork;
using RealtService.Domain.Entities.Users;

namespace RealtService.Application.Users.Queries.GetUserList;

public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListVm>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserListQueryHandler(IUnitOfWork unitOfWork) => (_unitOfWork) = (unitOfWork);

    public async Task<UserListVm> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        IRepository<User> userRepository = _unitOfWork.Users;
        IQueryable<User> userQuery = await userRepository
            .GetAllAsync();
        
        return new UserListVm { Users =  userQuery.ToList() };
    }
}
