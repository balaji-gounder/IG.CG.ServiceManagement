using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IG.CG.Core.Application.Models;
using System.IO.Compression;

namespace IG.CG.ServiceManagement.API.Helpers
{
    public static class DefectReportCsvExportHelper
    {
        public static MemoryStream GenerateZipWithCsvFiles(IEnumerable<ServiceTicketDefectReportModel> data)
        {
            var zipStream = new MemoryStream();
            using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
            {
                var tickets = data.SelectMany(x => x.AscServiceTicketlist).ToList();
                var defects = data.SelectMany(x => x.AscDefectlist).ToList();

                AddCsvToZip(archive, "Tickets.csv", tickets, TicketHeaderMap());
                AddCsvToZip(archive, "Defects.csv", defects, DefectHeaderMap());
            }

            zipStream.Position = 0;
            return zipStream;
        }

        private static void AddCsvToZip<T>(ZipArchive archive, string fileName, List<T> data, Dictionary<string, string> headerMap)
        {
            var entry = archive.CreateEntry(fileName);
            using var entryStream = entry.Open();
            using var writer = new StreamWriter(entryStream, Encoding.UTF8);

            writer.WriteLine(string.Join(",", headerMap.Values));

            foreach (var item in data)
            {
                var values = headerMap.Keys.Select(key =>
                {
                    var prop = typeof(T).GetProperty(key);
                    var val = prop?.GetValue(item, null);
                    return $"\"{(key == "ServiceTicketNumber" ? "\t" + val?.ToString() : val?.ToString())?.Replace("\"", "\"\"")}\"";
                });

                writer.WriteLine(string.Join(",", values));
            }
        }

        private static Dictionary<string, string> TicketHeaderMap() => new Dictionary<string, string>
        {
            ["RegionName"] = "Region",
            ["BranchName"] = "Branch",
            ["ServiceTicketNumber"] = "Service Ticket No",
            ["Distanc"] = "Distance",
            ["DistanceType"] = "Distance Type",
            ["LoggedMonth"] = "Logged Month",
            ["LoggedDate"] = "Logged Date",
            ["LoggedTime"] = "Logged Time",
            ["ComplaintAgedays"] = "Complaint Age (Days)",
            ["ClosureTat"] = "Closure TAT",
            ["WebClosureDate"] = "Web Closure Date",
            ["ASCName"] = "ASC Name",
            ["BusinessCall"] = "Business Call",
            ["ApplicationType"] = "Application Type",
            ["DivisionName"] = "Division",
            ["ProductLineName"] = "Product Line",
            ["ProductGroupName"] = "Product Group",
            ["ProductCode"] = "Product Code",
            ["ProductName"] = "Product Name",
            ["SerialNo"] = "Serial No",
            ["BatchNo"] = "Batch No",
            ["InvoiceNo"] = "Invoice No",
            ["InvoiceDate"] = "Invoice Date",
            ["InvoiceDateStatus"] = "Invoice Date Status",
            ["WarrantyDateStatus"] = "Warranty Status",
            ["CustomerName"] = "Customer",
            ["ContactPerson"] = "Contact Person",
            ["SiteAddress"] = "Site Address",
            ["CityName"] = "City",
            ["StateName"] = "State",
            ["PinCode"] = "Pin Code",
            ["PrimaryMobileNo"] = "Mobile No",
            ["NatureOfComplaint"] = "Nature of Complaint",
            ["ClosureStstaus"] = "Closure Status",
            ["ClosureRemarks"] = "Closure Remarks",
            ["NoOfdefect"] = "No. of Defects",
            ["ServiceCost"] = "Service Cost",
            ["SpecialApprovalCost"] = "Special Approval Cost",
            ["MaterialCost"] = "Material Cost",
            ["TotalCost"] = "Total Cost",
            ["PartConsumptionCost"] = "Part Cost",
            ["OEMName"] = "OEM",
            ["DealerName"] = "Dealer",
            ["VendorName"] = "Vendor",
            ["ComplainType"] = "Complaint Type",
            ["ReplacementTagApplied"] = "Replacement Tag Applied",
            ["IBNNumber"] = "IBN Number",
            ["DefectCategoryName1"] = "Defect Category 1",
            ["DefectName1"] = "Defect 1",
            ["DefectCategoryName2"] = "Defect Category 2",
            ["DefectName2"] = "Defect 2",
            ["DefectCategoryName3"] = "Defect Category 3",
            ["DefectName3"] = "Defect 3",
            ["DefectCategoryName4"] = "Defect Category 4",
            ["DefectName4"] = "Defect 4",
            ["TechnicianName"] = "ASM Name"
        };

        private static Dictionary<string, string> DefectHeaderMap() => new Dictionary<string, string>
        {
            ["DivisionName"] = "Division",
            ["ProductLineName"] = "Product Line",
            ["DefectCategoryName"] = "Defect Category",
            ["DefectDesc"] = "Defect Description",
            ["DefectCount"] = "Defect Count"
        };
    }
}
