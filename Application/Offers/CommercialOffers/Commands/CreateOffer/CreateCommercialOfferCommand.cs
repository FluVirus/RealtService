using MediatR;
using RealtService.Domain.Entities.Offers;

namespace RealtService.Application.Offers.CommercialOffers.Commands.CreateOffer;

public class CreateCommercialOfferCommand : IRequest<CommercialOffer>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public DateTime PublicationDate { get; set; }
    public int UserId { get; set; }
}
