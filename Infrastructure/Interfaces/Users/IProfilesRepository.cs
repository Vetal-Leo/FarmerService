using System;
using Domain.Entities;
using Domain.Entities.User;

namespace Infrastructure.Interfaces.Users
{
    public interface IProfilesRepository : IRepositoryAsync<Profile>, IDisposable
    {

    }
}
