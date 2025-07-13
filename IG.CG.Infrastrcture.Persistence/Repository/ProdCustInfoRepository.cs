using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;
using IG.CG.Core.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class ProdCustInfoRepository : IProdCustInfoRepository
    {
        private readonly ISqlDbContext _prodCustInfoRepository;
        private readonly ICommunication _CommunicationRepository;
        public ProdCustInfoRepository(ISqlDbContext prodCustInfoRepository, ICommunication communication)
        {
            _prodCustInfoRepository = prodCustInfoRepository;
            _CommunicationRepository = communication;
        }

        public async Task<string?> UpsertCustVerificationAsync(CustVerificationEntity CustVObj)
        {
            var para = new DynamicParameters();
            para.Add("@MobileNo", CustVObj.MobileNo);
            para.Add("@VerificationOTP", CustVObj.VerificationOTP);
            return await _prodCustInfoRepository.ExecuteScalarAsync<string?>(ProdCustInfoQueries.UpsertCustVerificationInsert, para);


        }

        public async Task<string?> UpsertSMSAsync(SMSDetailsEntity CustVObj)
        {
            var para = new DynamicParameters();
            para.Add("@MForm", CustVObj.MForm);
            para.Add("@MTo", CustVObj.MTo);
            para.Add("@Mess", CustVObj.Mess);
            para.Add("@Remarks", CustVObj.Remarks);
            para.Add("@REQID", CustVObj.REQID);
            para.Add("@SUBMITDATE", CustVObj.SUBMITDATE);
            para.Add("@TID", CustVObj.TID);
            return await _prodCustInfoRepository.ExecuteScalarAsync<string?>(ProdCustInfoQueries.UpsertCustSMSOTPInsert, para);

        }
        public async Task<IList<ProdCustInfoDisplayEnitity>> GetAllProdCustInfoAsync(ProdCustInfoFilter PciFilter)
        {

            var para = new DynamicParameters();
            para.Add("@MobileNo", PciFilter.MobileNo);
            para.Add("@VerificationOTP", PciFilter.VerificationOTP);
            para.Add("@Mode", PciFilter.Mode);
            var lstAsc = await _prodCustInfoRepository.GetAllAsync<ProdCustInfoDisplayEnitity>(ProdCustInfoQueries.AllProdCustInfo, para);
            return lstAsc.ToList();
        }
        public async Task<ProdSerialNoWarrantySAPDisplayEntity> GetAllProdSerialNoWarrantyAsync(ProdSerialNoFilter PsrnoFilter)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@ProductSerialNo", PsrnoFilter.ProductSerialNo);
            sp_params.Add("@ProductCode", PsrnoFilter.ProductCode);
            sp_params.Add("@DivisionCode", PsrnoFilter.DivisionCode);
            sp_params.Add("@ProductLineCode", PsrnoFilter.ProductLineCode);
            var lstProSerNo = await _prodCustInfoRepository.GetAsync<ProdSerialNoWarrantySAPEntity>(ProdCustInfoQueries.AllCheckProdSerialNoWarranty, sp_params);

            ProdSerialNoWarrantySAPDisplayEntity Objsrno = null;

            Objsrno = new ProdSerialNoWarrantySAPDisplayEntity();
            Objsrno.msg = lstProSerNo.msg;
            Objsrno.MsgCode = lstProSerNo.MsgCode;

            List<ProdSerialNoWarrantySAPEntity> ProdSerialNoWlist = new List<ProdSerialNoWarrantySAPEntity>();
            ProdSerialNoWarrantySAPEntity Objpsw = null;
            if (lstProSerNo != null)
            {
                Objpsw = new ProdSerialNoWarrantySAPEntity();
                Objpsw.SERNR = lstProSerNo.SERNR;
                Objpsw.MATNR = lstProSerNo.MATNR;
                Objpsw.DivisionCode = lstProSerNo.DivisionCode;
                Objpsw.ProductGroupCode = lstProSerNo.ProductGroupCode;
                Objpsw.ProductLineCode = lstProSerNo.ProductLineCode;
                Objpsw.DealerInvNo = lstProSerNo.DealerInvNo;
                Objpsw.Batch = lstProSerNo.Batch;
                Objpsw.DealerInvDate = lstProSerNo.DealerInvDate;
                Objpsw.WarrantyStartBatchDate = lstProSerNo.WarrantyStartBatchDate;
                Objpsw.WarrantyFromBatch = lstProSerNo.WarrantyFromBatch;
                Objpsw.WarrantyFromDOI = lstProSerNo.WarrantyFromDOI;
                Objpsw.WarrantyEndBatch = lstProSerNo.WarrantyEndBatch;
                Objpsw.WarrantyStatus = lstProSerNo.WarrantyStatus;
                Objpsw.FRAME = lstProSerNo.FRAME;
                Objpsw.KW = lstProSerNo.KW;
                Objpsw.POLE = lstProSerNo.POLE;
                Objpsw.KVA = lstProSerNo.KVA;
                Objpsw.EFFE = lstProSerNo.EFFE;
                Objpsw.FLPS = lstProSerNo.FLPS;
                Objpsw.ProductLineName = lstProSerNo.ProductLineName;
                ProdSerialNoWlist.Add(Objpsw);

            }

            Objsrno.ProdSerialNoWarrantyList = ProdSerialNoWlist;


            return Objsrno;
        }

        public async Task<ProdSerialNoWarrantySAPDisplayEntity> GetAllProdSerialNoWarrantyServiceTicketAsync(ProdSerialNoFilter PsrnoFilter)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@ProductSerialNo", PsrnoFilter.ProductSerialNo);
            sp_params.Add("@ProductCode", PsrnoFilter.ProductCode);
            sp_params.Add("@DivisionCode", PsrnoFilter.DivisionCode);
            sp_params.Add("@ProductLineCode", PsrnoFilter.ProductLineCode);

            var lstProSerNo = await _prodCustInfoRepository.GetAsync<ProdSerialNoWarrantySAPEntity>(ProdCustInfoQueries.AllCheckProdSerialNoWarrantyServiceTicket, sp_params);

            ProdSerialNoWarrantySAPDisplayEntity Objsrno = null;

            Objsrno = new ProdSerialNoWarrantySAPDisplayEntity();
            Objsrno.msg = lstProSerNo.msg;
            Objsrno.MsgCode = lstProSerNo.MsgCode;

            List<ProdSerialNoWarrantySAPEntity> ProdSerialNoWlist = new List<ProdSerialNoWarrantySAPEntity>();
            ProdSerialNoWarrantySAPEntity Objpsw = null;
            if (lstProSerNo != null)
            {
                Objpsw = new ProdSerialNoWarrantySAPEntity();
                Objpsw.SERNR = lstProSerNo.SERNR;
                Objpsw.MATNR = lstProSerNo.MATNR;
                Objpsw.DivisionCode = lstProSerNo.DivisionCode;
                Objpsw.ProductGroupCode = lstProSerNo.ProductGroupCode;
                Objpsw.ProductLineCode = lstProSerNo.ProductLineCode;
                Objpsw.DealerInvNo = lstProSerNo.DealerInvNo;
                Objpsw.Batch = lstProSerNo.Batch;
                Objpsw.DealerInvDate = lstProSerNo.DealerInvDate;
                Objpsw.WarrantyStartBatchDate = lstProSerNo.WarrantyStartBatchDate;
                Objpsw.WarrantyFromBatch = lstProSerNo.WarrantyFromBatch;
                Objpsw.WarrantyFromDOI = lstProSerNo.WarrantyFromDOI;
                Objpsw.WarrantyEndBatch = lstProSerNo.WarrantyEndBatch;
                Objpsw.WarrantyStatus = lstProSerNo.WarrantyStatus;
                Objpsw.FRAME = lstProSerNo.FRAME;
                Objpsw.KW = lstProSerNo.KW;
                Objpsw.POLE = lstProSerNo.POLE;
                Objpsw.KVA = lstProSerNo.KVA;
                Objpsw.EFFE = lstProSerNo.EFFE;
                Objpsw.FLPS = lstProSerNo.FLPS;
                Objpsw.HP = lstProSerNo.HP;
                Objpsw.ProductLineName = lstProSerNo.ProductLineName;
                Objpsw.ManufacturingDate = lstProSerNo.ManufacturingDate;
                Objpsw.DateOfDispatch = lstProSerNo.DateOfDispatch;
                ProdSerialNoWlist.Add(Objpsw);

            }

            Objsrno.ProdSerialNoWarrantyList = ProdSerialNoWlist;


            return Objsrno;
        }

        public async Task<string?> UpsertProductCustomerInfoAsync(ProductCustomerInfoEntity ProCustObj)
        {

            Random r = new Random();
            string RNo = r.Next(5, 100000).ToString();




            List<IFormFile>? InvoiceFile = ProCustObj.InvoceFilePath;
            DocumentTypes documentType = DocumentTypes.InvoiceDocument;
            bool ifSuccess;
            string dbPath = "";
            if (InvoiceFile.Count > 0)
            {
                List<Tuple<bool, string>> result = await _CommunicationRepository.UploadDocument(InvoiceFile, documentType);
                foreach (var item in result)
                {
                    ifSuccess = item.Item1;
                    if (ifSuccess == true)
                    {
                        dbPath = item.Item2;

                    }

                }
            }


            var para = new DynamicParameters();
            para.Add("@ProdRegAutoId", ProCustObj.ProdRegAutoId);
            para.Add("@CustVerificationId", ProCustObj.CustVerificationId);
            para.Add("@CustomerName", ProCustObj.CustomerName);
            para.Add("@ContactPerson", ProCustObj.ContactPerson);
            para.Add("@PrimaryMobileNo", ProCustObj.PrimaryMobileNo);
            para.Add("@EmailId", ProCustObj.EmailId);
            para.Add("@CustAddess", ProCustObj.CustAddess);
            para.Add("@AltContactNo", ProCustObj.AltContactNo);
            para.Add("@AltEmailId", ProCustObj.AltEmailId);
            para.Add("@SiteAddress", ProCustObj.SiteAddress);
            para.Add("@PinId", ProCustObj.PinId);
            para.Add("@CityId", ProCustObj.CityId);
            para.Add("@StateId", ProCustObj.StateId);
            para.Add("@NameOfSpoc", ProCustObj.NameOfSpoc);
            para.Add("@SpocMobileNo", ProCustObj.SpocMobileNo);
            para.Add("@SpocEmailId", ProCustObj.SpocEmailId);
            para.Add("@Address1", ProCustObj.Address1);
            para.Add("@Address2", ProCustObj.Address2);
            para.Add("@ProdInstallationPinId", ProCustObj.ProdInstallationPinId);
            para.Add("@ProdInstallationCityId", ProCustObj.ProdInstallationCityId);
            para.Add("@ProdInstallationStateId", ProCustObj.ProdInstallationStateId);
            para.Add("@SerialNo", ProCustObj.SerialNo);
            para.Add("@DivCode", ProCustObj.DivCode);
            para.Add("@ProductCode", ProCustObj.ProductCode);
            para.Add("@PurchaseFrom", ProCustObj.PurchaseFrom);
            para.Add("@ProductLineCode", ProCustObj.ProductLineCode);
            para.Add("@InvoiceNo", ProCustObj.InvoiceNo);
            para.Add("@BatchStartDate", ProCustObj.BatchStartDate);
            para.Add("@BatchEndDate", ProCustObj.BatchEndDate);
            para.Add("@InvoiceDate", ProCustObj.InvoiceDate);
            para.Add("@InvoceFilePath", dbPath);
            para.Add("@InWarranty", ProCustObj.InWarranty);
            para.Add("@ProductType", ProCustObj.ProductType);
            para.Add("@FrameSize", ProCustObj.FrameSize);
            para.Add("@Voltage", ProCustObj.Voltage);
            para.Add("@Pole", ProCustObj.Pole);
            para.Add("@Kva", ProCustObj.Kva);
            para.Add("@SAPWarrantyDate", ProCustObj.SAPWarrantyDate);
            para.Add("@HP", ProCustObj.HP);
            para.Add("@Efficiency", ProCustObj.Efficiency);
            para.Add("@Flp", ProCustObj.Flp);
            para.Add("@IsDeviation", ProCustObj.IsDeviation);
            para.Add("@IsActive", ProCustObj.IsActive);
            para.Add("@UserId", ProCustObj.UserId);
            para.Add("@Remarks", ProCustObj.Remarks);
            para.Add("@DefectId", ProCustObj.DefectId);
            para.Add("@RedirectingFrom", ProCustObj.RedirectingFrom);

            para.Add("@NearestPinCode", ProCustObj.NearestPinCode);
            para.Add("@NearestAsmUserCode", ProCustObj.NearestAsmUserCode);
            para.Add("@NearestAscUserCode", ProCustObj.NearestAscUserCode);
            para.Add("@UserCode", ProCustObj.UserCode);
            para.Add("@RandomNo", RNo);
            para.Add("@TicketCreateName", ProCustObj.TicketCreateName);
            para.Add("@TicketCreateNumber", ProCustObj.TicketCreateNumber);
            para.Add("@DealerCode", ProCustObj.DealerCode);
            para.Add("@RetailerCode", ProCustObj.RetailerCode);
            para.Add("@UserType", ProCustObj.UserType);

            para.Add("@SourceId", ProCustObj.SourceId);
            para.Add("@CallModeId", ProCustObj.CallModeId);
            para.Add("@IsPriority", ProCustObj.IsPriority);
            para.Add("@ProductGroup", ProCustObj.ProductGroup);
            para.Add("@ComplaintType", ProCustObj.ComplaintType);
            para.Add("@RequestType", ProCustObj.RequestType);
            para.Add("@OEMCode", ProCustObj.OEMCode);
            //para.Add("@ProductlineCode", "");
            para.Add("@Distance", ProCustObj.Distance);
            para.Add("@SourceTypeId", ProCustObj.SourceTypeId);

            return await _prodCustInfoRepository.ExecuteScalarAsync<string?>(ProdCustInfoQueries.UpsertProductCustomerInsert, para);

        }



        public async Task<string?> UpsertProductCustomerASMInfoAsync(ProductCustomerAMSInfoEntity ProCustObj)
        {

            Random r = new Random();
            string RNo = r.Next(5, 100000).ToString();

            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", ProCustObj.ServiceTicketId);
            para.Add("@MobileNo", ProCustObj.MobileNo);
            para.Add("@EmailId", ProCustObj.EmailId);
            para.Add("@Address", ProCustObj.Address);
            para.Add("@PinCode", ProCustObj.PinCode);
            para.Add("@CityId", ProCustObj.CityId);
            para.Add("@StateId", ProCustObj.StateId);
            para.Add("@SerialNo", ProCustObj.SerialNo);
            para.Add("@DivCode", ProCustObj.DivCode);
            para.Add("@ProductlineCode", ProCustObj.ProductlineCode);
            para.Add("@ProductCode", ProCustObj.ProductCode);
            para.Add("@InvoiceDate", ProCustObj.InvoiceDate);
            para.Add("@InvoiceNo", ProCustObj.InvoiceNo);
            para.Add("@Frame", ProCustObj.Frame);
            para.Add("@HP", ProCustObj.HP);
            para.Add("@Kva", ProCustObj.Kva);
            para.Add("@RandomNo", ProCustObj.RandomNo);
            para.Add("@UserType", ProCustObj.UserType);
            para.Add("@typeOfCustomerId", ProCustObj.typeOfCustomerId);
            para.Add("@CallTypeId", ProCustObj.CallTypeId);
            para.Add("@DefectId", ProCustObj.DefectId);
            para.Add("@DealerCode", ProCustObj.DealerCode);
            para.Add("@NearestAscUserCode", ProCustObj.NearestAscUserCode);
            para.Add("@Distance", ProCustObj.Distance);
            para.Add("@NearestPinCode", ProCustObj.NearestPinCode);
            return await _prodCustInfoRepository.ExecuteScalarAsync<string?>(ProdCustInfoQueries.UpsertProductASMCustomerInsert, para);

        }


        public async Task<string?> UpsertProductActivityAsync(ProductUpdateActivityEntity ProCustObj, string? InvoiceFile, string FIRCopy)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", ProCustObj.ServiceTicketId);
            para.Add("@SerialNo", ProCustObj.SerialNo);
            para.Add("@DivCode", ProCustObj.DivCode);
            para.Add("@ProductlineCode", ProCustObj.ProductlineCode);
            para.Add("@ProductCode", ProCustObj.ProductCode);
            para.Add("@InvoiceDate", ProCustObj.InvoiceDate);
            para.Add("@InvoiceNo", ProCustObj.InvoiceNo);
            para.Add("@Frame", ProCustObj.Frame);
            para.Add("@HP", ProCustObj.HP);
            para.Add("@Kva", ProCustObj.Kva);
            para.Add("@CallTypeId", ProCustObj.CallTypeId);
            para.Add("@DefectId", ProCustObj.DefectId);
            para.Add("@UserType", ProCustObj.UserType);
            para.Add("@DealerCode", ProCustObj.DealerCode);
            para.Add("@InvoiceFile", InvoiceFile);
            para.Add("@FIRCopy", FIRCopy);
            return await _prodCustInfoRepository.ExecuteScalarAsync<string?>(ProdCustInfoQueries.UpsertServiceTicketActivityProductInsert, para);

        }






        public async Task<ProdCustInfoDisplayEnitity?> GetProdCustInfoByIdAsync(int prodRegAutoId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@ProdRegAutoId", prodRegAutoId);
            return await _prodCustInfoRepository.GetAsync<ProdCustInfoDisplayEnitity>(ProdCustInfoQueries.GetProdCustInfoId, sp_params);
        }

        public async Task<string?> UpsertProdCustInfoAsync(ProdCustInfoDisplayEnitity CustVObj)
        {
            var para = new DynamicParameters();
            para.Add("@CustomerName", CustVObj.CustomerName);
            para.Add("@SiteAddress", CustVObj.SiteAddress);
            para.Add("@PrimaryMobileNo", CustVObj.PrimaryMobileNo);
            para.Add("@PinId", CustVObj.PinCode);
            para.Add("@CityId", CustVObj.CityId);
            para.Add("@StateId", CustVObj.StateId);
            para.Add("@ProdRegAutoId", CustVObj.ProdRegAutoId);
            return await _prodCustInfoRepository.ExecuteScalarAsync<string?>(ProdCustInfoQueries.UpdateProdCustInfo, para);

        }


        public async Task<ProductCustomerInfoDisplayEntity?> GetProductCustomerDeviationInfoByIdAsync(int prodRegAutoId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@ProdRegAutoId", prodRegAutoId);
            return await _prodCustInfoRepository.GetAsync<ProductCustomerInfoDisplayEntity>(ProdCustInfoQueries.GetProductCustomerDeviationInfoId, sp_params);
        }

        public async Task<IList<ProdCustInfoDisplayEnitity>> GetAllProductDeviationAsync(ProductDeviationFilter PciFilter)
        {
            var para = new DynamicParameters();
            para.Add("@SerialNo", PciFilter.SerialNo);
            para.Add("@ProductCode", PciFilter.ProductCode);
            para.Add("@CustomerMobile", PciFilter.CustomerMobile);
            para.Add("@FromDate", PciFilter.FromDate);
            para.Add("@ToDate", PciFilter.ToDate);
            para.Add("@ExtendedWarranty", PciFilter.ToDate);
            para.Add("@PageSize", PciFilter.PageSize);
            para.Add("@PageNumber", PciFilter.PageNumber);

            var lstAsc = await _prodCustInfoRepository.GetAllAsync<ProdCustInfoDisplayEnitity>(ProdCustInfoQueries.AllProdDeviation, para);
            return lstAsc.ToList();


        }

        public async Task<IList<ProdCustInfoDisplayEnitity>> GetAllProductCustomerDetailsAsync(ProductDeviationFilter PciFilter)
        {
            var para = new DynamicParameters();
            para.Add("@SerialNo", PciFilter.SerialNo);
            para.Add("@ProductCode", PciFilter.ProductCode);
            para.Add("@DivisionCode", PciFilter.DivisionCode);
            para.Add("@CustomerMobile", PciFilter.CustomerMobile);
            para.Add("@FromDate", PciFilter.FromDate);
            para.Add("@ToDate", PciFilter.ToDate);
            para.Add("@ExtendedWarranty", PciFilter.ToDate);
            para.Add("@PageSize", PciFilter.PageSize);
            para.Add("@PageNumber", PciFilter.PageNumber);

            var lstAsc = await _prodCustInfoRepository.GetAllAsync<ProdCustInfoDisplayEnitity>(ProdCustInfoQueries.AllProdCustomerDetails, para);
            return lstAsc.ToList();

        }

        public async Task<IList<ProductCustomerInfoDisplayEntity>> GetAllProductCustomeAdminAsync(ProductCustomeAdminFilter PciFilter)
        {
            var para = new DynamicParameters();
            para.Add("@SerialNo", PciFilter.SerialNo);
            para.Add("@ProductCode", PciFilter.ProductCode);
            para.Add("@MobileNo", PciFilter.CustomerMobile);
            para.Add("@FromDate", PciFilter.FromDate);
            para.Add("@ToDate", PciFilter.ToDate);
            para.Add("@Division", PciFilter.Division);
            para.Add("@PageSize", PciFilter.PageSize);
            para.Add("@PageNumber", PciFilter.PageNumber);

            var lstAsc = await _prodCustInfoRepository.GetAllAsync<ProductCustomerInfoDisplayEntity>(ProdCustInfoQueries.AllProductCustomerInfoAdmin, para);
            return lstAsc.ToList();

        }

        public async Task<string?> UpsertProdDeviationAsync(ProdDeviationEntity ProdDevObj)
        {


            var para = new DynamicParameters();
            para.Add("@ProdDevAutoId", ProdDevObj.ProdDevAutoId);
            para.Add("@TicketAutoId", ProdDevObj.TicketAutoId);
            para.Add("@BatchDate", Convert.ToDateTime(ProdDevObj.BatchDate).ToString("MM-dd-yyyy"));
            para.Add("@BatchEndDate", Convert.ToDateTime(ProdDevObj.BatchEndDate).ToString("MM-dd-yyyy"));
            para.Add("@InvoiceDate", Convert.ToDateTime(ProdDevObj.InvoiceDate).ToString("MM-dd-yyyy"));
            para.Add("@WarrantyDate", Convert.ToDateTime(ProdDevObj.WarrantyDate).ToString("MM-dd-yyyy"));
            if (ProdDevObj.ProdDeviationDate != "")
            {
                para.Add("@WarrantyToBeExtended", "YES");
                para.Add("@ProdDeviationDate", Convert.ToDateTime(ProdDevObj.ProdDeviationDate).ToString("MM-dd-yyyy"));
            }
            else
            {
                para.Add("@WarrantyToBeExtended", "NO");

            }

            para.Add("@Remarks", ProdDevObj.Remarks);
            para.Add("@UserId", ProdDevObj.UserId);

            return await _prodCustInfoRepository.ExecuteScalarAsync<string?>(ProdCustInfoQueries.UpsertProdDeviationInfoIn, para);

        }

        public async Task<string?> AddProductCustomerInfoDealer(ProductCustomerInfoDealerEntity objCutProdeal, string? userId, ProductDealerEntity ProdDeal, string RandomNo, string ServiceTicketNumber)
        {



            var para = new DynamicParameters();
            para.Add("@ProdRegAutoId", objCutProdeal.ProdRegAutoId);
            para.Add("@CustVerificationId", objCutProdeal.CustVerificationId);
            para.Add("@CustomerName", objCutProdeal.CustomerName);
            para.Add("@ContactPerson", objCutProdeal.ContactPerson);
            para.Add("@PrimaryMobileNo", objCutProdeal.PrimaryMobileNo);
            para.Add("@EmailId", objCutProdeal.EmailId);
            para.Add("@CustAddess", objCutProdeal.CustAddess);
            para.Add("@AltContactNo", objCutProdeal.AltContactNo);
            para.Add("@AltEmailId", objCutProdeal.AltEmailId);
            para.Add("@SiteAddress", objCutProdeal.SiteAddress);
            para.Add("@PinId", objCutProdeal.PinId);
            para.Add("@CityId", objCutProdeal.CityId);
            para.Add("@StateId", objCutProdeal.StateId);
            para.Add("@NameOfSpoc", ProdDeal.NameOfSpoc);
            para.Add("@SpocMobileNo", ProdDeal.SpocMobileNo);
            para.Add("@SpocEmailId", ProdDeal.SpocEmailId);
            para.Add("@Address1", ProdDeal.Address1);
            para.Add("@Address2", ProdDeal.Address2);
            para.Add("@ProdInstallationPinId", ProdDeal.ProdInstallationPinId);
            para.Add("@ProdInstallationCityId", ProdDeal.ProdInstallationCityId);
            para.Add("@ProdInstallationStateId", ProdDeal.ProdInstallationStateId);
            para.Add("@SerialNo", ProdDeal.SerialNo);
            para.Add("@DivCode", ProdDeal.DivCode);
            para.Add("@ProductCode", ProdDeal.ProductCode);
            para.Add("@PurchaseFrom", ProdDeal.PurchaseFrom);
            //para.Add("@PurchaseDate", ProCustObj.PurchaseDate);
            para.Add("@InvoiceNo", ProdDeal.InvoiceNo);
            para.Add("@BatchStartDate", ProdDeal.BatchStartDate);
            para.Add("@BatchEndDate", ProdDeal.BatchEndDate);
            para.Add("@InvoiceDate", ProdDeal.InvoiceDate);
            para.Add("@InvoceFilePath", "");
            para.Add("@InWarranty", ProdDeal.InWarranty);
            para.Add("@ProductType", ProdDeal.ProductType);
            para.Add("@FrameSize", ProdDeal.FrameSize);
            para.Add("@Voltage", ProdDeal.Voltage);
            para.Add("@Pole", ProdDeal.Pole);
            para.Add("@Kva", ProdDeal.Kva);
            para.Add("@SAPWarrantyDate", ProdDeal.SAPWarrantyDate);
            para.Add("@HP", ProdDeal.HP);
            para.Add("@Efficiency", ProdDeal.Efficiency);
            para.Add("@Flp", ProdDeal.Flp);
            para.Add("@IsDeviation", ProdDeal.IsDeviation);
            para.Add("@IsActive", objCutProdeal.IsActive);
            para.Add("@UserId", " ");
            para.Add("@Remarks", ProdDeal.Remarks);
            para.Add("@DefectId", ProdDeal.DefectId);
            para.Add("@RedirectingFrom", objCutProdeal.RedirectingFrom);
            para.Add("@NearestPinCode", ProdDeal.NearestPinCode);
            para.Add("@NearestAsmUserCode", ProdDeal.NearestAsmUserCode);
            para.Add("@NearestAscUserCode", ProdDeal.NearestAscUserCode);
            para.Add("@UserCode", objCutProdeal.UserCode);
            para.Add("@RandomNo", RandomNo);
            para.Add("@TicketCreateName", objCutProdeal.TicketCreateName);
            para.Add("@TicketCreateNumber", objCutProdeal.TicketCreateNumber);
            para.Add("@DealerCode", objCutProdeal.DealerCode);
            para.Add("@RetailerCode", objCutProdeal.RetailerCode);
            para.Add("@UserType", objCutProdeal.UserType);
            para.Add("@SourceId", objCutProdeal.SourceId);
            para.Add("@CallModeId", objCutProdeal.CallModeId);
            para.Add("@IsPriority", objCutProdeal.IsPriority);
            para.Add("@ProductGroup", ProdDeal.ProductGroup);
            para.Add("@ComplaintType", ProdDeal.ComplaintType);
            para.Add("@RequestType", ProdDeal.RequestType);
            para.Add("@OEMCode", objCutProdeal.OEMCode);
            para.Add("@ServiceTicketNo", ServiceTicketNumber);
            para.Add("@Distance", ProdDeal.Distance);
            para.Add("@ManufacturingDate", ProdDeal.ManufacturingDate);
            para.Add("@DateOfDispatch", ProdDeal.DateOfDispatch);
            para.Add("@ProductLineCode", ProdDeal.ProductLineCode);
            para.Add("@ParentId", ProdDeal.ParentId);
            para.Add("@TotalMultipleTicket", ProdDeal.TotalMultipleTicket);
            para.Add("@SourceTypeId", ProdDeal.SourceTypeId);

            return await _prodCustInfoRepository.ExecuteScalarAsync<string?>(ProdCustInfoQueries.UpsertProductDealerInsertUpdate, para);



        }


        public async Task<string?> ServiceTicketNoGetAsync()
        {
            var para = new DynamicParameters();
            return await _prodCustInfoRepository.ExecuteScalarAsync<string?>(ProdCustInfoQueries.ServiceTicketNumberGet, para);

        }

        public async Task<string?> AddAscTicketCreateInfo(AddAscTicketCreateEntity objCutProdeal, string? userId, string ServiceTicketNumber)
        {
            var para = new DynamicParameters();
            para.Add("@serviceTicketId", objCutProdeal.serviceTicketId);
            para.Add("@serialNo", objCutProdeal.serialNo);
            para.Add("@productCode", objCutProdeal.productCode);
            para.Add("@divisionCode", objCutProdeal.divisionCode);
            para.Add("@productLineCode", objCutProdeal.productLineCode);
            para.Add("@pInvoiceNo", objCutProdeal.pInvoiceNo);
            para.Add("@pInvoiceDate", objCutProdeal.pInvoiceDate);
            para.Add("@userId", userId);
            para.Add("@ServiceTicketNumber", ServiceTicketNumber);
            para.Add("@TotalMultipleTicket", objCutProdeal.TotalMultipleTicket);
            return await _prodCustInfoRepository.ExecuteScalarAsync<string?>(ProdCustInfoQueries.UpsertAscTicketCreateInsertUpdate, para);
        }



    }
}
