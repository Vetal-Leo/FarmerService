using System;
using Domain.Entities.Growing.FieldGrowing;

namespace Infrastructure.Interfaces.Growing
{
    public interface IBreadProfitsRepository : IRepositoryAsync<BreadProfit>, IDisposable
    {
       
    }

}
