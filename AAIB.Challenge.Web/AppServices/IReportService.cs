using AAIB.Challenge.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAIB.Challenge.Web.AppServices
{
    public interface IReportService
    {
        public IList<Ticket> LoadSpamTickets();
        public bool ResolveReport(string reportId);
        public bool BlockReport(string reportId);
    }
}
