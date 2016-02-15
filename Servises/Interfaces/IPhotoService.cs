using System;

namespace Servises.Interfaces
{
    public interface IPhotoService : IDisposable
    {
        string SavePhotoNameInDataBase(string article, int userid, string filename);
    }
}
