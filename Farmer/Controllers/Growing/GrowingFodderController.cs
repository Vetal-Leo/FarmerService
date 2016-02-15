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

        #region FodderComing

        // GET: Growing/FodderComing
        public ActionResult FodderComing()
        {
            return View(_growingFieldService.GetFodderComings(User.Identity.GetUserId<int>()));
        }


        // GET: Growing/FodderComingCreate
        public ActionResult FodderComingCreate()
        {
            return View(FillFieldDropDownList("Fodder"));

        }

        // POST: Growing/FodderComingCreate
        [HttpPost]
        public ActionResult FodderComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFieldCrops(collection);
                if (!ModelState.IsValid) return View(ConvertToFieldModel(collection, "Fodder"));

                _growingFieldService.AddNewFodder(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("FodderComing");
            }
            catch
            {
                return View(FillFieldDropDownList("Fodder"));
            }
        }


        // GET: Growing/FodderComingEdit/1
        public ActionResult FodderComingEdit(int id)
        {
            return View(_growingFieldService.GetFodderComingById(id));
        }

        // POST: Growing/FodderComingEdit/1
        [HttpPost]
        public ActionResult FodderComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFieldCrops(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetFodderComingById(id));

                _growingFieldService.AddNewFodderById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("FodderComing");
            }
            catch
            {
                return View(FillFieldDropDownList("Fodder"));
            }
        }

        // GET: Growing/FodderComingDelete/1
        public ActionResult FodderComingDelete(int id)
        {
            return View(_growingFieldService.GetFodderComingById(id));
        }


        // POST: Growing/FodderComingDelete/1
        [HttpPost]
        public ActionResult FodderComingDelete(int id, FormCollection collection)
        {
            try
            {  
                _growingFieldService.DeleteFodderById(id);
                Thread.Sleep(300);
                DeleteEmptyDocumentsFromServer();
                return RedirectToAction("FodderComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion



        #region FodderCharges
        // GET: Growing/FodderCharges
        public ActionResult FodderCharges()
        {
            return View(_growingFieldService.GetFodderCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/FodderChargesCreate
        public ActionResult FodderChargesCreate()
        {
            return View();
        }

        // POST: Growing/FodderChargesCreate
        [HttpPost]
        public ActionResult FodderChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _growingFieldService.AddNewFodderCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("FodderCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/FodderChargesEdit/1
        public ActionResult FodderChargesEdit(int id)
        {
            return View(_growingFieldService.GetFodderChargesById(id));
        }

        // POST: Growing/FodderChargesEdit/1
        [HttpPost]
        public ActionResult FodderChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetFodderChargesById(id));

                _growingFieldService.AddNewFodderChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("FodderCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/FodderChargesDelete/1
        public ActionResult FodderChargesDelete(int id)
        {
            return View(_growingFieldService.GetFodderChargesById(id));
        }

        // POST: Growing/FodderChargesDelete/1
        [HttpPost]

        public ActionResult FodderChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _growingFieldService.DeleteFodderChargesById(id);

                return RedirectToAction("FodderCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion



        #region FodderRetiring

        // GET: Growing/FodderProfits
        public ActionResult FodderProfits()
        {
            return View(_growingFieldService.GetFodderProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/FodderProfitEdit/1
        public ActionResult FodderProfitEdit(int id)
        {
            return View(_growingFieldService.GetFodderProfitById(id));
        }

        // POST: Growing/FodderProfitEdit/1
        [HttpPost]
        public ActionResult FodderProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetFodderProfitById(id));

                _growingFieldService.AddNewFodderProfitById(id, collection);

                return RedirectToAction("FodderProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}

