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



        #region GooseComing

        public List<BreedingComings> GetGooseComings(int userId)
        {
            return Calculate(_breedingComingsRepository.Get().Where(i => i.User.Id == userId && i.BreedingType.Name == "Goose").ToList());
        }

        public async Task AddNewGooseComing(int userId, FormCollection collection)
        {
            var camel = new BreedingComings
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                BreedingType = _breedingTypeRepository.Get().FirstOrDefault(i => i.Name == "Goose"),
                ReceiptDate = DateTime.Parse(collection[1]),
                CultureType = collection[2],
                Name = collection[3],
                MassType = collection[4],
                Mass = Convert.ToDecimal(collection[5].Replace(".", ",")),
                CurrencyType = collection[6],
                Cost = Convert.ToDecimal(collection[7].Replace(".", ",")),
                Amount = Convert.ToInt32(collection[8]),
                Document = FileNameValidator(collection[9])
            };

            _breedingComingsRepository.Add(camel);
            var culturetype = collection[2];
            var name = collection[3];
            var firstOrDefault = _breedingComingsRepository.Get().FirstOrDefault(c => c.CultureType == culturetype && c.Name == name);
            if (firstOrDefault != null)
            {
                var profit = new BreedingProfits
                {
                    Id = firstOrDefault.Id,
                    CultureType = collection[2],
                    Name = collection[3],
                    User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                    BreedingType = _breedingTypeRepository.Get().FirstOrDefault(i => i.Name == "Goose")
                };
                await _breedingProfitRepository.AddAsync(profit);
            }
        }

        public BreedingComings GetGooseComingById(int id)
        {
            var picked = _breedingComingsRepository.Get().Where(i => i.Id == id).ToList()[0];
            return new BreedingComings
            {
                ReceiptDate = picked.ReceiptDate,
                CultureType = picked.CultureType,
                Name = picked.Name,
                MassType = picked.MassType,
                Mass = picked.Mass,
                CurrencyType = picked.CurrencyType,
                Cost = picked.Cost,
                Amount = picked.Amount,
                Document = picked.Document,
                BreedingCultureses = _breedingCulturesRepository.Get().Where(c => c.BreedingType.Name == "Goose")
            };
        }

        public async Task AddNewGooseComingById(int id, FormCollection collection)
        {
            var picked = _breedingComingsRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.ReceiptDate = DateTime.Parse(collection[1]);
            picked.CultureType = collection[2];
            picked.Name = collection[3];
            picked.MassType = collection[4];
            picked.Mass = Convert.ToDecimal(collection[5].Replace(".", ","));
            picked.CurrencyType = collection[6];
            picked.Cost = Convert.ToDecimal(collection[7].Replace(".", ","));
            picked.Amount = Convert.ToInt32(collection[8]);
            picked.Document = FileNameValidator(collection[9]);

            var pickedprofit = _breedingProfitRepository.Get().Where(i => i.Id == id).ToList()[0];
            pickedprofit.CultureType = collection[2];
            pickedprofit.Name = collection[3];

            await _breedingComingsRepository.UpdateAsync(picked);
            await _breedingProfitRepository.UpdateAsync(pickedprofit);
        }

        public void DeleteGooseComingById(int id)
        {
            _breedingProfitRepository.Delete(id);
            _breedingComingsRepository.Delete(id);
        }

        #endregion


        #region GooseCharges

        public List<BreedingCharges> GetGooseCharges(int userId)
        {
            return Calculate(_breedingChargesRepository.Get().Where(i => i.User.Id == userId && i.BreedingType.Name == "Goose").ToList());
        }

        public List<string> GetGooseNamesById(int id)
        {
            var camels = _breedingComingsRepository.Get().Where(i => i.User.Id == id && i.BreedingType.Name == "Goose").ToList();
            return camels.Select(item => item.Name).ToList();
        }

        public async Task AddNewGooseCharges(int userId, FormCollection collection)
        {
            var charges = new BreedingCharges
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                BreedingType = _breedingTypeRepository.Get().FirstOrDefault(i => i.Name == "Goose"),
                ApplicationDate = DateTime.Parse(collection[1]),
                AnimalName = collection[2],
                Name = collection[3],
                Document = FileNameValidator(collection[4]),
                TotalCost = Convert.ToDecimal(collection[5].Replace(".", ",")),
            };

            await _breedingChargesRepository.AddAsync(charges);
        }

        public BreedingCharges GetGooseChargesById(int id)
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

        public async Task AddNewGooseChargesById(int id, FormCollection collection)
        {
            var picked = _breedingChargesRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.ApplicationDate = DateTime.Parse(collection[1]);
            picked.AnimalName = collection[2];
            picked.Name = collection[3];
            picked.Document = FileNameValidator(collection[4]);
            picked.TotalCost = Convert.ToDecimal(collection[5].Replace(".", ","));

            await _breedingChargesRepository.UpdateAsync(picked);
        }

        public void DeleteGooseChargesById(int id)
        {
            _breedingChargesRepository.Delete(id);
        }

        #endregion


        #region GooseDaily

        public List<BreedingDailyProfit> GetGooseDailyProfits(int userId)
        {
            return Calculate(_breedingDailyProfitRepository.Get().Where(i => i.User.Id == userId && i.BreedingType.Name == "Goose").ToList(), userId);
        }

        public async Task AddNewGooseDailyProfits(int userId, FormCollection collection)
        {
            var daily = new BreedingDailyProfit
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                BreedingType = _breedingTypeRepository.Get().FirstOrDefault(i => i.Name == "Goose"),
                Date = DateTime.Parse(collection[1]),
                AnimalName = collection[2],
                Name = collection[3],
                MassType = collection[4],
                Amount = Convert.ToDecimal(collection[5].Replace(".", ",")),
                Cost = Convert.ToDecimal(collection[6].Replace(".", ",")),
                Document = FileNameValidator(collection[7])
            };

            await _breedingDailyProfitRepository.AddAsync(daily);
        }

        public BreedingDailyProfit GetGooseDailyProfitById(int id)
        {
            var picked = _breedingDailyProfitRepository.Get().FirstOrDefault(i => i.Id == id);
            if (picked != null)
                return new BreedingDailyProfit
                {
                    Date = picked.Date,
                    AnimalName = picked.AnimalName,
                    Name = picked.Name,
                    MassType = picked.MassType,
                    Amount = picked.Amount,
                    Cost = picked.Cost,
                    Document = picked.Document
                };
            return null;
        }

        public async Task AddNewGooseDailyProfitById(int id, FormCollection collection)
        {
            var picked = _breedingDailyProfitRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.Date = DateTime.Parse(collection[1]);
            picked.AnimalName = collection[2];
            picked.Name = collection[3];
            picked.MassType = collection[4];
            picked.Amount = Convert.ToDecimal(collection[5].Replace(".", ","));
            picked.Cost = Convert.ToDecimal(collection[6].Replace(".", ","));
            picked.Document = FileNameValidator(collection[7]);

            await _breedingDailyProfitRepository.UpdateAsync(picked);
        }

        public void DeleteGooseDailyProfitById(int id)
        {
            _breedingDailyProfitRepository.Delete(id);
        }

        #endregion


        #region GooseProfit

        public List<BreedingProfits> GetGooseProfits(int userId)
        {
            return Calculate(_breedingProfitRepository.Get().Where(i => i.User.Id == userId && i.BreedingType.Name == "Goose").ToList());
        }

        public BreedingProfits GetGooseProfitById(int id)
        {
            var picked = _breedingProfitRepository.Get().Where(i => i.Id == id).ToList()[0];

            return new BreedingProfits
            {
                ExpirationDate = picked.ExpirationDate,
                Motive = picked.Motive,
                MassType = picked.MassType,
                Amount = picked.Amount,
                Cost = picked.Cost,
                Document = picked.Document
            };
        }

        public async Task AddNewGooseProfitById(int id, FormCollection collection)
        {
            var picked = _breedingProfitRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.ExpirationDate = DateTime.Parse(collection[1]);
            picked.Motive = collection[2];
            picked.MassType = collection[3];
            picked.Amount = Convert.ToDecimal(collection[4].Replace(".", ","));
            picked.Cost = Convert.ToDecimal(collection[5].Replace(".", ","));
            picked.Document = FileNameValidator(collection[6]);

            await _breedingProfitRepository.UpdateAsync(picked);
        }

        #endregion


        #region GooseRemiding

        public List<BreedingReminder> GetGooseRemindings(int userId)
        {
            return _breedingRemindingRepository.Get().Where(i => i.User.Id == userId && i.BreedingType.Name == "Goose").ToList();
        }

        public async Task AddNewGooseReminding(int userId, FormCollection collection)
        {
            var reminding = new BreedingReminder
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                BreedingType = _breedingTypeRepository.Get().FirstOrDefault(i => i.Name == "Goose"),
                AnimalName = collection[1],
                Text = collection[2],
                RemindDate = DateTime.Parse(collection[3]),
                RemindDays = Convert.ToInt32(collection[4])
            };

            await _breedingRemindingRepository.AddAsync(reminding);
        }

        public BreedingReminder GetGooseRemindingById(int id)
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

        public async Task AddNewGooseRemindingById(int id, FormCollection collection)
        {
            var picked = _breedingRemindingRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.AnimalName = collection[1];
            picked.Text = collection[2];
            picked.RemindDate = DateTime.Parse(collection[3]);
            picked.RemindDays = Convert.ToInt32(collection[4]);

            await _breedingRemindingRepository.UpdateAsync(picked);
        }

        public void DeleteGooseRemindingById(int id)
        {
            _breedingRemindingRepository.Delete(id);
        }

        #endregion

    }
}
