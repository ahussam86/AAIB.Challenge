using AAIB.Challenge.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AAIB.Challenge.Web.AppServices
{
    public class JsonReportDataLoader : IReportDataLoader
    {
        public string FilePath { get; private set; }
        public JsonReportDataLoader(string filePath)
        {
            FilePath = filePath;
        }
        public IList<Ticket> LoadTicketsByReportType(string reportType)
        {
            var lstTickets = new List<Ticket>();
            using (FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader sw = new StreamReader(fs))
                {
                    var content = sw.ReadToEnd();
                    dynamic dynReports = JsonConvert.DeserializeObject(content);
                    List<dynamic> dynlstReports = JsonConvert.DeserializeObject<List<dynamic>>(dynReports?.elements?.ToString());
                    foreach (var dynReport in dynlstReports)
                    {
                        var ticket = CreateTicket(dynReport);
                        if (ticket.ReportType.Equals(reportType, StringComparison.InvariantCultureIgnoreCase))
                            lstTickets.Add(ticket);
                    }
                }
            }
            return lstTickets;
        }

        private Ticket CreateTicket(dynamic dynReport)
        {
            Ticket ticket=new Ticket();
            ticket.Id = FormatValue(dynReport?.id?.ToString());
            ticket.State = FormatValue(dynReport?.state?.ToString());
            var dynPayload = JsonConvert.DeserializeObject(dynReport?.payload?.ToString());
            ticket.ReportType = FormatValue(dynPayload?.reportType?.ToString());
            ticket.ReportId = FormatValue(dynPayload?.reportId?.ToString());
            ticket.Message = FormatValue(dynPayload?.message?.ToString());
            return ticket;
        }

        const string EMPTYSTR = "N/A";
        private string FormatValue(string val)
        {
            return !string.IsNullOrWhiteSpace(val)?val: EMPTYSTR;
        }
    }
}
