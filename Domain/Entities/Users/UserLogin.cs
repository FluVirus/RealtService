using Microsoft.AspNetCore.Identity;

namespace RealtService.Domain.Entities.Users;

public class UserLogin: IdentityUserLogin<int>
{
    public virtual User User { get; set; }
}
