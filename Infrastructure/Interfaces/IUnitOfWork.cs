using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        bool EnableSaveChanges { get; set; }

        bool EnableDetectChanges { get; set; }

        bool EnableValidation { get; set; }

        Task SaveChangesAsync();
      
    }
}
