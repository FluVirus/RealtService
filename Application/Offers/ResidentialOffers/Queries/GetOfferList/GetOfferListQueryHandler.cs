﻿using MediatR;
using RealtService.Application.Common.UnitOfWork;
using RealtService.Domain.Entities.Offers;

namespace RealtService.Application.Offers.ResidentialOffers.Queries.GetOfferList;

public class GetOfferListQueryHandler : IRequestHandler<GetOfferListQuery, ResiadentialOfferListVm>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetOfferListQueryHandler(IUnitOfWork unitOfWork) => (_unitOfWork) = (unitOfWork);
    public async Task<ResiadentialOfferListVm> Handle(GetOfferListQuery request, CancellationToken cancellationToken)
    {
        IRepository<ResidentialOffer> offerRepository = _unitOfWork.ResidentialOffers;
        IQueryable<ResidentialOffer> offerQuery = await offerRepository
            .GetAllAsync();

        return new ResiadentialOfferListVm { Offers = offerQuery.ToList() };
    }
}
