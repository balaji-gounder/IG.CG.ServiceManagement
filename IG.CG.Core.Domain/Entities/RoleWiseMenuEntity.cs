namespace IG.CG.Core.Domain.Entities
{
    public class RoleWiseMenuEntity
    {
        public int MenuId { get; set; }
        public string? MenuCode { get; set; }
        public string? MenuText { get; set; }
        public string? MenuUrl { get; set; }
        public int ParentId { get; set; }
        public bool IsAdd { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public bool IsView { get; set; }
        public bool IsDownload { get; set; }
        public bool IsUpload { get; set; }
        public bool IsApproved { get; set; }
        public string? TotalRows { get; set; }
    }
}
