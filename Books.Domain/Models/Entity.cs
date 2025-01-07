namespace Books.Domain.Models
{
    public abstract class Entity<T> : IEntity<T>
    {
        public T Id { get; set; }
    }
}
