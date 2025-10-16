using IG.CG.Core.Application.Models;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IG.CG.ServiceManagement.API.Helpers
{
    public static class AscIbnReportCsvExportHelper
    {
        public static MemoryStream GenerateZipWithCsvFile(IEnumerable<IBNManagmentModel> data)
        {
            var zipStream = new MemoryStream();
            using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
            {
                AddCsvToZip(archive, "IBNReport.csv", data.ToList(), HeaderMap());
            }
            zipStream.Position = 0;
            return zipStream;
        }

        private static void AddCsvToZip(ZipArchive archive, string fileName, List<IBNManagmentModel> data, Dictionary<string, string> headerMap)
        {
            var entry = archive.CreateEntry(fileName);
            using var entryStream = entry.Open();
            using var writer = new StreamWriter(entryStream, Encoding.UTF8);

            writer.WriteLine(string.Join(",", headerMap.Values));

            foreach (var item in data)
            {
                var values = headerMap.Keys.Select(key =>
                {
                    var prop = typeof(IBNManagmentModel).GetProperty(key, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                    var val = prop?.GetValue(item, null);

                    var isIdLike = key == "ServiceTicketNumber" || key == "IBNNumber" || key == "ProductCode" || key == "SerialNo";

                    var str = val?.ToString() ?? string.Empty;

                    str = str.Replace("\"", "\"\"");

                    if (val is decimal dec)
                        str = dec.ToString("0.00");

                    if (isIdLike && !string.IsNullOrEmpty(str))
                        str = "\t" + str;

                    return $"\"{str}\"";
                });

                writer.WriteLine(string.Join(",", values));
            }
        }

        private static Dictionary<string, string> HeaderMap() => new Dictionary<string, string>
        {
            ["RegionName"] = "Region",
            ["BranchName"] = "Branch",
            ["ServiceTicketNumber"] = "Service Ticket No",
            ["TicketLoggedDate"] = "Ticket Logged Date",
            ["TicketLoggedTime"] = "Ticket Logged Time",
            ["WebClosureDate"] = "Web Closure Date",
            ["ComplaintAgeDays"] = "Complaint Age (Days)",
            ["DivisionName"] = "Division",
            ["ProductLineName"] = "Product Line",
            ["ProductCode"] = "Product Code",
            ["SerialNo"] = "Serial No",
            ["BusinessCall"] = "Business Call",
            ["WarrantyStatusAsPerBatch"] = "Warranty Status (Batch)",
            ["WarrantyStatusAsPerInvoiceDate"] = "Warranty Status (Invoice)",
            ["ClosureStatus"] = "Closure Status",
            ["ClosureRemarks"] = "Closure Remarks",
            ["ASCName"] = "ASC Name",
            ["NoOfdefect"] = "No. of defect",
            ["DefectName1"] = "Defect 1",
            ["DefectCategoryName1"] = "Defect Category 1",
            ["DefectName2"] = "Defect 2",
            ["DefectCategoryName2"] = "Defect Category 2",
            ["DefectName3"] = "Defect 3",
            ["DefectCategoryName3"] = "Defect Category 3",
            ["DefectName4"] = "Defect 4",
            ["DefectCategoryName4"] = "Defect Category 4",
            ["ServiceCost"] = "Service Cost",
            ["MaterialCost"] = "Material Cost",
            ["SpecialApprovalCost"] = "Special Approval Cost",
            ["TotalCost"] = "Total Cost",
            ["PartConsumptionCost"] = "Part Consumption Cost",
            ["IBNNumber"] = "IBN Number",
            ["IBNGeneratedDate"] = "IBN Generated Date",
            ["IBMAmount"] = "IBM Amount",
            ["IBNMonth"] = "IBN Month",
            ["ASMName"] = "ASM Name",
            ["ASMClaimApprovedDate"] = "ASM Claim Approved Date",
            ["RSMName"] = "RSM Name",
            ["RSMClaimApprovedDate"] = "RSM Claim Approved Date"
        };
    }
}