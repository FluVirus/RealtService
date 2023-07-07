namespace RealtService.Domain.Entities.Estates;

public class Flat : ResidentialEstate
{
    public int StoreyNumber { get; set; }
    public int RoomNumber { get; set; }
    public int WCNumber { get; set; }
}
