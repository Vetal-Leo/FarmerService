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


        #region OliveComings

        public List<GrowingFieldComings> GetOliveComings(int userId)
        {
            return Calculate(_growingFieldComingsRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Olive").ToList());
        }

        public async Task AddNewOlive(int userId, FormCollection collection)
        {
            var groving = new GrowingFieldComings
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Olive"),
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
                    ExpirationDate = GetExpirationDateForOliveCulture(DateTime.Parse(collection[1]), collection[2]),
                    Remind = false,
                    User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                    GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Olive")
                };
                await _growingFieldProfitsRepository.AddAsync(profit);
            }
        }

        private static DateTime? GetExpirationDateForOliveCulture(DateTime landingdate, string culturetype)
        {

            switch (culturetype)
            {
                case "Кешью":
                    return landingdate.AddDays(60);
                case "Фисташка настоящая":
                    return landingdate.AddDays(140);
                case "Артишок испанский":
                    return landingdate.AddDays(180);
                case "Подсолнечник однолетний":
                    return landingdate.AddDays(90);
                case "Арахис культурный":
                    return landingdate.AddDays(130);
                case "Виноград культурный":
                    return landingdate.AddDays(110);
                case "Кукуруза сахарная":
                    return landingdate.AddDays(70);
                case "Рапс":
                    return landingdate.AddDays(200);
                case "Сурепица":
                    return landingdate.AddDays(70);
                case "Горчица":
                    return landingdate.AddDays(85);
                case "Рыжик посевной":
                    return landingdate.AddDays(75);
                case "Смородина чёрная":
                    return landingdate.AddDays(45);
                case "Авокадо":
                    return landingdate.AddDays(270);
                case "Лён обыкновенный":
                    return landingdate.AddDays(80);
                case "Хлопчатник":
                    return landingdate.AddDays(125);
                case "Какао":
                    return landingdate.AddDays(195);
                case "Кофе аравийский":
                    return landingdate.AddDays(195);
                case "Олива европейская":
                    return landingdate.AddDays(135);
                case "Тунг":
                    return landingdate.AddDays(110);
                case "Клещевина обыкновенная":
                    return landingdate.AddDays(130);
                case "Орех грецкий":
                    return landingdate.AddDays(180);
                case "Баланитес":
                    return landingdate.AddDays(90);
                case "Кунжут индийский":
                    return landingdate.AddDays(105);
                case "Миндаль":
                    return landingdate.AddDays(135);
                case "Аргания колючая":
                    return landingdate.AddYears(1);
                case "Пиния":
                    return landingdate.AddDays(120);
                case "Сибирский кедр":
                    return landingdate.AddDays(42);
                case "Чай":
                    return landingdate.AddDays(225);
                case "Ляллеманция":
                    return landingdate.AddDays(90);
                case "Перилла":
                    return landingdate.AddDays(115);
            }
            return DateTime.Now;
        }


        public GrowingFieldComings GetOliveComingById(int id)
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
                GrowingCultureses = _growingCulturesRepository.Get().Where(c => c.GrowingType.Name == "Olive")
            };
        }

        public async Task AddNewOliveById(int id, FormCollection collection)
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


        public void DeleteOliveById(int id)
        {
            _growingFieldProfitsRepository.Delete(id);
            _growingFieldComingsRepository.Delete(id);
        }
        #endregion



        #region OliveCharges

        public List<GrowingCharges> GetOliveCharges(int userId)
        {
            return Calculate(_growingChargesRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Olive").ToList());
        }



        public List<string> GetOliveNamesById(int id)
        {
            var grovings = _growingFieldComingsRepository.Get().Where(i => i.User.Id == id && i.GrowingType.Name == "Olive").ToList();
            return grovings.Select(item => item.Name).ToList();
        }

        public async Task AddNewOliveCharges(int id, FormCollection collection)
        {
            var charges = new GrowingCharges
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == id),
                GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Olive"),
                ApplicationDate = DateTime.Parse(collection[1]),
                PlantName = collection[2],
                Name = collection[3],
                Document = FileNameValidator(collection[4]),
                TotalCost = Convert.ToDecimal(collection[5].Replace(".", ",")),
            };

            await _growingChargesRepository.AddAsync(charges);
        }


        public GrowingCharges GetOliveChargesById(int id)
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

        public async Task AddNewOliveChargesById(int id, FormCollection collection)
        {
            var picked = _growingChargesRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.ApplicationDate = DateTime.Parse(collection[1]);
            picked.PlantName = collection[2];
            picked.Name = collection[3];
            picked.Document = FileNameValidator(collection[4]);
            picked.TotalCost = Convert.ToDecimal(collection[5].Replace(".", ","));

            await _growingChargesRepository.UpdateAsync(picked);
        }


        public void DeleteOliveChargesById(int id)
        {
            _growingChargesRepository.Delete(id);
        }

        #endregion



        #region MelonProfits

        public List<GrowingFieldProfits> GetOliveProfits(int userId)
        {
            return Calculate(_growingFieldProfitsRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Olive").ToList(), userId);
        }

        public GrowingFieldProfits GetOliveProfitById(int id)
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

        public async Task AddNewOliveProfitById(int id, FormCollection collection)
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
