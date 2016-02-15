using System;
using Domain.Entities.Growing.FieldGrowing;

namespace Infrastructure.Interfaces.Growing
{
    public interface IOliveChargesRepository : IRepositoryAsync<OliveCharges>, IDisposable
    {
    }

}
