using MediatR;

namespace RealtService.Application.Offers.CommercialOffers.Commands.UpdateOffer;

public class UpdateCommercialOfferCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
}
