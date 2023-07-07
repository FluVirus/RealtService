using MediatR;

namespace RealtService.Application.Offers.Queries.GetOfferDetails;

public class GetOfferDetailsQuery : IRequest<OfferDetailsVm>
{
    public int Id { get; set; }
}
