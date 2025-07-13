namespace IG.CG.Core.Domain.Entities
{
    public class CustomerDisplayEntity : CustomerEntity
    {
        public string? TalukaName { get; set; }
        public string? StateName { get; set; }
        public string? CityName { get; set; }
        public string? AreaName { get; set; }

    }
}
