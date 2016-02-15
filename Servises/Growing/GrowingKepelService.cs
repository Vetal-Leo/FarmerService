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


        #region KepelComings

        public List<GrowingFruitComings> GetKepelComings(int userId)
        {
            return Calculate(_growingFruitComingsRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Kepel").ToList());
        }


        public async Task AddNewKepel(int userId, FormCollection collection)
        {
            var bergamot = new GrowingFruitComings()
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Kepel"),
                LandingDate = DateTime.Parse(collection[1]),
                FloweringDate = DateTime.Parse(collection[2]),
                CultureType = collection[3],
                Name = collection[4],
                MassType = collection[5],
                CurrencyType = collection[6],
                Cost = Convert.ToDecimal(collection[7].Replace(".", ",")),
                Amount = Convert.ToDecimal(collection[8].Replace(".", ",")),
                Document = FileNameValidator(collection[9])
            };

            _growingFruitComingsRepository.Add(bergamot);
            var culturetype = collection[3];
            var name = collection[4];
            var firstOrDefault = _growingFruitComingsRepository.Get().FirstOrDefault(c => c.CultureType == culturetype && c.Name == name);
            if (firstOrDefault != null)
            {
                var profit = new GrowingFruitProfits
                {
                    Id = firstOrDefault.Id,
                    CultureType = collection[3],
                    Name = collection[4],
                    ExpirationDate = GetExpirationDateForKepel(DateTime.Parse(collection[2]), collection[3]),
                    Remind = false,
                    User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                    GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Kepel")
                };
                await _growingFruitProfitsRepository.AddAsync(profit);
            }
        }


        private static DateTime? GetExpirationDateForKepel(DateTime floweringdate, string culturetype)
        {
            switch (culturetype)
            {
                case "Какао":
                    return floweringdate.AddDays(240);
                case "Каламондин":
                    return floweringdate.AddDays(330);
                case "Канариум филиппинский":
                    return floweringdate.AddDays(28);
                case "Капулин":
                    return floweringdate.AddDays(195);
                case "Карамбола":
                    return floweringdate.AddDays(60);
                case "Кафрская слива":
                    return floweringdate.AddDays(180);
                case "Каштан американский":
                    return floweringdate.AddDays(70);
                case "Каштан Генри":
                    return floweringdate.AddDays(120);
                case "Каштан городчатый":
                    return floweringdate.AddDays(120);
                case "Каштан мягчайший":
                    return floweringdate.AddDays(120);
                case "Каштан посевной":
                    return floweringdate.AddDays(120);
                case "Каштан Сегю":
                    return floweringdate.AddDays(120);
                case "Кепел":
                    return floweringdate.AddDays(180);
                case "Кешью":
                    return floweringdate.AddDays(90);
                case "Клубничное дерево":
                    return floweringdate.AddDays(120);
                case "Кокосовая пальма":
                    return floweringdate.AddDays(380);
                case "Конфетное дерево":
                    return floweringdate.AddDays(90);
                case "Кофе аравийский":
                    return floweringdate.AddDays(210);
                case "Кофе конголезский":
                    return floweringdate.AddDays(315);
                case "Кумкват":
                    return floweringdate.AddDays(210);
                case "Купуасу":
                    return floweringdate.AddDays(165);
                case "Лайм":
                    return floweringdate.AddDays(120);
                case "Лещина древовидная":
                    return floweringdate.AddDays(180);
                case "Лимон":
                    return floweringdate.AddDays(240);
                case "Личи":
                    return floweringdate.AddDays(140);
                case "Макадамия":
                    return floweringdate.AddDays(195);
                case "Малайское яблоко":
                    return floweringdate.AddDays(60);
                case "Манго индийское":
                    return floweringdate.AddDays(135);
                case "Мандарин":
                    return floweringdate.AddDays(255);
                case "Мандарин уншиу":
                    return floweringdate.AddDays(180);
                case "Манильский тамаринд":
                    return floweringdate.AddDays(90);
                case "Марула":
                    return floweringdate.AddDays(210);
                case "Миндаль":
                    return floweringdate.AddDays(195);
                case "Мирабель":
                    return floweringdate.AddDays(90);
                case "Груша грушелистная":
                    return floweringdate.AddDays(135);
                case "Мирциария сомнительная":
                    return floweringdate.AddDays(105);
                case "Мускатник душистый":
                    return floweringdate.AddDays(270);
                case "Мушмула германская":
                    return floweringdate.AddDays(240);
                case "Мушмула японская":
                    return floweringdate.AddDays(240);
                case "Олива европейская":
                    return floweringdate.AddDays(180);
                case "Оранжекват":
                    return floweringdate.AddDays(180);
                case "Орех айлантолистный":
                    return floweringdate.AddDays(120);
                case "Орех грецкий":
                    return floweringdate.AddDays(210);
                case "Орех маньчжурский":
                    return floweringdate.AddDays(180);
                case "Пальчиковый лайм":
                    return floweringdate.AddDays(150);
                case "Папайя":
                    return floweringdate.AddDays(150);
                case "Пекан обыкновенный":
                    return floweringdate.AddDays(150);
                case "Персик":
                    return floweringdate.AddDays(120);
                case "Помело":
                    return floweringdate.AddDays(180);
                case "Померанец":
                    return floweringdate.AddDays(240);
            }

            return DateTime.Now;
        }

        public GrowingFruitComings GetKepelComingById(int id)
        {
            var picked = _growingFruitComingsRepository.Get().Where(i => i.Id == id).ToList()[0];
            return new GrowingFruitComings
            {
                LandingDate = picked.LandingDate,
                FloweringDate = picked.FloweringDate,
                CultureType = picked.CultureType,
                Name = picked.Name,
                MassType = picked.MassType,
                CurrencyType = picked.CurrencyType,
                Cost = picked.Cost,
                Amount = picked.Amount,
                Document = picked.Document,
                GrowingCultureses = _growingCulturesRepository.Get().Where(c => c.GrowingType.Name == "Kepel")
            };
        }

        public async Task AddNewKepelById(int id, FormCollection collection)
        {
            var picked = _growingFruitComingsRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.LandingDate = DateTime.Parse(collection[1]);
            picked.FloweringDate = DateTime.Parse(collection[2]);
            picked.CultureType = collection[3];
            picked.Name = collection[4];
            picked.MassType = collection[5];
            picked.CurrencyType = collection[6];
            picked.Cost = Convert.ToDecimal(collection[7].Replace(".", ","));
            picked.Amount = Convert.ToDecimal(collection[8].Replace(".", ","));
            picked.Document = FileNameValidator(collection[9]);


            var pickedprofit = _growingFruitProfitsRepository.Get().Where(i => i.Id == id).ToList()[0];
            pickedprofit.CultureType = collection[3];
            pickedprofit.Name = collection[4];
            pickedprofit.ExpirationDate = GetExpirationDateForBergamot(DateTime.Parse(collection[2]), collection[3]);

            await _growingFruitComingsRepository.UpdateAsync(picked);
            await _growingFruitProfitsRepository.UpdateAsync(pickedprofit);
        }

        public void DeleteKepelById(int id)
        {
            _growingFruitProfitsRepository.Delete(id);
            _growingFruitComingsRepository.Delete(id);
        }

        #endregion





        #region KepelCharges

        public List<GrowingCharges> GetKepelCharges(int userId)
        {
            return Calculate(_growingChargesRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Kepel").ToList());
        }
        public List<string> GetKepelNamesById(int id)
        {
            var bergamots = _growingFruitComingsRepository.Get().Where(i => i.User.Id == id && i.GrowingType.Name == "Kepel").ToList();
            return bergamots.Select(item => item.Name).ToList();
        }

        public async Task AddNewKepelCharges(int userId, FormCollection collection)
        {
            var charges = new GrowingCharges
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Kepel"),
                ApplicationDate = DateTime.Parse(collection[1]),
                PlantName = collection[2],
                Name = collection[3],
                Document = FileNameValidator(collection[4]),
                TotalCost = Convert.ToDecimal(collection[5].Replace(".", ",")),
            };

            await _growingChargesRepository.AddAsync(charges);
        }

        public GrowingCharges GetKepelChargesById(int id)
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

        public async Task AddNewKepelChargesById(int id, FormCollection collection)
        {
            var picked = _growingChargesRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.ApplicationDate = DateTime.Parse(collection[1]);
            picked.PlantName = collection[2];
            picked.Name = collection[3];
            picked.Document = FileNameValidator(collection[4]);
            picked.TotalCost = Convert.ToDecimal(collection[5].Replace(".", ","));

            await _growingChargesRepository.UpdateAsync(picked);
        }

        public void DeleteKepelChargesById(int id)
        {
            _growingChargesRepository.Delete(id);
        }
        #endregion



        #region KepelProfits

        public List<GrowingFruitProfits> GetKepelProfits(int userId)
        {
            return Calculate(_growingFruitProfitsRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Kepel").ToList(), userId);
        }

        public GrowingFruitProfits GetKepelProfitById(int id)
        {
            var picked = _growingFruitProfitsRepository.Get().Where(i => i.Id == id).ToList()[0];

            return new GrowingFruitProfits
            {
                ExpirationDate = picked.ExpirationDate,
                Remind = picked.Remind,
                MassType = picked.MassType,
                Amount = picked.Amount,
                Cost = picked.Cost,
                Document = picked.Document
            };
        }

        public async Task AddNewKepelProfitById(int id, FormCollection collection)
        {
            var picked = _growingFruitProfitsRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.ExpirationDate = DateTime.Parse(collection[1]);
            var remind = collection[2].Split(',')[0];
            picked.Remind = Convert.ToBoolean(remind);
            picked.MassType = collection[3];
            picked.Amount = Convert.ToDecimal(collection[4].Replace(".", ","));
            picked.Cost = Convert.ToDecimal(collection[5].Replace(".", ","));
            picked.Document = FileNameValidator(collection[6]);

            await _growingFruitProfitsRepository.UpdateAsync(picked);
        }

        #endregion


    }
}
