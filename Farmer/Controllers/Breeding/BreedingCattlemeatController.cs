using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Breeding
{

    public partial class BreedingController
    {

        #region CattlemeatYoung

        // GET: Breeding/CattlemeatYoung
        public ActionResult CattlemeatYoung()
        {
            return View(_breedingService.GetCattlemeatYoungs(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CattlemeatYoungCreate
        public ActionResult CattlemeatYoungCreate()
        {
            return View(FillYoungDropDownList("Cattlemeat"));
        }

        // POST: Breeding/CattlemeatYoungCreate
        [HttpPost]
        public ActionResult CattlemeatYoungCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToYoungModel(collection, "Cattlemeat"));
                _breedingService.AddNewCattlemeatYoung(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("CattlemeatYoung");
            }
            catch
            {
                return View(FillYoungDropDownList("Cattlemeat"));
            }
        }

        // GET: Breeding/CattlemeatYoungEdit/1
        public ActionResult CattlemeatYoungEdit(int id)
        {
            return View(_breedingService.GetCattlemeatYoungById(id));
        }

        // POST: Breeding/CattlemeatYoungEdit/1
        [HttpPost]
        public ActionResult CattlemeatYoungEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetCattlemeatYoungById(id));

                _breedingService.AddNewCattlemeatYoungById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemeatYoung");
            }
            catch
            {
                return View(FillYoungDropDownList("Cattlemeat"));
            }
        }

        // GET: Breeding/CattlemeatYoungDelete/1
        public ActionResult CattlemeatYoungDelete(int id)
        {
            return View(_breedingService.GetCattlemeatYoungById(id));
        }

        // POST: Breeding/CattlemeatYoungDelete/1
        [HttpPost]
        public ActionResult CattlemeatYoungDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteCattlemeatYoungById(id);
                Thread.Sleep(300);
                return RedirectToAction("CattlemeatYoung");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region CattlemeatComing

        // GET: Breeding/CattlemeatComing
        public ActionResult CattlemeatComing()
        {
            return View(_breedingService.GetCattlemeatComings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CattlemeatComingCreate
        public ActionResult CattlemeatComingCreate()
        {
            return View(FillDropDownList("Cattlemeat"));
        }


        // POST: Breeding/CattlemeatComingCreate
        [HttpPost]
        public ActionResult CattlemeatComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToAnimalsModel(collection, "Cattlemeat"));
                _breedingService.AddNewCattlemeatComing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("CattlemeatComing");
            }
            catch
            {
                return View(FillDropDownList("Cattlemeat"));
            }
        }

        // GET: Breeding/CattlemeatComingEdit/1
        public ActionResult CattlemeatComingEdit(int id)
        {
            return View(_breedingService.GetCattlemeatComingById(id));
        }

        // POST: Breeding/CattlemeatComingEdit/1
        [HttpPost]
        public ActionResult CattlemeatComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetCattlemeatComingById(id));

                _breedingService.AddNewCattlemeatComingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemeatComing");
            }
            catch
            {
                return View(FillDropDownList("Cattlemeat"));
            }
        }

        // GET: Breeding/CattlemeatComingDelete/1
        public ActionResult CattlemeatComingDelete(int id)
        {
            return View(_breedingService.GetCattlemeatComingById(id));
        }

        // POST: Breeding/CattlemeatComingDelete/1
        [HttpPost]
        public ActionResult CattlemeatComingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteCattlemeatComingById(id);
                Thread.Sleep(300);
                return RedirectToAction("CattlemeatComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region CattlemeatCharges

        // GET: Breeding/CattlemeatCharges
        public ActionResult CattlemeatCharges()
        {
            return View(_breedingService.GetCattlemeatCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CattlemeatChargesCreate
        public ActionResult CattlemeatChargesCreate()
        {
            return View();
        }
        // POST: Breeding/CattlemeatChargesCreate
        [HttpPost]
        public ActionResult CattlemeatChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _breedingService.AddNewCattlemeatCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemeatCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CattlemeatChargesEdit/1
        public ActionResult CattlemeatChargesEdit(int id)
        {
            return View(_breedingService.GetCattlemeatChargesById(id));
        }

        // POST: Breeding/CattlemeatChargesEdit/1
        [HttpPost]
        public ActionResult CattlemeatChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetCattlemeatChargesById(id));

                _breedingService.AddNewCattlemeatChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemeatCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CattlemeatChargesDelete/1
        public ActionResult CattlemeatChargesDelete(int id)
        {
            return View(_breedingService.GetCattlemeatChargesById(id));
        }

        // POST: Breeding/CattlemeatChargesDelete/1
        [HttpPost]

        public ActionResult CattlemeatChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteCattlemeatChargesById(id);

                return RedirectToAction("CattlemeatCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region CattlemeatDaily

        // GET: Breeding/CattlemeatDailyProfits
        public ActionResult CattlemeatDailyProfits()
        {
            return View(_breedingService.GetCattlemeatDailyProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CattlemeatDailyProfitCreate
        public ActionResult CattlemeatDailyProfitCreate()
        {
            return View();
        }
        // POST: Breeding/CattlemeatDailyProfitCreate
        [HttpPost]
        public ActionResult CattlemeatDailyProfitCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(ConvertToDailyModel(collection));

                _breedingService.AddNewCattlemeatDailyProfits(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(400);
                return RedirectToAction("CattlemeatDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CattlemeatDailyProfitEdit/1
        public ActionResult CattlemeatDailyProfitEdit(int id)
        {
            return View(_breedingService.GetCattlemeatDailyProfitById(id));
        }

        // POST: Breeding/CattlemeatDailyProfitEdit/1
        [HttpPost]
        public ActionResult CattlemeatDailyProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetCattlemeatDailyProfitById(id));

                _breedingService.AddNewCattlemeatDailyProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemeatDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CattlemeatDailyProfitDelete/1
        public ActionResult CattlemeatDailyProfitDelete(int id)
        {
            return View(_breedingService.GetCattlemeatDailyProfitById(id));
        }

        // POST: Breeding/CattlemeatDailyProfitDelete/1
        [HttpPost]

        public ActionResult CattlemeatDailyProfitDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteCattlemeatDailyProfitById(id);

                return RedirectToAction("CattlemeatDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region CattlemeatRetiring

        // GET: Breeding/CattlemeatProfits
        public ActionResult CattlemeatProfits()
        {
            return View(_breedingService.GetCattlemeatProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CattlemeatProfitEdit/1
        public ActionResult CattlemeatProfitEdit(int id)
        {

            return View(_breedingService.GetCattlemeatProfitById(id));
        }

        // POST: Breeding/CattlemeatProfitEdit/1
        [HttpPost]
        public ActionResult CattlemeatProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetCattlemeatProfitById(id));

                _breedingService.AddNewCattlemeatProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemeatProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region CattlemeatReminding

        // GET: Breeding/CattlemeatRemindings
        public ActionResult CattlemeatRemindings()
        {
            return View(_breedingService.GetCattlemeatRemindings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CattlemeatRemindingCreate
        public ActionResult CattlemeatRemindingCreate()
        {
            return View();
        }
        // POST: Breeding/CattlemeatRemindingCreate
        [HttpPost]
        public ActionResult CattlemeatRemindingCreate(FormCollection collection)
        {
            try
            {
                _breedingService.AddNewCattlemeatReminding(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemeatRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CattlemeatRemindingEdit/1
        public ActionResult CattlemeatRemindingEdit(int id)
        {
            return View(_breedingService.GetCattlemeatRemindingById(id));
        }

        // POST: Breeding/CattlemeatRemindingEdit/1
        [HttpPost]
        public ActionResult CattlemeatRemindingEdit(int id, FormCollection collection)
        {
            try
            {
                _breedingService.AddNewCattlemeatRemindingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemeatRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CattlemeatRemindingDelete/1
        public ActionResult CattlemeatRemindingDelete(int id)
        {
            return View(_breedingService.GetCattlemeatRemindingById(id));
        }

        // POST: Breeding/CattlemeatRemindingDelete/1
        [HttpPost]

        public ActionResult CattlemeatRemindingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteCattlemeatRemindingById(id);

                return RedirectToAction("CattlemeatRemindings");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}