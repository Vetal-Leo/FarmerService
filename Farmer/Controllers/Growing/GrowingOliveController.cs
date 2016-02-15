using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Growing
{

    public partial class GrowingController
    {

        #region OliveComing

        // GET: Growing/OliveComing
        public ActionResult OliveComing()
        {
            return View(_growingFieldService.GetOliveComings(User.Identity.GetUserId<int>()));
        }


        // GET: Growing/OliveComingCreate
        public ActionResult OliveComingCreate()
        {
            return View(FillFieldDropDownList("Olive"));

        }

        // POST: Growing/OliveComingCreate
        [HttpPost]
        public ActionResult OliveComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFieldCrops(collection);
                if (!ModelState.IsValid) return View(ConvertToFieldModel(collection, "Olive"));

                _growingFieldService.AddNewOlive(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("OliveComing");
            }
            catch
            {
                return View(FillFieldDropDownList("Olive"));
            }
        }


        // GET: Growing/OliveComingEdit/1
        public ActionResult OliveComingEdit(int id)
        {
            return View(_growingFieldService.GetOliveComingById(id));
        }

        // POST: Growing/OliveComingEdit/1
        [HttpPost]
        public ActionResult OliveComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFieldCrops(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetOliveComingById(id));

                _growingFieldService.AddNewOliveById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("OliveComing");
            }
            catch
            {
                return View(FillFieldDropDownList("Olive"));
            }
        }

        // GET: Growing/OliveComingDelete/1
        public ActionResult OliveComingDelete(int id)
        {
            return View(_growingFieldService.GetOliveComingById(id));
        }


        // POST: Growing/OliveComingDelete/1
        [HttpPost]
        public ActionResult OliveComingDelete(int id, FormCollection collection)
        {
            try
            {         
                _growingFieldService.DeleteOliveById(id);
                Thread.Sleep(300);
                DeleteEmptyDocumentsFromServer();
                return RedirectToAction("OliveComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion



        #region OliveCharges
        // GET: Growing/OliveCharges
        public ActionResult OliveCharges()
        {
            return View(_growingFieldService.GetOliveCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/OliveChargesCreate
        public ActionResult OliveChargesCreate()
        {
            return View();
        }

        // POST: Growing/OliveChargesCreate
        [HttpPost]
        public ActionResult OliveChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _growingFieldService.AddNewOliveCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("OliveCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/OliveChargesEdit/1
        public ActionResult OliveChargesEdit(int id)
        {
            return View(_growingFieldService.GetOliveChargesById(id));
        }

        // POST: Growing/OliveChargesEdit/1
        [HttpPost]
        public ActionResult OliveChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetOliveChargesById(id));

                _growingFieldService.AddNewOliveChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("OliveCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/OliveChargesDelete/1
        public ActionResult OliveChargesDelete(int id)
        {
            return View(_growingFieldService.GetOliveChargesById(id));
        }

        // POST: Growing/OliveChargesDelete/1
        [HttpPost]

        public ActionResult OliveChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _growingFieldService.DeleteOliveChargesById(id);

                return RedirectToAction("OliveCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion



        #region OliveRetiring

        // GET: Growing/OliveProfits
        public ActionResult OliveProfits()
        {
            return View(_growingFieldService.GetOliveProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/OliveProfitEdit/1
        public ActionResult OliveProfitEdit(int id)
        {
            return View(_growingFieldService.GetOliveProfitById(id));
        }

        // POST: Growing/OliveProfitEdit/1
        [HttpPost]
        public ActionResult OliveProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetOliveProfitById(id));

                _growingFieldService.AddNewOliveProfitById(id, collection);

                return RedirectToAction("OliveProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}

