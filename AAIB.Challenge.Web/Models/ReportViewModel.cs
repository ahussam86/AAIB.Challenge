using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAIB.Challenge.Web.Models
{
    public class ReportViewModel
    {
        public IList<Ticket> Tickets { get; }

        public ReportViewModel(IList<Ticket> tickets)
        {
            Tickets =new List<Ticket>(tickets);
        }
    }
}
