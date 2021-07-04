using AAIB.Challenge.Domain;
using System.Collections.Generic;

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
