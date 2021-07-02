using AAIB.Challenge.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAIB.Challenge.Web.AppServices
{
    public interface IReportDataLoader
    {
        
        public IList<Ticket> LoadTicketsByReportType(string reportType);
    }
}
