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


        #region StrawberryComing

        // GET: Growing/StrawberryComing
        public ActionResult StrawberryComing()
        {
            return View(_growingFruitService.GetStrawberryComings(User.Identity.GetUserId<int>()));
        }


        // GET: Growing/StrawberryComingCreate
        public ActionResult StrawberryComingCreate()
        {
            return View(FillFruitDropDownList("Strawberry"));
        }



        // POST: Growing/StrawberryComingCreate
        [HttpPost]
        public ActionResult StrawberryComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFruitCrops(collection);
                if (!ModelState.IsValid) return View(ConvertToFruitModel(collection, "Strawberry"));

                _growingFruitService.AddNewStrawberry(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("StrawberryComing");
            }
            catch
            {
                return View(FillFruitDropDownList("Strawberry"));
            }
        }


        // GET: Growing/StrawberryComingEdit/1
        public ActionResult StrawberryComingEdit(int id)
        {
            return View(_growingFruitService.GetStrawberryComingById(id));
        }

        // POST: Growing/StrawberryComingEdit/1
        [HttpPost]
        public ActionResult StrawberryComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFruitCrops(collection);
                if (!ModelState.IsValid) return View(_growingFruitService.GetStrawberryComingById(id));

                _growingFruitService.AddNewStrawberryById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("StrawberryComing");
            }
            catch
            {
                return View(FillFruitDropDownList("Strawberry"));
            }

        }


        // GET: Growing/StrawberryComingDelete/1
        public ActionResult StrawberryComingDelete(int id)
        {
            return View(_growingFruitService.GetStrawberryComingById(id));
        }

        // POST: Growing/StrawberryComingDelete/1
        [HttpPost]
        public ActionResult StrawberryComingDelete(int id, FormCollection collection)
        {
            try
            {      
                _growingFruitService.DeleteStrawberryById(id);
                Thread.Sleep(300);
                DeleteEmptyDocumentsFromServer();
                return RedirectToAction("StrawberryComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region StrawberryCharges

        // GET: Growing/StrawberryCharges
        public ActionResult StrawberryCharges()
        {
            return View(_growingFruitService.GetStrawberryCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/StrawberryChargesCreate
        public ActionResult StrawberryChargesCreate()
        {
            return View();
        }
        // POST: Growing/StrawberryChargesCreate
        [HttpPost]
        public ActionResult StrawberryChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _growingFruitService.AddNewStrawberryCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("StrawberryCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/StrawberryChargesEdit/1
        public ActionResult StrawberryChargesEdit(int id)
        {
            return View(_growingFruitService.GetStrawberryChargesById(id));
        }

        // POST: Growing/StrawberryChargesEdit/1
        [HttpPost]
        public ActionResult StrawberryChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_growingFruitService.GetStrawberryChargesById(id));

                _growingFruitService.AddNewStrawberryChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("StrawberryCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/StrawberryChargesDelete/1
        public ActionResult StrawberryChargesDelete(int id)
        {
            return View(_growingFruitService.GetStrawberryChargesById(id));
        }

        // POST: Growing/StrawberryChargesDelete/1
        [HttpPost]

        public ActionResult StrawberryChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _growingFruitService.DeleteStrawberryChargesById(id);

                return RedirectToAction("StrawberryCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion




        #region StrawberryRetiring

        // GET: Growing/StrawberryProfits
        public ActionResult StrawberryProfits()
        {
            return View(_growingFruitService.GetStrawberryProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/StrawberryProfitEdit/1
        public ActionResult StrawberryProfitEdit(int id)
        {
            return View(_growingFruitService.GetStrawberryProfitById(id));
        }

        // POST: Growing/StrawberryProfitEdit/1
        [HttpPost]
        public ActionResult StrawberryProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_growingFruitService.GetStrawberryProfitById(id));

                _growingFruitService.AddNewStrawberryProfitById(id, collection);

                return RedirectToAction("StrawberryProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        
    }
}
