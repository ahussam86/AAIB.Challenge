using AAIB.Challenge.Domain;
using System.Collections.Generic;

namespace AAIB.Challenge.Web.AppServices
{
    public interface IReportService
    {
        IList<Ticket> LoadSpamTickets();
        bool ResolveReport(string reportId);
        bool BlockReport(string reportId);
    }
}
