using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;


namespace IG.CG.ServiceManagement.WebApi.Helpers
{
    public static class ClaimListingCsvExportHelper
    {
        public static MemoryStream GenerateCsvStream<T>(List<T> data, Dictionary<string, string> headerMap)
        {
            var stream = new MemoryStream();
            var encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
            using var writer = new StreamWriter(stream, encoding, bufferSize: 8192, leaveOpen: true);

            // Cache properties of T in a case-insensitive dictionary for fast lookup
            var props = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToDictionary(p => p.Name, StringComparer.OrdinalIgnoreCase);

            writer.WriteLine(string.Join(",", headerMap.Values));

            foreach (var item in data)
            {
                var values = headerMap.Keys.Select(key =>
                {
                    // Try get the property (case-insensitive)
                    if (!props.TryGetValue(key, out var prop))
                        return "\"\"";

                    var val = prop.GetValue(item, null);
                    string str;

                    if (val == null)
                    {
                        str = string.Empty;
                    }
                    else if (val is decimal dec)
                    {
                        // Use invariant culture for consistent decimal formatting
                        str = dec.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else if (val is double d)
                    {
                        str = d.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else if (val is float f)
                    {
                        str = f.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else if (val is DateTime dt)
                    {
                        // Adjust format if you need a different date format
                        str = dt.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        str = Convert.ToString(val, System.Globalization.CultureInfo.InvariantCulture) ?? string.Empty;
                    }

                    // Determine ID-like keys that should be prefixed with a tab to preserve formatting in Excel
                    var isIdLike = string.Equals(key, "ServiceTicketNumber", StringComparison.OrdinalIgnoreCase)
                                 || string.Equals(key, "IBNNumber", StringComparison.OrdinalIgnoreCase)
                                 || string.Equals(key, "ProductCode", StringComparison.OrdinalIgnoreCase)
                                 || string.Equals(key, "SerialNo", StringComparison.OrdinalIgnoreCase);

                    if (isIdLike && !string.IsNullOrEmpty(str))
                        str = "\t" + str;

                    // Escape quotes for CSV and wrap in quotes
                    str = str.Replace("\"", "\"\"");
                    return $"\"{str}\"";
                });

                writer.WriteLine(string.Join(",", values));
            }

            writer.Flush();
            stream.Position = 0;
            return stream;
        }


        public static MemoryStream GenerateZippedCsvStream<T>(List<T> data, Dictionary<string, string> headerMap, string csvFileName = "ClaimLsiting.csv")
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

        public static Dictionary<string, string> ClaimlistingHeaderMap()
        {
            return new Dictionary<string, string>
            {
                ["RegionName"] = "Region",
                ["BranchName"] = "Branch",
                ["ASCName"] = "ASC Name",
                ["ASMName"] = "ASM Name",
                ["ServiceTicketNumber"] = "Ticket Number",
                ["ClaimNo"] = "Claim No",
                ["ClaimGenerationDate"] = "Claim Generation Date",
                ["TicketCreatedOn"] = "Ticket Date",
                ["DivisionName"] = "Division Name",
                ["ProductCode"] = "Product Code",
                ["SerialNo"] = "Serial Number",
                ["ProductLineName"] = "Product Line",
                ["ProductDescription"] = "Product Decsription",
                ["Type"] = "Complain Type",
                ["InvoiceNo"] = "Invoice Number",
                ["ActivityName"] = "Activity",
                ["Parameter"] = "Parameter",
                ["PossibleValue"] = "Possible Value",
                ["Qty"] = "Quantity",
                ["Rate"] = "Rate",
                ["TotalAmount"] = "Total Amount",
                ["ClaimRemarksByASC"] = "ASC Remarks",
                ["ASMStatus"] = "ASM Status",
                ["ASMApprovedRemarks"] = "ASM Approval Remarks",
                ["ASMApprovedOn"] = "ASM Approved Date",
                ["RSMStatus"] = "RSM Status",
                ["RSMApprovedRemarks"] = "RSM Approval Remarks",
                ["RSMApprovedOn"] = "RSM Approved Date",
                ["IBN"] = "IBN Number",
                ["IBNGenerationOn"] = "IBN Generation Date",
                ["IsClaimResubmission"] = "Is claim Submission",
                ["AscJustification"] = "ASC Justification"
            };
        }
    }
}
