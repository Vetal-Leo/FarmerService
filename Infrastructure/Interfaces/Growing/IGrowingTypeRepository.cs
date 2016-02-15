using System;
using Domain.Entities.Growing;

namespace Infrastructure.Interfaces.Growing
{
    public interface IGrowingTypeRepository : IRepositoryAsync<GrowingType>, IDisposable
    {
    }
}
