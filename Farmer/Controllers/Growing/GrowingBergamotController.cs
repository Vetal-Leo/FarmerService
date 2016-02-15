using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using Domain.Context;
using Domain.Entities.Growing;
using Infrastructure.Interfaces.Growing;
using Infrastructure.Repository.Growing;
using Infrastructure.Repository.Users;
using Microsoft.AspNet.Identity;
using Servises.Growing;
using Servises.Interfaces;

namespace Farmer.Controllers.Growing
{
    [FarmerAuthorize]
    public partial class GrowingController : Controller
    {
        #region Declarations

        private readonly IGrowingService _growingFieldService;
        private readonly IGrowingService _growingFruitService;
        private static IGrowingCulturesRepository _growingCulturesRepository;
        private static IGrowingTypeRepository _growingTypeRepository;
        private readonly DatabaseContext _context = new DatabaseContext();
        #endregion


        #region Constructor

        public GrowingController()
        {
            _growingFieldService = new GrowingService(new GrowingFieldComingsRepository(_context), new GrowingChargesRepository(_context),
                new UsersRepository(_context), new GrowingFieldProfitsRepository(_context), new GrowingTypeRepository(_context),
                new GrowingCulturesRepository(_context));
            _growingFruitService = new GrowingService(new GrowingFruitComingsRepository(_context), new GrowingChargesRepository(_context),
                new UsersRepository(_context), new GrowingFruitProfitsRepository(_context), new GrowingTypeRepository(_context),
                new GrowingCulturesRepository(_context));
            _growingCulturesRepository = new GrowingCulturesRepository(_context);
            _growingTypeRepository = new GrowingTypeRepository(_context);

        }
        #endregion


        // GET: Growing
        public ActionResult Index()
        {
            return View();
        }


        #region BergamotComing

        // GET: Growing/BergamotComing
        public ActionResult BergamotComing()
        {
            return View(_growingFruitService.GetBergamotComings(User.Identity.GetUserId<int>()));
        }


        // GET: Growing/BergamotComingCreate
        public ActionResult BergamotComingCreate()
        {
            return View(FillFruitDropDownList("Bergamot"));
        }

        // POST: Growing/BergamotComingCreate
        [HttpPost]
        public ActionResult BergamotComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFruitCrops(collection);
                if (!ModelState.IsValid) return View(ConvertToFruitModel(collection, "Bergamot"));

                _growingFruitService.AddNewBergamot(User.Identity.GetUserId<int>(), collection);
                return RedirectToAction("BergamotComing");
            }
            catch
            {
                return View(FillFruitDropDownList("Bergamot"));
            }
        }



        // GET: Growing/BergamotComingEdit/1
        public ActionResult BergamotComingEdit(int id)
        {
            return View(_growingFruitService.GetBergamotComingById(id));
        }

        // POST: Growing/BergamotComingEdit/1
        [HttpPost]
        public ActionResult BergamotComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFruitCrops(collection);
                if (!ModelState.IsValid) return View(_growingFruitService.GetBergamotComingById(id));

                _growingFruitService.AddNewBergamotById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("BergamotComing");
            }
            catch
            {
                return View(FillFruitDropDownList("Bergamot"));
            }
        }


        // GET: Growing/BergamotComingDelete/1
        public ActionResult BergamotComingDelete(int id)
        {
            return View(_growingFruitService.GetBergamotComingById(id));
        }

        // POST: Growing/BergamotComingDelete/1
        [HttpPost]
        public ActionResult BergamotComingDelete(int id, FormCollection collection)
        {
            try
            {     
                _growingFruitService.DeleteBergamotById(id);
                Thread.Sleep(300);
                DeleteEmptyDocumentsFromServer();
                return RedirectToAction("BergamotComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region BergamotCharges

        // GET: Growing/BergamotCharges
        public ActionResult BergamotCharges()
        {
            return View(_growingFruitService.GetBergamotCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/BergamotChargesCreate
        public ActionResult BergamotChargesCreate()
        {
            return View();
        }
        // POST: Growing/BergamotChargesCreate
        [HttpPost]
        public ActionResult BergamotChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _growingFruitService.AddNewBergamotCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("BergamotCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/BergamotChargesEdit/1
        public ActionResult BergamotChargesEdit(int id)
        {
            return View(_growingFruitService.GetBergamotChargesById(id));
        }

        // POST: Growing/BergamotChargesEdit/1
        [HttpPost]
        public ActionResult BergamotChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_growingFruitService.GetBergamotChargesById(id));

                _growingFruitService.AddNewBergamotChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("BergamotCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/BergamotChargesDelete/1
        public ActionResult BergamotChargesDelete(int id)
        {
            return View(_growingFruitService.GetBergamotChargesById(id));
        }

        // POST: Growing/BergamotChargesDelete/1
        [HttpPost]

        public ActionResult BergamotChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _growingFruitService.DeleteBergamotChargesById(id);

                return RedirectToAction("BergamotCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion




        #region BergamotRetiring

        // GET: Growing/BergamotProfits
        public ActionResult BergamotProfits()
        {
            return View(_growingFruitService.GetBergamotProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/BergamotProfitEdit/1
        public ActionResult BergamotProfitEdit(int id)
        {
            return View(_growingFruitService.GetBergamotProfitById(id));
        }

        // POST: Growing/BergamotProfitEdit/1
        [HttpPost]
        public ActionResult BergamotProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_growingFruitService.GetBergamotProfitById(id));

                _growingFruitService.AddNewBergamotProfitById(id, collection);

                return RedirectToAction("BergamotProfits");
            }
            catch
            {
                return View();
            }
        }



        #endregion

        #region Validation

        private void ValidationForFruitCrops(NameValueCollection collection)
        {
            if (string.IsNullOrEmpty(collection[1]) || string.IsNullOrEmpty(collection[2]) ||
                string.IsNullOrEmpty(collection[3]) || string.IsNullOrEmpty(collection[4]) ||
                string.IsNullOrEmpty(collection[7]) || string.IsNullOrEmpty(collection[8]))
                ModelState.AddModelError("", "Вы заполнили не все поля");
            DateTime d1; DateTime d2;
            if (DateTime.TryParse(collection[1], out d1) &&
                DateTime.TryParse(collection[2], out d2))
            {
                if (Convert.ToDateTime(collection[2]) <= Convert.ToDateTime(collection[1]).AddDays(7))
                    ModelState.AddModelError("FloweringDate", "Дата цветения должна быть больше даты посадки минимум 1 неделя");
            }

            decimal result1; decimal result2;
            if (!decimal.TryParse(collection[7].Replace(".", ","), out result1))
                ModelState.AddModelError("Cost", "Вводите только дробные числа с запятой");
            if (!decimal.TryParse(collection[8].Replace(".", ","), out result2))
                ModelState.AddModelError("Amount", "Вводите только дробные числа с запятой");

        }


        private static GrowingFruitComings ConvertToFruitModel(NameValueCollection collection, string growingtype)
        {
            var fruitmodel = new GrowingFruitComings()
            {
                CultureType = collection[3],
                Name = collection[4],
                MassType = collection[5],
                CurrencyType = collection[6]
            };
            DateTime d1; DateTime d2;
            if (DateTime.TryParse(collection[1], out d1)) fruitmodel.LandingDate = Convert.ToDateTime(collection[1]);
            if (DateTime.TryParse(collection[2], out d2)) fruitmodel.FloweringDate = Convert.ToDateTime(collection[2]);

            decimal result;
            var cost = collection[7].Replace(".", ",");
            if (!string.IsNullOrEmpty(cost) && decimal.TryParse(cost, out result))
                fruitmodel.Cost = Convert.ToDecimal(cost);
            var amount = collection[8].Replace(".", ",");
            if (!string.IsNullOrEmpty(amount) && decimal.TryParse(amount, out result))
                fruitmodel.Amount = Convert.ToDecimal(amount);

            fruitmodel.Document = collection[9];
            fruitmodel.GrowingCultureses = _growingCulturesRepository.Get().Where(c => c.GrowingType.Name == growingtype);

            return fruitmodel;
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

        private static GrowingCharges ConvertToChargesModel(NameValueCollection collection)
        {
            var chargesmodel = new GrowingCharges();
            DateTime d1;
            if (DateTime.TryParse(collection[1], out d1)) chargesmodel.ApplicationDate = Convert.ToDateTime(collection[1]);
            chargesmodel.PlantName = collection[2];
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

        public static GrowingFruitComings FillFruitDropDownList(string growingtype)
        {
            return new GrowingFruitComings { GrowingCultureses = _growingCulturesRepository.Get().Where(c => c.GrowingType.Name == growingtype) };
        }

        private static FormCollection Compatibility(FormCollection collection)
        {
            switch (collection.Count)
            {
                case 9:                  
                    if(!IsDocument(collection)) collection.Add("Document", "");
                    return collection;
                case 8:
                    if (!IsDocument(collection)) collection.Add("Document", "");
                    return collection;
                case 6:
                    var totalcost = collection[4];
                    var plantname = collection[5];
                    collection.Remove("TotalCost");
                    collection.Remove("PlantName");
                    if (!IsDocument(collection)) collection.Add("Document", "");
                    collection.Add("TotalCost", totalcost);
                    collection.Add("PlantName", plantname);
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
            if (_growingFieldService == null) return;
            _growingFieldService.Dispose();
            if (_growingFruitService == null) return;
            _growingFruitService.Dispose();
            if (_growingTypeRepository == null) return;
            _growingTypeRepository.Dispose();
            // ReSharper disable once UseNullPropagation
            if (_growingCulturesRepository == null) return;
            _growingCulturesRepository.Dispose();

        }

      
        #endregion
    }
}
