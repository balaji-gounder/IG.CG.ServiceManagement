namespace IG.CG.Core.Domain.Constants.Queries
{
    public class ServiceTicketQueries
    {
        public static string GetServiceTicketById = "ServiceTicketDetailsGet";

        public static string GetServiceTicketCreateById = "ServiceTicketCreateGet";


        public static string GetAllServiceTicketInfo = "ServiceTicketInfoGetAll";
        public static string GetSerialWiseServiceTicketInfo = "SerialWiseServiceTicketDetailsGet";
        public static string UpdateIsAcknowledgment = "IsAcknowledgmentServiceTicketUpdate";
        public static string ServiceTicketDetailsById = "ServiceTicketDetailsByIdGet";
        public static string GetServiceRequestNoOfDays = "ServiceRequestNoOfDaysGet";
        public static string UpdateReassignedTechnicianServiceTicket = "ReassignedTechnicianServiceTicketUpdate";
        public static string UpdateAssignedASCServiceTicket = "AssignedASCServiceTicketUpdate";
        public static string UpdateAscServiceTicketActivity = "AscServiceTicketActivityInsertUpdate";
        public static string InsertServiceTicketPendencyReason = "ServiceTicketPendencyReasonInsert";
        public static string GetAllPendencyReason = "ServiceTicketPendencyReasonGetAll";
        public static string GetAllSTPendingWithWhom = "ServiceTicketPendingWithWhomGetAll";
        public static string GetAllPendencyActionRequired = "PendencyActionRequiredGetAll";
        public static string UpdateAssignedASMServiceTicket = "AssignedASMServiceTicketUpdate";
        public static string GetSerialWiseServiceTicketFIRInfo = "SerialWiseServiceTicketFIRDetailsGet";
        public static string DeleteAscServiceTicketActivity = "DeleteServiceTicketActivityDelete";
        public static string GetSSerialWiseServiceTicketJobsheet = "SerialWiseServiceTicketJobsheetGet";
        public static string GetServiceTicketSpareDetail = "ServiceTicketSpareDetailGet";
        public static string UpdateServiceTickeBusinessCall = "UpdateServiceTickeBusinessCall";

        public static string UpdateServiceTicketHappyCodeUpdate = "ServiceTicketHappyCodeUpdate";
        public static string ReplacementTagGet = "ReplacementTagGet";

        public static string UpdateCancelServiceTicket = "CancellationRequestTicketUpdate";
   
    }
}
