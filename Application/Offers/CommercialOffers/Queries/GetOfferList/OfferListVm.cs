using RealtService.Domain.Entities.Offers;

namespace RealtService.Application.Offers.CommercialOffers.Queries.GetOfferList;

public class CommercialOfferListVm
{
    public IList<CommercialOffer> Offers { get; set; }
}
