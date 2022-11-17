namespace UDPTracker.Data.Entities.Interfaces
{
    public interface IBaseEntity : ITrackable
    {
        Guid Id { get; set; }
    }
}