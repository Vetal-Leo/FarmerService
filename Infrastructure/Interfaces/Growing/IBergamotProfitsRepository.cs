using System;
using Domain.Entities.Growing.FruitGrowing;

namespace Infrastructure.Interfaces.Growing
{
    public interface IBergamotProfitsRepository : IRepositoryAsync<BergamotProfit>, IDisposable
    {
       
    }

}
