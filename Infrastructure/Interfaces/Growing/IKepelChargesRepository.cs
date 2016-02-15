using System;
using Domain.Entities.Growing.FruitGrowing;

namespace Infrastructure.Interfaces.Growing
{
    public interface IKepelChargesRepository : IRepositoryAsync<KepelCharges>, IDisposable
    {
    }

}
