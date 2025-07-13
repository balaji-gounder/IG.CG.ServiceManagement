using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;
using IG.CG.Core.Domain.Enums;

namespace IG.CG.Core.Application.Specification
{
    public class ProdCustInfoService : IProdCustInfoService
    {

        private readonly IMapper _mapper;
        private readonly IProdCustInfoRepository _ProdCustInfoRepository;
        public readonly ICommunication _ProdCustInfoRepository1;
        public ProdCustInfoService(IMapper mapper, IProdCustInfoRepository ProdCustInfoRepository, ICommunication communication)
        {
            _mapper = mapper;
            _ProdCustInfoRepository = ProdCustInfoRepository;
            _ProdCustInfoRepository1 = communication;
        }
        public async Task<IList<ProdCustInfoDisplayModel>> GetAllProdCustInfoAsync(ProdCustInfoFilter pciFilter)
        {
            var prodcustinfo = await _ProdCustInfoRepository.GetAllProdCustInfoAsync(pciFilter);
            var prodcustinfoModel = _mapper.Map<List<ProdCustInfoDisplayModel>>(prodcustinfo.ToList());
            return prodcustinfoModel;
        }

        public async Task<string?> UpsertCustVerificationAsync(CustVerificationModel CvfModel)
        {
            string MobileTop = "";
            CustVerificationEntity CvfObj = _mapper.Map<CustVerificationEntity>(CvfModel);
            MobileTop = await _ProdCustInfoRepository.UpsertCustVerificationAsync(CvfObj);
            string Msg = "";

            Msg = MobileTop + " is your One Time Password for CGPISL product warranty registration  -CGPISL";

            SMSModel smsModel = new SMSModel();

            smsModel.ToNumber = CvfModel.MobileNo;
            smsModel.SmsBody = Msg;

            await _ProdCustInfoRepository1.SendSMS(smsModel);


            return MobileTop;

        }



        public async Task<string?> UpsertSMSAsync(SMSDetailsModel CvfModel)
        {
            SMSDetailsEntity CvfObj = _mapper.Map<SMSDetailsEntity>(CvfModel);
            return await _ProdCustInfoRepository.UpsertSMSAsync(CvfObj);

        }

        public async Task<ProdSerialNoWarrantySAPDisplayModel> GetAllProdSerialNoWarrantyAsync(ProdSerialNoFilter PsrnoFilter)
        {
            var Psrnow = await _ProdCustInfoRepository.GetAllProdSerialNoWarrantyAsync(PsrnoFilter);
            var PsrnowModel = _mapper.Map<ProdSerialNoWarrantySAPDisplayModel>(Psrnow);
            return PsrnowModel;
        }



        public async Task<ProdSerialNoWarrantySAPDisplayModel> GetAllProdSerialNoWarrantyServiceTicketAsync(ProdSerialNoFilter PsrnoFilter)
        {
            var Psrnow = await _ProdCustInfoRepository.GetAllProdSerialNoWarrantyServiceTicketAsync(PsrnoFilter);
            var PsrnowModel = _mapper.Map<ProdSerialNoWarrantySAPDisplayModel>(Psrnow);
            return PsrnowModel;
        }

        public async Task<string?> UpsertProductCustomerInfoAsync(ProductCustomerInfoModel ProCustInfoModel, string? userId, string? DocumentPath)
        {
            ProductCustomerInfoEntity ProCustObj = _mapper.Map<ProductCustomerInfoEntity>(ProCustInfoModel);
            ProCustObj.UserId = "";
            //ProCustObj.InvoceFilePath = DocumentPath;
            return await _ProdCustInfoRepository.UpsertProductCustomerInfoAsync(ProCustObj);
        }



        public async Task<string?> UpsertProductCustomerASMInfoAsync(ProductCustomerAMSInfoModel ProCustInfoModel)
        {
            ProductCustomerAMSInfoEntity ProCustObj = _mapper.Map<ProductCustomerAMSInfoEntity>(ProCustInfoModel);

            return await _ProdCustInfoRepository.UpsertProductCustomerASMInfoAsync(ProCustObj);
        }


        public async Task<string?> UpsertProductActivityAsync(ProductUpdateActivityModel ProCustInfoModel)
        {
            bool ifSuccess;
            DocumentTypes docType = DocumentTypes.FIRDocument;
            string? filePath = "";
            string? FIRCopy = "";
            List<Tuple<bool, string>> documentResult = await _ProdCustInfoRepository1.UploadDocument(ProCustInfoModel.InvoiceFile, docType);

            foreach (var item in documentResult)
            {

                ifSuccess = item.Item1;
                if (ifSuccess == true)
                {
                    filePath = item.Item2;
                }
            }


            List<Tuple<bool, string>> documentResult1 = await _ProdCustInfoRepository1.UploadDocument(ProCustInfoModel.FIRcopy, docType);

            foreach (var item in documentResult1)
            {

                ifSuccess = item.Item1;
                if (ifSuccess == true)
                {
                    FIRCopy = item.Item2;
                }
            }



            ProductUpdateActivityEntity ProCustObj = _mapper.Map<ProductUpdateActivityEntity>(ProCustInfoModel);

            return await _ProdCustInfoRepository.UpsertProductActivityAsync(ProCustObj, filePath, FIRCopy);
        }


        public async Task<ProdCustInfoDisplayModel> GetProdCustInfoByIdAsync(int prodRegAutoId)
        {
            var prodcust = await _ProdCustInfoRepository.GetProdCustInfoByIdAsync(prodRegAutoId);
            var prodcustModel = _mapper.Map<ProdCustInfoDisplayModel>(prodcust);
            return prodcustModel;
        }

        public async Task<string?> UpsertProdCustInfoAsync(ProdCustInfoDisplayModel ProdcustModel)
        {
            ProdCustInfoDisplayEnitity ProdcustObj = _mapper.Map<ProdCustInfoDisplayEnitity>(ProdcustModel);

            return await _ProdCustInfoRepository.UpsertProdCustInfoAsync(ProdcustObj);
        }

        public async Task<ProductCustomerInfoDisplayModel> GetProductCustomerDeviationInfoByIdAsync(int prodRegAutoId)
        {
            var prodcust = await _ProdCustInfoRepository.GetProductCustomerDeviationInfoByIdAsync(prodRegAutoId);
            var prodcustModel = _mapper.Map<ProductCustomerInfoDisplayModel>(prodcust);
            return prodcustModel;
        }


        public async Task<IList<ProdCustInfoDisplayModel>> GetAllProductDeviationAsync(ProductDeviationFilter pciFilter)
        {
            var prodcustinfo = await _ProdCustInfoRepository.GetAllProductDeviationAsync(pciFilter);
            var prodcustinfoModel = _mapper.Map<List<ProdCustInfoDisplayModel>>(prodcustinfo.ToList());
            return prodcustinfoModel;
        }


        public async Task<IList<ProdCustInfoDisplayModel>> GetAllProductCustomerDetailsAsync(ProductDeviationFilter pciFilter)
        {
            var prodcustdetails = await _ProdCustInfoRepository.GetAllProductCustomerDetailsAsync(pciFilter);
            var prodcustinfoModel = _mapper.Map<List<ProdCustInfoDisplayModel>>(prodcustdetails.ToList());
            return prodcustinfoModel;
        }
        public async Task<IList<ProductCustomerInfoDisplayModel>> GetAllProductCustomeAdminAsync(ProductCustomeAdminFilter pciFilter)
        {
            var prodcustinfo = await _ProdCustInfoRepository.GetAllProductCustomeAdminAsync(pciFilter);
            var prodcustinfoModel = _mapper.Map<List<ProductCustomerInfoDisplayModel>>(prodcustinfo.ToList());
            return prodcustinfoModel;
        }


        // Product Deviation
        public async Task<string?> UpsertProdDeviationAsync(ProdDeviationModel ProdDevModel, string? UserId)
        {
            ProdDeviationEntity ProdDevObj = _mapper.Map<ProdDeviationEntity>(ProdDevModel);
            ProdDevObj.UserId = UserId;
            return await _ProdCustInfoRepository.UpsertProdDeviationAsync(ProdDevObj);
        }


        public async Task<string?> AddProductCustomerInfoDealer(ProductCustomerInfoDealerModel objProductCutDeal, string? userId, List<ProductDealerModel> lstProductDeal)
        {
            string? result = null;

            var lstProductDealModel = _mapper.Map<List<ProductDealerEntity>>(lstProductDeal);

            ProductCustomerInfoDealerEntity objProductCutDealModel = _mapper.Map<ProductCustomerInfoDealerEntity>(objProductCutDeal);

            Random r = new Random();
            int TNo = 0;
            string ServiceTicketNumber = "";
            string ServiceTicketNo = "";


            ServiceTicketNo = await _ProdCustInfoRepository.ServiceTicketNoGetAsync();

            string RNo = r.Next(5, 100000).ToString();

            foreach (var ProductDeal in lstProductDealModel)
            {
                if (ProductDeal.ParentId == "1")
                {
                    ServiceTicketNumber = ServiceTicketNo;

                }
                else
                {
                    TNo = TNo + 1;

                    ServiceTicketNumber = ServiceTicketNo + "/" + TNo.ToString();
                }

                result = await _ProdCustInfoRepository.AddProductCustomerInfoDealer(objProductCutDealModel, userId, ProductDeal, RNo, ServiceTicketNumber);
            }

            return result;
        }


        public async Task<string?> AddAscTicketCreateInfo(List<AddAscTicketCreateModel> objProductCutDeal, string? userId)
        {
            string? result = null;

            var lstProductModel = _mapper.Map<List<AddAscTicketCreateEntity>>(objProductCutDeal);



            Random r = new Random();
            int TNo = 0;
            string ServiceTicketNumber = "";


            string RNo = r.Next(5, 100000).ToString();

            foreach (var ProductDeal in lstProductModel)
            {


                TNo = TNo + 1;

                ServiceTicketNumber = ProductDeal.ServiceTicketNumber + "/" + TNo.ToString();
                result = await _ProdCustInfoRepository.AddAscTicketCreateInfo(ProductDeal, userId, ServiceTicketNumber);
            }

            return result;
        }


    }
}
