using MediatR;
using RealtService.Application.Common.UnitOfWork;
using RealtService.Domain.Entities;

namespace RealtService.Application.Offers.Queries.GetOfferList;

public class GetOfferListQueryHandler : IRequestHandler<GetOfferListQuery, OfferListVm>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetOfferListQueryHandler(IUnitOfWork unitOfWork) => (_unitOfWork) = (unitOfWork);

    public async Task<OfferListVm> Handle(GetOfferListQuery request, CancellationToken cancellationToken)
    {
        IRepository<Offer> offerRepository = _unitOfWork.Offers;
        IQueryable<Offer> offerQuery = await offerRepository
            .GetAllAsync();

        return new OfferListVm { Offers = offerQuery.ToList() };
    }
}
