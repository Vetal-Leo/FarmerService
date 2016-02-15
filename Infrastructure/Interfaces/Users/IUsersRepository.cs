using System;
using Domain.Entities;
using Domain.Entities.User;

namespace Infrastructure.Interfaces.Users
{
    public interface IUsersRepository : IRepositoryAsync<FarmerUser>, IDisposable
    {
    }
}
