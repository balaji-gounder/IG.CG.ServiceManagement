using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;

namespace IG.CG.Core.Application.Specification
{
    public class ServiceTicketService : IServiceTicketService
    {
        private readonly IMapper _mapper;
        private readonly IServiceTicketRepository _ServiceTicketRepository;
        public ServiceTicketService(IMapper mapper, IServiceTicketRepository ServiceTicketRepository)
        {
            _mapper = mapper;
            _ServiceTicketRepository = ServiceTicketRepository;
        }

        public async Task<IList<ServiceTicketDetailsModel>> GetServiceTicketDetailsByIdAsync(string? ServiceTickeId)
        {
            var ServiceTicket = await _ServiceTicketRepository.GetServiceTicketDetailsByIdAsync(ServiceTickeId);
            var ServiceTicketModel = _mapper.Map<List<ServiceTicketDetailsModel>>(ServiceTicket?.ToList());
            return ServiceTicketModel;

        }

        public async Task<IList<ServiceTicketDetailsModel>> GetServiceTicketCreateByIdAsync(int ServiceTickeId)
        {
            var ServiceTicket = await _ServiceTicketRepository.GetServiceTicketCreateByIdAsync(ServiceTickeId);
            var ServiceTicketModel = _mapper.Map<List<ServiceTicketDetailsModel>>(ServiceTicket?.ToList());
            return ServiceTicketModel;

        }


        public async Task<IList<ServiceTicketInfoDisplayModel>> GetAllServiceTicketInfoAsync(ServiceTicketInfoFilter serviceTicketInfoFilter)
        {
            var ServiceTicketInfo = await _ServiceTicketRepository.GetAllServiceTicketInfoAsync(serviceTicketInfoFilter);
            var ServiceTicketModel = _mapper.Map<List<ServiceTicketInfoDisplayModel>>(ServiceTicketInfo.ToList());
            return ServiceTicketModel;
        }

        public async Task<IList<SerialWiseServiceTicketInfoModel>> GetAllSerialWiseServiceTicketInfoAsync(SerialWiseServiceTicketInfoFilter serialWiseServiceTicketInfoFilter)
        {
            var SerialWiseServiceTicket = await _ServiceTicketRepository.GetAllSerialWiseServiceTicketInfoAsync(serialWiseServiceTicketInfoFilter);
            var SerialWiseServiceTicketModel = _mapper.Map<List<SerialWiseServiceTicketInfoModel>>(SerialWiseServiceTicket?.ToList());
            return SerialWiseServiceTicketModel;

        }


        public async Task<IList<SerialWiseServiceTicketInfoModel>> GetAllSerialWiseServiceTicketInfoFIRAsync(SerialWiseServiceTicketInfoFilter serialWiseServiceTicketInfoFilter)
        {
            var SerialWiseServiceTicket = await _ServiceTicketRepository.GetAllSerialWiseServiceTicketInfoFIRAsync(serialWiseServiceTicketInfoFilter);
            var SerialWiseServiceTicketModel = _mapper.Map<List<SerialWiseServiceTicketInfoModel>>(SerialWiseServiceTicket?.ToList());
            return SerialWiseServiceTicketModel;

        }


        public async Task<IList<SerialWiseServiceTicketInfoModel>> GetServiceTicketJobsheetIdAsync(int ServiceTickeId)
        {
            var SerialWiseServiceTicket = await _ServiceTicketRepository.GetServiceTicketJobsheetIdAsync(ServiceTickeId);
            var lstSerialWiseServiceTicket = _mapper.Map<List<SerialWiseServiceTicketInfoModel>>(SerialWiseServiceTicket?.ToList());

            List<SerialWiseServiceTicketInfoModel> JobSheetlist = new List<SerialWiseServiceTicketInfoModel>();
            SerialWiseServiceTicketInfoModel Objcr = null;
            foreach (var item in lstSerialWiseServiceTicket)
            {
                Objcr = new SerialWiseServiceTicketInfoModel();
                Objcr.ServiceTicketId = item.ServiceTicketId;
                Objcr.SerialNo = item.SerialNo;
                Objcr.ProductCode = item.ProductCode;
                Objcr.DivisionCode = item.DivisionCode;

                Objcr.DivisionName = item.DivisionName;
                Objcr.ProductGroupCode = item.ProductGroupCode;
                Objcr.ProductLineCode = item.ProductLineCode;
                Objcr.ProductLineName = item.ProductLineName;
                Objcr.FRAME = item.FRAME;
                Objcr.KW = item.KW;
                Objcr.POLE = item.POLE;
                Objcr.KVA = item.KVA;
                Objcr.EFFE = item.EFFE;
                Objcr.FLPS = item.FLPS;
                Objcr.HP = item.HP;
                Objcr.WarrantyDateStatus = item.WarrantyDateStatus;
                Objcr.InvoiceDateStatus = item.InvoiceDateStatus;
                Objcr.CustomerName = item.CustomerName;
                Objcr.PrimaryMobileNo = item.PrimaryMobileNo;
                Objcr.SiteAddress = item.SiteAddress;
                Objcr.ASCName = item.ASCName;
                Objcr.ASCMobileNo = item.ASCMobileNo;
                Objcr.ASMName = item.ASMName;
                Objcr.ASMMobileNo = item.ASMMobileNo;
                Objcr.DefectDesc = item.DefectDesc;
                Objcr.ServiceTicketNumber = item.ServiceTicketNumber;
                Objcr.TicketStateus = item.TicketStateus;
                Objcr.RequestDate = item.RequestDate;
                Objcr.TotalRows = item.TotalRows;
                Objcr.MsgCode = item.MsgCode;
                Objcr.msg = item.msg;
                Objcr.BatchStartDate = item.BatchStartDate;
                Objcr.BatchEndDate = item.BatchEndDate;
                Objcr.ProductGroupName = item.ProductGroupName;
                Objcr.BatchCode = item.BatchCode;
                Objcr.ProductDescription = item.ProductDescription;
                Objcr.InvoiceNo = item.InvoiceNo;
                Objcr.TicketGenerationDate = item.TicketGenerationDate;
                Objcr.InvoiceDate = item.InvoiceDate;
                Objcr.ASCAddress = item.ASCAddress;
                Objcr.TechnicianName = item.TechnicianName;
                Objcr.CustomerEmailId = item.CustomerEmailId;
                Objcr.CustomerContactDate = item.CustomerContactDate;
                Objcr.ClosureRemarks = item.ClosureRemarks;
                Objcr.NoOfHours = item.NoOfHours;
                Objcr.BranchAddress = item.BranchAddress;
                Objcr.PurchaseFrom = item.PurchaseFrom;
                Objcr.ReplacementTagApplied = item.ReplacementTagApplied;
                Objcr.NatureOfComplaint = item.NatureOfComplaint;
                Objcr.AscState = item.AscState;
                Objcr.DefectObserved = item.DefectObserved;
                Objcr.DateOfCommissioning = item.DateOfCommissioning;
                Objcr.ASCEmailId = item.ASCEmailId;

                var SpareDetail = await _ServiceTicketRepository.GetServiceTicketSpareAsync(ServiceTickeId);
                var lstSpareDetail = _mapper.Map<List<SpareDetailModel>>(SpareDetail?.ToList());

                List<SpareDetailModel> SpareDetaillist = new List<SpareDetailModel>();
                SpareDetailModel ObjCrd = null;

                if (lstSpareDetail != null)
                {
                    foreach (var itemlcrd in lstSpareDetail)
                    {
                        ObjCrd = new SpareDetailModel();
                        ObjCrd.Qty = itemlcrd.Qty;
                        ObjCrd.SpareCode = itemlcrd.SpareCode;
                        ObjCrd.SparePrice = itemlcrd.SparePrice;
                        ObjCrd.SpareDescription = itemlcrd.SpareDescription;
                        ObjCrd.SpareSerialNumber = itemlcrd.SpareSerialNumber;

                        SpareDetaillist.Add(ObjCrd);
                    }
                }


                Objcr.SpareDetails = SpareDetaillist;

                JobSheetlist.Add(Objcr);

            }



            return JobSheetlist;

        }

        public async Task<int?> UpdateAcknowledgmentServiceTicketAsync(int serviceTicketId, bool isAcknowledgment, string? StatusName, string? Remark, string UserId)
        {
            return await _ServiceTicketRepository.UpdateAcknowledgmentServiceTicketAsync(serviceTicketId, isAcknowledgment, StatusName, Remark, UserId);
        }

        public async Task<IList<ServiceTicketDetailsModel>> GetServiceTicketByIdAsync(int ServiceTickeId)
        {
            var ServiceTicket = await _ServiceTicketRepository.GetServiceTicketByIdAsync(ServiceTickeId);
            var ServiceTicketModel = _mapper.Map<List<ServiceTicketDetailsModel>>(ServiceTicket?.ToList());
            return ServiceTicketModel;

        }

        public async Task<int?> GetServiceRequestNoOfDays(string productCode)
        {
            return await _ServiceTicketRepository.GetServiceRequestNoOfDays(productCode);
        }

        public async Task<IList<SpareDetailModel>> GetServiceTicketSpareAsync(int ServiceTickeId)
        {
            var SpareDetail = await _ServiceTicketRepository.GetServiceTicketSpareAsync(ServiceTickeId);
            var lstSpareDetail = _mapper.Map<List<SpareDetailModel>>(SpareDetail?.ToList());

            return lstSpareDetail;

        }


        public async Task<int?> UpdateServiceTickeBusinessCall(string? serviceTicketId, string? businessCallId)
        {
            return await _ServiceTicketRepository.UpdateServiceTickeBusinessCall(serviceTicketId, businessCallId);
        }

        public async Task<int?> UpdateServiceTickeHappyCode(string? serviceTicketId, string? ServiceTicketNumber)
        {
            return await _ServiceTicketRepository.UpdateServiceTickeHappyCode(serviceTicketId, ServiceTicketNumber);
        }



        //public async Task<string?> ReplacementTagGet(string? ServiceTicketId, string? DivCode, string? ProductLineCode)
        //{
        //    return await _ServiceTicketRepository.ReplacementTagGet(ServiceTicketId, DivCode, ProductLineCode);
        //}


        public async Task<string> ReplacementTagGet(string? ServiceTicketId, string? DivCode, string? ProductLineCode)
        {
            return await _ServiceTicketRepository.ReplacementTagGet(ServiceTicketId, DivCode, ProductLineCode);
        }


    }


}
