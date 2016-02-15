using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Growing
{

    public partial class GrowingController
    {

        #region SilageComing

        // GET: Growing/SilageComing
        public ActionResult SilageComing()
        {
            return View(_growingFieldService.GetSilageComings(User.Identity.GetUserId<int>()));
        }


        // GET: Growing/SilageComingCreate
        public ActionResult SilageComingCreate()
        {
            return View(FillFieldDropDownList("Silage"));

        }

        // POST: Growing/SilageComingCreate
        [HttpPost]
        public ActionResult SilageComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFieldCrops(collection);
                if (!ModelState.IsValid) return View(ConvertToFieldModel(collection, "Silage"));

                _growingFieldService.AddNewSilage(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("SilageComing");
            }
            catch
            {
                return View(FillFieldDropDownList("Silage"));
            }
        }


        // GET: Growing/SilageComingEdit/1
        public ActionResult SilageComingEdit(int id)
        {
            return View(_growingFieldService.GetSilageComingById(id));
        }

        // POST: Growing/SilageComingEdit/1
        [HttpPost]
        public ActionResult SilageComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFieldCrops(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetSilageComingById(id));

                _growingFieldService.AddNewSilageById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("SilageComing");
            }
            catch
            {
                return View(FillFieldDropDownList("Silage"));
            }
        }

        // GET: Growing/SilageComingDelete/1
        public ActionResult SilageComingDelete(int id)
        {
            return View(_growingFieldService.GetSilageComingById(id));
        }


        // POST: Growing/SilageComingDelete/1
        [HttpPost]
        public ActionResult SilageComingDelete(int id, FormCollection collection)
        {
            try
            {
                _growingFieldService.DeleteSilageById(id);
                Thread.Sleep(300);
                DeleteEmptyDocumentsFromServer();
                return RedirectToAction("SilageComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion



        #region SilageCharges
        // GET: Growing/SilageCharges
        public ActionResult SilageCharges()
        {
            return View(_growingFieldService.GetSilageCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/SilageChargesCreate
        public ActionResult SilageChargesCreate()
        {
            return View();
        }

        // POST: Growing/SilageChargesCreate
        [HttpPost]
        public ActionResult SilageChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _growingFieldService.AddNewSilageCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("SilageCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/SilageChargesEdit/1
        public ActionResult SilageChargesEdit(int id)
        {
            return View(_growingFieldService.GetSilageChargesById(id));
        }

        // POST: Growing/SilageChargesEdit/1
        [HttpPost]
        public ActionResult SilageChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetSilageChargesById(id));

                _growingFieldService.AddNewSilageChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("SilageCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/SilageChargesDelete/1
        public ActionResult SilageChargesDelete(int id)
        {
            return View(_growingFieldService.GetSilageChargesById(id));
        }

        // POST: Growing/SilageChargesDelete/1
        [HttpPost]

        public ActionResult SilageChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _growingFieldService.DeleteSilageChargesById(id);

                return RedirectToAction("SilageCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion



        #region SilageRetiring

        // GET: Growing/SilageProfits
        public ActionResult SilageProfits()
        {
            return View(_growingFieldService.GetSilageProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/SilageProfitEdit/1
        public ActionResult SilageProfitEdit(int id)
        {
            return View(_growingFieldService.GetSilageProfitById(id));
        }

        // POST: Growing/SilageProfitEdit/1
        [HttpPost]
        public ActionResult SilageProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetSilageProfitById(id));

                _growingFieldService.AddNewSilageProfitById(id, collection);

                return RedirectToAction("SilageProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}

