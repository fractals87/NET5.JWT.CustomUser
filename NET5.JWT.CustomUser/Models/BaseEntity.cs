namespace NET5.JWT.CustomUser.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        //TODO: Da integrare con campo concurrency
        //[Timestamp]
        //public byte[] RowVersion { get; set; }

        //TODO: Da integrare con Pattern DomainEvent
        //public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}