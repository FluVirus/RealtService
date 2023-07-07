using RealtService.Domain.Entities.Estates;

namespace RealtService.Application.Estates.ResidentialEstates.Flats.Queries.GetEstateList;

public class FlatListVm
{
    public IList<Flat> Estates { get; set; }
}
