using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain.Entities.Breeding;
using Infrastructure.Interfaces.Breeding;
using Infrastructure.Interfaces.Users;
using Servises.Interfaces;


namespace Servises.Breeding
{
    public partial class BreedingService : BaseService, IBreedingService
    {

        #region Declarations

        private IYoungBreedingRepository _youngBreedingRepository;
        private IBreedingComingsRepository _breedingComingsRepository;
        private IBeeComingsRepository _beeComingsRepository;
        private IFishComingsRepository _fishComingsRepository;
        private IBreedingChargesRepository _breedingChargesRepository;
        private IBreedingDailyProfitRepository _breedingDailyProfitRepository;
        private IBeeHoneyRepository _beeHoneyRepository;
        private IBreedingProfitRepository _breedingProfitRepository;
        private IFishProfitRepository _fishProfitRepository;
        private IBreedingRemindingRepository _breedingRemindingRepository;
        private IBreedingTypeRepository _breedingTypeRepository;
        private IBreedingCulturesRepository _breedingCulturesRepository;
        private static IHoneyTypeRepository _honeyTypeRepository;
        private IUsersRepository _usersRepository;

        #endregion

        #region Constructor 

        public BreedingService(IBreedingComingsRepository breedingComingsRepository)
        {
            _breedingComingsRepository = breedingComingsRepository;
        }
        public BreedingService(IBeeComingsRepository beeComingsRepository)
        {
            _beeComingsRepository = beeComingsRepository;
        }
        public BreedingService(IFishComingsRepository fishComingsRepository)
        {
            _fishComingsRepository = fishComingsRepository;
        }

        public BreedingService(IYoungBreedingRepository youngBreedingRepository, IBreedingComingsRepository breedingComingsRepository, IBeeComingsRepository beeComingsRepository,
           IFishComingsRepository fishComingsRepository, IBreedingChargesRepository breedingChargesRepository, IBreedingDailyProfitRepository breedingDailyProfitRepository,
           IBeeHoneyRepository beeHoneyRepository, IBreedingProfitRepository breedingProfitsRepository, IFishProfitRepository fishProfitRepository,
           IBreedingRemindingRepository breedingRemindingRepository, IBreedingTypeRepository breedingTypeRepository, IBreedingCulturesRepository breedingCulturesRepository,
           IHoneyTypeRepository honeyTypeRepository, IUsersRepository userRepository)
        {
            _youngBreedingRepository = youngBreedingRepository;
            _breedingComingsRepository = breedingComingsRepository;
            _beeComingsRepository = beeComingsRepository;
            _fishComingsRepository = fishComingsRepository;
            _breedingChargesRepository = breedingChargesRepository;
            _breedingDailyProfitRepository = breedingDailyProfitRepository;
            _beeHoneyRepository = beeHoneyRepository;
            _breedingProfitRepository = breedingProfitsRepository;
            _fishProfitRepository = fishProfitRepository;
            _breedingRemindingRepository = breedingRemindingRepository;
            _breedingTypeRepository = breedingTypeRepository;
            _breedingCulturesRepository = breedingCulturesRepository;
            _honeyTypeRepository = honeyTypeRepository;
            _usersRepository = userRepository;
        }

        #endregion


        #region BeeComing

        public List<BeeComings> GetBeeComings(int userId)
        {
            return Calculate(_beeComingsRepository.Get().Where(i => i.User.Id == userId && i.BreedingType.Name == "Bee").ToList());
        }

        public async Task AddNewBeeComing(int userId, FormCollection collection)
        {
            var bee = new BeeComings
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                BreedingType = _breedingTypeRepository.Get().FirstOrDefault(i => i.Name == "Bee"),
                ReceiptDate = DateTime.Parse(collection[1]),
                CultureType = collection[2],
                Name = collection[3],
                CurrencyType = collection[4],
                Cost = Convert.ToDecimal(collection[5].Replace(".", ",")),
                Amount = Convert.ToInt32(collection[6]),
                Document = FileNameValidator(collection[7])
            };

           await _beeComingsRepository.AddAsync(bee);
        }

        public BeeComings GetBeeComingById(int id)
        {
            var picked = _beeComingsRepository.Get().Where(i => i.Id == id).ToList()[0];
            return new BeeComings
            {
                ReceiptDate = picked.ReceiptDate,
                CultureType = picked.CultureType,
                Name = picked.Name,
                CurrencyType = picked.CurrencyType,
                Cost = picked.Cost,
                Amount = picked.Amount,
                Document = picked.Document,
                BreedingCultureses = _breedingCulturesRepository.Get().Where(c => c.BreedingType.Name == "Bee")
            };
        }

        public async Task AddNewBeeComingById(int id, FormCollection collection)
        {
            var picked = _beeComingsRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.ReceiptDate = DateTime.Parse(collection[1]);
            picked.CultureType = collection[2];
            picked.Name = collection[3];
            picked.CurrencyType = collection[4];
            picked.Cost = Convert.ToDecimal(collection[5].Replace(".", ","));
            picked.Amount = Convert.ToInt32(collection[6]);
            picked.Document = FileNameValidator(collection[7]);
  
            await _beeComingsRepository.UpdateAsync(picked);
        }

        public void DeleteBeeComingById(int id)
        {
            _beeComingsRepository.Delete(id);
        }

        #endregion


        #region BeeCharges

        public List<BreedingCharges> GetBeeCharges(int userId)
        {
            return Calculate(_breedingChargesRepository.Get().Where(i => i.User.Id == userId && i.BreedingType.Name == "Bee").ToList());
        }

        public List<string> GetBeeNamesById(int id)
        {
            var camels = _beeComingsRepository.Get().Where(i => i.User.Id == id && i.BreedingType.Name == "Bee").ToList();
            return camels.Select(item => item.Name).ToList();
        }

        public async Task AddNewBeeCharges(int userId, FormCollection collection)
        {
            var charges = new BreedingCharges
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                BreedingType = _breedingTypeRepository.Get().FirstOrDefault(i => i.Name == "Bee"),
                ApplicationDate = DateTime.Parse(collection[1]),
                AnimalName = collection[2],
                Name = collection[3],
                Document = FileNameValidator(collection[4]),
                TotalCost = Convert.ToDecimal(collection[5].Replace(".", ",")),
            };

            await _breedingChargesRepository.AddAsync(charges);
        }

        public BreedingCharges GetBeeChargesById(int id)
        {
            var picked = _breedingChargesRepository.Get().FirstOrDefault(i => i.Id == id);

            if (picked != null)
                return new BreedingCharges
                {
                    ApplicationDate = picked.ApplicationDate,
                    AnimalName = picked.AnimalName,
                    Name = picked.Name,
                    Document = picked.Document,
                    TotalCost = picked.TotalCost
                };
            return null;
        }

        public async Task AddNewBeeChargesById(int id, FormCollection collection)
        {
            var picked = _breedingChargesRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.ApplicationDate = DateTime.Parse(collection[1]);
            picked.AnimalName = collection[2];
            picked.Name = collection[3];
            picked.Document = FileNameValidator(collection[4]);
            picked.TotalCost = Convert.ToDecimal(collection[5].Replace(".", ","));

            await _breedingChargesRepository.UpdateAsync(picked);
        }

        public void DeleteBeeChargesById(int id)
        {
            _breedingChargesRepository.Delete(id);
        }

        #endregion


        #region BeeHoney

        public List<BeeHoney> GetBeeHoneys(int userId)
        {
            return Calculate(_beeHoneyRepository.Get().Where(i => i.User.Id == userId && i.BreedingType.Name == "Bee").ToList());
        }

       
        public async Task AddNewBeeHoney(int userId, FormCollection collection)
        {
            var beehoney = new BeeHoney
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                BreedingType = _breedingTypeRepository.Get().FirstOrDefault(i => i.Name == "Bee"),
                Date = DateTime.Parse(collection[1]),
                HoneyType = collection[3],
                MassType = collection[4],
                Amount = Convert.ToDecimal(collection[5].Replace(".", ",")),
                Cost = Convert.ToDecimal(collection[6].Replace(".", ",")),
                Document = FileNameValidator(collection[7]),
                AnimalName = collection[8]
            };

            await _beeHoneyRepository.AddAsync(beehoney);
        }

        public BeeHoney GetBeeHoneyById(int id)
        {
            var picked = _beeHoneyRepository.Get().FirstOrDefault(i => i.Id == id);
            if (picked != null)
                return new BeeHoney
                {
                    Date = picked.Date,
                    HoneyType = picked.HoneyType,
                    MassType = picked.MassType,
                    Amount = picked.Amount,
                    Cost = picked.Cost,
                    Document = picked.Document,
                    AnimalName = picked.AnimalName,
                    HoneyTypeses = _honeyTypeRepository.Get().ToList()
                };
            return null;
        }

        public async Task AddNewBeeHoneyById(int id, FormCollection collection)
        {
            var picked = _beeHoneyRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.Date = DateTime.Parse(collection[1]);
            picked.AnimalName = collection[2];
            picked.HoneyType = collection[3];
            picked.MassType = collection[4];
            picked.Amount = Convert.ToDecimal(collection[5].Replace(".", ","));
            picked.Cost = Convert.ToDecimal(collection[6].Replace(".", ","));
            picked.Document = FileNameValidator(collection[7]);
           
            await _beeHoneyRepository.UpdateAsync(picked);
        }

        public void DeleteBeeHoneyById(int id)
        {
            _beeHoneyRepository.Delete(id);
        }

        #endregion




        #region BeeRemiding

        public List<BreedingReminder> GetBeeRemindings(int userId)
        {
            return _breedingRemindingRepository.Get().Where(i => i.User.Id == userId && i.BreedingType.Name == "Bee").ToList();
        }

        public async Task AddNewBeeReminding(int userId, FormCollection collection)
        {
            var reminding = new BreedingReminder
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                BreedingType = _breedingTypeRepository.Get().FirstOrDefault(i => i.Name == "Bee"),
                AnimalName = collection[1],
                Text = collection[2],
                RemindDate = DateTime.Parse(collection[3]),
                RemindDays = Convert.ToInt32(collection[4])
            };

            await _breedingRemindingRepository.AddAsync(reminding);
        }

        public BreedingReminder GetBeeRemindingById(int id)
        {
            var picked = _breedingRemindingRepository.Get().FirstOrDefault(i => i.Id == id);
            if (picked != null)
                return new BreedingReminder
                {
                    AnimalName = picked.AnimalName,
                    Text = picked.Text,
                    RemindDate = picked.RemindDate,
                    RemindDays = picked.RemindDays
                };
            return null;
        }

        public async Task AddNewBeeRemindingById(int id, FormCollection collection)
        {
            var picked = _breedingRemindingRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.AnimalName = collection[1];
            picked.Text = collection[2];
            picked.RemindDate = DateTime.Parse(collection[3]);
            picked.RemindDays = Convert.ToInt32(collection[4]);

            await _breedingRemindingRepository.UpdateAsync(picked);
        }

        public void DeleteBeeRemindingById(int id)
        {
            _breedingRemindingRepository.Delete(id);
        }

        #endregion



        #region FileNameValidatortor

        private static string FileNameValidator(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename)) return string.Empty;
            var temp = filename.Substring(filename.Length - 4);
            if (temp.Equals(".pdf")) return "/Storefiles/" + filename;

            return string.Empty;
        }
        #endregion

        #region Calculate

        private static List<YoungBreeding> Calculate(List<YoungBreeding> list)
        {
            foreach (var item in list) item.TotalCost = item.Cost * item.Amount;
            return list;
        }

        private static List<BreedingComings> Calculate(List<BreedingComings> list)
        {
            foreach (var item in list) item.TotalCost = item.Cost * item.Amount;
            return list;
        }

        private static List<BeeComings> Calculate(List<BeeComings> list)
        {
            foreach (var item in list) item.TotalCost = item.Cost * item.Amount;
            return list;
        }

        private static List<FishComings> Calculate(List<FishComings> list)
        {
            foreach (var item in list) item.TotalCost = item.Cost * item.Amount;
            return list;
        }

        private static List<BreedingCharges> Calculate(List<BreedingCharges> list)
        {
            foreach (var item in list)
            {
                var samenamelist = list.Where(n => n.AnimalName == item.AnimalName).ToList();
                var sumcost = samenamelist.Aggregate<BreedingCharges, decimal?>(0, (current, same) => current + same.TotalCost);
                item.SumCost = sumcost;
            }

            return list;
        }

        private List<BreedingDailyProfit> Calculate(List<BreedingDailyProfit> list, int userId)
        {
            foreach (var item in list)
            {
                item.СlearCost = item.Cost * item.Amount;
                item.ProfitCost = item.Cost * item.Amount - GetSumCamelChargesForNameAndDate(item.AnimalName, item.Date, userId);
            }
            return list;
        }

        private static List<BeeHoney> Calculate(List<BeeHoney> list)
        {
            foreach (var item in list)
            {
                item.ProfitCost = item.Cost * item.Amount;
            }
            return list;
        }

        private static List<BreedingProfits> Calculate(List<BreedingProfits> list)
        {
            foreach (var item in list) item.ProfitCost = item.Cost * item.Amount;
            return list;
        }

        private static List<FishProfits> Calculate(List<FishProfits> list)
        {
            foreach (var item in list) item.ProfitCost = item.Cost * item.Amount;
            return list;
        }

        private decimal GetSumCamelChargesForNameAndDate(string name, DateTime? date, int userId)
        {
            return _breedingChargesRepository.Get().Where(i => i.User.Id == userId).ToList().Where(charge => charge.AnimalName == name &&
            charge.ApplicationDate == date).Aggregate<BreedingCharges, decimal>(0, (current, charge) => current + Convert.ToDecimal(charge.TotalCost));
        }

        #endregion


        public override void Dispose()
        {

            if (_youngBreedingRepository == null) return;
            _youngBreedingRepository.Dispose();
            _youngBreedingRepository = null;

            if (_breedingComingsRepository == null) return;
            _breedingComingsRepository.Dispose();
            _breedingComingsRepository = null;

            if (_beeComingsRepository == null) return;
            _beeComingsRepository.Dispose();
            _beeComingsRepository = null;

            if (_fishComingsRepository == null) return;
            _fishComingsRepository.Dispose();
            _fishComingsRepository = null;

            if (_breedingChargesRepository == null) return;
            _breedingChargesRepository.Dispose();
            _breedingChargesRepository = null;

            if (_breedingDailyProfitRepository == null) return;
            _breedingDailyProfitRepository.Dispose();
            _breedingDailyProfitRepository = null;

            if (_beeHoneyRepository == null) return;
            _beeHoneyRepository.Dispose();
            _beeHoneyRepository = null;

            if (_breedingProfitRepository == null) return;
            _breedingProfitRepository.Dispose();
            _breedingProfitRepository = null;

            if (_fishProfitRepository == null) return;
            _fishProfitRepository.Dispose();
            _fishProfitRepository = null;

            if (_breedingRemindingRepository == null) return;
            _breedingRemindingRepository.Dispose();
            _breedingRemindingRepository = null;

            if (_breedingTypeRepository == null) return;
            _breedingTypeRepository.Dispose();
            _breedingTypeRepository = null;

            if (_breedingCulturesRepository == null) return;
            _breedingCulturesRepository.Dispose();
            _breedingCulturesRepository = null;

            if (_honeyTypeRepository == null) return;
            _honeyTypeRepository.Dispose();
            _honeyTypeRepository = null;

            if (_usersRepository == null) return;
            _usersRepository.Dispose();
            _usersRepository = null;
        }


    }
}
