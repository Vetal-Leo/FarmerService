using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain.Context;
using Domain.Entities.Growing;
using Infrastructure.Interfaces.Growing;
using Infrastructure.Interfaces.Users;
using Servises.Interfaces;

namespace Servises.Growing
{
    public partial class GrowingService : BaseService, IGrowingService
    {
        #region Declarations

        private IGrowingFieldComingsRepository _growingFieldComingsRepository;
        private IGrowingFruitComingsRepository _growingFruitComingsRepository;
        private IGrowingChargesRepository _growingChargesRepository;
        private IGrowingFieldProfitsRepository _growingFieldProfitsRepository;
        private IGrowingFruitProfitsRepository _growingFruitProfitsRepository;
        private IGrowingTypeRepository _growingTypeRepository;
        private IGrowingCulturesRepository _growingCulturesRepository;
        private IUsersRepository _usersRepository;
        private readonly DatabaseContext _context = new DatabaseContext();
        #endregion

        #region Constructor 

        public GrowingService(IGrowingFieldComingsRepository growingFieldComingsRepository)
        {
            _growingFieldComingsRepository = growingFieldComingsRepository;
        }
        public GrowingService(IGrowingFruitComingsRepository growingFruitComingsRepository)
        {
            _growingFruitComingsRepository = growingFruitComingsRepository;
        }
        public GrowingService(IGrowingFieldComingsRepository growingFieldComingsRepository, IGrowingChargesRepository growingChargesRepository,
           IUsersRepository userRepository, IGrowingFieldProfitsRepository growingFieldProfitsRepository, IGrowingTypeRepository growingTypeRepository,
           IGrowingCulturesRepository growingCulturesRepository)
        {
            _growingFieldComingsRepository = growingFieldComingsRepository;
            _growingChargesRepository = growingChargesRepository;
            _growingFieldProfitsRepository = growingFieldProfitsRepository;
            _growingTypeRepository = growingTypeRepository;
            _growingCulturesRepository = growingCulturesRepository;
            _usersRepository = userRepository;
        }
        public GrowingService(IGrowingFruitComingsRepository growingFruitComingsRepository, IGrowingChargesRepository growingChargesRepository,
          IUsersRepository userRepository, IGrowingFruitProfitsRepository growingFruitProfitsRepository, IGrowingTypeRepository growingTypeRepository,
          IGrowingCulturesRepository growingCulturesRepository)
        {
            _growingFruitComingsRepository = growingFruitComingsRepository;
            _growingChargesRepository = growingChargesRepository;
            _growingFruitProfitsRepository = growingFruitProfitsRepository;
            _growingTypeRepository = growingTypeRepository;
            _growingCulturesRepository = growingCulturesRepository;
            _usersRepository = userRepository;
        }


        #endregion



        #region BergamotComings

        public List<GrowingFruitComings> GetBergamotComings(int userId)
        {

            return Calculate(_growingFruitComingsRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Bergamot").ToList());
        }


        public async Task AddNewBergamot(int userId, FormCollection collection)
        {
            var bergamot = new GrowingFruitComings()
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Bergamot"),
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
                    ExpirationDate = GetExpirationDateForBergamot(DateTime.Parse(collection[2]), collection[3]),
                    Remind = false,
                    User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                    GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Bergamot")
                };
                await _growingFruitProfitsRepository.AddAsync(profit);
            }
        }

      

        private static DateTime? GetExpirationDateForBergamot(DateTime floweringdate, string culturetype)
        {
            switch (culturetype)
            {
                case "Абрикос":
                    return floweringdate.AddDays(40);
                case "Абрикос японский":
                    return floweringdate.AddDays(140);
                case "Авара":
                    return floweringdate.AddDays(135);
                case "Авокадо":
                    return floweringdate.AddDays(150);
                case "Азимина трёхлопастная":
                    return floweringdate.AddDays(100);
                case "Айва":
                    return floweringdate.AddDays(200);
                case "Айва китайская":
                    return floweringdate.AddDays(180);
                case "Алыча":
                    return floweringdate.AddDays(120);
                case "Амазонский виноград":
                    return floweringdate.AddDays(110);
                case "Аннона сенегальская":
                    return floweringdate.AddDays(190);
                case "Антильский крыжовник":
                    return floweringdate.AddDays(120);
                case "Апельсин":
                    return floweringdate.AddDays(230);
                case "Араза":
                    return floweringdate.AddDays(150);
                case "Бабако":
                    return floweringdate.AddDays(255);
                case "Баиль":
                    return floweringdate.AddDays(315);
                case "Белая сапота":
                    return floweringdate.AddDays(210);
                case "Бергамот":
                    return floweringdate.AddDays(280);
                case "Бигнай":
                    return floweringdate.AddDays(180);
                case "Билимби":
                    return floweringdate.AddDays(180);
                case "Бирманский виноград":
                    return floweringdate.AddDays(90);
                case "Боярышник азароль":
                    return floweringdate.AddDays(150);
                case "Боярышник понтийский":
                    return floweringdate.AddDays(150);
                case "Боярышник тёмно-кровавый":
                    return floweringdate.AddDays(150);
                case "Вампи":
                    return floweringdate.AddDays(90);
                case "Вишня":
                    return floweringdate.AddDays(90);
                case "Вишня вишнеобразная":
                    return floweringdate.AddDays(90);
                case "Вишня колокольчатая":
                    return floweringdate.AddDays(90);
                case "Вишня мелкопильчатая":
                    return floweringdate.AddDays(90);
                case "Вишня обыкновенная":
                    return floweringdate.AddDays(90);
                case "Водяное яблоко":
                    return floweringdate.AddDays(90);
                case "Горная папайя":
                    return floweringdate.AddDays(270);
                case "Гранат":
                    return floweringdate.AddDays(195);
                case "Грейпфрут":
                    return floweringdate.AddDays(315);
                case "Грумичама":
                    return floweringdate.AddDays(120);
                case "Груша грушелистная":
                    return floweringdate.AddDays(135);
                case "Груша обыкновенная":
                    return floweringdate.AddDays(135);
                case "Джамболан":
                    return floweringdate.AddDays(30);
                case "Джекфрут":
                    return floweringdate.AddDays(165);
                case "Дуриан цибетиновый":
                    return floweringdate.AddDays(30);
                case "Дюки":
                    return floweringdate.AddDays(60);
                case "Жаботикаба":
                    return floweringdate.AddDays(28);
                case "Земляничное дерево красное":
                    return floweringdate.AddDays(60);
                case "Земляничное дерево крупноплодное":
                    return floweringdate.AddDays(60);
                case "Земляничное дерево Менциса":
                    return floweringdate.AddDays(180);
                case "Инжир":
                    return floweringdate.AddDays(180);
            }
            return DateTime.Now;
        }

        public GrowingFruitComings GetBergamotComingById(int id)
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
                GrowingCultureses = _growingCulturesRepository.Get().Where(c => c.GrowingType.Name == "Bergamot")
            };
        }

        public async Task AddNewBergamotById(int id, FormCollection collection)
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

        public void DeleteBergamotById(int id)
        {
            _growingFruitProfitsRepository.Delete(id);
            _growingFruitComingsRepository.Delete(id);
        }

        #endregion





        #region BergamotCharges

        public List<GrowingCharges> GetBergamotCharges(int userId)
        {
            return Calculate(_growingChargesRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Bergamot").ToList());
        }

        public List<string> GetBergamotNamesById(int id)
        {
            var bergamots = _growingFruitComingsRepository.Get().Where(i => i.User.Id == id && i.GrowingType.Name == "Bergamot").ToList();
            return bergamots.Select(item => item.Name).ToList();
        }

        public async Task AddNewBergamotCharges(int userId, FormCollection collection)
        {
            var charges = new GrowingCharges
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Bergamot"),
                ApplicationDate = DateTime.Parse(collection[1]),
                PlantName = collection[2],
                Name = collection[3],
                Document = FileNameValidator(collection[4]),
                TotalCost = Convert.ToDecimal(collection[5].Replace(".", ",")),
            };

            await _growingChargesRepository.AddAsync(charges);
        }

        public GrowingCharges GetBergamotChargesById(int id)
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

        public async Task AddNewBergamotChargesById(int id, FormCollection collection)
        {
            var picked = _growingChargesRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.ApplicationDate = DateTime.Parse(collection[1]);
            picked.PlantName = collection[2];
            picked.Name = collection[3];
            picked.Document = FileNameValidator(collection[4]);
            picked.TotalCost = Convert.ToDecimal(collection[5].Replace(".", ","));

            await _growingChargesRepository.UpdateAsync(picked);
        }

        public void DeleteBergamotChargesById(int id)
        {
            _growingChargesRepository.Delete(id);
        }
        #endregion



        #region BergamotProfits

        public List<GrowingFruitProfits> GetBergamotProfits(int userId)
        {
            return Calculate(_growingFruitProfitsRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Bergamot").ToList(), userId);
        }

        public GrowingFruitProfits GetBergamotProfitById(int id)
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

        public async Task AddNewBergamotProfitById(int id, FormCollection collection)
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

        #region FileNameValidatortor

        private static string FileNameValidator(string filename)
        {
            if(string.IsNullOrWhiteSpace(filename)) return string.Empty;
            var temp = filename.Substring(filename.Length - 4);
            if (temp.Equals(".pdf")) return "/Storefiles/" + filename;
                 
            return string.Empty;
        }
        #endregion


        #region Calculate

        private static List<GrowingFruitComings> Calculate(List<GrowingFruitComings> list)
        {
            foreach (var item in list)
            {
                if (item.LandingDate != null)
                {
                    if (DateTime.Now.Month < item.LandingDate.Value.Month || (DateTime.Now.Month == item.LandingDate.Value.Month && DateTime.Now.Day < item.LandingDate.Value.Day))
                        item.WasastPlants = DateTime.Now.Year - item.LandingDate.Value.Year - 1;
                    else item.WasastPlants = DateTime.Now.Year - item.LandingDate.Value.Year;
                }
                item.TotalCost = item.Cost * item.Amount;
            }

            return list;
        }

        private static List<GrowingCharges> Calculate(List<GrowingCharges> list)
        {
            foreach (var item in list)
            {
                var samenamelist = list.Where(n => n.PlantName == item.PlantName).ToList();
                var sumcost = samenamelist.Aggregate<GrowingCharges, decimal?>(0, (current, same) => current + same.TotalCost);
                item.SumCost = sumcost;
            }

            return list;
        }

        private List<GrowingFruitProfits> Calculate(List<GrowingFruitProfits> list, int userid)
        {
            foreach (var item in list)
            {
                item.ClearCost = item.Cost * item.Amount;
                item.ProfitCost = item.Cost * item.Amount - GetSumBergamotChargesForName(item.Name, userid);
            }

            return list;
        }

        private decimal GetSumBergamotChargesForName(string name, int userId)
        {
            return _growingChargesRepository.Get().Where(i => i.User.Id == userId).ToList().Where(charge => charge.PlantName ==
                name).Aggregate<GrowingCharges, decimal>(0, (current, charge) => current + Convert.ToDecimal(charge.TotalCost));
        }

        #endregion


        public override void Dispose()
        {
            if (_growingFieldComingsRepository == null) return;
            _growingFieldComingsRepository.Dispose();
            _growingFieldComingsRepository = null;

            if (_growingFruitComingsRepository == null) return;
            _growingFruitComingsRepository.Dispose();
            _growingFruitComingsRepository = null;

            if (_growingFieldProfitsRepository == null) return;
            _growingFieldProfitsRepository.Dispose();
            _growingFieldProfitsRepository = null;

            if (_growingFruitProfitsRepository == null) return;
            _growingFruitProfitsRepository.Dispose();
            _growingFruitProfitsRepository = null;

            if (_growingTypeRepository == null) return;
            _growingTypeRepository.Dispose();
            _growingTypeRepository = null;

            if (_growingCulturesRepository == null) return;
            _growingCulturesRepository.Dispose();
            _growingCulturesRepository = null;

            if (_growingChargesRepository == null) return;
            _growingChargesRepository.Dispose();
            _growingChargesRepository = null;

            if (_usersRepository == null) return;
            _usersRepository.Dispose();
            _usersRepository = null;
        }
    }
}
