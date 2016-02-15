using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Breeding
{

    public partial class BreedingController
    {

        #region CattlemilkYoung

        // GET: Breeding/CattlemilkYoung
        public ActionResult CattlemilkYoung()
        {
            return View(_breedingService.GetCattlemilkYoungs(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CattlemilkYoungCreate
        public ActionResult CattlemilkYoungCreate()
        {
            return View(FillYoungDropDownList("Cattlemilk"));
        }

        // POST: Breeding/CattlemilkYoungCreate
        [HttpPost]
        public ActionResult CattlemilkYoungCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToYoungModel(collection, "Cattlemilk"));
                _breedingService.AddNewCattlemilkYoung(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("CattlemilkYoung");
            }
            catch
            {
                return View(FillYoungDropDownList("Cattlemilk"));
            }
        }

        // GET: Breeding/CattlemilkYoungEdit/1
        public ActionResult CattlemilkYoungEdit(int id)
        {
            return View(_breedingService.GetCattlemilkYoungById(id));
        }

        // POST: Breeding/CattlemilkYoungEdit/1
        [HttpPost]
        public ActionResult CattlemilkYoungEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetCattlemilkYoungById(id));

                _breedingService.AddNewCattlemilkYoungById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemilkYoung");
            }
            catch
            {
                return View(FillYoungDropDownList("Cattlemilk"));
            }
        }

        // GET: Breeding/CattlemilkYoungDelete/1
        public ActionResult CattlemilkYoungDelete(int id)
        {
            return View(_breedingService.GetCattlemilkYoungById(id));
        }

        // POST: Breeding/CattlemilkYoungDelete/1
        [HttpPost]
        public ActionResult CattlemilkYoungDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteCattlemilkYoungById(id);
                Thread.Sleep(300);
                return RedirectToAction("CattlemilkYoung");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region CattlemilkComing

        // GET: Breeding/CattlemilkComing
        public ActionResult CattlemilkComing()
        {
            return View(_breedingService.GetCattlemilkComings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CattlemilkComingCreate
        public ActionResult CattlemilkComingCreate()
        {
            return View(FillDropDownList("Cattlemilk"));
        }


        // POST: Breeding/CattlemilkComingCreate
        [HttpPost]
        public ActionResult CattlemilkComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToAnimalsModel(collection, "Cattlemilk"));
                _breedingService.AddNewCattlemilkComing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("CattlemilkComing");
            }
            catch
            {
                return View(FillDropDownList("Cattlemilk"));
            }
        }

        // GET: Breeding/CattlemilkComingEdit/1
        public ActionResult CattlemilkComingEdit(int id)
        {
            return View(_breedingService.GetCattlemilkComingById(id));
        }

        // POST: Breeding/CattlemilkComingEdit/1
        [HttpPost]
        public ActionResult CattlemilkComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetCattlemilkComingById(id));

                _breedingService.AddNewCattlemilkComingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemilkComing");
            }
            catch
            {
                return View(FillDropDownList("Cattlemilk"));
            }
        }

        // GET: Breeding/CattlemilkComingDelete/1
        public ActionResult CattlemilkComingDelete(int id)
        {
            return View(_breedingService.GetCattlemilkComingById(id));
        }

        // POST: Breeding/CattlemilkComingDelete/1
        [HttpPost]
        public ActionResult CattlemilkComingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteCattlemilkComingById(id);
                Thread.Sleep(300);
                return RedirectToAction("CattlemilkComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region CattlemilkCharges

        // GET: Breeding/CattlemilkCharges
        public ActionResult CattlemilkCharges()
        {
            return View(_breedingService.GetCattlemilkCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CattlemilkChargesCreate
        public ActionResult CattlemilkChargesCreate()
        {
            return View();
        }
        // POST: Breeding/CattlemilkChargesCreate
        [HttpPost]
        public ActionResult CattlemilkChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _breedingService.AddNewCattlemilkCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemilkCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CattlemilkChargesEdit/1
        public ActionResult CattlemilkChargesEdit(int id)
        {
            return View(_breedingService.GetCattlemilkChargesById(id));
        }

        // POST: Breeding/CattlemilkChargesEdit/1
        [HttpPost]
        public ActionResult CattlemilkChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetCattlemilkChargesById(id));

                _breedingService.AddNewCattlemilkChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemilkCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CattlemilkChargesDelete/1
        public ActionResult CattlemilkChargesDelete(int id)
        {
            return View(_breedingService.GetCattlemilkChargesById(id));
        }

        // POST: Breeding/CattlemilkChargesDelete/1
        [HttpPost]

        public ActionResult CattlemilkChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteCattlemilkChargesById(id);

                return RedirectToAction("CattlemilkCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region CattlemilkDaily

        // GET: Breeding/CattlemilkDailyProfits
        public ActionResult CattlemilkDailyProfits()
        {
            return View(_breedingService.GetCattlemilkDailyProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CattlemilkDailyProfitCreate
        public ActionResult CattlemilkDailyProfitCreate()
        {
            return View();
        }
        // POST: Breeding/CattlemilkDailyProfitCreate
        [HttpPost]
        public ActionResult CattlemilkDailyProfitCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(ConvertToDailyModel(collection));

                _breedingService.AddNewCattlemilkDailyProfits(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(400);
                return RedirectToAction("CattlemilkDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CattlemilkDailyProfitEdit/1
        public ActionResult CattlemilkDailyProfitEdit(int id)
        {
            return View(_breedingService.GetCattlemilkDailyProfitById(id));
        }

        // POST: Breeding/CattlemilkDailyProfitEdit/1
        [HttpPost]
        public ActionResult CattlemilkDailyProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetCattlemilkDailyProfitById(id));

                _breedingService.AddNewCattlemilkDailyProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemilkDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CattlemilkDailyProfitDelete/1
        public ActionResult CattlemilkDailyProfitDelete(int id)
        {
            return View(_breedingService.GetCattlemilkDailyProfitById(id));
        }

        // POST: Breeding/CattlemilkDailyProfitDelete/1
        [HttpPost]

        public ActionResult CattlemilkDailyProfitDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteCattlemilkDailyProfitById(id);

                return RedirectToAction("CattlemilkDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region CattlemilkRetiring

        // GET: Breeding/CattlemilkProfits
        public ActionResult CattlemilkProfits()
        {
            return View(_breedingService.GetCattlemilkProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CattlemilkProfitEdit/1
        public ActionResult CattlemilkProfitEdit(int id)
        {

            return View(_breedingService.GetCattlemilkProfitById(id));
        }

        // POST: Breeding/CattlemilkProfitEdit/1
        [HttpPost]
        public ActionResult CattlemilkProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetCattlemilkProfitById(id));

                _breedingService.AddNewCattlemilkProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemilkProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region CattlemilkReminding

        // GET: Breeding/CattlemilkRemindings
        public ActionResult CattlemilkRemindings()
        {
            return View(_breedingService.GetCattlemilkRemindings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CattlemilkRemindingCreate
        public ActionResult CattlemilkRemindingCreate()
        {
            return View();
        }
        // POST: Breeding/CattlemilkRemindingCreate
        [HttpPost]
        public ActionResult CattlemilkRemindingCreate(FormCollection collection)
        {
            try
            {
                _breedingService.AddNewCattlemilkReminding(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemilkRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CattlemilkRemindingEdit/1
        public ActionResult CattlemilkRemindingEdit(int id)
        {
            return View(_breedingService.GetCattlemilkRemindingById(id));
        }

        // POST: Breeding/CattlemilkRemindingEdit/1
        [HttpPost]
        public ActionResult CattlemilkRemindingEdit(int id, FormCollection collection)
        {
            try
            {
                _breedingService.AddNewCattlemilkRemindingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CattlemilkRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CattlemilkRemindingDelete/1
        public ActionResult CattlemilkRemindingDelete(int id)
        {
            return View(_breedingService.GetCattlemilkRemindingById(id));
        }

        // POST: Breeding/CattlemilkRemindingDelete/1
        [HttpPost]

        public ActionResult CattlemilkRemindingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteCattlemilkRemindingById(id);

                return RedirectToAction("CattlemilkRemindings");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}