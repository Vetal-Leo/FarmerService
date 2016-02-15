using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servises.Interfaces
{
    public interface IProfileService : IDisposable
    {
        Task<int> SaveName(int userid, string name, string lastname, string patronymic, string birthday, string phone);
    }
}
