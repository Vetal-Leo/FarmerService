using System.ComponentModel.DataAnnotations;

namespace Domain.Interfaces
{
    public interface IEntity<T>
    {
        [Key]
        T Id { get; set; }
    }

    public interface IEntity : IEntity<int>
    {
    }
}
