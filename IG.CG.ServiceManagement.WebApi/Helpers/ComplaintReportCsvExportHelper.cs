using IG.CG.Core.Application.Models;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IG.CG.ServiceManagement.API.Helpers
{
    public static class ComplaintReportCsvExportHelper
    {
        public static MemoryStream GenerateCsvStream<T>(List<T> data, Dictionary<string, string> headerMap)
        {
            var stream = new MemoryStream();
            var encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
            using var writer = new StreamWriter(stream, encoding, bufferSize: 8192, leaveOpen: true);

            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                 .ToDictionary(p => p.Name, p => p);

            var sb = new StringBuilder(2048);

            writer.WriteLine(string.Join(",", headerMap.Values));

            foreach (var item in data)
            {
                sb.Clear();
                foreach (var key in headerMap.Keys)
                {
                    if (props.TryGetValue(key, out var prop))
                    {
                        var value = prop.GetValue(item)?.ToString() ?? "";

                        if (key == "ServiceTicketNumber")
                            value = "\t" + value;

                        value = $"\"{value.Replace("\"", "\"\"")}\"";
                        sb.Append(value).Append(',');
                    }
                    else
                    {
                        sb.Append("\"\"").Append(',');
                    }
                }

                if (sb.Length > 0)
                {
                    sb.Length--;
                    writer.WriteLine(sb.ToString());
                }
            }

            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static Dictionary<string, string> ComplaintHeaderMap()
        {
            return new Dictionary<string, string>
            {
                ["RegionName"] = "Region",
                ["BranchName"] = "Branch",
                ["ServiceTicketNumber"] = "Service Ticket No",
                ["LoggedMonth"] = "Logged Month",
                ["LoggedDate"] = "Logged Date",
                ["LoggedTime"] = "Logged Time",
                ["Distanc"] = "Distance",
                ["DistanceType"] = "Distance Type",
                ["NatureOfComplaint"] = "Nature Of Complaint",
                ["CustomerName"] = "Customer Name",
                ["ContactPerson"] = "Contact Person",
                ["SiteAddress"] = "Site Address",
                ["CityName"] = "City",
                ["StateName"] = "State",
                ["PinCode"] = "Pin Code",
                ["PrimaryMobileNo"] = "Primary Mobile",
                ["AltContactNo"] = "Alternate Contact",
                ["Quantity"] = "Quantity",
                ["ComplainType"] = "Complaint Type",
                ["WarrantyDateStatus"] = "Warranty Status",
                ["InvoiceDateStatus"] = "Invoice Status",
                ["BusinessCall"] = "Business Call",
                ["DivisionName"] = "Division",
                ["ProductLineName"] = "Product Line",
                ["ProductGroupName"] = "Product Group",
                ["ProductCode"] = "Product Code",
                ["ProductName"] = "Product Name",
                ["SerialNo"] = "Serial No",
                ["ASCName"] = "ASC",
                ["TechnicianName"] = "Technician",
                ["STSubStatusName"] = "Sub Status",
                ["ClosureStatus"] = "Closure Status",
                ["ComplaintCurrentStatus"] = "Complaint Present Status",
                ["ReplacementTagApplied"] = "Replacement Tag",
                ["ClosureRemarks"] = "Closure Remarks",
                ["LatestComment"] = "Latest Comment",
                ["ComplaintAgedays"] = "Complaint Age (Days)",
                ["ClosureTat"] = "Closure TAT",
                ["WebClosureDate"] = "Web Closure Date",
                ["ClosureTime"] = "Closure Time",
                ["InternalEmployeeDrivesAndLRM"] = "Employee Drives/LRM",
                ["ModeOfReceipt"] = "Receipt Mode",
                ["SourceName"] = "Source",
                ["ServiceRequestType"] = "Service Request Type",
                ["FileCountAttached"] = "Attachment Count",
                ["OEMName"] = "OEM",
                ["DealerName"] = "Dealer",
                ["PendencyRemarks"] = "Pendency Remarks",
                ["PendencyReasonUpdatedOn"] = "Pendency Updated On",
                ["ActualStatusOfComplaint"] = "Actual Status",
                ["PendingWithWhom"] = "Pending With",
                ["ActionRequired"] = "Action Required",
                ["ClaimStatus"] = "Service Claim Status By ASM / RSM",
                ["DefectName"] = "Defect Name (Combined)",
                ["DefectCategoryName"] = "Defect Category (Combined)",
                ["ASMName"] = "ASM",
                ["IBNNumber"] = "IBN Number",
                ["PurchaseFrom"] = "Purchased From",
            };
        }

        internal static Stream GenerateCsvStream<T>(IList<AscServiceTicketInfoComplaintReportModel> data, Dictionary<string, string> dictionary)
        {
            throw new NotImplementedException();
        }
    }
}
