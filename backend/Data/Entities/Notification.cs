namespace Data.Entities
{
    public class Notification : BaseEntity
    {
        public string NotificationName { get; set; }

        public int IdeaId { get; set; }

        public virtual Idea Ideas { get; set; }
    }
}