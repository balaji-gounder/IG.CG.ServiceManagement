using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IG.CG.ServiceManagement.WebApi.Helpers
{
    public static class CostingReportCsvExportHelper
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

                        if (key == "SomeCodeOrId")
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

        public static MemoryStream GenerateZippedCsvStream<T>(List<T> data, Dictionary<string, string> headerMap, string csvFileName = "CostingReport.csv")
        {
            using var csvStream = GenerateCsvStream(data, headerMap);
            csvStream.Position = 0;

            var zipStream = new MemoryStream();
            using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create, leaveOpen: true))
            {
                var entry = archive.CreateEntry(csvFileName, CompressionLevel.Fastest);
                using var entryStream = entry.Open();
                csvStream.CopyTo(entryStream);
            }

            zipStream.Position = 0;
            return zipStream;
        }

        public static Dictionary<string, string> CostingHeaderMap()
        {
            return new Dictionary<string, string>
            {
                ["Region"] = "Region",
                ["Branch"] = "Branch",
                ["ProductDivision"] = "Product Division",
                ["ProductLine"] = "Product Line",
                ["ProductGroup"] = "Product Group",
                ["ProductCode"] = "Product Code",
                ["ProductDescription"] = "Product Description",
                ["TicketMonth"] = "Ticket Month",
                ["AuthorisedServiceContractor"] = "ASC",
                ["TicketNumber"] = "Ticket Number",
                ["TicketDate"] = "Ticket Date",
                ["FinalClaimApprovedDate"] = "Claim Approved Date",
                ["DistanceType"] = "Distance Type",
                ["RepairType"] = "Repair Type",
                ["IBNNO"] = "IBN No",
                ["IBNGeneratedDate"] = "IBN Generated Date",
                ["SpecialApprovalCost"] = "Special Approval Cost",
                ["ServiceCharges"] = "Service Charges",
                ["Conveyance"] = "Conveyance",
                ["LodgingDAFood"] = "Lodging / DA / Food",
                ["Rewinding"] = "Rewinding",
                ["RepairCharges"] = "Repair Charges",
                ["SundryCharges"] = "Sundry Charges",
                ["TotalAmount"] = "Total Amount"
            };
        }
    }
}