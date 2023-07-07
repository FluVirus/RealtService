using RealtService.Domain.Entities.Offers;

namespace RealtService.Domain.Entities.Estates;

public abstract class CommercialEstate : Estate
{
    public CommercialOffer Offer { get; set; }
    public int OfferId { get; set; }
}
