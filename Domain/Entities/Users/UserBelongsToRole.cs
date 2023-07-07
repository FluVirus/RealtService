using Microsoft.AspNetCore.Identity;

namespace RealtService.Domain.Entities.Users;

public class UserBelongsToRole: IdentityUserRole<int>
{
    public virtual UserRole Role { get; set; }
    public virtual User User { get; set; }
}
