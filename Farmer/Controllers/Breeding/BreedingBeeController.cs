using System;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using Domain.Context;
using Domain.Entities.Breeding;
using Infrastructure.Interfaces.Breeding;
using Infrastructure.Repository.Breeding;
using Infrastructure.Repository.Users;
using Microsoft.AspNet.Identity;
using Servises.Breeding;
using Servises.Interfaces;

namespace Farmer.Controllers.Breeding
{

    [FarmerAuthorize]
    public partial class BreedingController : Controller
    {

        #region Declarations

        private readonly IBreedingService _breedingService;
        private static IBreedingCulturesRepository _breedingCulturesRepository;
        private static IHoneyTypeRepository _honeyTypeRepository;
        private readonly DatabaseContext _context = new DatabaseContext();
        #endregion


        #region Constructor

        public BreedingController()
        {
            _breedingService = new BreedingService(new YoungBreedingRepository(_context), new BreedingComingsRepository(_context),
             new BeeComingsRepository(_context), new FishComingsRepository(_context), new BreedingChargesRepository(_context),
             new BreedingDailyProfitRepository(_context), new BeeHoneyRepository(_context), new BreedingProfitRepository(_context),
             new FishProfitRepository(_context), new BreedingRemindingRepository(_context), new BreedingTypeRepository(_context),
             new BreedingCulturesRepository(_context), new HoneyTypeRepository(_context), new UsersRepository(_context));
            _breedingCulturesRepository = new BreedingCulturesRepository(_context);
            _honeyTypeRepository = new HoneyTypeRepository(_context);
        }
        #endregion


        // GET: Breeding
        public ActionResult Index()
        {
            return View();
        }



        #region BeeComing

        // GET: Breeding/BeeComing
        public ActionResult BeeComing()
        {
            return View(_breedingService.GetBeeComings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/BeeComingCreate
        public ActionResult BeeComingCreate()
        {
            return View(FillDropDownListForBee("Bee"));
        }


        // POST: Breeding/BeeComingCreate
        [HttpPost]
        public ActionResult BeeComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForBees(collection);
                if (!ModelState.IsValid) return View(ConvertToBeesModel(collection, "Bee"));
                _breedingService.AddNewBeeComing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("BeeComing");
            }
            catch
            {
                return View(FillDropDownListForBee("Bee"));
            }
        }

        // GET: Breeding/BeeComingEdit/1
        public ActionResult BeeComingEdit(int id)
        {
            return View(_breedingService.GetBeeComingById(id));
        }

        // POST: Breeding/BeeComingEdit/1
        [HttpPost]
        public ActionResult BeeComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForBees(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetBeeComingById(id));

                _breedingService.AddNewBeeComingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("BeeComing");
            }
            catch
            {
                return View(FillDropDownListForBee("Bee"));
            }
        }

        // GET: Breeding/BeeComingDelete/1
        public ActionResult BeeComingDelete(int id)
        {
            return View(_breedingService.GetBeeComingById(id));
        }

        // POST: Breeding/BeeComingDelete/1
        [HttpPost]
        public ActionResult BeeComingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteBeeComingById(id);
                Thread.Sleep(300);
                return RedirectToAction("BeeComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region BeeCharges

        // GET: Breeding/BeeCharges
        public ActionResult BeeCharges()
        {
            return View(_breedingService.GetBeeCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/BeeChargesCreate
        public ActionResult BeeChargesCreate()
        {
            return View();
        }
        // POST: Breeding/BeeChargesCreate
        [HttpPost]
        public ActionResult BeeChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _breedingService.AddNewBeeCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("BeeCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/BeeChargesEdit/1
        public ActionResult BeeChargesEdit(int id)
        {
            return View(_breedingService.GetBeeChargesById(id));
        }

        // POST: Breeding/BeeChargesEdit/1
        [HttpPost]
        public ActionResult BeeChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetBeeChargesById(id));

                _breedingService.AddNewBeeChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("BeeCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/BeeChargesDelete/1
        public ActionResult BeeChargesDelete(int id)
        {
            return View(_breedingService.GetBeeChargesById(id));
        }

        // POST: Breeding/BeeChargesDelete/1
        [HttpPost]

        public ActionResult BeeChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteBeeChargesById(id);

                return RedirectToAction("BeeCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region BeeHoney

        // GET: Breeding/BeeHoneys
        public ActionResult BeeHoneys()
        {
            return View(_breedingService.GetBeeHoneys(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/BeeHoneyCreate
        public ActionResult BeeHoneyCreate()
        {
            return View(FillDropDownListForHoney());
        }
        // POST: Breeding/BeeHoneyCreate
        [HttpPost]
        public ActionResult BeeHoneyCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForHoney(collection);
                if (!ModelState.IsValid) return View(ConvertToHoneyModel(collection, "Bee"));

                _breedingService.AddNewBeeHoney(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(400);
                return RedirectToAction("BeeHoneys");
            }
            catch
            {
                return View(FillDropDownListForHoney());
            }
        }

        // GET: Breeding/BeeHoneyEdit/1
        public ActionResult BeeHoneyEdit(int id)
        {
            return View(_breedingService.GetBeeHoneyById(id));
        }

        // POST: Breeding/BeeHoneyEdit/1
        [HttpPost]
        public ActionResult BeeHoneyEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetBeeHoneyById(id));

                _breedingService.AddNewBeeHoneyById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("BeeHoneys");
            }
            catch
            {
                return View(FillDropDownListForHoney());
            }
        }

        // GET: Breeding/BeeHoneyDelete/1
        public ActionResult BeeHoneyDelete(int id)
        {
            return View(_breedingService.GetBeeHoneyById(id));
        }

        // POST: Breeding/BeeHoneyDelete/1
        [HttpPost]

        public ActionResult BeeHoneyDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteBeeHoneyById(id);

                return RedirectToAction("BeeHoneys");
            }
            catch
            {
                return View();
            }
        }

        #endregion



        #region BeeReminding

        // GET: Breeding/BeeRemindings
        public ActionResult BeeRemindings()
        {
            return View(_breedingService.GetBeeRemindings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/BeeRemindingCreate
        public ActionResult BeeRemindingCreate()
        {
            return View();
        }
        // POST: Breeding/BeeRemindingCreate
        [HttpPost]
        public ActionResult BeeRemindingCreate(FormCollection collection)
        {
            try
            {
                _breedingService.AddNewBeeReminding(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("BeeRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/BeeRemindingEdit/1
        public ActionResult BeeRemindingEdit(int id)
        {
            return View(_breedingService.GetBeeRemindingById(id));
        }

        // POST: Breeding/BeeRemindingEdit/1
        [HttpPost]
        public ActionResult BeeRemindingEdit(int id, FormCollection collection)
        {
            try
            {
                _breedingService.AddNewBeeRemindingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("BeeRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/BeeRemindingDelete/1
        public ActionResult BeeRemindingDelete(int id)
        {
            return View(_breedingService.GetBeeRemindingById(id));
        }

        // POST: Breeding/BeeRemindingDelete/1
        [HttpPost]

        public ActionResult BeeRemindingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteBeeRemindingById(id);

                return RedirectToAction("BeeRemindings");
            }
            catch
            {
                return View();
            }
        }
        #endregion



        #region Validation

        private void ValidationForAnimals(NameValueCollection collection)
        {
            if (string.IsNullOrEmpty(collection[1]) || string.IsNullOrEmpty(collection[2]) ||
                string.IsNullOrEmpty(collection[3]) || string.IsNullOrEmpty(collection[4]) ||
                string.IsNullOrEmpty(collection[5]) || string.IsNullOrEmpty(collection[7]) ||
                string.IsNullOrEmpty(collection[8]))
                ModelState.AddModelError("", "Вы заполнили не все поля");
            decimal result1; decimal result2;
            if (!decimal.TryParse(collection[5].Replace(".", ","), out result1))
                ModelState.AddModelError("Mass", "Вводите только дробные числа с запятой");
            if (!decimal.TryParse(collection[7].Replace(".", ","), out result2))
                ModelState.AddModelError("Cost", "Вводите только дробные числа с запятой");
        }

        private void ValidationForBees(NameValueCollection collection)
        {
            if (string.IsNullOrEmpty(collection[1]) || string.IsNullOrEmpty(collection[2]) ||
               string.IsNullOrEmpty(collection[3]) || string.IsNullOrEmpty(collection[4]) ||
               string.IsNullOrEmpty(collection[5]) || string.IsNullOrEmpty(collection[6]))
                ModelState.AddModelError("", "Вы заполнили не все поля");
            decimal result;
            if (!decimal.TryParse(collection[5].Replace(".", ","), out result))
                ModelState.AddModelError("Cost", "Вводите только дробные числа с запятой");
        }

        private void ValidationForFishes(NameValueCollection collection)
        {

            if (string.IsNullOrEmpty(collection[1]) || string.IsNullOrEmpty(collection[2]) ||
                string.IsNullOrEmpty(collection[3]) || string.IsNullOrEmpty(collection[4]) ||
                string.IsNullOrEmpty(collection[5]) || string.IsNullOrEmpty(collection[6]) ||
                string.IsNullOrEmpty(collection[7]))
                ModelState.AddModelError("", "Вы заполнили не все поля");
            decimal result1; decimal result2;
            if (!decimal.TryParse(collection[6].Replace(".", ","), out result1))
                ModelState.AddModelError("Cost", "Вводите только дробные числа с запятой");
            if (!decimal.TryParse(collection[7].Replace(".", ","), out result2))
                ModelState.AddModelError("Amount", "Вводите только дробные числа с запятой");
        }

        private void ValidationForHoney(NameValueCollection collection)
        {
            if (string.IsNullOrEmpty(collection[1]) || string.IsNullOrEmpty(collection[3]) ||
                string.IsNullOrEmpty(collection[4]) || string.IsNullOrEmpty(collection[5]) ||
                string.IsNullOrEmpty(collection[6]) || string.IsNullOrEmpty(collection[8]))
                ModelState.AddModelError("", "Вы заполнили не все поля");
            decimal result1; decimal result2;
            if (!decimal.TryParse(collection[5].Replace(".", ","), out result1))
                ModelState.AddModelError("Amount", "Вводите только дробные числа с запятой");
            if (!decimal.TryParse(collection[6].Replace(".", ","), out result2))
                ModelState.AddModelError("Cost", "Вводите только дробные числа с запятой");
        }


        private static YoungBreeding ConvertToYoungModel(NameValueCollection collection, string breedingtype)
        {
            var youngmodel = new YoungBreeding
            {
                CultureType = collection[2],
                Name = collection[3],
                MassType = collection[4],
                CurrencyType = collection[6]
            };
            DateTime d1;
            if (DateTime.TryParse(collection[1], out d1)) youngmodel.ReceiptDate = Convert.ToDateTime(collection[1]);
            decimal result1;
            var mass = collection[5].Replace(".", ",");
            if (!string.IsNullOrEmpty(mass) && decimal.TryParse(mass, out result1))
                youngmodel.Mass = Convert.ToDecimal(mass);
            decimal result2;
            var cost = collection[7].Replace(".", ",");
            if (!string.IsNullOrEmpty(cost) && decimal.TryParse(cost, out result2))
                youngmodel.Cost = Convert.ToDecimal(cost);
            var amount = collection[8];
            if (!string.IsNullOrEmpty(amount))
                youngmodel.Amount = Convert.ToInt32(amount);
            youngmodel.Document = collection[9];
            youngmodel.BreedingCultureses = _breedingCulturesRepository.Get().Where(c => c.BreedingType.Name == breedingtype);

            return youngmodel;
        }

        private static YoungBreeding FillYoungDropDownList(string breedingtype)
        {
            return new YoungBreeding { BreedingCultureses = _breedingCulturesRepository.Get().Where(c => c.BreedingType.Name == breedingtype) };
        }



        private static BreedingComings ConvertToAnimalsModel(NameValueCollection collection, string breedingtype)
        {
            var breedingmodel = new BreedingComings
            {
                CultureType = collection[2],
                Name = collection[3],
                MassType = collection[4],
                CurrencyType = collection[6]
            };
            DateTime d1;
            if (DateTime.TryParse(collection[1], out d1)) breedingmodel.ReceiptDate = Convert.ToDateTime(collection[1]);
            decimal result1;
            var mass = collection[5].Replace(".", ",");
            if (!string.IsNullOrEmpty(mass) && decimal.TryParse(mass, out result1))
                breedingmodel.Mass = Convert.ToDecimal(mass);
            decimal result2;
            var cost = collection[7].Replace(".", ",");
            if (!string.IsNullOrEmpty(cost) && decimal.TryParse(cost, out result2))
                breedingmodel.Cost = Convert.ToDecimal(cost);
            var amount = collection[8];
            if (!string.IsNullOrEmpty(amount))
                breedingmodel.Amount = Convert.ToInt32(amount);
            breedingmodel.Document = collection[9];
            breedingmodel.BreedingCultureses = _breedingCulturesRepository.Get().Where(c => c.BreedingType.Name == breedingtype);

            return breedingmodel;
        }

        private static BeeComings ConvertToBeesModel(NameValueCollection collection, string breedingtype)
        {
            var beemodel = new BeeComings
            {
                CultureType = collection[2],
                Name = collection[3],
                CurrencyType = collection[4]
            };
            DateTime d1;
            if (DateTime.TryParse(collection[1], out d1)) beemodel.ReceiptDate = Convert.ToDateTime(collection[1]);
            decimal result1;
            var cost = collection[5].Replace(".", ",");
            if (!string.IsNullOrEmpty(cost) && decimal.TryParse(cost, out result1))
                beemodel.Cost = Convert.ToDecimal(cost);
            var amount = collection[6];
            if (!string.IsNullOrEmpty(amount))
                beemodel.Amount = Convert.ToInt32(amount);
            beemodel.Document = collection[7];
            beemodel.BreedingCultureses = _breedingCulturesRepository.Get().Where(c => c.BreedingType.Name == breedingtype);

            return beemodel;
        }

        private static FishComings ConvertToFishesModel(NameValueCollection collection, string breedingtype)
        {
            var fishmodel = new FishComings
            {
                CultureType = collection[2],
                Name = collection[3],
                MassType = collection[4],
                CurrencyType = collection[5]
            };
            DateTime d1;
            if (DateTime.TryParse(collection[1], out d1)) fishmodel.ReceiptDate = Convert.ToDateTime(collection[1]);
            decimal result1; decimal result2;
            var cost = collection[6].Replace(".", ",");
            if (!string.IsNullOrEmpty(cost) && decimal.TryParse(cost, out result1))
                fishmodel.Cost = Convert.ToDecimal(cost);
            var amount = collection[7].Replace(".", ",");
            if (!string.IsNullOrEmpty(amount) && decimal.TryParse(amount, out result2))
                fishmodel.Amount = Convert.ToDecimal(amount);

            fishmodel.Document = collection[8];
            fishmodel.BreedingCultureses = _breedingCulturesRepository.Get().Where(c => c.BreedingType.Name == breedingtype);

            return fishmodel;
        }

        private static BeeHoney ConvertToHoneyModel(NameValueCollection collection, string breedingtype)
        {
            var honeymodel = new BeeHoney
            {
                AnimalName = collection[2],
                HoneyType = collection[3],
                MassType = collection[4]
            };
            DateTime d1;
            if (DateTime.TryParse(collection[1], out d1)) honeymodel.Date = Convert.ToDateTime(collection[1]);
            decimal result1; decimal result2;
            var amount = collection[5].Replace(".", ",");
            if (!string.IsNullOrEmpty(amount) && decimal.TryParse(amount, out result1))
                honeymodel.Amount = Convert.ToDecimal(amount);
            var cost = collection[6].Replace(".", ",");
            if (!string.IsNullOrEmpty(cost) && decimal.TryParse(cost, out result2))
                honeymodel.Cost = Convert.ToDecimal(cost);

            honeymodel.Document = collection[7];
            honeymodel.BreedingCultureses = _breedingCulturesRepository.Get().Where(c => c.BreedingType.Name == breedingtype);
            honeymodel.HoneyTypeses = _honeyTypeRepository.Get().ToList();

            return honeymodel;
        }


        private static BreedingComings FillDropDownList(string breedingtype)
        {
            return new BreedingComings { BreedingCultureses = _breedingCulturesRepository.Get().Where(c => c.BreedingType.Name == breedingtype) };
        }

        private static BeeComings FillDropDownListForBee(string breedingtype)
        {
            return new BeeComings { BreedingCultureses = _breedingCulturesRepository.Get().Where(c => c.BreedingType.Name == breedingtype) };
        }

        private static FishComings FillDropDownListForFish(string breedingtype)
        {
            return new FishComings { BreedingCultureses = _breedingCulturesRepository.Get().Where(c => c.BreedingType.Name == breedingtype) };
        }

        private static BeeHoney FillDropDownListForHoney()
        {
            return new BeeHoney { HoneyTypeses = _honeyTypeRepository.Get().ToList() };
        }

        private void ValidationForCharges(NameValueCollection collection)
        {
            if (string.IsNullOrEmpty(collection[1]) || string.IsNullOrEmpty(collection[2]) ||
             string.IsNullOrEmpty(collection[3]) || string.IsNullOrEmpty(collection[5]))
                ModelState.AddModelError("", "Вы заполнили не все поля");

            decimal result;
            if (!decimal.TryParse(collection[5].Replace(".", ","), out result))
                ModelState.AddModelError("TotalCost", "Вводите только дробные числа с запятой");
        }

        private static BreedingCharges ConvertToChargesModel(NameValueCollection collection)
        {
            var chargesmodel = new BreedingCharges();
            DateTime d1;
            if (DateTime.TryParse(collection[1], out d1)) chargesmodel.ApplicationDate = Convert.ToDateTime(collection[1]);
            chargesmodel.AnimalName = collection[2];
            chargesmodel.Name = collection[3];
            chargesmodel.Document = collection[4];
            decimal result;
            var cost = collection[5].Replace(".", ",");
            if (!string.IsNullOrEmpty(cost) && decimal.TryParse(cost, out result))
                chargesmodel.TotalCost = Convert.ToDecimal(cost);

            return chargesmodel;
        }

        private void ValidationForProfits(NameValueCollection collection)
        {
            if (string.IsNullOrEmpty(collection[1]) || string.IsNullOrEmpty(collection[4]) ||
              string.IsNullOrEmpty(collection[5]))
                ModelState.AddModelError("", "Вы заполнили не все поля");
            decimal result1; decimal result2;
            if (!decimal.TryParse(collection[4].Replace(".", ","), out result1))
                ModelState.AddModelError("Amount", "Вводите только дробные числа с запятой");
            if (!decimal.TryParse(collection[5].Replace(".", ","), out result2))
                ModelState.AddModelError("Cost", "Вводите только дробные числа с запятой");
        }

        private void ValidationForDaily(NameValueCollection collection)
        {
            if (string.IsNullOrEmpty(collection[1]) || string.IsNullOrEmpty(collection[2]) ||
                string.IsNullOrEmpty(collection[3]) || string.IsNullOrEmpty(collection[4]) ||
                string.IsNullOrEmpty(collection[5]) || string.IsNullOrEmpty(collection[6]))
                ModelState.AddModelError("", "Вы заполнили не все поля");
            decimal result1; decimal result2;
            if (!decimal.TryParse(collection[5].Replace(".", ","), out result1))
                ModelState.AddModelError("Amount", "Вводите только дробные числа с запятой");
            if (!decimal.TryParse(collection[6].Replace(".", ","), out result2))
                ModelState.AddModelError("Cost", "Вводите только дробные числа с запятой");
        }

        private static BreedingDailyProfit ConvertToDailyModel(NameValueCollection collection)
        {
            var dailymodel = new BreedingDailyProfit();
            DateTime d1;
            if (DateTime.TryParse(collection[1], out d1)) dailymodel.Date = Convert.ToDateTime(collection[1]);
            dailymodel.AnimalName = collection[2];
            dailymodel.Name = collection[3];
            dailymodel.MassType = collection[4];
            decimal result1;
            var amount = collection[5].Replace(".", ",");
            if (!string.IsNullOrEmpty(amount) && decimal.TryParse(amount, out result1))
                dailymodel.Amount = Convert.ToDecimal(amount);
            decimal result2;
            var cost = collection[6].Replace(".", ",");
            if (!string.IsNullOrEmpty(cost) && decimal.TryParse(cost, out result2))
                dailymodel.Cost = Convert.ToDecimal(cost);
            dailymodel.Document = collection[7];

            return dailymodel;
        }

        private static FormCollection Compatibility(FormCollection collection)
        {
            switch (collection.Count)
            {
                case 7:
                    if (!IsDocument(collection)) collection.Add("Document", "");
                    return collection;
                case 9:
                    if (!IsDocument(collection)) collection.Add("Document", "");
                    return collection;
                case 8:
                    var animalname = collection[7];
                    collection.Remove("AnimalName");
                    if (!IsDocument(collection)) collection.Add("Document", "");
                    collection.Add("AnimalName", animalname);
                    return collection;
                case 6:
                    var totalcost = collection[4];
                    var animalname1 = collection[5];
                    collection.Remove("TotalCost");
                    collection.Remove("AnimalName");
                    if (!IsDocument(collection)) collection.Add("Document", "");
                    collection.Add("TotalCost", totalcost);
                    collection.Add("AnimalName", animalname1);
                    return collection;
                default:
                    return collection;
            }
        }

        private static bool IsDocument(NameValueCollection collection)
        {
            return collection.AllKeys.Any(item => item.Equals("Document"));
        }
        #endregion


        #region Dispose

        public new void Dispose()
        {
            if (_breedingService == null) return;
            _breedingService.Dispose();
            if (_breedingCulturesRepository == null) return;
            _breedingCulturesRepository.Dispose();
            // ReSharper disable once UseNullPropagation
            if (_honeyTypeRepository == null) return;
            _honeyTypeRepository.Dispose();
        }
        #endregion

    }
}