using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;

namespace Infrastructure.Interfaces
{
    public interface IEntity<TKey> where TKey : struct
    {
        [Key]
        TKey Id { get; set; }
    }

    public interface IEntity : IEntity<int>
    {
    }
}
