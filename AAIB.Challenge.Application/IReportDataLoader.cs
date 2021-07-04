using AAIB.Challenge.Domain;
using System.Collections.Generic;

namespace AAIB.Challenge.Application
{
    public interface IReportDataLoader
    {
        
        IList<Ticket> LoadTicketsByReportType(string reportType);
    }
}
