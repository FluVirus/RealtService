using RealtService.Domain.Entities.Base;

namespace RealtService.Domain.Entities.Users;

public class UserContact: NamedEntity
{
    public virtual int UserId { get; set; }
    public virtual User User { get; set; }
}
