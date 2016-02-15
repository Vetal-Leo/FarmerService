using System;
using Domain.Entities.Growing.FieldGrowing;

namespace Infrastructure.Interfaces.Growing
{
    public interface IForageChargesRepository : IRepositoryAsync<ForageCharges>, IDisposable
    {
    }

}
