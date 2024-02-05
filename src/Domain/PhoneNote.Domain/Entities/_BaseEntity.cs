namespace PhoneNote.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get;protected set; }
        public byte[] RowVersion { get; protected set; }
        public DateTime? UpdateDate { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public bool IsDeleted { get; protected set; }
    }
}
