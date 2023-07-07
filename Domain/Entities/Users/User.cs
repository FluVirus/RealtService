using Microsoft.AspNetCore.Identity;

namespace RealtService.Domain.Entities.Users;

public abstract class User : IdentityUser<int>
{
    public virtual ICollection<UserClaim> Claims { get; }
    public virtual ICollection<UserContact> Contacts { get; }
    public virtual ICollection<UserLogin> Logins { get; }
    public virtual ICollection<UserToken> Tokens { get; }
    public virtual ICollection<UserBelongsToRole> BelongsToRoles { get; }
    public virtual ICollection<Offer> Offers { get; }
}
