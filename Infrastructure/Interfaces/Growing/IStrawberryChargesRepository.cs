using System;
using Domain.Entities.Growing.FruitGrowing;

namespace Infrastructure.Interfaces.Growing
{
    public interface IStrawberryChargesRepository : IRepositoryAsync<StrawberryCharges>, IDisposable
    {
    }

}
