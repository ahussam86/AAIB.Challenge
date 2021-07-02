using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAIB.Challenge.Web.Models
{
    [Serializable]
    public class Ticket
    {
        public string Id { get; set; }
        public string State { get; set; }
        public string ReportType { get; set; }
        public string ReportId { get; set; }
        public string Message { get; set; }
    }
}
