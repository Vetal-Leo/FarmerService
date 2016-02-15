using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain.Entities.Growing;


namespace Servises.Growing
{
    public partial class GrowingService
    {


        #region SpicyComings

        public List<GrowingFieldComings> GetSpicyComings(int userId)
        {
            return Calculate(_growingFieldComingsRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Spicy").ToList());
        }

        public async Task AddNewSpicy(int userId, FormCollection collection)
        {
            var groving = new GrowingFieldComings
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Spicy"),
                LandingDate = DateTime.Parse(collection[1]),
                CultureType = collection[2],
                Name = collection[3],
                MassType = collection[4],
                CurrencyType = collection[5],
                Cost = Convert.ToDecimal(collection[6].Replace(".", ",")),
                Amount = Convert.ToDecimal(collection[7].Replace(".", ",")),
                Document = FileNameValidator(collection[8])
            };

            _growingFieldComingsRepository.Add(groving);
            var culturetype = collection[2];
            var name = collection[3];
            var firstOrDefault = _growingFieldComingsRepository.Get().FirstOrDefault(c => c.CultureType == culturetype && c.Name == name);
            if (firstOrDefault != null)
            {
                var profit = new GrowingFieldProfits
                {
                    Id = firstOrDefault.Id,
                    CultureType = collection[2],
                    Name = collection[3],
                    ExpirationDate = GetExpirationDateForSpicyCulture(DateTime.Parse(collection[1]), collection[2]),
                    Remind = false,
                    User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                    GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Spicy")
                };
                await _growingFieldProfitsRepository.AddAsync(profit);
            }
        }

        private static DateTime? GetExpirationDateForSpicyCulture(DateTime landingdate, string culturetype)
        {
            switch (culturetype)
            {
                case "Kапуста белокочанная":
                    return landingdate.AddDays(120);
                case "Капуста краснокочанная":
                    return landingdate.AddDays(130);
                case "Капуста савойская":
                    return landingdate.AddDays(100);
                case "Капуста брюссельская":
                    return landingdate.AddDays(140);
                case "Капуста цветная":
                    return landingdate.AddDays(120);
                case "Капуста кольраби":
                    return landingdate.AddDays(80);
                case "Капуста брокколи":
                    return landingdate.AddDays(80);
                case "Салат":
                    return landingdate.AddDays(55);
                case "Укроп":
                    return landingdate.AddDays(37);
                case "Эстрагон":
                    return landingdate.AddDays(110);
                case "Чабер":
                    return landingdate.AddDays(50);
                case "Базилик":
                    return landingdate.AddDays(155);
                case "Майоран":
                    return landingdate.AddDays(150);
            }
            return DateTime.Now;
        }


        public GrowingFieldComings GetSpicyComingById(int id)
        {

            var picked = _growingFieldComingsRepository.Get().Where(i => i.Id == id).ToList()[0];
            return new GrowingFieldComings
            {
                LandingDate = picked.LandingDate,
                CultureType = picked.CultureType,
                Name = picked.Name,
                MassType = picked.MassType,
                CurrencyType = picked.CurrencyType,
                Cost = picked.Cost,
                Amount = picked.Amount,
                Document = picked.Document,
                GrowingCultureses = _growingCulturesRepository.Get().Where(c => c.GrowingType.Name == "Spicy")
            };
        }

        public async Task AddNewSpicyById(int id, FormCollection collection)
        {
            var picked = _growingFieldComingsRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.LandingDate = DateTime.Parse(collection[1]);
            picked.CultureType = collection[2];
            picked.Name = collection[3];
            picked.MassType = collection[4];
            picked.CurrencyType = collection[5];
            picked.Cost = Convert.ToDecimal(collection[6].Replace(".", ","));
            picked.Amount = Convert.ToDecimal(collection[7].Replace(".", ","));
            picked.Document = FileNameValidator(collection[8]);

            var pickedprofit = _growingFieldProfitsRepository.Get().Where(i => i.Id == id).ToList()[0];
            pickedprofit.CultureType = collection[2];
            pickedprofit.Name = collection[3];
            pickedprofit.ExpirationDate = GetExpirationDateForBreadCulture(DateTime.Parse(collection[1]), collection[2]);

            await _growingFieldComingsRepository.UpdateAsync(picked);
            await _growingFieldProfitsRepository.UpdateAsync(pickedprofit);
        }


        public void DeleteSpicyById(int id)
        {
            _growingFieldProfitsRepository.Delete(id);
            _growingFieldComingsRepository.Delete(id);
        }
        #endregion



        #region SpicyCharges

        public List<GrowingCharges> GetSpicyCharges(int userId)
        {
            return Calculate(_growingChargesRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Spicy").ToList());
        }


        public List<string> GetSpicyNamesById(int id)
        {
            var grovings = _growingFieldComingsRepository.Get().Where(i => i.User.Id == id && i.GrowingType.Name == "Spicy").ToList();
            return grovings.Select(item => item.Name).ToList();
        }

        public async Task AddNewSpicyCharges(int id, FormCollection collection)
        {
            var charges = new GrowingCharges
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == id),
                GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Spicy"),
                ApplicationDate = DateTime.Parse(collection[1]),
                PlantName = collection[2],
                Name = collection[3],
                Document = FileNameValidator(collection[4]),
                TotalCost = Convert.ToDecimal(collection[5].Replace(".", ",")),
            };

            await _growingChargesRepository.AddAsync(charges);
        }


        public GrowingCharges GetSpicyChargesById(int id)
        {
            var picked = _growingChargesRepository.Get().FirstOrDefault(i => i.Id == id);

            if (picked != null)
                return new GrowingCharges
                {
                    ApplicationDate = picked.ApplicationDate,
                    PlantName = picked.PlantName,
                    Name = picked.Name,
                    Document = picked.Document,
                    TotalCost = picked.TotalCost
                };
            return null;
        }

        public async Task AddNewSpicyChargesById(int id, FormCollection collection)
        {
            var picked = _growingChargesRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.ApplicationDate = DateTime.Parse(collection[1]);
            picked.PlantName = collection[2];
            picked.Name = collection[3];
            picked.Document = FileNameValidator(collection[4]);
            picked.TotalCost = Convert.ToDecimal(collection[5].Replace(".", ","));

            await _growingChargesRepository.UpdateAsync(picked);
        }


        public void DeleteSpicyChargesById(int id)
        {
            _growingChargesRepository.Delete(id);
        }

        #endregion



        #region MelonProfits

        public List<GrowingFieldProfits> GetSpicyProfits(int userId)
        {
            return Calculate(_growingFieldProfitsRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Spicy").ToList(), userId);
        }

        public GrowingFieldProfits GetSpicyProfitById(int id)
        {
            var picked = _growingFieldProfitsRepository.Get().Where(i => i.Id == id).ToList()[0];

            return new GrowingFieldProfits
            {
                ExpirationDate = picked.ExpirationDate,
                Remind = picked.Remind,
                MassType = picked.MassType,
                Amount = picked.Amount,
                Cost = picked.Cost,
                Document = picked.Document
            };
        }

        public async Task AddNewSpicyProfitById(int id, FormCollection collection)
        {
            var picked = _growingFieldProfitsRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.ExpirationDate = DateTime.Parse(collection[1]);
            var remind = collection[2].Split(',')[0];
            picked.Remind = Convert.ToBoolean(remind);
            picked.MassType = collection[3];
            picked.Amount = Convert.ToDecimal(collection[4].Replace(".", ","));
            picked.Cost = Convert.ToDecimal(collection[5].Replace(".", ","));
            picked.Document = FileNameValidator(collection[6]);

            await _growingFieldProfitsRepository.UpdateAsync(picked);
        }

        #endregion

    }
}
