using System;

namespace AAIB.Challenge.Domain
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
