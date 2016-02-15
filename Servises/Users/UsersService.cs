using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain.Entities.User;
using Infrastructure.Interfaces.Breeding;
using Infrastructure.Interfaces.Growing;
using Infrastructure.Interfaces.Users;
using Servises.Interfaces;

namespace Servises.Users
{
    public class UsersService : BaseService, IUsersService
    {
        #region Declarations

        private IUsersRepository _usersRepository;
        private IRemindingRepository _remindingRepository;
        private IGrowingFieldProfitsRepository _growingFieldProfitsRepository;
        private IGrowingFruitProfitsRepository _growingFruitProfitsRepository;
        private IBreedingRemindingRepository _breedingRemindingRepository;
        #endregion



        #region Ctors

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public UsersService(IRemindingRepository remindingRepository)
        {
            _remindingRepository = remindingRepository;
        }

        public UsersService(IGrowingFieldProfitsRepository growingFieldProfitsRepository,
            IGrowingFruitProfitsRepository growingFruitProfitsRepository,
            IBreedingRemindingRepository breedingRemindingRepository,
            IRemindingRepository remindingRepository, IUsersRepository usersRepository)
        {
            _growingFieldProfitsRepository = growingFieldProfitsRepository;
            _growingFruitProfitsRepository = growingFruitProfitsRepository;
            _breedingRemindingRepository = breedingRemindingRepository;
            _remindingRepository = remindingRepository;
            _usersRepository = usersRepository;
        }
        #endregion


        public async Task Activation(string email)
        {
            var users = _usersRepository.Get().Where(e => e.Email == email).ToList()[0];
            users.EmailConfirmed = true;
            await _usersRepository.SaveChangesAsync();
        }

        public async Task UpdateUserEmail(int userid, string newemail)
        {
            var users = _usersRepository.Get().Where(i => i.Id == userid).ToList()[0];
            users.Email = newemail;
            users.EmailConfirmed = false;
            users.UserName = newemail;
            await _usersRepository.SaveChangesAsync();
        }
        public async Task ActivateAccount(string newlogin)
        {
            var users = _usersRepository.Get().Where(i => i.Email == newlogin).ToList()[0];
            users.EmailConfirmed = true;
            users.Remind = true;
            await _usersRepository.SaveChangesAsync();
        }

        public List<Reminding> GetRemindings(int id)
        {
            return _remindingRepository.Get().Where(i => i.User.Id == id).ToList();
        }

        public void RemindingFill(int id)
        {
            ClierRemindings(id);

            //Reminders of Field Culture.
            var fieldtypes = new List<string>
            {
                "Bread",
                "Leguminous",
                "Tuber",
                "Spicy",
                "Melon",
                "Olive",
                "Silage",
                "Fodder",
                "Fodder",
                "Forage"
            };
            var newremind = new Reminding();
            var user = _usersRepository.Get().FirstOrDefault(i => i.Id == id);
            foreach (var profit in fieldtypes.Select(type => _growingFieldProfitsRepository.Get().Where(i => i.User.Id == id &&
            i.GrowingType.Name == type).ToList()).SelectMany(fieldprofits => fieldprofits.Where(profit => profit.ExpirationDate != null).
            Where(profit => DateTime.Now > profit.ExpirationDate.Value.AddDays(-21) && profit.Remind)))
            {
                newremind.Name = profit.Name;
                newremind.ExpirationDate = profit.ExpirationDate;
                newremind.User = user;
                if (!IsReminding(profit.Name, profit.ExpirationDate)) _remindingRepository.Add(newremind);
            }

            //Reminders of Fruit Culture.
            var fruittypes = new List<string>
            {
                "Bergamot",
                "Kepel",
                "Finik",
                "Crataegus",
                "Tern",
                "Strawberry",
            };
            foreach (var profit in fruittypes.Select(type => _growingFruitProfitsRepository.Get().Where(i => i.User.Id == id &&
            i.GrowingType.Name == type).ToList()).SelectMany(fruitprofits => fruitprofits.Where(profit => profit.ExpirationDate != null).
            Where(profit => DateTime.Now > profit.ExpirationDate.Value.AddDays(-21) && profit.Remind)))
            {
                newremind.Name = profit.Name;
                newremind.ExpirationDate = profit.ExpirationDate;
                newremind.User = user;
                if (!IsReminding(profit.Name, profit.ExpirationDate)) _remindingRepository.Add(newremind);
            }

            //Reminders of Breeding.
            var breendingtypes = new List<string>
            {
                "Сamel",
                "Goat",
                "Horse",
                "Pony",
                "RabbitSkin",
                "RabbitMeat",
                "Sheep",
                "HenMeat",
                "HenEgg",
                "Goose",
                "Quail",
                "Bee",
                "TeplovyeFish",
                "СoldwaterFish",
                "Swine",
                "Cattlemeat",
                "Cattlemilk",
                "Cattlemixed",
                "Pinscherdog",
                "Houndsdog",
                "Сopsdog",
                "Borzoidog"
            };
            foreach (var remind in breendingtypes.Select(type => _breedingRemindingRepository.Get().Where(i => i.User.Id == id &&
            i.BreedingType.Name == type).ToList()).SelectMany(breedingprofits => breedingprofits.Where(remind => remind.RemindDate != null).
            Where(remind => DateTime.Now >= remind.RemindDate && DateTime.Now <= remind.RemindDate.Value.AddDays(Convert.ToInt32(remind.RemindDays)))))
            {
                newremind.Name = remind.Text;
                newremind.ExpirationDate = remind.RemindDate;
                newremind.User = user;
                if (!IsReminding(remind.Text, remind.RemindDate)) _remindingRepository.Add(newremind);
            }

        }

        public List<FarmerUser> GetAllUsers(int adminId)
        {
            return _usersRepository.Get().Where(i => i.Id != adminId).ToList();
        }

        public FarmerUser GetUsersById(int id)
        {
            return _usersRepository.Get().FirstOrDefault(i => i.Id == id);
        }

        public async Task AddNewUsersById(int id, FormCollection collection)
        {
            var picked = _usersRepository.Get().Where(i => i.Id == id).ToList()[0];
            var state = collection[1].Split(',')[0];
            picked.АccountBlocking = Convert.ToBoolean(state);
            await _usersRepository.UpdateAsync(picked);
        }

        private void ClierRemindings(int id)
        {
            var reminds = _remindingRepository.Get().Where(i => i.User.Id == id).ToList();
            foreach (var remind in reminds)
            {
                _remindingRepository.Delete(remind.Id);
            }
        }

        private bool IsReminding(string name, DateTime? expirationDate)
        {
            return _remindingRepository.Get().FirstOrDefault(n => n.Name == name && n.ExpirationDate == expirationDate) != null;
        }


        public override void Dispose()
        {
            if (_usersRepository == null) return;
            _usersRepository.Dispose();
            _usersRepository = null;

            if (_remindingRepository == null) return;
            _remindingRepository.Dispose();
            _remindingRepository = null;

            if (_growingFieldProfitsRepository == null) return;
            _growingFieldProfitsRepository.Dispose();
            _growingFieldProfitsRepository = null;

            if (_growingFruitProfitsRepository == null) return;
            _growingFruitProfitsRepository.Dispose();
            _growingFruitProfitsRepository = null;

            if (_breedingRemindingRepository == null) return;
            _breedingRemindingRepository.Dispose();
            _breedingRemindingRepository = null;
        }
    }
}
