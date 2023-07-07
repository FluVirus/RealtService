using RealtService.Domain.Entities.Offers;

namespace RealtService.Domain.Entities.Terms;

public abstract class CommercialTerm: Term
{
    public CommercialOffer Offer { get; set; }
    public int OfferId { get; set; }
}
