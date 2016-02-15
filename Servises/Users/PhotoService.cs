using System.Linq;
using Infrastructure.Interfaces.Users;
using Servises.Interfaces;

namespace Servises.Users
{
    public class PhotoService : BaseService, IPhotoService
    {
        #region Declarations
        private IPhotoRepository _photoRepository;
        private IProfilesRepository _profileRepository;
        #endregion

        #region Ctors

        public PhotoService(IPhotoRepository photoRepository) 
        {
            _photoRepository = photoRepository;

        }
        #endregion


        public string SavePhotoNameInDataBase(string article, int userid, string filename)
        {
            var oldimage = string.Empty;
            switch (article)
            {
                case "Avatar":
                    var firstAvatar = _photoRepository.Get().FirstOrDefault(i => i.Id == userid);
                    if (firstAvatar != null)
                    {
                        oldimage = firstAvatar.Avatar;
                        firstAvatar.Avatar = filename;
                    }
                    _photoRepository.SaveChangesAsync();
                    break;
                case "Growing":
                    var firstGrowing = _photoRepository.Get().FirstOrDefault(i => i.Id == userid);
                    if (firstGrowing != null)
                    {
                        oldimage = firstGrowing.Growing;
                        firstGrowing.Growing = filename;
                    }
                    _photoRepository.SaveChangesAsync();
                    break;
                case "Breeding":
                    var firstBreeding = _photoRepository.Get().FirstOrDefault(i => i.Id == userid);
                    if (firstBreeding != null)
                    {
                        oldimage = firstBreeding.Breeding;
                        firstBreeding.Breeding = filename;
                    }
                    _photoRepository.SaveChangesAsync();
                    break;
                case "Technic":
                    var firstTechnic = _photoRepository.Get().FirstOrDefault(i => i.Id == userid);
                    if (firstTechnic != null)
                    {
                        oldimage = firstTechnic.Technique;
                        firstTechnic.Technique = filename;
                    }
                    _photoRepository.SaveChangesAsync();
                    break;
                case "Product":
                    var firstProduct = _photoRepository.Get().FirstOrDefault(i => i.Id == userid);
                    if (firstProduct != null)
                    {
                        oldimage = firstProduct.Product;
                        firstProduct.Product = filename;
                    }
                    _photoRepository.SaveChangesAsync();
                    break;
            }
            return oldimage;
        }


        public override void Dispose()
        {
            if (_photoRepository == null) return;
            _photoRepository.Dispose();
            _photoRepository = null;

            if (_profileRepository == null) return;
            _profileRepository.Dispose();
            _profileRepository = null;
        }
    }
}
