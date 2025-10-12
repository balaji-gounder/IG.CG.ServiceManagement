using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IG.CG.ServiceManagement.WebApi.Helpers
{
    public static class PartConsumptionReportCsvExportHelper
    {
        //public static MemoryStream GenerateCsvStream<T>(List<T> data, Dictionary<string, string> headerMap)
        //{
        //    var stream = new MemoryStream();
        //    var encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
        //    using var writer = new StreamWriter(stream, encoding, bufferSize: 8192, leaveOpen: true);

        //    var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
        //                         .ToDictionary(p => p.Name, p => p);

        //    var sb = new StringBuilder(2048);

        //    writer.WriteLine(string.Join(",", headerMap.Values));

        //    foreach (var item in data)
        //    {
        //        sb.Clear();
        //        foreach (var key in headerMap.Keys)
        //        {
        //            if (props.TryGetValue(key, out var prop))
        //            {
        //                var value = prop.GetValue(item)?.ToString() ?? "";

        //                if (key == "SomeCodeOrId")
        //                    value = "\t" + value;

        //                value = $"\"{value.Replace("\"", "\"\"")}\"";
        //                sb.Append(value).Append(',');
        //            }
        //            else
        //            {
        //                sb.Append("\"\"").Append(',');
        //            }
        //        }

        //        if (sb.Length > 0)
        //        {
        //            sb.Length--;
        //            writer.WriteLine(sb.ToString());
        //        }
        //    }

        //    writer.Flush();
        //    stream.Position = 0;
        //    return stream;
        //}

        public static MemoryStream GenerateCsvStream<T>(List<T> data, Dictionary<string, string> headerMap)
        {
            var stream = new MemoryStream();
            var encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
            using var writer = new StreamWriter(stream, encoding, bufferSize: 8192, leaveOpen: true);

            var props = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToDictionary(p => p.Name, p => p, StringComparer.OrdinalIgnoreCase);

            var idLikeKeys = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "ServiceTicketNumber",
                "IBNNumber",
                "ProductCode",
                "SerialNo",
                "ProductSerialNumber",
                "TicketNumber",
                "SomeCodeOrId"
            };

            var sb = new StringBuilder(2048);

            writer.WriteLine(string.Join(",", headerMap.Values));

            foreach (var item in data)
            {
                sb.Clear();

                foreach (var key in headerMap.Keys)
                {
                    if (props.TryGetValue(key, out var prop))
                    {
                        var val = prop.GetValue(item, null);
                        string str;

                        if (val is null)
                        {
                            str = string.Empty;
                        }
                        else if (val is decimal dec)
                        {
                            str = dec.ToString("0.00");
                        }
                        else if (val is DateTime dt)
                        {
                            str = dt.ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        else
                        {
                            str = val.ToString();
                        }

                        str = str.Replace("\"", "\"\"");

                        if (idLikeKeys.Contains(key) && !string.IsNullOrEmpty(str))
                            str = "\t" + str;

                        sb.Append('"').Append(str).Append('"').Append(',');
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

        public static MemoryStream GenerateZippedCsvStream<T>(List<T> data, Dictionary<string, string> headerMap, string csvFileName = "PartConsumptionReport.csv")
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

        public static Dictionary<string, string> PartConsumptionHeaderMap()
        {
            return new Dictionary<string, string>
            {
                ["Region"] = "Region",
                ["Branch"] = "Branch",
                ["TicketMonth"] = "Ticket Month",
                ["TicketNumber"] = "Ticket Number",
                ["LoggedDate"] = "Logged Date",
                ["ClosedDate"] = "Closed Date",
                ["WarrantyStatus"] = "Warranty Status",
                ["Natureofcomplaint"] = "Nature of Complaint",
                ["ProductDivisionDesc"] = "Product Division Description",
                ["ProductLineDesc"] = "Product Line Description",
                ["ProductGroup"] = "Product Group",
                ["ProductCode"] = "Product Code",
                ["ProductSerialNumber"] = "Product Serial Number",
                ["AuthorisedServiceContractor"] = "Authorised Service Contractor",
                ["ComplaintAge"] = "Complaint Age",
                ["CustomerFirstName"] = "Customer First Name",
                ["CustomerContactNo"] = "Customer Contact Number",
                ["ClosureStatus"] = "Closure Status",
                ["ClosureRemarks"] = "Closure Remarks",
                ["SpareCode"] = "Spare Code",
                ["SpareDescription"] = "Spare Description",
                ["SpareSerialNumber"] = "Spare Serial Number",
                ["Quantity"] = "Quantity",
                ["Rate"] = "Rate",
                ["Total"] = "Total",
            };
        }
    }
}
