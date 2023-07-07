using Microsoft.AspNetCore.Identity;

namespace RealtService.Domain.Entities.Users;

public class UserRole: IdentityRole<int>
{
    public virtual ICollection<RoleClaim> Claims { get; set; }
    public virtual ICollection<UserBelongsToRole> UserBelongsToRoles { get; set; }

    public UserRole() : base() { }

    public UserRole(string name) : base(name) { }
}
