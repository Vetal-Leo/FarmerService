using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Breeding
{

    public partial class BreedingController
    {

        #region CattlemixedYoung

        // GET: Breeding/CattlemixedYoung
        public ActionResult CattlemixedYoung()
        {
            return View(_breedingService.GetCattlemixedYoungs(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CattlemixedYoungCreate
        public ActionResult CattlemixedYoungCreate()
        {
            return View(FillYoungDropDownList("Cattlemixed"));
        }

        // POST: Breeding/CattlemixedYoungCreate
        [HttpPost]
        public ActionResult CattlemixedYoungCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToYoungModel(collection, "Cattlemixed"));
                _breedingService.AddNewCattlemixedYoung(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("CattlemixedYoung");
            }
            catch
            {
                return View(FillYoungDropDownList("Cattlemixed"));
            }
        }

        // GET: Breeding/CattlemixedYoungEdit/1
        public ActionResult CattlemixedYoungEdit(int id)
        {
            return View(_breedingService.GetCattlemixedYoungById(id));
        }

        // POST: Breeding/CattlemixedYoungEdit/1
        [HttpPost]
        public ActionResult CattlemixedYoungEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetCattlemixedYoungById(id));

                _breedingService.AddNewCattlemixedYoungById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemixedYoung");
            }
            catch
            {
                return View(FillYoungDropDownList("Cattlemixed"));
            }
        }

        // GET: Breeding/CattlemixedYoungDelete/1
        public ActionResult CattlemixedYoungDelete(int id)
        {
            return View(_breedingService.GetCattlemixedYoungById(id));
        }

        // POST: Breeding/CattlemixedYoungDelete/1
        [HttpPost]
        public ActionResult CattlemixedYoungDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteCattlemixedYoungById(id);
                Thread.Sleep(300);
                return RedirectToAction("CattlemixedYoung");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region CattlemixedComing

        // GET: Breeding/CattlemixedComing
        public ActionResult CattlemixedComing()
        {
            return View(_breedingService.GetCattlemixedComings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CattlemixedComingCreate
        public ActionResult CattlemixedComingCreate()
        {
            return View(FillDropDownList("Cattlemixed"));
        }


        // POST: Breeding/CattlemixedComingCreate
        [HttpPost]
        public ActionResult CattlemixedComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToAnimalsModel(collection, "Cattlemixed"));
                _breedingService.AddNewCattlemixedComing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("CattlemixedComing");
            }
            catch
            {
                return View(FillDropDownList("Cattlemixed"));
            }
        }

        // GET: Breeding/CattlemixedComingEdit/1
        public ActionResult CattlemixedComingEdit(int id)
        {
            return View(_breedingService.GetCattlemixedComingById(id));
        }

        // POST: Breeding/CattlemixedComingEdit/1
        [HttpPost]
        public ActionResult CattlemixedComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetCattlemixedComingById(id));

                _breedingService.AddNewCattlemixedComingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemixedComing");
            }
            catch
            {
                return View(FillDropDownList("Cattlemixed"));
            }
        }

        // GET: Breeding/CattlemixedComingDelete/1
        public ActionResult CattlemixedComingDelete(int id)
        {
            return View(_breedingService.GetCattlemixedComingById(id));
        }

        // POST: Breeding/CattlemixedComingDelete/1
        [HttpPost]
        public ActionResult CattlemixedComingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteCattlemixedComingById(id);
                Thread.Sleep(300);
                return RedirectToAction("CattlemixedComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region CattlemixedCharges

        // GET: Breeding/CattlemixedCharges
        public ActionResult CattlemixedCharges()
        {
            return View(_breedingService.GetCattlemixedCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CattlemixedChargesCreate
        public ActionResult CattlemixedChargesCreate()
        {
            return View();
        }
        // POST: Breeding/CattlemixedChargesCreate
        [HttpPost]
        public ActionResult CattlemixedChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _breedingService.AddNewCattlemixedCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemixedCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CattlemixedChargesEdit/1
        public ActionResult CattlemixedChargesEdit(int id)
        {
            return View(_breedingService.GetCattlemixedChargesById(id));
        }

        // POST: Breeding/CattlemixedChargesEdit/1
        [HttpPost]
        public ActionResult CattlemixedChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetCattlemixedChargesById(id));

                _breedingService.AddNewCattlemixedChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemixedCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CattlemixedChargesDelete/1
        public ActionResult CattlemixedChargesDelete(int id)
        {
            return View(_breedingService.GetCattlemixedChargesById(id));
        }

        // POST: Breeding/CattlemixedChargesDelete/1
        [HttpPost]

        public ActionResult CattlemixedChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteCattlemixedChargesById(id);

                return RedirectToAction("CattlemixedCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region CattlemixedDaily

        // GET: Breeding/CattlemixedDailyProfits
        public ActionResult CattlemixedDailyProfits()
        {
            return View(_breedingService.GetCattlemixedDailyProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CattlemixedDailyProfitCreate
        public ActionResult CattlemixedDailyProfitCreate()
        {
            return View();
        }
        // POST: Breeding/CattlemixedDailyProfitCreate
        [HttpPost]
        public ActionResult CattlemixedDailyProfitCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(ConvertToDailyModel(collection));

                _breedingService.AddNewCattlemixedDailyProfits(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(400);
                return RedirectToAction("CattlemixedDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CattlemixedDailyProfitEdit/1
        public ActionResult CattlemixedDailyProfitEdit(int id)
        {
            return View(_breedingService.GetCattlemixedDailyProfitById(id));
        }

        // POST: Breeding/CattlemixedDailyProfitEdit/1
        [HttpPost]
        public ActionResult CattlemixedDailyProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetCattlemixedDailyProfitById(id));

                _breedingService.AddNewCattlemixedDailyProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemixedDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CattlemixedDailyProfitDelete/1
        public ActionResult CattlemixedDailyProfitDelete(int id)
        {
            return View(_breedingService.GetCattlemixedDailyProfitById(id));
        }

        // POST: Breeding/CattlemixedDailyProfitDelete/1
        [HttpPost]

        public ActionResult CattlemixedDailyProfitDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteCattlemixedDailyProfitById(id);

                return RedirectToAction("CattlemixedDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region CattlemixedRetiring

        // GET: Breeding/CattlemixedProfits
        public ActionResult CattlemixedProfits()
        {
            return View(_breedingService.GetCattlemixedProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CattlemixedProfitEdit/1
        public ActionResult CattlemixedProfitEdit(int id)
        {

            return View(_breedingService.GetCattlemixedProfitById(id));
        }

        // POST: Breeding/CattlemixedProfitEdit/1
        [HttpPost]
        public ActionResult CattlemixedProfitEdit(int id, FormCollection collection)
        {
            try
            {
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetCattlemixedProfitById(id));

                _breedingService.AddNewCattlemixedProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemixedProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region CattlemixedReminding

        // GET: Breeding/CattlemixedRemindings
        public ActionResult CattlemixedRemindings()
        {
            return View(_breedingService.GetCattlemixedRemindings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CattlemixedRemindingCreate
        public ActionResult CattlemixedRemindingCreate()
        {
            return View();
        }
        // POST: Breeding/CattlemixedRemindingCreate
        [HttpPost]
        public ActionResult CattlemixedRemindingCreate(FormCollection collection)
        {
            try
            {
                _breedingService.AddNewCattlemixedReminding(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemixedRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CattlemixedRemindingEdit/1
        public ActionResult CattlemixedRemindingEdit(int id)
        {
            return View(_breedingService.GetCattlemixedRemindingById(id));
        }

        // POST: Breeding/CattlemixedRemindingEdit/1
        [HttpPost]
        public ActionResult CattlemixedRemindingEdit(int id, FormCollection collection)
        {
            try
            {
                _breedingService.AddNewCattlemixedRemindingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemixedRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CattlemixedRemindingDelete/1
        public ActionResult CattlemixedRemindingDelete(int id)
        {
            return View(_breedingService.GetCattlemixedRemindingById(id));
        }

        // POST: Breeding/CattlemixedRemindingDelete/1
        [HttpPost]

        public ActionResult CattlemixedRemindingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteCattlemixedRemindingById(id);

                return RedirectToAction("CattlemixedRemindings");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}