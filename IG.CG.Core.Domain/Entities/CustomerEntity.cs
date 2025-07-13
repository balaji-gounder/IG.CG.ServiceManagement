namespace IG.CG.Core.Domain.Entities
{
    public class CustomerEntity : BaseEntity
    {
        public int CustAutoId { get; set; }
        public string? CustName { get; set; }
        public string? CustPhone { get; set; }
        public string? CustPhone2 { get; set; }
        public string? CustEmail { get; set; }
        public string? CustAddess { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int TalukaId { get; set; }
        public int AreaId { get; set; }
        public int PinId { get; set; }
        public bool IsActive { get; set; }

    }
}
