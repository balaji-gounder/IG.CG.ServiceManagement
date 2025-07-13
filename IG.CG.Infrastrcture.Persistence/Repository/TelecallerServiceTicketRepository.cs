using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class TelecallerServiceTicketRepository : ITelecallerServiceTicketRepository
    {
        private readonly ISqlDbContext _prodCustInfoRepository;
        public TelecallerServiceTicketRepository(ISqlDbContext prodCustInfoRepository)
        {
            _prodCustInfoRepository = prodCustInfoRepository;
        }


        public async Task<ProductCustomerInfoDisplayEntity?> GetAllProdSerialNoAsync(string? SerialNo, string? ProductCode)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@SerialNo", SerialNo);
            sp_params.Add("@ProductCode", ProductCode);

            //sp_params.Add("@ProdRegAutoId", "");
            return await _prodCustInfoRepository.GetAsync<ProductCustomerInfoDisplayEntity>(ProdCustInfoQueries.GetTelecallerServiceTicket, sp_params);
        }


        public async Task<string?> UpsertProductTelecallerInfoAsync(ProductCustomerInfoEntity ProCustObj)
        {


            Random r = new Random();
            int TNo = 0;
            string ServiceTicketNumber = "";
            string ServiceTicketNo = "";

            var para1 = new DynamicParameters();
            ServiceTicketNo = await _prodCustInfoRepository.ExecuteScalarAsync<string?>(ProdCustInfoQueries.ServiceTicketNumberGet, para1);

            string RNOCREATE = "";

            string RNo = r.Next(5, 100000).ToString();

            var paraR = new DynamicParameters();
            paraR.Add("@RandomNo", RNo);
            RNOCREATE = await _prodCustInfoRepository.ExecuteScalarAsync<string?>(ProdCustInfoQueries.ServiceTicketRandomNumberGet, paraR);



            for (int i = 0; i < ProCustObj.noOfProducts; i++)
            {
                var para = new DynamicParameters();
                if (i == 0)
                {
                    ServiceTicketNumber = ServiceTicketNo;

                    para.Add("@SerialNo", ProCustObj.SerialNo);

                    para.Add("@ProductCode", ProCustObj.ProductCode);
                    para.Add("@PurchaseFrom", ProCustObj.PurchaseFrom);
                    para.Add("@InvoiceNo", ProCustObj.InvoiceNo);
                    para.Add("@BatchStartDate", ProCustObj.BatchStartDate);
                    para.Add("@BatchEndDate", ProCustObj.BatchEndDate);
                    para.Add("@InvoiceDate", ProCustObj.InvoiceDate);
                    para.Add("@InvoceFilePath", ProCustObj.InvoceFilePath);
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
                }
                else
                {
                    TNo = TNo + 1;

                    ServiceTicketNumber = ServiceTicketNo + "/" + TNo.ToString();

                    para.Add("@InvoiceNo", "");
                    para.Add("@BatchStartDate", "");
                    para.Add("@BatchEndDate", "");
                    para.Add("@InvoiceDate", "");
                    para.Add("@InvoceFilePath", "");
                    para.Add("@InWarranty", "");
                    para.Add("@ProductType", "");
                    para.Add("@FrameSize", "");
                    para.Add("@Voltage", "");
                    para.Add("@Pole", "");
                    para.Add("@Kva", "");
                    para.Add("@SAPWarrantyDate", "");
                    para.Add("@HP", "");
                    para.Add("@Efficiency", "");
                    para.Add("@Flp", "");
                    para.Add("@SerialNo", "");

                    para.Add("@ProductCode", "");
                    para.Add("@PurchaseFrom", "");
                }

                para.Add("@DivCode", ProCustObj.DivCode);
                para.Add("@ServiceTicketNumber", ServiceTicketNumber);
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

                //para.Add("@PurchaseDate", ProCustObj.PurchaseDate);

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
                para.Add("@RandomNo", RNOCREATE);
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
                para.Add("@Distance", ProCustObj.Distance);

                para.Add("@ServiceRequestTypeName", ProCustObj.ServiceRequestTypeName);
                para.Add("@ProductlineCode", ProCustObj.productLineName);
                para.Add("@Isreceived", ProCustObj.Isreceived);
                para.Add("@ManufacturingDate", ProCustObj.ManufacturingDate);
                para.Add("@DateOfDispatch", ProCustObj.DateOfDispatch);
                para.Add("@SourceTypeId", ProCustObj.SourceTypeId);
                para.Add("@FinalRemarks", ProCustObj.FinalRemarks);

                await _prodCustInfoRepository.ExecuteScalarAsync<string?>(ProdCustInfoQueries.UpsertTelecallerProductCustomerInsert, para);

            }


            return RNOCREATE;



        }






        public async Task<string?> UpsertProductCustomerInfoAsync(ProductCustomerInfoEntity ProCustObj)
        {

            Random r = new Random();
            string RNo = r.Next(5, 100000).ToString();



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
            //para.Add("@PurchaseDate", ProCustObj.PurchaseDate);
            para.Add("@InvoiceNo", ProCustObj.InvoiceNo);
            para.Add("@BatchStartDate", ProCustObj.BatchStartDate);
            para.Add("@BatchEndDate", ProCustObj.BatchEndDate);
            para.Add("@InvoiceDate", ProCustObj.InvoiceDate);
            para.Add("@InvoceFilePath", ProCustObj.InvoceFilePath);
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
            para.Add("@Distance", ProCustObj.Distance);

            para.Add("@ServiceRequestTypeName", ProCustObj.ServiceRequestTypeName);
            para.Add("@ProductlineCode", ProCustObj.productLineName);
            para.Add("@Isreceived", ProCustObj.Isreceived);
            para.Add("@ManufacturingDate", ProCustObj.ManufacturingDate);
            para.Add("@DateOfDispatch", ProCustObj.DateOfDispatch);
            para.Add("@SourceTypeId", ProCustObj.SourceTypeId);
            para.Add("@FinalRemarks", ProCustObj.FinalRemarks);


            return await _prodCustInfoRepository.ExecuteScalarAsync<string?>(ProdCustInfoQueries.UpsertTelecallerProductCustomerInsert, para);

        }


        public async Task<IList<ProdCustInfoDisplayEnitity>> GetAllProdCustInfoAsync(string? MobileNo)
        {
            var para = new DynamicParameters();
            para.Add("@MobileNo", MobileNo);
            var lstAsc = await _prodCustInfoRepository.GetAllAsync<ProdCustInfoDisplayEnitity>(ProdCustInfoQueries.AllProdCustInfoTelecaller, para);
            return lstAsc.ToList();
        }

        public async Task<ProdSerialNoWarrantySAPDisplayEntity> GetAllProdSerialNoWarrantyServiceTicketAsync(ProdSerialNoFilter PsrnoFilter)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@ProductSerialNo", PsrnoFilter.ProductSerialNo);
            sp_params.Add("@ProductCode", PsrnoFilter.ProductCode);
            sp_params.Add("@DivisionCode", PsrnoFilter.DivisionCode);


            var lstProSerNo = await _prodCustInfoRepository.GetAsync<ProdSerialNoWarrantySAPEntity>(ProdCustInfoQueries.AllCheckTelecallerServiceTicket, sp_params);

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
                Objpsw.ManufacturingDate = lstProSerNo.ManufacturingDate;
                Objpsw.DateOfDispatch = lstProSerNo.DateOfDispatch;

                ProdSerialNoWlist.Add(Objpsw);

            }

            Objsrno.ProdSerialNoWarrantyList = ProdSerialNoWlist;


            return Objsrno;
        }


        public async Task<ProdSerialNoWarrantySAPDisplayEntity> GetAllProdSerialNoWarrantyServiceTicketTelecallerAsync(ProdSerialNoTelecallerFilter PsrnoFilter)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@ProductSerialNo", PsrnoFilter.ProductSerialNo);
            sp_params.Add("@ProductCode", PsrnoFilter.ProductCode);
            sp_params.Add("@DivisionCode", PsrnoFilter.DivisionCode);
            sp_params.Add("@MobileNo", PsrnoFilter.MobileNo);
            sp_params.Add("@ProductLCode", PsrnoFilter.ProductLineCode);

            var lstProSerNo = await _prodCustInfoRepository.GetAsync<ProdSerialNoWarrantySAPEntity>(ProdCustInfoQueries.AllCheckTelecallerProdSerialNoWarrantyServiceTicket, sp_params);

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
    }
}
