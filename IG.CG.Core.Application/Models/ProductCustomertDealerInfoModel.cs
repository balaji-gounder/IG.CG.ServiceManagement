using Microsoft.AspNetCore.Http;

namespace IG.CG.Core.Application.Models
{
    public class ProductCustomertDealerInfoModel
    {
        public List<ProductDealerModel> lstProdDeal { get; set; }
        public List<IFormFile>? InvoceFilePath { get; set; }
        public ProductCustomerInfoDealerModel ObjProdCustDeal { get; set; }
    }
}
