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


        #region FinikComings

        public List<GrowingFruitComings> GetFinikComings(int userId)
        {
            return Calculate(_growingFruitComingsRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Finik").ToList());
        }


        public async Task AddNewFinik(int userId, FormCollection collection)
        {
            var bergamot = new GrowingFruitComings()
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Finik"),
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
                    ExpirationDate = GetExpirationDateForFinik(DateTime.Parse(collection[2]), collection[3]),
                    Remind = false,
                    User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                    GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Finik")
                };
                await _growingFruitProfitsRepository.AddAsync(profit);
            }
        }


        private static DateTime? GetExpirationDateForFinik(DateTime floweringdate, string culturetype)
        {
            switch (culturetype)
            {
                case "Рамбутан":
                    return floweringdate.AddDays(115);
                case "Ренклод":
                    return floweringdate.AddDays(90);
                case "Рожковое дерево":
                    return floweringdate.AddDays(240);
                case "Розовое яблоко":
                    return floweringdate.AddDays(150);
                case "Рябина обыкновенная":
                    return floweringdate.AddDays(150);
                case "Рябина обыкновенная (Дочь Кубовой)":
                    return floweringdate.AddDays(150);
                case "Рябина сибирская":
                    return floweringdate.AddDays(120);
                case "Салак":
                    return floweringdate.AddDays(180);
                case "Сахарное яблоко":
                    return floweringdate.AddDays(150);
                case "Сизигиум масляный":
                    return floweringdate.AddDays(150);
                case "Сикомор":
                    return floweringdate.AddDays(150);
                case "Слива":
                    return floweringdate.AddDays(105);
                case "Слива домашняя":
                    return floweringdate.AddDays(90);
                case "Слива китайская":
                    return floweringdate.AddDays(90);
                case "Сметанное яблоко":
                    return floweringdate.AddDays(150);
                case "Суринамская вишня":
                    return floweringdate.AddDays(21);
                case "Тамарилло":
                    return floweringdate.AddDays(195);
                case "Тамаринд":
                    return floweringdate.AddDays(30);
                case "Фейхоа":
                    return floweringdate.AddDays(180);
                case "Финик пальчатый":
                    return floweringdate.AddDays(210);
                case "Фисташка настоящая":
                    return floweringdate.AddDays(210);
                case "Хлебное дерево":
                    return floweringdate.AddDays(165);
                case "Хурма восточная":
                    return floweringdate.AddDays(180);
                case "Хурма кавказская":
                    return floweringdate.AddDays(180);
                case "Хурма мушмуловидная":
                    return floweringdate.AddDays(180);
                case "Цитрон":
                    return floweringdate.AddDays(360);
                case "Цитрон пальчатый":
                    return floweringdate.AddDays(180);
                case "Черёмуха виргинская":
                    return floweringdate.AddDays(75);
                case "Черёмуха обыкновенная":
                    return floweringdate.AddDays(90);
                case "Черёмуха пенсильванская":
                    return floweringdate.AddDays(90);
                case "Черёмуха поздняя":
                    return floweringdate.AddDays(90);
                case "Черешня":
                    return floweringdate.AddDays(45);
                case "Черимойя":
                    return floweringdate.AddDays(270);
                case "Чёрная сапота":
                    return floweringdate.AddDays(40);
                case "Шелковица белая":
                    return floweringdate.AddDays(30);
                case "Шелковица чёрная":
                    return floweringdate.AddDays(30);
                case "Ши(дерево)":
                    return floweringdate.AddDays(210);
                case "Юдзу":
                    return floweringdate.AddDays(210);
                case "Яблоня домашняя":
                    return floweringdate.AddDays(150);
                case "Ятоба":
                    return floweringdate.AddDays(120);
            }
            return DateTime.Now;
        }

        public GrowingFruitComings GetFinikComingById(int id)
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
                GrowingCultureses = _growingCulturesRepository.Get().Where(c => c.GrowingType.Name == "Finik")
            };
        }

        public async Task AddNewFinikById(int id, FormCollection collection)
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

        public void DeleteFinikById(int id)
        {
            _growingFruitProfitsRepository.Delete(id);
            _growingFruitComingsRepository.Delete(id);
        }

        #endregion





        #region FinikCharges

        public List<GrowingCharges> GetFinikCharges(int userId)
        {
            return Calculate(_growingChargesRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Finik").ToList());
        }
        public List<string> GetFinikNamesById(int id)
        {
            var bergamots = _growingFruitComingsRepository.Get().Where(i => i.User.Id == id && i.GrowingType.Name == "Finik").ToList();
            return bergamots.Select(item => item.Name).ToList();
        }

        public async Task AddNewFinikCharges(int userId, FormCollection collection)
        {
            var charges = new GrowingCharges
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Finik"),
                ApplicationDate = DateTime.Parse(collection[1]),
                PlantName = collection[2],
                Name = collection[3],
                Document = FileNameValidator(collection[4]),
                TotalCost = Convert.ToDecimal(collection[5].Replace(".", ",")),
            };

            await _growingChargesRepository.AddAsync(charges);
        }

        public GrowingCharges GetFinikChargesById(int id)
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

        public async Task AddNewFinikChargesById(int id, FormCollection collection)
        {
            var picked = _growingChargesRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.ApplicationDate = DateTime.Parse(collection[1]);
            picked.PlantName = collection[2];
            picked.Name = collection[3];
            picked.Document = FileNameValidator(collection[4]);
            picked.TotalCost = Convert.ToDecimal(collection[5].Replace(".", ","));

            await _growingChargesRepository.UpdateAsync(picked);
        }

        public void DeleteFinikChargesById(int id)
        {
            _growingChargesRepository.Delete(id);
        }
        #endregion



        #region FinikProfits

        public List<GrowingFruitProfits> GetFinikProfits(int userId)
        {
            return Calculate(_growingFruitProfitsRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Finik").ToList(), userId);
        }

        public GrowingFruitProfits GetFinikProfitById(int id)
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

        public async Task AddNewFinikProfitById(int id, FormCollection collection)
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
