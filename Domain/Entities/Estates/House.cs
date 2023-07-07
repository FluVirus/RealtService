namespace RealtService.Domain.Entities.Estates;

public class House : ResidentialEstate
{
    public int RoomNumber { get; set; }
    public int StroreyNumber { get; set; }
    public bool HasGarage { get; set; }
    public bool HasSwimmingPool { get; set; }
}
