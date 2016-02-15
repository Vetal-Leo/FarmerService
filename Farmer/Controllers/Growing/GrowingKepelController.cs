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


        #region KepelComing

        // GET: Growing/KepelComing
        public ActionResult KepelComing()
        {
            return View(_growingFruitService.GetKepelComings(User.Identity.GetUserId<int>()));
        }


        // GET: Growing/KepelComingCreate
        public ActionResult KepelComingCreate()
        {
            return View(FillFruitDropDownList("Kepel"));
        }



        // POST: Growing/KepelComingCreate
        [HttpPost]
        public ActionResult KepelComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFruitCrops(collection);
                if (!ModelState.IsValid) return View(ConvertToFruitModel(collection, "Kepel"));

                _growingFruitService.AddNewKepel(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("KepelComing");
            }
            catch (Exception e)
            {

                return View(FillFruitDropDownList("Kepel"));
            }
        }


        // GET: Growing/KepelComingEdit/1
        public ActionResult KepelComingEdit(int id)
        {
            return View(_growingFruitService.GetKepelComingById(id));
        }

        // POST: Growing/KepelComingEdit/1
        [HttpPost]
        public ActionResult KepelComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFruitCrops(collection);
                if (!ModelState.IsValid) return View(_growingFruitService.GetKepelComingById(id));

                _growingFruitService.AddNewKepelById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("KepelComing");
            }
            catch
            {
                return View(FillFruitDropDownList("Kepel"));
            }

        }


        // GET: Growing/KepelComingDelete/1
        public ActionResult KepelComingDelete(int id)
        {
            return View(_growingFruitService.GetKepelComingById(id));
        }

        // POST: Growing/KepelComingDelete/1
        [HttpPost]
        public ActionResult KepelComingDelete(int id, FormCollection collection)
        {
            try
            {
                _growingFruitService.DeleteKepelById(id);
                Thread.Sleep(300);
                DeleteEmptyDocumentsFromServer();
                return RedirectToAction("KepelComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region KepelCharges

        // GET: Growing/KepelCharges
        public ActionResult KepelCharges()
        {
            return View(_growingFruitService.GetKepelCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/KepelChargesCreate
        public ActionResult KepelChargesCreate()
        {
            return View();
        }
        // POST: Growing/KepelChargesCreate
        [HttpPost]
        public ActionResult KepelChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _growingFruitService.AddNewKepelCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("KepelCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/KepelChargesEdit/1
        public ActionResult KepelChargesEdit(int id)
        {
            return View(_growingFruitService.GetKepelChargesById(id));
        }

        // POST: Growing/KepelChargesEdit/1
        [HttpPost]
        public ActionResult KepelChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_growingFruitService.GetKepelChargesById(id));

                _growingFruitService.AddNewKepelChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("KepelCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/KepelChargesDelete/1
        public ActionResult KepelChargesDelete(int id)
        {
            return View(_growingFruitService.GetKepelChargesById(id));
        }

        // POST: Growing/KepelChargesDelete/1
        [HttpPost]

        public ActionResult KepelChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _growingFruitService.DeleteKepelChargesById(id);

                return RedirectToAction("KepelCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion




        #region KepelRetiring

        // GET: Growing/KepelProfits
        public ActionResult KepelProfits()
        {
            return View(_growingFruitService.GetKepelProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/KepelProfitEdit/1
        public ActionResult KepelProfitEdit(int id)
        {
            return View(_growingFruitService.GetKepelProfitById(id));
        }

        // POST: Growing/KepelProfitEdit/1
        [HttpPost]
        public ActionResult KepelProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_growingFruitService.GetKepelProfitById(id));

                _growingFruitService.AddNewKepelProfitById(id, collection);

                return RedirectToAction("KepelProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


    }

}
