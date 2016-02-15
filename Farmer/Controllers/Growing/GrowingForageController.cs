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

        #region ForageComing

        // GET: Growing/ForageComing
        public ActionResult ForageComing()
        {
            return View(_growingFieldService.GetForageComings(User.Identity.GetUserId<int>()));
        }


        // GET: Growing/ForageComingCreate
        public ActionResult ForageComingCreate()
        {
            return View(FillFieldDropDownList("Forage"));

        }

        // POST: Growing/ForageComingCreate
        [HttpPost]
        public ActionResult ForageComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFieldCrops(collection);
                if (!ModelState.IsValid) return View(ConvertToFieldModel(collection, "Forage"));

                _growingFieldService.AddNewForage(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("ForageComing");
            }
            catch
            {
                return View(FillFieldDropDownList("Forage"));
            }
        }


        // GET: Growing/ForageComingEdit/1
        public ActionResult ForageComingEdit(int id)
        {
            return View(_growingFieldService.GetForageComingById(id));
        }

        // POST: Growing/ForageComingEdit/1
        [HttpPost]
        public ActionResult ForageComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFieldCrops(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetForageComingById(id));

                _growingFieldService.AddNewForageById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("ForageComing");
            }
            catch
            {
                return View(FillFieldDropDownList("Forage"));
            }
        }

        // GET: Growing/ForageComingDelete/1
        public ActionResult ForageComingDelete(int id)
        {
            return View(_growingFieldService.GetForageComingById(id));
        }


        // POST: Growing/ForageComingDelete/1
        [HttpPost]
        public ActionResult ForageComingDelete(int id, FormCollection collection)
        {
            try
            {         
                _growingFieldService.DeleteForageById(id);
                Thread.Sleep(300);
                DeleteEmptyDocumentsFromServer();
                return RedirectToAction("ForageComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion



        #region ForageCharges
        // GET: Growing/ForageCharges
        public ActionResult ForageCharges()
        {
            return View(_growingFieldService.GetForageCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/ForageChargesCreate
        public ActionResult ForageChargesCreate()
        {
            return View();
        }

        // POST: Growing/ForageChargesCreate
        [HttpPost]
        public ActionResult ForageChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _growingFieldService.AddNewForageCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("ForageCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/ForageChargesEdit/1
        public ActionResult ForageChargesEdit(int id)
        {
            return View(_growingFieldService.GetForageChargesById(id));
        }

        // POST: Growing/ForageChargesEdit/1
        [HttpPost]
        public ActionResult ForageChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetForageChargesById(id));

                _growingFieldService.AddNewForageChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("ForageCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/ForageChargesDelete/1
        public ActionResult ForageChargesDelete(int id)
        {
            return View(_growingFieldService.GetForageChargesById(id));
        }

        // POST: Growing/ForageChargesDelete/1
        [HttpPost]

        public ActionResult ForageChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _growingFieldService.DeleteForageChargesById(id);

                return RedirectToAction("ForageCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion



        #region ForageRetiring

        // GET: Growing/ForageProfits
        public ActionResult ForageProfits()
        {
            return View(_growingFieldService.GetForageProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/ForageProfitEdit/1
        public ActionResult ForageProfitEdit(int id)
        {
            return View(_growingFieldService.GetForageProfitById(id));
        }

        // POST: Growing/ForageProfitEdit/1
        [HttpPost]
        public ActionResult ForageProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetForageProfitById(id));

                _growingFieldService.AddNewForageProfitById(id, collection);

                return RedirectToAction("ForageProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}

