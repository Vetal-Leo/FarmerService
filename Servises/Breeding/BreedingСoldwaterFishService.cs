using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain.Entities.Breeding;


namespace Servises.Breeding
{
    public partial class BreedingService
    {


        #region СoldwaterFishComing

        public List<FishComings> GetСoldwaterFishComings(int userId)
        {
            return Calculate(_fishComingsRepository.Get().Where(i => i.User.Id == userId && i.BreedingType.Name == "СoldwaterFish").ToList());
        }

        public async Task AddNewСoldwaterFishComing(int userId, FormCollection collection)
        {
            var fish = new FishComings
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                BreedingType = _breedingTypeRepository.Get().FirstOrDefault(i => i.Name == "СoldwaterFish"),
                ReceiptDate = DateTime.Parse(collection[1]),
                CultureType = collection[2],
                Name = collection[3],
                MassType = collection[4],
                CurrencyType = collection[5],
                Cost = Convert.ToDecimal(collection[6].Replace(".", ",")),
                Amount = Convert.ToDecimal(collection[7].Replace(".", ",")),
                Document = FileNameValidator(collection[8])
            };

            _fishComingsRepository.Add(fish);
            var culturetype = collection[2];
            var name = collection[3];
            var firstOrDefault = _fishComingsRepository.Get().FirstOrDefault(c => c.CultureType == culturetype && c.Name == name);
            if (firstOrDefault != null)
            {
                var profit = new FishProfits
                {
                    Id = firstOrDefault.Id,
                    CultureType = collection[2],
                    Name = collection[3],
                    User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                    BreedingType = _breedingTypeRepository.Get().FirstOrDefault(i => i.Name == "СoldwaterFish")
                };
                await _fishProfitRepository.AddAsync(profit);
            }
        }

        public FishComings GetСoldwaterFishComingById(int id)
        {
            var picked = _fishComingsRepository.Get().Where(i => i.Id == id).ToList()[0];
            return new FishComings
            {
                ReceiptDate = picked.ReceiptDate,
                CultureType = picked.CultureType,
                Name = picked.Name,
                MassType = picked.MassType,
                CurrencyType = picked.CurrencyType,
                Cost = picked.Cost,
                Amount = picked.Amount,
                Document = picked.Document,
                BreedingCultureses = _breedingCulturesRepository.Get().Where(c => c.BreedingType.Name == "СoldwaterFish")
            };
        }

        public async Task AddNewСoldwaterFishComingById(int id, FormCollection collection)
        {
            var picked = _fishComingsRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.ReceiptDate = DateTime.Parse(collection[1]);
            picked.CultureType = collection[2];
            picked.Name = collection[3];
            picked.MassType = collection[4];
            picked.CurrencyType = collection[5];
            picked.Cost = Convert.ToDecimal(collection[6].Replace(".", ","));
            picked.Amount = Convert.ToDecimal(collection[7].Replace(".", ","));
            picked.Document = FileNameValidator(collection[8]);

            var pickedprofit = _fishProfitRepository.Get().Where(i => i.Id == id).ToList()[0];
            pickedprofit.CultureType = collection[2];
            pickedprofit.Name = collection[3];

            await _fishComingsRepository.UpdateAsync(picked);
            await _fishProfitRepository.UpdateAsync(pickedprofit);
        }

        public void DeleteСoldwaterFishComingById(int id)
        {
            _fishProfitRepository.Delete(id);
            _fishComingsRepository.Delete(id);
        }

        #endregion


        #region СoldwaterFishCharges

        public List<BreedingCharges> GetСoldwaterFishCharges(int userId)
        {
            return Calculate(_breedingChargesRepository.Get().Where(i => i.User.Id == userId && i.BreedingType.Name == "СoldwaterFish").ToList());
        }

        public List<string> GetСoldwaterFishNamesById(int id)
        {
            var camels = _fishComingsRepository.Get().Where(i => i.User.Id == id && i.BreedingType.Name == "СoldwaterFish").ToList();
            return camels.Select(item => item.Name).ToList();
        }

        public async Task AddNewСoldwaterFishCharges(int userId, FormCollection collection)
        {
            var charges = new BreedingCharges
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                BreedingType = _breedingTypeRepository.Get().FirstOrDefault(i => i.Name == "СoldwaterFish"),
                ApplicationDate = DateTime.Parse(collection[1]),
                AnimalName = collection[2],
                Name = collection[3],
                Document = FileNameValidator(collection[4]),
                TotalCost = Convert.ToDecimal(collection[5].Replace(".", ","))
            };

            await _breedingChargesRepository.AddAsync(charges);
        }

        public BreedingCharges GetСoldwaterFishChargesById(int id)
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

        public async Task AddNewСoldwaterFishChargesById(int id, FormCollection collection)
        {
            var picked = _breedingChargesRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.ApplicationDate = DateTime.Parse(collection[1]);
            picked.AnimalName = collection[2];
            picked.Name = collection[3];
            picked.Document = FileNameValidator(collection[4]);
            picked.TotalCost = Convert.ToDecimal(collection[5].Replace(".", ","));

            await _breedingChargesRepository.UpdateAsync(picked);
        }

        public void DeleteСoldwaterFishChargesById(int id)
        {
            _breedingChargesRepository.Delete(id);
        }

        #endregion


        #region СoldwaterFishProfit

        public List<FishProfits> GetСoldwaterFishProfits(int userId)
        {
            return Calculate(_fishProfitRepository.Get().Where(i => i.User.Id == userId && i.BreedingType.Name == "СoldwaterFish").ToList());
        }

        public FishProfits GetСoldwaterFishProfitById(int id)
        {
            var picked = _fishProfitRepository.Get().Where(i => i.Id == id).ToList()[0];

            return new FishProfits
            {
                ExpirationDate = picked.ExpirationDate,
                Motive = picked.Motive,
                MassType = picked.MassType,
                Amount = picked.Amount,
                Cost = picked.Cost,
                Document = picked.Document
            };
        }


        public async Task AddNewСoldwaterFishProfitById(int id, FormCollection collection)
        {
            var picked = _fishProfitRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.ExpirationDate = DateTime.Parse(collection[1]);
            picked.Motive = collection[2];
            picked.MassType = collection[3];
            picked.Amount = Convert.ToDecimal(collection[4].Replace(".", ","));
            picked.Cost = Convert.ToDecimal(collection[5].Replace(".", ","));
            picked.Document = FileNameValidator(collection[6]);

            await _fishProfitRepository.UpdateAsync(picked);
        }

        #endregion


        #region СoldwaterFishRemiding

        public List<BreedingReminder> GetСoldwaterFishRemindings(int userId)
        {
            return _breedingRemindingRepository.Get().Where(i => i.User.Id == userId && i.BreedingType.Name == "СoldwaterFish").ToList();
        }

        public async Task AddNewСoldwaterFishReminding(int userId, FormCollection collection)
        {
            var reminding = new BreedingReminder
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                BreedingType = _breedingTypeRepository.Get().FirstOrDefault(i => i.Name == "СoldwaterFish"),
                AnimalName = collection[1],
                Text = collection[2],
                RemindDate = DateTime.Parse(collection[3]),
                RemindDays = Convert.ToInt32(collection[4])
            };

            await _breedingRemindingRepository.AddAsync(reminding);
        }

        public BreedingReminder GetСoldwaterFishRemindingById(int id)
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

        public async Task AddNewСoldwaterFishRemindingById(int id, FormCollection collection)
        {
            var picked = _breedingRemindingRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.AnimalName = collection[1];
            picked.Text = collection[2];
            picked.RemindDate = DateTime.Parse(collection[3]);
            picked.RemindDays = Convert.ToInt32(collection[4]);

            await _breedingRemindingRepository.UpdateAsync(picked);
        }

        public void DeleteСoldwaterFishRemindingById(int id)
        {
            _breedingRemindingRepository.Delete(id);
        }

        #endregion

    }
}
