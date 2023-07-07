using MediatR;

namespace RealtService.Application.Estates.ResidentialEstates.Flats.Commands.UpdateFlat;

public class UpdateFlatCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public float Square { get; set; }
    public int StoreyNumber { get; set; }
    public int RoomNumber { get; set; }
    public int WCNumber { get; set; }
}
