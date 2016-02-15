using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Infrastructure.Interfaces.Users;
using Servises.Interfaces;

namespace Servises.Users
{
    public class ProfileService : BaseService, IProfileService
    {
        #region Declarations
        private IProfilesRepository _profileRepository;
        private readonly IUsersRepository _usersRepository;
        #endregion

        #region Ctors
      
        public ProfileService(IProfilesRepository profileRepository, IUsersRepository usersRepository)
        {
            _profileRepository = profileRepository;
            _usersRepository = usersRepository;
        }
        #endregion



        public async Task<int> SaveName(int userid, string name, string lastname, string patronymic, string birthday, string phone)
        {
            if (name == null || lastname == null || patronymic == null || birthday == null || phone == null) return 1;
            phone = phone.Replace("ϙ", "+");
            if (!ValidatePhone(phone)) return 2;
            var profile = _profileRepository.Get().Where(i => i.Id == userid).ToList()[0];
            profile.Name = name;
            profile.LastName = lastname;
            profile.Patronymic = patronymic;
            profile.Birthday = DateTime.Parse(birthday);        
            var user = _usersRepository.Get().Where(i => i.Id == userid).ToList()[0];
            user.PhoneNumber = phone;
            await  _profileRepository.SaveChangesAsync();
            await  _usersRepository.SaveChangesAsync(); 
            return 0;
        }

        private static bool ValidatePhone(string phone)
        {   
            var regex = new Regex("^\\+?[0-9]{7,12}$");
            return regex.IsMatch(phone);
        }


        public override void Dispose()
        {
            if (_profileRepository == null) return;
            _profileRepository.Dispose();
            _profileRepository = null;

        }

      
    }
}
