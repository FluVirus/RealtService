using RealtService.Domain.Entities.Offers;

namespace RealtService.Domain.Entities.Terms;

public abstract class ResidentialTerm: Term
{
    public ResidentialOffer Offer { get; set; }
    public int OfferId { get; set; }
}
