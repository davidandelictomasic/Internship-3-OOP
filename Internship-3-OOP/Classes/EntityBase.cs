namespace Internship_3_OOP.Classes
{
    public abstract class EntityBase
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

        public DateTime UpdatetAt { get; protected set; } = DateTime.UtcNow;

        public void UpdateTimestamp()
        {
            UpdatetAt = DateTime.UtcNow;
        }
    }
}
