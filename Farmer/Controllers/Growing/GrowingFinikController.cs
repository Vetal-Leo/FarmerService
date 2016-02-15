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


        #region FinikComing

        // GET: Growing/FinikComing
        public ActionResult FinikComing()
        {
            return View(_growingFruitService.GetFinikComings(User.Identity.GetUserId<int>()));
        }


        // GET: Growing/FinikComingCreate
        public ActionResult FinikComingCreate()
        {
            return View(FillFruitDropDownList("Finik"));
        }



        // POST: Growing/FinikComingCreate
        [HttpPost]
        public ActionResult FinikComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFruitCrops(collection);
                if (!ModelState.IsValid) return View(ConvertToFruitModel(collection, "Finik"));

                _growingFruitService.AddNewFinik(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("FinikComing");
            }
            catch
            {
                return View(FillFruitDropDownList("Finik"));
            }
        }


        // GET: Growing/FinikComingEdit/1
        public ActionResult FinikComingEdit(int id)
        {
            return View(_growingFruitService.GetFinikComingById(id));
        }

        // POST: Growing/FinikComingEdit/1
        [HttpPost]
        public ActionResult FinikComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFruitCrops(collection);
                if (!ModelState.IsValid) return View(_growingFruitService.GetFinikComingById(id));

                _growingFruitService.AddNewFinikById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("FinikComing");
            }
            catch
            {
                return View(FillFruitDropDownList("Finik"));
            }

        }


        // GET: Growing/FinikComingDelete/1
        public ActionResult FinikComingDelete(int id)
        {
            return View(_growingFruitService.GetFinikComingById(id));
        }

        // POST: Growing/FinikComingDelete/1
        [HttpPost]
        public ActionResult FinikComingDelete(int id, FormCollection collection)
        {
            try
            {
              
                _growingFruitService.DeleteFinikById(id);
                Thread.Sleep(300);
                DeleteEmptyDocumentsFromServer();
                return RedirectToAction("FinikComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region FinikCharges

        // GET: Growing/FinikCharges
        public ActionResult FinikCharges()
        {
            return View(_growingFruitService.GetFinikCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/FinikChargesCreate
        public ActionResult FinikChargesCreate()
        {
            return View();
        }
        // POST: Growing/FinikChargesCreate
        [HttpPost]
        public ActionResult FinikChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _growingFruitService.AddNewFinikCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("FinikCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/FinikChargesEdit/1
        public ActionResult FinikChargesEdit(int id)
        {
            return View(_growingFruitService.GetFinikChargesById(id));
        }

        // POST: Growing/FinikChargesEdit/1
        [HttpPost]
        public ActionResult FinikChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_growingFruitService.GetFinikChargesById(id));

                _growingFruitService.AddNewFinikChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("FinikCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/FinikChargesDelete/1
        public ActionResult FinikChargesDelete(int id)
        {
            return View(_growingFruitService.GetFinikChargesById(id));
        }

        // POST: Growing/FinikChargesDelete/1
        [HttpPost]

        public ActionResult FinikChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _growingFruitService.DeleteFinikChargesById(id);

                return RedirectToAction("FinikCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion




        #region FinikRetiring

        // GET: Growing/FinikProfits
        public ActionResult FinikProfits()
        {
            return View(_growingFruitService.GetFinikProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/FinikProfitEdit/1
        public ActionResult FinikProfitEdit(int id)
        {
            return View(_growingFruitService.GetFinikProfitById(id));
        }

        // POST: Growing/FinikProfitEdit/1
        [HttpPost]
        public ActionResult FinikProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_growingFruitService.GetFinikProfitById(id));

                _growingFruitService.AddNewFinikProfitById(id, collection);

                return RedirectToAction("FinikProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion
     

    }

}
