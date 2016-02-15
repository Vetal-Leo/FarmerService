using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Breeding
{

    public partial class BreedingController
    {


        #region QuailComing

        // GET: Breeding/QuailComing
        public ActionResult QuailComing()
        {
            return View(_breedingService.GetQuailComings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/QuailComingCreate
        public ActionResult QuailComingCreate()
        {
            return View(FillDropDownList("Quail"));
        }


        // POST: Breeding/QuailComingCreate
        [HttpPost]
        public ActionResult QuailComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToAnimalsModel(collection, "Quail"));
                _breedingService.AddNewQuailComing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("QuailComing");
            }
            catch
            {
                return View(FillDropDownList("Quail"));
            }
        }

        // GET: Breeding/QuailComingEdit/1
        public ActionResult QuailComingEdit(int id)
        {
            return View(_breedingService.GetQuailComingById(id));
        }

        // POST: Breeding/QuailComingEdit/1
        [HttpPost]
        public ActionResult QuailComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetQuailComingById(id));

                _breedingService.AddNewQuailComingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("QuailComing");
            }
            catch
            {
                return View(FillDropDownList("Quail"));
            }
        }

        // GET: Breeding/QuailComingDelete/1
        public ActionResult QuailComingDelete(int id)
        {
            return View(_breedingService.GetQuailComingById(id));
        }

        // POST: Breeding/QuailComingDelete/1
        [HttpPost]
        public ActionResult QuailComingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteQuailComingById(id);
                Thread.Sleep(300);
                return RedirectToAction("QuailComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region QuailCharges

        // GET: Breeding/QuailCharges
        public ActionResult QuailCharges()
        {
            return View(_breedingService.GetQuailCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/QuailChargesCreate
        public ActionResult QuailChargesCreate()
        {
            return View();
        }
        // POST: Breeding/QuailChargesCreate
        [HttpPost]
        public ActionResult QuailChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _breedingService.AddNewQuailCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("QuailCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/QuailChargesEdit/1
        public ActionResult QuailChargesEdit(int id)
        {
            return View(_breedingService.GetQuailChargesById(id));
        }

        // POST: Breeding/QuailChargesEdit/1
        [HttpPost]
        public ActionResult QuailChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetQuailChargesById(id));

                _breedingService.AddNewQuailChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("QuailCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/QuailChargesDelete/1
        public ActionResult QuailChargesDelete(int id)
        {
            return View(_breedingService.GetQuailChargesById(id));
        }

        // POST: Breeding/QuailChargesDelete/1
        [HttpPost]

        public ActionResult QuailChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteQuailChargesById(id);

                return RedirectToAction("QuailCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region QuailDaily

        // GET: Breeding/QuailDailyProfits
        public ActionResult QuailDailyProfits()
        {
            return View(_breedingService.GetQuailDailyProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/QuailDailyProfitCreate
        public ActionResult QuailDailyProfitCreate()
        {
            return View();
        }
        // POST: Breeding/QuailDailyProfitCreate
        [HttpPost]
        public ActionResult QuailDailyProfitCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(ConvertToDailyModel(collection));

                _breedingService.AddNewQuailDailyProfits(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(400);
                return RedirectToAction("QuailDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/QuailDailyProfitEdit/1
        public ActionResult QuailDailyProfitEdit(int id)
        {
            return View(_breedingService.GetQuailDailyProfitById(id));
        }

        // POST: Breeding/QuailDailyProfitEdit/1
        [HttpPost]
        public ActionResult QuailDailyProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetQuailDailyProfitById(id));

                _breedingService.AddNewQuailDailyProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("QuailDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/QuailDailyProfitDelete/1
        public ActionResult QuailDailyProfitDelete(int id)
        {
            return View(_breedingService.GetQuailDailyProfitById(id));
        }

        // POST: Breeding/QuailDailyProfitDelete/1
        [HttpPost]

        public ActionResult QuailDailyProfitDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteQuailDailyProfitById(id);

                return RedirectToAction("QuailDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region QuailRetiring

        // GET: Breeding/QuailProfits
        public ActionResult QuailProfits()
        {
            return View(_breedingService.GetQuailProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/QuailProfitEdit/1
        public ActionResult QuailProfitEdit(int id)
        {

            return View(_breedingService.GetQuailProfitById(id));
        }

        // POST: Breeding/QuailProfitEdit/1
        [HttpPost]
        public ActionResult QuailProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetQuailProfitById(id));

                _breedingService.AddNewQuailProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("QuailProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region QuailReminding

        // GET: Breeding/QuailRemindings
        public ActionResult QuailRemindings()
        {
            return View(_breedingService.GetQuailRemindings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/QuailRemindingCreate
        public ActionResult QuailRemindingCreate()
        {
            return View();
        }
        // POST: Breeding/QuailRemindingCreate
        [HttpPost]
        public ActionResult QuailRemindingCreate(FormCollection collection)
        {
            try
            {
                _breedingService.AddNewQuailReminding(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("QuailRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/QuailRemindingEdit/1
        public ActionResult QuailRemindingEdit(int id)
        {
            return View(_breedingService.GetQuailRemindingById(id));
        }

        // POST: Breeding/QuailRemindingEdit/1
        [HttpPost]
        public ActionResult QuailRemindingEdit(int id, FormCollection collection)
        {
            try
            {
                _breedingService.AddNewQuailRemindingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("QuailRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/QuailRemindingDelete/1
        public ActionResult QuailRemindingDelete(int id)
        {
            return View(_breedingService.GetQuailRemindingById(id));
        }

        // POST: Breeding/QuailRemindingDelete/1
        [HttpPost]

        public ActionResult QuailRemindingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteQuailRemindingById(id);

                return RedirectToAction("QuailRemindings");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}