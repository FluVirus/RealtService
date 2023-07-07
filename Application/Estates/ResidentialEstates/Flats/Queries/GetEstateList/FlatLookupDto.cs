namespace RealtService.Application.Estates.ResidentialEstates.Flats.Queries.GetEstateList;

public class FlatLookupDto 
{
    public int Id { get; set; }
    public float Square { get; set; }
    public int StoreyNumber { get; set; }
    public int RoomNumber { get; set; }
    public int WCNumber { get; set; }
}
