using RealtService.Domain.Entities.Offers;

namespace RealtService.Domain.Entities.Estates;

public abstract class ResidentialEstate : Estate
{
    public ResidentialOffer Offer { get; set; }
    public int OfferId { get; set; }
}
