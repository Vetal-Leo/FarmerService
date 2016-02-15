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


        #region TuberComings

        public List<GrowingFieldComings> GetTuberComings(int userId)
        {
            return Calculate(_growingFieldComingsRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Tuber").ToList());
        }

        public async Task AddNewTuber(int userId, FormCollection collection)
        {
            var groving = new GrowingFieldComings
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Tuber"),
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
                    ExpirationDate = GetExpirationDateForTuberCulture(DateTime.Parse(collection[1]), collection[2]),
                    Remind = false,
                    User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                    GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Tuber")
                };
                await _growingFieldProfitsRepository.AddAsync(profit);
            }
        }

        private static DateTime? GetExpirationDateForTuberCulture(DateTime landingdate, string culturetype)
        {
            switch (culturetype)
            {
                case "Топинамбур":
                    return landingdate.AddDays(125);
                case "Батат":
                    return landingdate.AddDays(100);
                case "Картофель":
                    return landingdate.AddDays(85);
                case "Морковь":
                    return landingdate.AddDays(80);
                case "Свёкла":
                    return landingdate.AddDays(80);
                case "Репа":
                    return landingdate.AddDays(70);
                case "Брюква":
                    return landingdate.AddDays(105);
                case "Редька":
                    return landingdate.AddDays(100);
                case "Редис":
                    return landingdate.AddDays(42);
                case "Петрушка":
                    return landingdate.AddDays(90);
                case "Пастернак":
                    return landingdate.AddDays(102);
                case "Сельдерей":
                    return landingdate.AddDays(115);
                case "Хрен":
                    return landingdate.AddDays(180);
            }
            return DateTime.Now;
        }


        public GrowingFieldComings GetTuberComingById(int id)
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
                GrowingCultureses = _growingCulturesRepository.Get().Where(c => c.GrowingType.Name == "Tuber")
            };
        }

        public async Task AddNewTuberById(int id, FormCollection collection)
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


        public void DeleteTuberById(int id)
        {
            _growingFieldProfitsRepository.Delete(id);
            _growingFieldComingsRepository.Delete(id);
        }
        #endregion



        #region TuberCharges

        public List<GrowingCharges> GetTuberCharges(int userId)
        {
            return Calculate(_growingChargesRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Tuber").ToList());
        }


        public List<string> GetTuberNamesById(int id)
        {
            var grovings = _growingFieldComingsRepository.Get().Where(i => i.User.Id == id && i.GrowingType.Name == "Tuber").ToList();
            return grovings.Select(item => item.Name).ToList();
        }

        public async Task AddNewTuberCharges(int id, FormCollection collection)
        {
            var charges = new GrowingCharges
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == id),
                GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Tuber"),
                ApplicationDate = DateTime.Parse(collection[1]),
                PlantName = collection[2],
                Name = collection[3],
                Document = FileNameValidator(collection[4]),
                TotalCost = Convert.ToDecimal(collection[5].Replace(".", ",")),
            };

            await _growingChargesRepository.AddAsync(charges);
        }


        public GrowingCharges GetTuberChargesById(int id)
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

        public async Task AddNewTuberChargesById(int id, FormCollection collection)
        {
            var picked = _growingChargesRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.ApplicationDate = DateTime.Parse(collection[1]);
            picked.PlantName = collection[2];
            picked.Name = collection[3];
            picked.Document = FileNameValidator(collection[4]);
            picked.TotalCost = Convert.ToDecimal(collection[5].Replace(".", ","));

            await _growingChargesRepository.UpdateAsync(picked);
        }


        public void DeleteTuberChargesById(int id)
        {
            _growingChargesRepository.Delete(id);
        }

        #endregion



        #region TuberProfits

        public List<GrowingFieldProfits> GetTuberProfits(int userId)
        {
            return Calculate(_growingFieldProfitsRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Tuber").ToList(), userId);
        }

        public GrowingFieldProfits GetTuberProfitById(int id)
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

        public async Task AddNewTuberProfitById(int id, FormCollection collection)
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
