using Microsoft.AspNetCore.Identity;

namespace RealtService.Domain.Entities.Users;

public class UserToken: IdentityUserToken<int>
{
    public virtual User User { get; set; }
}
