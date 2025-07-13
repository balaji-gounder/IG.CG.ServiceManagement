using Microsoft.AspNetCore.Http;

namespace IG.CG.Core.Application.Models
{
    public class knowledgeInfoDetailslistModel
    {
        public int? knowledgeId { get; set; }
        public int? CategoryId { get; set; }
        public string? knowledgeTitle { get; set; }
        public string? Description { get; set; }
        public string? UserId { get; set; }
        public List<IFormFile>? InvoiceFile { get; set; }

        public string? Division { get; set; }
        public string? ProductLine { get; set; }
        public string? ValidTill { get; set; }

        public string? ValidFrom { get; set; }
    }


}
