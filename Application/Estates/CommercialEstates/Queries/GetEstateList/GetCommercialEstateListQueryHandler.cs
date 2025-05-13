﻿using MediatR;
using RealtService.Application.Common.UnitOfWork;
using RealtService.Domain.Entities.Estates;

namespace RealtService.Application.Estates.CommercialEstates.Queries.GetEstateList;

public class GetCommercialEstateListQueryHandler : IRequestHandler<GetCommercialEstateListQuery, CommercialEstateListVm>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCommercialEstateListQueryHandler(IUnitOfWork unitOfWork) => (_unitOfWork) = (unitOfWork);

    public async Task<CommercialEstateListVm> Handle(GetCommercialEstateListQuery request, CancellationToken cancellationToken)
    {
        IRepository<CommercialEstate> estateRepository = _unitOfWork.CommercialEstates;
        IQueryable<CommercialEstate> estateQuery = await estateRepository
            .GetAllAsync();

        return new CommercialEstateListVm { Estates = estateQuery.ToList() };
    }
}
