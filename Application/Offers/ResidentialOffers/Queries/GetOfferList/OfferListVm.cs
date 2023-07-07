using RealtService.Domain.Entities.Offers;

namespace RealtService.Application.Offers.ResidentialOffers.Queries.GetOfferList;

public class ResiadentialOfferListVm
{
    public IList<ResidentialOffer> Offers { get; set; }
}
