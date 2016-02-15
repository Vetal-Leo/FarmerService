using System;
using Domain.Entities.Growing;

namespace Infrastructure.Interfaces.Growing
{
    public interface IGrowingChargesRepository : IRepositoryAsync<GrowingCharges>, IDisposable
    {
    }

}
