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

        #region LeguminousComing

        // GET: Growing/LeguminousComing
        public ActionResult LeguminousComing()
        {
            return View(_growingFieldService.GetLeguminousComings(User.Identity.GetUserId<int>()));
        }


        // GET: Growing/LeguminousComingCreate
        public ActionResult LeguminousComingCreate()
        {
            return View(FillFieldDropDownList("Leguminous"));

        }

        // POST: Growing/LeguminousComingCreate
        [HttpPost]
        public ActionResult LeguminousComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFieldCrops(collection);
                if (!ModelState.IsValid) return View(ConvertToFieldModel(collection, "Leguminous"));

                _growingFieldService.AddNewLeguminous(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("LeguminousComing");
            }
            catch
            {
                return View(FillFieldDropDownList("Leguminous"));
            }
        }


        // GET: Growing/LeguminousComingEdit/1
        public ActionResult LeguminousComingEdit(int id)
        {
            return View(_growingFieldService.GetLeguminousComingById(id));
        }

        // POST: Growing/LeguminousComingEdit/1
        [HttpPost]
        public ActionResult LeguminousComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFieldCrops(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetLeguminousComingById(id));

                _growingFieldService.AddNewLeguminousById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("LeguminousComing");
            }
            catch
            {
                return View(FillFieldDropDownList("Leguminous"));
            }
        }

        // GET: Growing/LeguminousComingDelete/1
        public ActionResult LeguminousComingDelete(int id)
        {
            return View(_growingFieldService.GetLeguminousComingById(id));
        }


        // POST: Growing/LeguminousComingDelete/1
        [HttpPost]
        public ActionResult LeguminousComingDelete(int id, FormCollection collection)
        {
            try
            {    
                _growingFieldService.DeleteLeguminousById(id);
                Thread.Sleep(300);
                DeleteEmptyDocumentsFromServer();
                return RedirectToAction("LeguminousComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion



        #region LeguminousCharges
        // GET: Growing/LeguminousCharges
        public ActionResult LeguminousCharges()
        {
            return View(_growingFieldService.GetLeguminousCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/LeguminousChargesCreate
        public ActionResult LeguminousChargesCreate()
        {
            return View();
        }

        // POST: Growing/LeguminousChargesCreate
        [HttpPost]
        public ActionResult LeguminousChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _growingFieldService.AddNewLeguminousCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("LeguminousCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/LeguminousChargesEdit/1
        public ActionResult LeguminousChargesEdit(int id)
        {
            return View(_growingFieldService.GetLeguminousChargesById(id));
        }

        // POST: Growing/LeguminousChargesEdit/1
        [HttpPost]
        public ActionResult LeguminousChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetLeguminousChargesById(id));

                _growingFieldService.AddNewLeguminousChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("LeguminousCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/LeguminousChargesDelete/1
        public ActionResult LeguminousChargesDelete(int id)
        {
            return View(_growingFieldService.GetLeguminousChargesById(id));
        }

        // POST: Growing/LeguminousChargesDelete/1
        [HttpPost]

        public ActionResult LeguminousChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _growingFieldService.DeleteLeguminousChargesById(id);

                return RedirectToAction("LeguminousCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion



        #region LeguminousRetiring

        // GET: Growing/LeguminousProfits
        public ActionResult LeguminousProfits()
        {
            return View(_growingFieldService.GetLeguminousProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/LeguminousProfitEdit/1
        public ActionResult LeguminousProfitEdit(int id)
        {
            return View(_growingFieldService.GetLeguminousProfitById(id));
        }

        // POST: Growing/LeguminousProfitEdit/1
        [HttpPost]
        public ActionResult LeguminousProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetLeguminousProfitById(id));

                _growingFieldService.AddNewLeguminousProfitById(id, collection);

                return RedirectToAction("LeguminousProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}

