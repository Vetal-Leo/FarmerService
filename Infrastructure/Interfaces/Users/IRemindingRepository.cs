using System;
using Domain.Entities.User;

namespace Infrastructure.Interfaces.Users
{
    public interface IRemindingRepository : IRepositoryAsync<Reminding>, IDisposable
    {
       
    }
}
