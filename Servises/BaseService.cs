using System;
using Servises.Interfaces;

namespace Servises
{
    public class BaseService : IService, IDisposable
    {
        public virtual void Dispose()
        {
        }
    }
}
