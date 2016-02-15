using System;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using Domain.Entities.Growing;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Growing
{
   
    public partial class GrowingController 
    {
       
        #region BreadComing

        // GET: Growing/BreadComing
        public ActionResult BreadComing()
        {
            return View(_growingFieldService.GetBreadComings(User.Identity.GetUserId<int>()));
        }


        // GET: Growing/BreadComingCreate
        public ActionResult BreadComingCreate()
        {
            return View(FillFieldDropDownList("Bread"));
              
        }

        // POST: Growing/BreadComingCreate
        [HttpPost]
        public ActionResult BreadComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFieldCrops(collection);
                if (!ModelState.IsValid) return View(ConvertToFieldModel(collection, "Bread"));
                _growingFieldService.AddNewGrowing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("BreadComing");
            }
            catch
            {
                return View(FillFieldDropDownList("Bread"));
            }
        }


        // GET: Growing/BreadComingEdit/1
        public ActionResult BreadComingEdit(int id)
        {
            return View(_growingFieldService.GetBreadComingById(id));
        }

        // POST: Growing/BreadComingEdit/1
        [HttpPost]
        public ActionResult BreadComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFieldCrops(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetBreadComingById(id));

                _growingFieldService.AddNewGrowingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("BreadComing");
            }
            catch
            {
                return View(FillFieldDropDownList("Bread"));
            }
        }

        // GET: Growing/BreadComingDelete/1
        public ActionResult BreadComingDelete(int id)
        {
            return View(_growingFieldService.GetBreadComingById(id));
        }


        // POST: Growing/BreadComingDelete/1
        [HttpPost]
        public ActionResult BreadComingDelete(int id, FormCollection collection)
        {
            try
            {      
                _growingFieldService.DeleteGrowingById(id);
                Thread.Sleep(300);
                DeleteEmptyDocumentsFromServer();
                return RedirectToAction("BreadComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion



        #region BreadCharges
        // GET: Growing/BreadCharges
        public ActionResult BreadCharges()
        {
            return View(_growingFieldService.GetBreadCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/BreadChargesCreate
        public ActionResult BreadChargesCreate()
        {
            return View();
        }

        // POST: Growing/BreadChargesCreate
        [HttpPost]
        public ActionResult BreadChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _growingFieldService.AddNewBreadCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("BreadCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/BreadChargesEdit/1
        public ActionResult BreadChargesEdit(int id)
        {
            return View(_growingFieldService.GetBreadChargesById(id));
        }

        // POST: Growing/BreadChargesEdit/1
        [HttpPost]
        public ActionResult BreadChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetBreadChargesById(id));

                _growingFieldService.AddNewBreadChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("BreadCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/BreadChargesDelete/1
        public ActionResult BreadChargesDelete(int id)
        {
            return View(_growingFieldService.GetBreadChargesById(id));
        }

        // POST: Growing/BreadChargesDelete/1
        [HttpPost]

        public ActionResult BreadChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _growingFieldService.DeleteBreadChargesById(id);

                return RedirectToAction("BreadCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion



        #region BreadRetiring

        // GET: Growing/BreadProfits
        public ActionResult BreadProfits()
        {
            return View(_growingFieldService.GetBreadProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/BreadProfitEdit/1
        public ActionResult BreadProfitEdit(int id)
        {
            return View(_growingFieldService.GetBreadProfitById(id));
        }

        // POST: Growing/BreadProfitEdit/1
        [HttpPost]
        public ActionResult BreadProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetBreadProfitById(id));

                _growingFieldService.AddNewBreadProfitById(id, collection);

                return RedirectToAction("BreadProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region Validation
    
        private void ValidationForFieldCrops(NameValueCollection collection)
        {
            if (string.IsNullOrEmpty(collection[1]) || string.IsNullOrEmpty(collection[2]) ||
                string.IsNullOrEmpty(collection[3]) || string.IsNullOrEmpty(collection[6]) ||
                string.IsNullOrEmpty(collection[7]))
                ModelState.AddModelError("", "Вы заполнили не все поля");
            decimal result1; decimal result2;
            if (!decimal.TryParse(collection[6].Replace(".", ","), out result1))
                ModelState.AddModelError("Cost", "Вводите только дробные числа с запятой");
          
            if (!decimal.TryParse(collection[7].Replace(".", ","), out result2))
                ModelState.AddModelError("Amount", "Вводите только дробные числа с запятой");

        }


        private static GrowingFieldComings ConvertToFieldModel(NameValueCollection collection, string growingtype)
        {
            var bread = new GrowingFieldComings
            {
                CultureType = collection[2],
                Name = collection[3],
                MassType = collection[4],
                CurrencyType = collection[5]
            };
            DateTime d1;
            if (DateTime.TryParse(collection[1], out d1)) bread.LandingDate = Convert.ToDateTime(collection[1]);
            decimal result;
            var cost = collection[6].Replace(".", ",");
            if (!string.IsNullOrEmpty(cost) && decimal.TryParse(cost, out result))
                bread.Cost = Convert.ToDecimal(cost);
            var amount = collection[7].Replace(".", ",");
            if (!string.IsNullOrEmpty(amount))
                if (!string.IsNullOrEmpty(amount) && decimal.TryParse(amount, out result))
                    bread.Amount = Convert.ToDecimal(amount);
            bread.Document = collection[8];
            bread.GrowingCultureses = _growingCulturesRepository.Get().Where(c => c.GrowingType.Name == growingtype);

            return bread;
        }

        private static GrowingFieldComings FillFieldDropDownList(string growingtype)
        {
            return new GrowingFieldComings { GrowingCultureses = _growingCulturesRepository.Get().Where(c => c.GrowingType.Name == growingtype) };
        }

        #endregion


    }
}

