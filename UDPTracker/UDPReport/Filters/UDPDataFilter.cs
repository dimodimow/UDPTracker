namespace UDPReport.Models
{
    public class UDPDataFilter
    {
        public string? IP { get; set; }
        public DateTimeOffset? DateFrom { get; set; }
        public DateTimeOffset? DateTo { get; set; }
    }
}