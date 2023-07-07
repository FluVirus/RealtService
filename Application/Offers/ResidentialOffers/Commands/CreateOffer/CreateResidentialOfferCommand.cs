using MediatR;
using RealtService.Domain.Entities.Offers;

namespace RealtService.Application.Offers.ResidentialOffers.Commands.CreateOffer;

public record class CreateResidentialOfferCommand : IRequest<ResidentialOffer>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public DateTime PublicationDate { get; set; }
    public int UserId { get; set; }
}
