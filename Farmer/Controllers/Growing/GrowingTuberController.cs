using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Growing
{

    public partial class GrowingController
    {

        #region TuberComing

        // GET: Growing/TuberComing
        public ActionResult TuberComing()
        {
            return View(_growingFieldService.GetTuberComings(User.Identity.GetUserId<int>()));
        }


        // GET: Growing/TuberComingCreate
        public ActionResult TuberComingCreate()
        {
            return View(FillFieldDropDownList("Tuber"));

        }

        // POST: Growing/TuberComingCreate
        [HttpPost]
        public ActionResult TuberComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFieldCrops(collection);
                if (!ModelState.IsValid) return View(ConvertToFieldModel(collection, "Tuber"));

                _growingFieldService.AddNewTuber(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("TuberComing");
            }
            catch
            {
                return View(FillFieldDropDownList("Tuber"));
            }
        }


        // GET: Growing/TuberComingEdit/1
        public ActionResult TuberComingEdit(int id)
        {
            return View(_growingFieldService.GetTuberComingById(id));
        }

        // POST: Growing/TuberComingEdit/1
        [HttpPost]
        public ActionResult TuberComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFieldCrops(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetTuberComingById(id));

                _growingFieldService.AddNewTuberById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("TuberComing");
            }
            catch
            {
                return View(FillFieldDropDownList("Tuber"));
            }
        }

        // GET: Growing/TuberComingDelete/1
        public ActionResult TuberComingDelete(int id)
        {
            return View(_growingFieldService.GetTuberComingById(id));
        }


        // POST: Growing/TuberComingDelete/1
        [HttpPost]
        public ActionResult TuberComingDelete(int id, FormCollection collection)
        {
            try
            {     
                _growingFieldService.DeleteTuberById(id);
                Thread.Sleep(300);
                DeleteEmptyDocumentsFromServer();
                return RedirectToAction("TuberComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion



        #region TuberCharges
        // GET: Growing/TuberCharges
        public ActionResult TuberCharges()
        {
            return View(_growingFieldService.GetTuberCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/TuberChargesCreate
        public ActionResult TuberChargesCreate()
        {
            return View();
        }

        // POST: Growing/TuberChargesCreate
        [HttpPost]
        public ActionResult TuberChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _growingFieldService.AddNewTuberCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("TuberCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/TuberChargesEdit/1
        public ActionResult TuberChargesEdit(int id)
        {
            return View(_growingFieldService.GetTuberChargesById(id));
        }

        // POST: Growing/TuberChargesEdit/1
        [HttpPost]
        public ActionResult TuberChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetTuberChargesById(id));

                _growingFieldService.AddNewTuberChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("TuberCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/TuberChargesDelete/1
        public ActionResult TuberChargesDelete(int id)
        {
            return View(_growingFieldService.GetTuberChargesById(id));
        }

        // POST: Growing/TuberChargesDelete/1
        [HttpPost]

        public ActionResult TuberChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _growingFieldService.DeleteTuberChargesById(id);

                return RedirectToAction("TuberCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion



        #region TuberRetiring

        // GET: Growing/TuberProfits
        public ActionResult TuberProfits()
        {
            return View(_growingFieldService.GetTuberProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/TuberProfitEdit/1
        public ActionResult TuberProfitEdit(int id)
        {
            return View(_growingFieldService.GetTuberProfitById(id));
        }

        // POST: Growing/TuberProfitEdit/1
        [HttpPost]
        public ActionResult TuberProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetTuberProfitById(id));

                _growingFieldService.AddNewTuberProfitById(id, collection);

                return RedirectToAction("TuberProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}

