﻿using AutoMapper;
using MediatR;
using RealtService.Application.Common.Exceptions;
using RealtService.Application.Common.UnitOfWork;
using RealtService.Domain.Entities;

namespace RealtService.Application.Offers.Queries.GetOfferDetails;

public class GetOfferDetailsQueryHandler : IRequestHandler<GetOfferDetailsQuery, OfferDetailsVm>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetOfferDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

    public async Task<OfferDetailsVm> Handle(GetOfferDetailsQuery request, CancellationToken cancellationToken)
    {
        IRepository<Offer> offerRepository = _unitOfWork.Offers;
        var entity = await offerRepository.GetFirstOrDefaulAsync(offer => offer.Id == request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Offer), request.Id);
        }

        return _mapper.Map<OfferDetailsVm>(entity);
    }
}
