using AAIB.Challenge.Web.Models;
using System.Collections.Generic;

namespace AAIB.Challenge.Web.AppServices
{
    public interface IReportDataLoader
    {
        
        IList<Ticket> LoadTicketsByReportType(string reportType);
    }
}
