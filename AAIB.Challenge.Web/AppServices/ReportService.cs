
using AAIB.Challenge.Application;
using AAIB.Challenge.Domain;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace AAIB.Challenge.Web.AppServices
{
    public class ReportService : IReportService
    {

        const string TICKETSKEY = "tickets";
        const string SPAMREPORT = "SPAM";

        private IMemoryCache Cache;
        
        private IReportDataLoader ReportDataLoader;
        public  ReportService(IMemoryCache cache,IReportDataLoader reportDataLoader)
        {
            Cache = cache;
            ReportDataLoader = reportDataLoader;
        }

        public IList<Ticket> LoadSpamTickets()
        {
            IList<Ticket> tickets;
            if (Cache.TryGetValue(TICKETSKEY, out tickets))
                return tickets;

            tickets = ReportDataLoader.LoadTicketsByReportType(SPAMREPORT);
            Cache.Set(TICKETSKEY, tickets);
            return tickets;
        }

        public bool BlockReport(string reportId)
        {
            /*
             * Not sure where to go from here based on the requirements provided
             */
            return true;
        }

        public bool ResolveReport(string reportId)
        {
            /*
             * Not sure where to go from here based on the requirements provided
             */
            return true;
        }
    }
}
