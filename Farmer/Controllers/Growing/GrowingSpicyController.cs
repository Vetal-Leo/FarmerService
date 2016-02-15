using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Growing
{

    public partial class GrowingController
    {

        #region SpicyComing

        // GET: Growing/SpicyComing
        public ActionResult SpicyComing()
        {
            return View(_growingFieldService.GetSpicyComings(User.Identity.GetUserId<int>()));
        }


        // GET: Growing/SpicyComingCreate
        public ActionResult SpicyComingCreate()
        {
            return View(FillFieldDropDownList("Spicy"));

        }

        // POST: Growing/SpicyComingCreate
        [HttpPost]
        public ActionResult SpicyComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFieldCrops(collection);
                if (!ModelState.IsValid) return View(ConvertToFieldModel(collection, "Spicy"));

                _growingFieldService.AddNewSpicy(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("SpicyComing");
            }
            catch
            {
                return View(FillFieldDropDownList("Spicy"));
            }
        }


        // GET: Growing/SpicyComingEdit/1
        public ActionResult SpicyComingEdit(int id)
        {
            return View(_growingFieldService.GetSpicyComingById(id));
        }

        // POST: Growing/SpicyComingEdit/1
        [HttpPost]
        public ActionResult SpicyComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFieldCrops(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetSpicyComingById(id));

                _growingFieldService.AddNewSpicyById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("SpicyComing");
            }
            catch
            {
                return View(FillFieldDropDownList("Spicy"));
            }
        }

        // GET: Growing/SpicyComingDelete/1
        public ActionResult SpicyComingDelete(int id)
        {
            return View(_growingFieldService.GetSpicyComingById(id));
        }


        // POST: Growing/SpicyComingDelete/1
        [HttpPost]
        public ActionResult SpicyComingDelete(int id, FormCollection collection)
        {
            try
            {
                _growingFieldService.DeleteSpicyById(id);
                Thread.Sleep(300);
                DeleteEmptyDocumentsFromServer();
                return RedirectToAction("SpicyComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion



        #region SpicyCharges
        // GET: Growing/SpicyCharges
        public ActionResult SpicyCharges()
        {
            return View(_growingFieldService.GetSpicyCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/SpicyChargesCreate
        public ActionResult SpicyChargesCreate()
        {
            return View();
        }

        // POST: Growing/SpicyChargesCreate
        [HttpPost]
        public ActionResult SpicyChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _growingFieldService.AddNewSpicyCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("SpicyCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/SpicyChargesEdit/1
        public ActionResult SpicyChargesEdit(int id)
        {
            return View(_growingFieldService.GetSpicyChargesById(id));
        }

        // POST: Growing/SpicyChargesEdit/1
        [HttpPost]
        public ActionResult SpicyChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetSpicyChargesById(id));

                _growingFieldService.AddNewSpicyChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("SpicyCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/SpicyChargesDelete/1
        public ActionResult SpicyChargesDelete(int id)
        {
            return View(_growingFieldService.GetSpicyChargesById(id));
        }

        // POST: Growing/SpicyChargesDelete/1
        [HttpPost]

        public ActionResult SpicyChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _growingFieldService.DeleteSpicyChargesById(id);

                return RedirectToAction("SpicyCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion



        #region SpicyRetiring

        // GET: Growing/SpicyProfits
        public ActionResult SpicyProfits()
        {
            return View(_growingFieldService.GetSpicyProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/SpicyProfitEdit/1
        public ActionResult SpicyProfitEdit(int id)
        {
            return View(_growingFieldService.GetSpicyProfitById(id));
        }

        // POST: Growing/SpicyProfitEdit/1
        [HttpPost]
        public ActionResult SpicyProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_growingFieldService.GetSpicyProfitById(id));

                _growingFieldService.AddNewSpicyProfitById(id, collection);

                return RedirectToAction("SpicyProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}

