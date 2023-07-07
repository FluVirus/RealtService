namespace RealtService.Domain.Entities.Estates;

public class Warehouse: CommercialEstate
{
    public float CeilingHeight { get; set; }
    public bool HasClimateControl { get; set; }
}
