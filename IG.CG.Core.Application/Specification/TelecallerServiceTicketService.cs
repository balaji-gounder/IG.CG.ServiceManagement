using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class TelecallerServiceTicketService : ITelecallerServiceTicketService
    {
        private readonly IMapper _mapper;
        private readonly ITelecallerServiceTicketRepository _ProdCustInfoRepository;
        public TelecallerServiceTicketService(IMapper mapper, ITelecallerServiceTicketRepository ProdCustInfoRepository)
        {
            _mapper = mapper;
            _ProdCustInfoRepository = ProdCustInfoRepository;
        }

        public async Task<ProductCustomerInfoDisplayModel> GetAllProdSerialNoAsync(string? SerialNo, string? ProductCode)
        {
            var prodcust = await _ProdCustInfoRepository.GetAllProdSerialNoAsync(SerialNo, ProductCode);
            var prodcustModel = _mapper.Map<ProductCustomerInfoDisplayModel>(prodcust);
            return prodcustModel;
        }



        public async Task<string?> UpsertProductCustomerInfoAsync(ProductCustomerInfoModel ProCustInfoModel, string? userId, string? DocumentPath)
        {
            ProductCustomerInfoEntity ProCustObj = _mapper.Map<ProductCustomerInfoEntity>(ProCustInfoModel);
            ProCustObj.UserId = userId;
            //ProCustObj.InvoceFilePath = DocumentPath;
            return await _ProdCustInfoRepository.UpsertProductCustomerInfoAsync(ProCustObj);
        }


        public async Task<string?> UpsertProductTelecallerInfoAsync(ProductCustomerInfoModel ProCustInfoModel, string? userId, string? DocumentPath)
        {
            ProductCustomerInfoEntity ProCustObj = _mapper.Map<ProductCustomerInfoEntity>(ProCustInfoModel);
            ProCustObj.UserId = userId;
            //ProCustObj.InvoceFilePath = DocumentPath;
            return await _ProdCustInfoRepository.UpsertProductTelecallerInfoAsync(ProCustObj);
        }




        public async Task<IList<ProdCustInfoDisplayModel>> GetAllProdCustInfoAsync(string? MobileNo)
        {
            var prodcustinfo = await _ProdCustInfoRepository.GetAllProdCustInfoAsync(MobileNo);
            var prodcustinfoModel = _mapper.Map<List<ProdCustInfoDisplayModel>>(prodcustinfo.ToList());
            return prodcustinfoModel;
        }

        public async Task<ProdSerialNoWarrantySAPDisplayModel> GetAllProdSerialNoWarrantyServiceTicketAsync(ProdSerialNoFilter PsrnoFilter)
        {
            var Psrnow = await _ProdCustInfoRepository.GetAllProdSerialNoWarrantyServiceTicketAsync(PsrnoFilter);
            var PsrnowModel = _mapper.Map<ProdSerialNoWarrantySAPDisplayModel>(Psrnow);
            return PsrnowModel;
        }

        public async Task<ProdSerialNoWarrantySAPDisplayModel> GetAllProdSerialNoWarrantyServiceTicketTelecallerAsync(ProdSerialNoTelecallerFilter PsrnoFilter)
        {
            var Psrnow = await _ProdCustInfoRepository.GetAllProdSerialNoWarrantyServiceTicketTelecallerAsync(PsrnoFilter);
            var PsrnowModel = _mapper.Map<ProdSerialNoWarrantySAPDisplayModel>(Psrnow);
            return PsrnowModel;
        }
    }
}
