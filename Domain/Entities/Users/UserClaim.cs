using Microsoft.AspNetCore.Identity;
using RealtService.Domain.Entities.Base;

namespace RealtService.Domain.Entities.Users;

public class UserClaim: IdentityUserClaim<int>
{
    public virtual User User { get; set; }
}
