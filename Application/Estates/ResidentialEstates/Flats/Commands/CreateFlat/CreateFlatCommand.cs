using MediatR;
using RealtService.Domain.Entities.Estates;

namespace RealtService.Application.Estates.ResidentialEstates.Flats.Commands.CreateFlat;

public record class CreateFlatCommand : IRequest<Flat>
{
    public int OfferId { get; set; }
    public float Square { get; set; }
    public int StoreyNumber { get; set; }
    public int RoomNumber { get; set; }
    public int WCNumber { get; set; }
}
