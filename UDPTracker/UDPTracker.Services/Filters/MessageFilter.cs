namespace UDPTracker.Services.Filters
{
    public class MessageFilter
    {
        public string? IP { get; set; }
        public DateTimeOffset? DateFrom { get; set; }
        public DateTimeOffset? DateTo { get; set; }
    }
}
