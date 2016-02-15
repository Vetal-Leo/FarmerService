using System;
using Domain.Entities.Growing;

namespace Infrastructure.Interfaces.Growing
{
    public interface IGrowingFruitProfitsRepository : IRepositoryAsync<GrowingFruitProfits>, IDisposable
    {
    }
}
