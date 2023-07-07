using MediatR;
using RealtService.Application.Common.UnitOfWork;
using RealtService.Domain.Entities.Estates;

namespace RealtService.Application.Estates.ResidentialEstates.Flats.Queries.GetEstateList;

public class GetFlatListQueryHandler : IRequestHandler<GetFlatListQuery, FlatListVm>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetFlatListQueryHandler(IUnitOfWork unitOfWork) => (_unitOfWork) = (unitOfWork);
    public async Task<FlatListVm> Handle(GetFlatListQuery request, CancellationToken cancellationToken)
    {
        IRepository<Flat> estateRepository = _unitOfWork.Flats;
        IQueryable<Flat> estateQuery = await estateRepository
            .GetAllAsync();

        return new FlatListVm { Estates = estateQuery.ToList() };
    }
}
