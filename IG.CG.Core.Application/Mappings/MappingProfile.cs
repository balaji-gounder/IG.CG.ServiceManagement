using AutoMapper;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;


namespace IG.CG.Core.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RoleWiseMenuModel, RoleWiseMenuEntity>();
            CreateMap<RoleWiseMenuEntity, RoleWiseMenuModel>();
            CreateMap<AscModel, AscEntity>();
            CreateMap<AscEntity, AscModel>();
            CreateMap<AscEntity, AscModel>();

            CreateMap<AscDisplayEntity, AscDisplayModel>();
            CreateMap<AscDisplayEntity, AscDisplayModel>();


            CreateMap<RoleModel, RoleEntity>();
            CreateMap<RoleEntity, RoleModel>();
            CreateMap<RoleModel, RoleEntity>();
            CreateMap<RegionEntity, RegionModel>();
            CreateMap<RegionModel, RegionEntity>();
            CreateMap<BranchEntity, BranchModel>();
            CreateMap<BranchModel, BranchEntity>();
            CreateMap<BranchDisplayEntity, BranchDisplayModel>();
            CreateMap<DivisionEntity, DivisionModel>();
            CreateMap<DivisionModel, DivisionEntity>();
            CreateMap<ProductGroupEntity, ProductGroupModel>();
            CreateMap<ProductGroupModel, ProductGroupEntity>();
            CreateMap<ProductGroupDisplayEntity, ProductGroupDisplayModel>();
            CreateMap<ProductLineEntity, ProductLineModel>();
            CreateMap<ProductLineModel, ProductLineEntity>();
            CreateMap<ProductLineDisplayEntity, ProductLineDisplayModel>();
            CreateMap<DefectEntity, DefectModel>();
            CreateMap<DefectModel, DefectEntity>();
            CreateMap<DefectDisplayEntity, DefectDisplayModel>();
            CreateMap<ProductEntity, ProductModel>();
            CreateMap<ProductModel, ProductEntity>();
            CreateMap<ProductDisplayEntity, ProductDisplayModel>();
            CreateMap<ProductDeviationModel, ProductDeviationEntity>();
            CreateMap<ProductDeviationEntity, ProductDeviationModel>();
            CreateMap<ProductDeviationDisplayEntity, ProductDeviationDisplayModel>();


            CreateMap<CustomerEntity, CustomerModel>();
            CreateMap<CustomerModel, CustomerEntity>();
            CreateMap<CustomerDisplayEntity, CustomerDisplayModel>();
            CreateMap<DefectCategoryEntity, DefectCategoryModel>();
            CreateMap<DefectCategoryModel, DefectCategoryEntity>();
            CreateMap<UserModel, UserEntity>();
            CreateMap<UserEntity, UserModel>();

            CreateMap<UserDisplayModel, UserDisplayEntity>();
            CreateMap<UserDisplayEntity, UserDisplayModel>();


            CreateMap<ParaValModel, ParaValEntity>();
            CreateMap<ParaValEntity, ParaValModel>();
            CreateMap<ParaTypeModel, ParaTypeEntity>();
            CreateMap<ParaTypeEntity, ParaTypeModel>();
            CreateMap<CustomerAssestsEntity, CustomerAssetModel>();
            CreateMap<CustomerAssetModel, CustomerAssestsEntity>();
            CreateMap<CustomerAssestDisplayEntity, CustomerAssetDisplayModel>();
            CreateMap<DealerModel, DealerEntity>();
            CreateMap<DealerEntity, DealerModel>();
            CreateMap<DealerDisplayEntity, DealerDisplayModel>();
            CreateMap<UserEntity, UserModel>();
            CreateMap<UserModel, UserEntity>();
            CreateMap<UserDisplayEntity, UserDisplayModel>();
            CreateMap<TechnicianEntity, TechnicianModel>();
            CreateMap<TechnicianModel, TechnicianEntity>();
            CreateMap<TechnicianDisplayEntity, TechnicianDisplayModel>();
            CreateMap<MasterEntity, MasterModel>();
            CreateMap<MasterModel, MasterEntity>();
            CreateMap<DefectCategoryEntity, DefectCategoryModel>();
            CreateMap<DefectCategoryModel, DefectCategoryEntity>();
            CreateMap<LoginModel, LoginEntity>();
            CreateMap<LoginEntity, LoginModel>();

            CreateMap<ChangePasswordModel, ChangePasswordEntity>();
            CreateMap<ChangePasswordEntity, ChangePasswordModel>();

            CreateMap<UserGetByUserTypeModel, UserGetByUserTypeEntity>();
            CreateMap<UserGetByUserTypeEntity, UserGetByUserTypeModel>();

            CreateMap<ParaValDispEntity, ParaValDispModel>();
            CreateMap<ParaValDispModel, ParaValDispEntity>();
            CreateMap<VendorDisplayEntity, VendorDisplayModel>();
            CreateMap<VendorDisplayModel, VendorDisplayEntity>();
            CreateMap<VendorModel, VendorEntity>();
            CreateMap<VendorEntity, VendorModel>();
            CreateMap<LeadsDivisionProductEntity, LeadsDivisionProductModel>();
            CreateMap<LeadsDivisionProductModel, LeadsDivisionProductEntity>();

            CreateMap<ASCWisePinCodeEntity, ASCWisePinCodeModel>();
            CreateMap<ASCWisePinCodeModel, ASCWisePinCodeEntity>();

            CreateMap<ASCWisePinCodeDisplayEntity, ASCWisePinCodeDisplayModel>();
            CreateMap<ASCWisePinCodeDisplayModel, ASCWisePinCodeDisplayEntity>();

            CreateMap<TemplateMailAndSmsEntity, TemplateMailAndSmsModel>();
            CreateMap<TemplateMailAndSmsModel, TemplateMailAndSmsEntity>();


            //-------------------------------------------------- Leads ----------------------

            CreateMap<LeadsDashboardModel, LeadsDashboardEntity>();
            CreateMap<LeadsDashboardEntity, LeadsDashboardModel>();

            CreateMap<LeadsDashboardChartModel, LeadsDashboardChartEntity>();
            CreateMap<LeadsDashboardChartEntity, LeadsDashboardChartModel>();

            CreateMap<LeadModel, LeadEntity>();
            CreateMap<LeadEntity, LeadModel>();

            CreateMap<LeadDisplayModel, LeadDisplayEntity>();
            CreateMap<LeadDisplayEntity, LeadDisplayModel>();

            CreateMap<LeadActivityModel, LeadActivityEntity>();
            CreateMap<LeadActivityEntity, LeadActivityModel>();

            CreateMap<LeadsDivisionProductDisplayEntity, LeadsDivisionProductDisplayModel>();
            CreateMap<LeadsDivisionProductDisplayModel, LeadsDivisionProductDisplayEntity>();

            CreateMap<LeadsFollowupListEntity, LeadsFollowupListModel>();
            CreateMap<LeadsFollowupListModel, LeadsFollowupListEntity>();

            CreateMap<LeadsFollowupExcelEntity, LeadsFollowupExcelModel>();
            CreateMap<LeadsFollowupExcelModel, LeadsFollowupExcelEntity>();



            CreateMap<LeadFollowupSelectEntity, LeadFollowupSelectModel>();
            CreateMap<LeadFollowupSelectModel, LeadFollowupSelectEntity>();

            CreateMap<LeadFollowupDisplayEntity, LeadFollowupDisplayModel>();
            CreateMap<LeadFollowupDisplayModel, LeadFollowupDisplayEntity>();

            CreateMap<LeadFollowupEntity, LeadFollowupModel>();
            CreateMap<LeadFollowupModel, LeadFollowupEntity>();

            CreateMap<DefectCatDispEntity, DefectCatDispModel>();
            CreateMap<DefectCatDispModel, DefectCatDispEntity>();

            CreateMap<DealerSAPEntity, DealerSAPModel>();
            CreateMap<DealerSAPModel, DealerSAPEntity>();


            CreateMap<SAPDataEnitity, SAPDataModel>();
            CreateMap<SAPDataModel, SAPDataEnitity>();

            CreateMap<UserAdditionalRightsModel, UserAdditionalRightsEntity>();
            CreateMap<UserAdditionalRightsEntity, UserAdditionalRightsModel>();

            CreateMap<AscApprovalEnitity, AscApprovalModel>();
            CreateMap<AscApprovalModel, AscApprovalEnitity>();

            CreateMap<ClaimRateEntity, ClaimRateModel>();
            CreateMap<ClaimRateModel, ClaimRateEntity>();

            CreateMap<ClaimRateDetailsEntity, ClaimRateDetailsModel>();
            CreateMap<ClaimRateDetailsModel, ClaimRateDetailsEntity>();

            CreateMap<ClaimRateDisplayEntity, ClaimRateDisplayModel>();
            CreateMap<ClaimRateDisplayModel, ClaimRateDisplayEntity>();



            CreateMap<CityPincodeMappingEntity, CityPincodeMappingModel>();
            CreateMap<CityPincodeMappingModel, CityPincodeMappingEntity>();

            //------------------------------------------------------------- Product Warranty ---------------------------------------------

            CreateMap<ProdCustInfoDisplayEnitity, ProdCustInfoDisplayModel>();
            CreateMap<ProdCustInfoDisplayModel, ProdCustInfoDisplayEnitity>();

            CreateMap<CustVerificationEntity, CustVerificationModel>();
            CreateMap<CustVerificationModel, CustVerificationEntity>();

            CreateMap<ProdSerialNoWarrantySAPEntity, ProdSerialNoWarrantySAPModel>();
            CreateMap<ProdSerialNoWarrantySAPModel, ProdSerialNoWarrantySAPEntity>();

            CreateMap<ProdSerialNoWarrantySAPDisplayEntity, ProdSerialNoWarrantySAPDisplayModel>();
            CreateMap<ProdSerialNoWarrantySAPDisplayModel, ProdSerialNoWarrantySAPDisplayEntity>();

            CreateMap<ProductCustomerInfoEntity, ProductCustomerInfoModel>();
            CreateMap<ProductCustomerInfoModel, ProductCustomerInfoEntity>();

            CreateMap<ProductCustomerInfoDisplayEntity, ProductCustomerInfoDisplayModel>();
            CreateMap<ProductCustomerInfoDisplayModel, ProductCustomerInfoDisplayEntity>();


            CreateMap<ServiceTicketDetailsEntity, ServiceTicketDetailsModel>();
            CreateMap<ServiceTicketDetailsModel, ServiceTicketDetailsEntity>();

            CreateMap<ProdDeviationEntity, ProdDeviationModel>();
            CreateMap<ProdDeviationModel, ProdDeviationEntity>();

            CreateMap<ProductCustomerInfoDealerEntity, ProductCustomerInfoDealerModel>();
            CreateMap<ProductCustomerInfoDealerModel, ProductCustomerInfoDealerEntity>();

            CreateMap<ProductDealerEntity, ProductDealerModel>();
            CreateMap<ProductDealerModel, ProductDealerEntity>();

            CreateMap<ProductTypeEntity, ProductTypeModel>();
            CreateMap<ProductTypeModel, ProductTypeEntity>();

            CreateMap<ServiceTicketInfoDisplayEntity, ServiceTicketInfoDisplayModel>();
            CreateMap<ServiceTicketInfoDisplayModel, ServiceTicketInfoDisplayEntity>();

            CreateMap<PincodeMappingUserDisplayEntity, PincodeMappingUserDisplayModel>();
            CreateMap<PincodeMappingUserDisplayModel, PincodeMappingUserDisplayEntity>();

            CreateMap<STStatusEntity, STStatusModel>();
            CreateMap<STStatusModel, STStatusEntity>();

            CreateMap<STSubStatusEntity, STSubStatusModel>();
            CreateMap<STSubStatusModel, STSubStatusEntity>();

            CreateMap<ActivityEntity, ActivityModel>();
            CreateMap<ActivityModel, ActivityEntity>();

            CreateMap<ActivityDisplayEntity, ActivityDisplayModel>();
            CreateMap<ActivityDisplayModel, ActivityDisplayEntity>();

            CreateMap<RewindingServicesDisplayEntity, RewindingServicesDisplayModel>();
            CreateMap<RewindingServicesDisplayModel, RewindingServicesDisplayModel>();

            CreateMap<ASCServiceRequestEntity, ASCServiceRequestModel>();
            CreateMap<ASCServiceRequestModel, ASCServiceRequestEntity>();

            CreateMap<SerialWiseServiceTicketInfoEntity, SerialWiseServiceTicketInfoModel>();
            CreateMap<SerialWiseServiceTicketInfoModel, SerialWiseServiceTicketInfoEntity>();

            CreateMap<AscServiceTicketCustomerEntity, AscServiceTicketCustomerModel>();
            CreateMap<AscServiceTicketCustomerModel, AscServiceTicketCustomerEntity>();

            CreateMap<ASCSiteVisitAndProductReceivedModel, ASCSiteVisitAndProductReceivedEntity>();
            CreateMap<ASCSiteVisitAndProductReceivedEntity, ASCSiteVisitAndProductReceivedModel>();


            CreateMap<AscServiceTicketCustomerDisplayEntity, AscServiceTicketCustomerDisplayModel>();
            CreateMap<AscServiceTicketCustomerDisplayModel, AscServiceTicketCustomerDisplayEntity>();


            CreateMap<AscWiseTechnicianEntity, AscWiseTechnicianModel>();
            CreateMap<AscWiseTechnicianModel, AscWiseTechnicianEntity>();

            CreateMap<ServiceTicketTaskDetailsModel, ServiceTicketTaskDetailsEntity>();
            CreateMap<ServiceTicketTaskDetailsEntity, ServiceTicketTaskDetailsModel>();

            //CreateMap<AscActivitiesEntity, AscActivitiesModel>();
            //CreateMap<AscActivitiesModel, AscActivitiesEntity>();



            CreateMap<IssueEntity, IssueModel>();
            CreateMap<IssueModel, IssueEntity>();

            CreateMap<IssueDisplayEntity, IssueDisplayModel>();
            CreateMap<IssueDisplayModel, IssueDisplayEntity>();

            CreateMap<PartConsumptionReportModel, PartConsumptionReportEntity>();
            CreateMap<PartConsumptionReportEntity, PartConsumptionReportModel>();

            CreateMap<CostingReportModel, CostingReportEntity>();
            CreateMap<CostingReportEntity, CostingReportModel>();

            CreateMap<TrackServiceTicketDetailsEntity, TrackServiceTicketDetailsModel>();
            CreateMap<TrackServiceTicketDetailsModel, TrackServiceTicketDetailsEntity>();

            CreateMap<FeedbackQuestionsEntity, FeedbackQuestionsModel>();
            CreateMap<FeedbackQuestionsModel, FeedbackQuestionsEntity>();

            CreateMap<FeedbackRatingEntity, FeedbackRatingModel>();
            CreateMap<FeedbackRatingModel, FeedbackRatingEntity>();

            CreateMap<FeedbackQuestionAnswerEntity, FeedbackQuestionAnswerModel>();
            CreateMap<FeedbackQuestionAnswerModel, FeedbackQuestionAnswerEntity>();

            CreateMap<FeedbackQuestionAnswerDisplayEntity, FeedbackQuestionAnswerDisplayModel>();
            CreateMap<FeedbackQuestionAnswerDisplayModel, FeedbackQuestionAnswerDisplayEntity>();

            CreateMap<FeedbackRatingDisplayModel, FeedbackRatingDisplayEntity>();
            CreateMap<FeedbackRatingDisplayEntity, FeedbackRatingDisplayModel>();

            CreateMap<TrackServiceTicketReportEntity, TrackServiceTicketReportModel>();
            CreateMap<TrackServiceTicketReportModel, TrackServiceTicketReportEntity>();


            CreateMap<SMSDetailsEntity, SMSDetailsModel>();
            CreateMap<SMSDetailsModel, SMSDetailsEntity>();

            CreateMap<ServiceTicketDashboardEntity, ServiceTicketDashboardModel>();
            CreateMap<ServiceTicketDashboardModel, ServiceTicketDashboardEntity>();

            CreateMap<STSubStatusByTypeEntity, STSubStatusByTypeModel>();
            CreateMap<STSubStatusByTypeModel, STSubStatusByTypeEntity>();

            CreateMap<AscListEntity, AscListModel>();
            CreateMap<AscListModel, AscListEntity>();

            CreateMap<SpareEntity, SpareModel>();
            CreateMap<SpareModel, SpareEntity>();

            CreateMap<SpareDisplayEntity, SpareDisplayModel>();
            CreateMap<SpareDisplayModel, SpareDisplayEntity>();

            CreateMap<ServiceTicketASCCodeEntity, ServiceTicketASCCodeModel>();
            CreateMap<ServiceTicketASCCodeModel, ServiceTicketASCCodeEntity>();

            CreateMap<AscServiceTicketActivityEntity, AscServiceTicketActivityModel>();
            CreateMap<AscServiceTicketActivityModel, AscServiceTicketActivityEntity>();

            CreateMap<ServiceTicketStatusEntity, ServiceTicketStatusModel>();
            CreateMap<ServiceTicketStatusModel, ServiceTicketStatusEntity>();

            CreateMap<AsmServiceTicketCancellationApprovalEntity, AsmServiceTicketCancellationApprovalModel>();
            CreateMap<AsmServiceTicketCancellationApprovalModel, AsmServiceTicketCancellationApprovalEntity>();

            CreateMap<AsmServiceTicketCancellationRejectedEntity, AsmServiceTicketCancellationRejectedModel>();
            CreateMap<AsmServiceTicketCancellationRejectedModel, AsmServiceTicketCancellationRejectedEntity>();

            CreateMap<AscListByTicketCountEntity, AscListByTicketCountModel>();
            CreateMap<AscListByTicketCountModel, AscListByTicketCountEntity>();

            CreateMap<AscServiceTicketFirEntity, AscServiceTicketFirModel>();
            CreateMap<AscServiceTicketFirModel, AscServiceTicketFirEntity>();

            CreateMap<FIRDefectListEntity, FIRDefectListModel>();
            CreateMap<FIRDefectListModel, FIRDefectListEntity>();


            CreateMap<SpareDetailsEntity, SpareDetailsModel>();
            CreateMap<SpareDetailsModel, SpareDetailsEntity>();

            CreateMap<FIRDocumentListEntity, FIRDocumentListModel>();
            CreateMap<FIRDocumentListModel, FIRDocumentListEntity>();

            CreateMap<CancellationRemarksEntity, CancellationRemarksModel>();
            CreateMap<CancellationRemarksModel, CancellationRemarksEntity>();

            CreateMap<ServiceTicketPendencyReasonModel, ServiceTicketPendencyReasonEntity>();
            CreateMap<ServiceTicketPendencyReasonEntity, ServiceTicketPendencyReasonModel>();

            CreateMap<ServiceTicketPendencyReasonDisplayEntity, ServiceTicketPendencyReasonDisplayModel>();
            CreateMap<ServiceTicketPendencyReasonDisplayModel, ServiceTicketPendencyReasonDisplayEntity>();

            CreateMap<PendingWithWhomEntity, PendingWithWhomModel>();
            CreateMap<PendingWithWhomModel, PendingWithWhomEntity>();

            CreateMap<PendencyActionRequiredModel, PendencyActionRequiredEntity>();
            CreateMap<PendencyActionRequiredEntity, PendencyActionRequiredModel>();

            CreateMap<TypeOfWorkDoneEntity, TypeOfWorkDoneModel>();
            CreateMap<TypeOfWorkDoneModel, TypeOfWorkDoneEntity>();

            CreateMap<InternalEngineerASMListModel, InternalEngineerASMListEntity>();
            CreateMap<InternalEngineerASMListEntity, InternalEngineerASMListModel>();

            CreateMap<AscWiseProductLineEntity, AscWiseProductLineModel>();
            CreateMap<AscWiseProductLineModel, AscWiseProductLineEntity>();

            //CreateMap<ServiceTicketASMCodeEntity, ServiceTicketASMCodeModel>();
            //CreateMap<ServiceTicketASMCodeModel, ServiceTicketASMCodeEntity>();


            CreateMap<ServiceTicketClaimRateDetailEntity, ServiceTicketClaimRateDetailModel>();
            CreateMap<ServiceTicketClaimRateDetailModel, ServiceTicketClaimRateDetailEntity>();

            CreateMap<ServiceTicketClaimInfoEntity, ServiceTicketClaimInfoModel>();
            CreateMap<ServiceTicketClaimInfoModel, ServiceTicketClaimInfoEntity>();

            CreateMap<AscServiceTicketFirDisplayEntity, AscServiceTicketFirDisplayModel>();
            CreateMap<AscServiceTicketFirDisplayModel, AscServiceTicketFirDisplayEntity>();

            CreateMap<SpareDetailsDisplayEntity, SpareDetailsDisplayModel>();
            CreateMap<SpareDetailsDisplayModel, SpareDetailsDisplayEntity>();

            CreateMap<FIRDocumentListDisplayEntity, FIRDocumentListDisplayModel>();
            CreateMap<FIRDocumentListDisplayModel, FIRDocumentListDisplayEntity>();


            CreateMap<FIRDefectListDisplayEntity, FIRDefectListDisplayModel>();
            CreateMap<FIRDefectListDisplayModel, FIRDefectListDisplayEntity>();

            CreateMap<ServiceTicketASMCodeEntity, ServiceTicketASMCodeModel>();
            CreateMap<ServiceTicketASMCodeModel, ServiceTicketASMCodeEntity>();

            CreateMap<ASMServiceRequestClaimInfoEntity, ASMServiceRequestClaimInfoModel>();
            CreateMap<ASMServiceRequestClaimInfoModel, ASMServiceRequestClaimInfoEntity>();

            CreateMap<ClaimAttachmentListEntity, ClaimAttachmentListModel>();
            CreateMap<ClaimAttachmentListModel, ClaimAttachmentListEntity>();

            CreateMap<FIRDocumentWithTypeEntity, FIRDocumentWithTypeModel>();
            CreateMap<FIRDocumentWithTypeModel, FIRDocumentWithTypeEntity>();

            CreateMap<ASMServiceRequestClaimLineItemsEntity, ASMServiceRequestClaimLineItemsModel>();
            CreateMap<ASMServiceRequestClaimLineItemsModel, ASMServiceRequestClaimLineItemsEntity>();

            CreateMap<ASMServiceRequestClaimApprovalEntity, ASMServiceRequestClaimApprovalModel>();
            CreateMap<ASMServiceRequestClaimApprovalModel, ASMServiceRequestClaimApprovalEntity>();

            CreateMap<ASCServiceRequestClaimInfoEntity, ASCServiceRequestClaimInfoModel>();
            CreateMap<ASCServiceRequestClaimInfoModel, ASCServiceRequestClaimInfoEntity>();

            CreateMap<ASCServiceRequestClaimLineItemsEntity, ASCServiceRequestClaimLineItemsModel>();
            CreateMap<ASCServiceRequestClaimLineItemsModel, ASCServiceRequestClaimLineItemsEntity>();

            CreateMap<AscTatPerformanceModel, AscTatPerformanceEntity>();
            CreateMap<AscTatPerformanceEntity, AscTatPerformanceModel>();

            CreateMap<AscClaimApprovalLineItemsModel, AscClaimApprovalLineItemsEntity>();
            CreateMap<AscClaimApprovalLineItemsEntity, AscClaimApprovalLineItemsModel>();

            CreateMap<ASCServiceRequestClaimItemsManageApprovalEntity, ASCServiceRequestClaimItemsManageApprovalModel>();
            CreateMap<ASCServiceRequestClaimItemsManageApprovalModel, ASCServiceRequestClaimItemsManageApprovalEntity>();

            CreateMap<AscServiceRequestClaimReApprovalEntity, AscServiceRequestClaimReApprovalModel>();
            CreateMap<AscServiceRequestClaimReApprovalModel, AscServiceRequestClaimReApprovalEntity>();

            CreateMap<FIRDocumentListDispalyEntity, FIRDocumentListDisplaynModel>();
            CreateMap<FIRDocumentListDisplaynModel, FIRDocumentListDispalyEntity>();

            CreateMap<AscSpecialApprovalClaimEntity, AscSpecialApprovalClaimModel>();
            CreateMap<AscSpecialApprovalClaimModel, AscSpecialApprovalClaimEntity>();

            CreateMap<AscIBNListEntity, AscIBNListModel>();
            CreateMap<AscIBNListModel, AscIBNListEntity>();

            CreateMap<ServiceTicketDeviationClaimInfoEntity, ServiceTicketDeviationClaimInfoModel>();
            CreateMap<ServiceTicketDeviationClaimInfoModel, ServiceTicketDeviationClaimInfoEntity>();

            CreateMap<IBNPdfInfoModel, IBNPdfInfoEntity>();
            CreateMap<IBNPdfInfoEntity, IBNPdfInfoModel>();

            CreateMap<ClaimDetailsModel, ClaimDetailsEntity>();
            CreateMap<ClaimDetailsEntity, ClaimDetailsModel>();


            CreateMap<AscServiceTicketProductFirEntity, AscServiceTicketProductFirModel>();
            CreateMap<AscServiceTicketProductFirModel, AscServiceTicketProductFirEntity>();

            CreateMap<ProductCustomerAMSInfoEntity, ProductCustomerAMSInfoModel>();
            CreateMap<ProductCustomerAMSInfoModel, ProductCustomerAMSInfoEntity>();

            CreateMap<ClaimApprovalHistoryModel, ClaimApprovalHistoryEntity>();
            CreateMap<ClaimApprovalHistoryEntity, ClaimApprovalHistoryModel>();

            CreateMap<AsmServiceTicketClaimAmountDistanceModel, AsmServiceTicketClaimAmountDistanceEntity>();
            CreateMap<AsmServiceTicketClaimAmountDistanceEntity, AsmServiceTicketClaimAmountDistanceModel>();

            CreateMap<ClaimApprovalHistoryDisplayEntity, ClaimApprovalHistoryDisplayModel>();
            CreateMap<ClaimApprovalHistoryDisplayModel, ClaimApprovalHistoryDisplayEntity>();

            CreateMap<UserWiseDivisionEntity, UserWiseDivisionModel>();
            CreateMap<UserWiseDivisionModel, UserWiseDivisionEntity>();

            CreateMap<DivisionWiseProductLineModel, DivisionWiseProductLineEntity>();
            CreateMap<DivisionWiseProductLineEntity, DivisionWiseProductLineModel>();

            CreateMap<ASMSpecialApprovalLineItemsEntity, ASMSpecialApprovalLineItemsModel>();
            CreateMap<ASMSpecialApprovalLineItemsModel, ASMSpecialApprovalLineItemsEntity>();

            CreateMap<RSMSpecialApprovalLineItemsModel, RSMSpecialApprovalLineItemsEntity>();
            CreateMap<RSMSpecialApprovalLineItemsEntity, RSMSpecialApprovalLineItemsModel>();

            CreateMap<UpdateRSMSpecialApprovalModel, UpdateRSMSpecialApprovalEntity>();
            CreateMap<UpdateRSMSpecialApprovalEntity, UpdateRSMSpecialApprovalModel>();

            CreateMap<UpdateASMAcceptRejectionResubmissionEntity, UpdateASMAcceptRejectionResubmissionModel>();
            CreateMap<UpdateASMAcceptRejectionResubmissionModel, UpdateASMAcceptRejectionResubmissionEntity>();

            CreateMap<SpecialApprovalClaimAttachmentListModel, SpecialApprovalClaimAttachmentListEntity>();
            CreateMap<SpecialApprovalClaimAttachmentListEntity, SpecialApprovalClaimAttachmentListModel>();

            CreateMap<SpecialApprovalHistoryEntity, SpecialApprovalHistoryModel>();
            CreateMap<SpecialApprovalHistoryModel, SpecialApprovalHistoryEntity>();

            CreateMap<SpecialApprovalHistoryDisplayModel, SpecialApprovalHistoryDisplayEntity>();
            CreateMap<SpecialApprovalHistoryDisplayEntity, SpecialApprovalHistoryDisplayModel>();

            CreateMap<SpareDetailModel, SpareDetailEntity>();
            CreateMap<SpareDetailEntity, SpareDetailModel>();

            CreateMap<ApprovalLevelEntity, ApprovalLevelModel>();
            CreateMap<ApprovalLevelModel, ApprovalLevelEntity>();

            CreateMap<ApprovalLevelDisplayModel, ApprovalLevelDisplayEntity>();
            CreateMap<ApprovalLevelDisplayEntity, ApprovalLevelDisplayModel>();

            CreateMap<ApprovalLevelUsersEntity, ApprovalLevelUsersModel>();
            CreateMap<ApprovalLevelUsersModel, ApprovalLevelUsersEntity>();

            CreateMap<ASCSpecialApprovalLineItemsEntity, ASCSpecialApprovalLineItemsModel>();
            CreateMap<ASCSpecialApprovalLineItemsModel, ASCSpecialApprovalLineItemsEntity>();

            CreateMap<AddAscTicketCreateEntity, AddAscTicketCreateModel>();
            CreateMap<AddAscTicketCreateModel, AddAscTicketCreateEntity>();


            CreateMap<ProductUpdateActivityModel, ProductUpdateActivityEntity>();
            CreateMap<ProductUpdateActivityEntity, ProductUpdateActivityModel>();

            CreateMap<ProductLineFrontModel, ProductLineFrontEntity>();
            CreateMap<ProductLineFrontEntity, ProductLineFrontModel>();

            CreateMap<ASCServiceRequestTotalCountModel, ASCServiceRequestTotalCountEntity>();
            CreateMap<ASCServiceRequestTotalCountEntity, ASCServiceRequestTotalCountModel>();


            CreateMap<ServiceTicketTaskDetailsReportModel, ServiceTicketTaskDetailsReportEntity>();
            CreateMap<ServiceTicketTaskDetailsReportEntity, ServiceTicketTaskDetailsReportModel>();

            CreateMap<AscServiceTicketCustomerReportModel, AscServiceTicketCustomerReportEntity>();
            CreateMap<AscServiceTicketCustomerReportEntity, AscServiceTicketCustomerReportModel>();

            CreateMap<AscServiceTicketInfoReportModel, AscServiceTicketInfoReportEntity>();
            CreateMap<AscServiceTicketInfoReportEntity, AscServiceTicketInfoReportModel>();

            CreateMap<AscServiceTicketActivitiesEntity, AscServiceTicketActivitiesModel>();
            CreateMap<AscServiceTicketActivitiesModel, AscServiceTicketActivitiesEntity>();

            CreateMap<ServiceTicketDefectReportEntity, ServiceTicketDefectReportModel>();
            CreateMap<ServiceTicketDefectReportModel, ServiceTicketDefectReportEntity>();


            CreateMap<AscDefectlistEntity, AscDefectlistModel>();
            CreateMap<AscDefectlistModel, AscDefectlistEntity>();

            CreateMap<ASCDetailsModel, ASCDetailsEntity>();
            CreateMap<ASCDetailsEntity, ASCDetailsModel>();

            CreateMap<DashboardModel, DashboardEntity>();
            CreateMap<DashboardEntity, DashboardModel>();


            CreateMap<ReplacementTagEntity, ReplacementTagModel>();
            CreateMap<ReplacementTagModel, ReplacementTagEntity>();

            CreateMap<AscServiceTicketInfoComplaintReportModel, AscServiceTicketInfoComplaintReportEntity>();
            CreateMap<AscServiceTicketInfoComplaintReportEntity, AscServiceTicketInfoComplaintReportModel>();

            CreateMap<AscServiceTicketInfoDefetReportEntity, AscServiceTicketInfoDefetReportModel>();
            CreateMap<AscServiceTicketInfoDefetReportModel, AscServiceTicketInfoDefetReportEntity>();

            CreateMap<ClosureTATBranchWiseModel, ClosureTATBranchWiseEntity>();
            CreateMap<ClosureTATBranchWiseEntity, ClosureTATBranchWiseModel>();

            CreateMap<AscServiceTicketFirDefectModel, AscServiceTicketFirDefectEntity>();
            CreateMap<AscServiceTicketFirDefectEntity, AscServiceTicketFirDefectModel>();

            CreateMap<DurationTicketTatDashboardEntity, DurationTicketTatDashboardModel>();
            CreateMap<DurationTicketTatDashboardModel, DurationTicketTatDashboardEntity>();

            CreateMap<ServiceTicketPendencyReasonHistoryEntity, ServiceTicketPendencyReasonHistoryModel>();
            CreateMap<ServiceTicketPendencyReasonHistoryModel, ServiceTicketPendencyReasonHistoryEntity>();

            CreateMap<ServiceTicketCommenInfoEntitys, ServiceTicketCommenInfoModel>();
            CreateMap<ServiceTicketCommenInfoModel, ServiceTicketCommenInfoEntitys>();

            CreateMap<ServiceTicketCommenInfoListEntitys, ServiceTicketCommenInfoListModel>();
            CreateMap<ServiceTicketCommenInfoListModel, ServiceTicketCommenInfoListEntitys>();



            CreateMap<knowledgeInfoDetailslistModel, knowledgeInfoDetailslistEntity>();
            CreateMap<knowledgeInfoDetailslistEntity, knowledgeInfoDetailslistModel>();

            CreateMap<AscServiceTicketFirDefectOneModel, AscServiceTicketFirDefectOneEntity>();
            CreateMap<AscServiceTicketFirDefectOneEntity, AscServiceTicketFirDefectOneModel>();


            CreateMap<knowledgelistModel, knowledgelistEntity>();
            CreateMap<knowledgelistEntity, knowledgelistModel>();

            CreateMap<SerialNoWiseTicketEntity, SerialNoWiseTicketModel>();
            CreateMap<SerialNoWiseTicketModel, SerialNoWiseTicketEntity>();

            CreateMap<DashboardClaimEntity, DashboardClaimModel>();
            CreateMap<DashboardClaimModel, DashboardClaimEntity>();


            CreateMap<UniversalSearchModel, UniversalSearchEntity>();
            CreateMap<UniversalSearchEntity, UniversalSearchModel>();

            CreateMap<ServiceTicketCancelModel, ServiceTicketCancelEntity>();
            CreateMap<ServiceTicketCancelEntity, ServiceTicketCancelModel>();

            CreateMap<ComplaintCancelReportModel, ComplaintCancelReportEntity>();
            CreateMap<ComplaintCancelReportEntity, ComplaintCancelReportModel>();


            CreateMap<RepeatedTicketsReportEntity, RepeatedTicketsReportModel>();
            CreateMap<RepeatedTicketsReportModel, RepeatedTicketsReportEntity>();

            CreateMap<RepeatedTicketsCallsSummaryEntity, RepeatedTicketsCallsSummaryModel>();
            CreateMap<RepeatedTicketsCallsSummaryModel, RepeatedTicketsCallsSummaryEntity>();

            CreateMap<RepeatedTicketsCallsEntity, RepeatedTicketsCallsModel>();
            CreateMap<RepeatedTicketsCallsModel, RepeatedTicketsCallsEntity>();


            CreateMap<ClaimApprovalTATReportEntity, ClaimApprovalTATReportModel>();
            CreateMap<ClaimApprovalTATReportModel, ClaimApprovalTATReportEntity>();

            CreateMap<AsmIBNTicketClaimAmountModel, AsmIBNTicketClaimAmountEntity>();
            CreateMap<AsmIBNTicketClaimAmountEntity, AsmIBNTicketClaimAmountModel>();





        }
    }
}
