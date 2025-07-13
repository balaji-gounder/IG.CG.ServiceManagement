using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Auth;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Specification;
using IG.CG.Infrastrcture.Persistence;
using IG.CG.Infrastrcture.Persistence.Repository;

namespace IG.CG.ServiceManagement.WebApi.Extensions
{
    internal static class DependencyRegistry
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddSingleton<IAscService, AscService>();
            services.AddSingleton<IASCRepository, AscRepository>();
            services.AddSingleton<IRoleService, RoleService>();
            services.AddSingleton<IRoleRepository, RoleRepository>();
            services.AddSingleton<IRegionService, RegionService>();
            services.AddSingleton<IRegionRepository, RegionRepository>();
            services.AddSingleton<IBranchService, BranchService>();
            services.AddSingleton<IBranchRepository, BranchRepository>();
            services.AddSingleton<IDivisionService, DivisionService>();
            services.AddSingleton<IDivisionRepository, DivisionRepository>();
            services.AddSingleton<IProductLineService, ProductLineService>();
            services.AddSingleton<IProductLineRepository, ProductLineRepository>();
            services.AddSingleton<IProductGroupService, ProductGroupService>();
            services.AddSingleton<IProductGroupRepository, ProductGroupRepository>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IProductDeviationService, ProductDeviationService>();
            services.AddSingleton<IProductDeviationRepository, ProductDeviationRepository>();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IDefectService, DefectService>();
            services.AddSingleton<IDefectRepository, DefectRepository>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ITechnicianService, TechnicianService>();
            services.AddSingleton<ITechnicianRepository, TechnicianRepository>();
            services.AddSingleton<IDefectCategoryService, DefectCategoryService>();
            services.AddSingleton<IDefectCategoryRepository, DefectCategoryRepository>();
            services.AddSingleton<IJwtAuthManager, JwtAuthManager>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<ILoginRepository, LoginRepositoy>();
            services.AddSingleton<ILoginService, LoginService>();
            services.AddSingleton<ISqlDbContext, SqlDbContext>();
            services.AddSingleton<IParaValRepository, ParaValRepository>();
            services.AddSingleton<IParaValService, ParaValService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IDealerService, DealerService>();
            services.AddSingleton<IDealerRepository, DealerRepository>();
            services.AddSingleton<ICustomerAssestRepository, CustomerAssestRepository>();
            services.AddSingleton<ICustomerAssetsServices, CustomerAssestService>();

            services.AddSingleton<IUserGetByUserTypeRepository, UserGetByUserTypeRepository>();
            services.AddSingleton<IUserGetByUserTypeService, UserGetByUserTypeService>();
            services.AddSingleton<ICommonRepository, CommonRepository>();
            services.AddSingleton<ICommonService, CommonService>();
            services.AddSingleton<IRoleWiseMenuService, RoleWiseMenuService>();
            services.AddSingleton<IRoleWiseMenuRepository, RoleWiseMenuRepository>();


            services.AddSingleton<IDealerSAPService, DealerSAPService>();
            services.AddSingleton<IDealerSAPRepository, DealerSAPRepository>();

            services.AddSingleton<ISAPService, SAPService>();
            services.AddSingleton<ISAPRepository, SAPRepository>();

            //vendor
            services.AddSingleton<IVendorService, VendorService>();
            services.AddSingleton<IVendorRepository, VendorRepository>();

            // Lead
            services.AddSingleton<ILeadService, LeadService>();
            services.AddSingleton<ILeadRepository, LeadRepository>();

            services.AddSingleton<ILeadsFollowupListService, LeadFollowupService>();
            services.AddSingleton<ILeadsFollowupListRepository, LeadFollowupRepository>();


            services.AddSingleton<ITemplateMailAndSmsService, TemplateMailAndSmsService>();
            services.AddSingleton<ITemplateMailAndSmsRepository, TemplateMailAndSmsRepository>();

            //------------------------
            services.AddSingleton<IUAddRightsRepository, UAddRightsRepository>();
            services.AddSingleton<IAddRightsService, AddRightsService>();

            services.AddSingleton<IASCWisePinCodeService, ASCWisePinCodeService>();
            services.AddSingleton<IASCWisePinCodeRepository, ASCWisePinCodeRepository>();


            services.AddSingleton<IClaimRateService, ClaimRateService>();
            services.AddSingleton<IClaimRateRepository, ClaimRateRepository>();

            //-------------------------------------------------------------------- 

            services.AddSingleton<IProdCustInfoService, ProdCustInfoService>();
            services.AddSingleton<IProdCustInfoRepository, ProdCustInfoRepository>();


            services.AddSingleton<ICityPincodeMappingService, CityPincodeMappingService>();
            services.AddSingleton<ICityPincodeMappingRepository, CityPincodeMappingRepository>();

            services.AddSingleton<IServiceTicketService, ServiceTicketService>();
            services.AddSingleton<IServiceTicketRepository, ServiceTicketRepository>();

            services.AddSingleton<ICommunication, CommunicationService>();

            services.AddSingleton<IPincodeMappingUserService, PincodeMappingUserService>();
            services.AddSingleton<IPincodeMappingUserRepository, PincodeMappingUserRepository>();

            services.AddSingleton<ICommunication, CommunicationService>();

            services.AddSingleton<ITelecallerServiceTicketService, TelecallerServiceTicketService>();
            services.AddSingleton<ITelecallerServiceTicketRepository, TelecallerServiceTicketRepository>();

            services.AddSingleton<ISTStatusService, STStatusService>();
            services.AddSingleton<ISTStatusRepository, STStatusRepository>();

            services.AddSingleton<ISTSubStatusService, STSubStatusService>();
            services.AddSingleton<ISTSubStatusRepository, STSubStatusRepository>();

            services.AddSingleton<IActivityService, ActivityService>();
            services.AddSingleton<IActivityRepository, ActivityRepository>();

            services.AddSingleton<IRewindingServicesService, RewindingServicesService>();
            services.AddSingleton<IRewindingServicesRepository, RewindingServicesRepository>();

            services.AddSingleton<IASCServiceRequestService, ASCServiceRequestService>();
            services.AddSingleton<IASCServiceRequestRepository, ASCServiceRequestRepository>();

            services.AddSingleton<IAscServiceTicketCustomerService, AscServiceTicketCustomerService>();
            services.AddSingleton<IAscServiceTicketCustomerRepository, AscServiceTicketCustomerRepository>();

            services.AddSingleton<IIssueService, IssueService>();
            services.AddSingleton<IIssueRepository, IssueRepository>();

            services.AddSingleton<ITrackServiceTicketService, TrackServiceTicketService>();
            services.AddSingleton<ITrackServiceTicketRepository, TrackServiceTicketRepository>();

            services.AddSingleton<IServiceTicketDashboardService, ServiceTicketDashboardService>();
            services.AddSingleton<IServiceTicketDashboardRepository, ServiceTicketDashboardRepository>();

            services.AddSingleton<ISpareService, SpareService>();
            services.AddSingleton<ISpareRepository, SpareRepository>();

            services.AddSingleton<IAsmServiceTicketCustomerService, AsmServiceTicketCustomerService>();
            services.AddSingleton<IAsmServiceTicketCustomerRepository, AsmServiceTicketCustomerRepository>();

            services.AddSingleton<IServiceTicketClaimRateDetailService, ServiceTicketClaimRateDetailService>();
            services.AddSingleton<IServiceTicketClaimRateDetailRepository, ServiceTicketClaimRateDetailRepository>();

            services.AddSingleton<IServiceTicketClaimInfoService, ServiceTicketClaimInfoService>();
            services.AddSingleton<IServiceTicketClaimInfoRepository, ServiceTicketClaimInfoRepository>();

            services.AddSingleton<IASMServiceTicketClaimApprovalRepository, ASMServiceTicketClaimApprovalRepository>();
            services.AddSingleton<IASMServiceTicketClaimApprovalService, ASMServiceTicketClaimApprovalService>();

            services.AddSingleton<IClaimApprovalHistoryService, ClaimApprovalHistoryService>();
            services.AddSingleton<IClaimApprovalHistoryRepository, ClaimApprovalHistoryRepository>();

            services.AddSingleton<IApprovalLevelRepository, ApprovalLevelRepository>();
            services.AddSingleton<IApprovalLevelService, ApprovalLevelService>();

            services.AddSingleton<ITicketReportRepository, TicketReportRepository>();
            services.AddSingleton<ITicketReportService, TicketReportService>();

            services.AddSingleton<ICostingReportRepository, CostingReportRepository>();
            services.AddSingleton<ICostingReportService, CostingReportService>();

            services.AddSingleton<IPartConsumptionReportRepository, PartConsumptionReportRepository>();
            services.AddSingleton<IPartCosnumptionReportService, PartConsumptionReportService>();

            services.AddSingleton<IASCDetailsRepository, ASCDetailsRepository>();
            services.AddSingleton<IASCDetailsService, ASCDetailsService>();

            services.AddSingleton<IDashboardRepository, DashboardRepository>();
            services.AddSingleton<IDashboardService, DashboardService>();

            services.AddSingleton<IClosureTATBranchWiseRepository, ClosureTATBranchWiseRepository>();
            services.AddSingleton<IClosureTATBranchWiseService, ClosureTATBranchWiseService>();


            services.AddSingleton<IServiceTicketCommenInfoRepository, ServiceTicketCommenInfoRepository>();
            services.AddSingleton<IServiceTicketCommenInfoService, ServiceTicketCommenInfoService>();



            services.AddSingleton<IknowledgeService, knowledgeService>();
            services.AddSingleton<IknowledgeRepository, knowledgeRepository>();

            services.AddSingleton<IUniversalSearchService, UniversalSearchService>();
            services.AddSingleton<IUniversalSearchRepository, UniversalSearchRepository>();


            return services;
        }
    }
}
