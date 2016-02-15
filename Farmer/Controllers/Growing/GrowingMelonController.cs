using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Growing
{

    public partial class GrowingController
    {

        #region MelonComing

        // GET: Growing/MelonComing
        public ActionResult MelonComing()
        {
            return View(_growingFieldService.GetMelonComings(User.Identity.GetUserId<int>()));
        }


        // GET: Growing/MelonComingCreate
        public ActionResult MelonComingCreate()
        {
            return View(FillFieldDropDownList("Melon"));

        }

        // POST: Growing/MelonComingCreate
        [HttpPost]
        public ActionResult MelonComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFieldCrops(collection);
                if (!ModelState.IsValid) return View(ConvertToFieldModel(collection, "Melon"));

                _growingFieldService.AddNewMelon(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("MelonComing");
            }
            catch
            {
                return View(FillFieldDropDownList("Melon"));
            }
        }


        // GET: Growing/MelonComingEdit/1
        public ActionResult MelonComingEdit(int id)
        {
            return View(_growingFieldService.GetMelonComingById(id));
        }

        // POST: Growing/MelonComingEdit/1
        [HttpPost]
        public ActionResult MelonComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFieldCrops(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetMelonComingById(id));

                _growingFieldService.AddNewMelonById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("MelonComing");
            }
            catch
            {
                return View(FillFieldDropDownList("Melon"));
            }
        }

        // GET: Growing/MelonComingDelete/1
        public ActionResult MelonComingDelete(int id)
        {
            return View(_growingFieldService.GetMelonComingById(id));
        }


        // POST: Growing/MelonComingDelete/1
        [HttpPost]
        public ActionResult MelonComingDelete(int id, FormCollection collection)
        {
            try
            {     
                _growingFieldService.DeleteMelonById(id);
                Thread.Sleep(300);
                DeleteEmptyDocumentsFromServer();
                return RedirectToAction("MelonComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion



        #region MelonCharges
        // GET: Growing/MelonCharges
        public ActionResult MelonCharges()
        {
            return View(_growingFieldService.GetMelonCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/MelonChargesCreate
        public ActionResult MelonChargesCreate()
        {
            return View();
        }

        // POST: Growing/MelonChargesCreate
        [HttpPost]
        public ActionResult MelonChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _growingFieldService.AddNewMelonCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("MelonCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/MelonChargesEdit/1
        public ActionResult MelonChargesEdit(int id)
        {
            return View(_growingFieldService.GetMelonChargesById(id));
        }

        // POST: Growing/MelonChargesEdit/1
        [HttpPost]
        public ActionResult MelonChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetMelonChargesById(id));

                _growingFieldService.AddNewMelonChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("MelonCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/MelonChargesDelete/1
        public ActionResult MelonChargesDelete(int id)
        {
            return View(_growingFieldService.GetMelonChargesById(id));
        }

        // POST: Growing/MelonChargesDelete/1
        [HttpPost]

        public ActionResult MelonChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _growingFieldService.DeleteMelonChargesById(id);

                return RedirectToAction("MelonCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion



        #region MelonRetiring

        // GET: Growing/MelonProfits
        public ActionResult MelonProfits()
        {
            return View(_growingFieldService.GetMelonProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/MelonProfitEdit/1
        public ActionResult MelonProfitEdit(int id)
        {
            return View(_growingFieldService.GetMelonProfitById(id));
        }

        // POST: Growing/MelonProfitEdit/1
        [HttpPost]
        public ActionResult MelonProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetMelonProfitById(id));

                _growingFieldService.AddNewMelonProfitById(id, collection);

                return RedirectToAction("MelonProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}

