using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Breeding
{

    public partial class BreedingController
    {


        #region CamelYoung

        // GET: Breeding/CamelYoung
        public ActionResult CamelYoung()
        {
            return View(_breedingService.GetCamelYoungs(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CamelYoungCreate
        public ActionResult CamelYoungCreate()
        {
            return View(FillYoungDropDownList("Сamel"));
        }

        // POST: Breeding/CamelYoungCreate
        [HttpPost]
        public ActionResult CamelYoungCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToYoungModel(collection, "Сamel"));
                _breedingService.AddNewCamelYoung(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("CamelYoung");
            }
            catch
            {
                return View(FillYoungDropDownList("Сamel"));
            }
        }

        // GET: Breeding/CamelYoungEdit/1
        public ActionResult CamelYoungEdit(int id)
        {
            return View(_breedingService.GetCamelYoungById(id));
        }

        // POST: Breeding/CamelYoungEdit/1
        [HttpPost]
        public ActionResult CamelYoungEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetCamelYoungById(id));

                _breedingService.AddNewCamelYoungById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CamelYoung");
            }
            catch
            {
                return View(FillYoungDropDownList("Сamel"));
            }
        }

        // GET: Breeding/CamelYoungDelete/1
        public ActionResult CamelYoungDelete(int id)
        {
            return View(_breedingService.GetCamelYoungById(id));
        }

        // POST: Breeding/CamelYoungDelete/1
        [HttpPost]
        public ActionResult CamelYoungDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteCamelYoungById(id);
                Thread.Sleep(300);
                return RedirectToAction("CamelYoung");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region CamelComing

        // GET: Breeding/CamelComing
        public ActionResult CamelComing()
        {
            return View(_breedingService.GetCamelComings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CamelComingCreate
        public ActionResult CamelComingCreate()
        {
            return View(FillDropDownList("Сamel"));
        }


        // POST: Breeding/CamelComingCreate
        [HttpPost]
        public ActionResult CamelComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToAnimalsModel(collection, "Сamel"));
                _breedingService.AddNewCamelComing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("CamelComing");
            }
            catch
            {
                return View(FillDropDownList("Сamel"));
            }
        }

        // GET: Breeding/CamelComingEdit/1
        public ActionResult CamelComingEdit(int id)
        {
            return View(_breedingService.GetCamelComingById(id));
        }

        // POST: Breeding/CamelComingEdit/1
        [HttpPost]
        public ActionResult CamelComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetCamelComingById(id));

                _breedingService.AddNewCamelComingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CamelComing");
            }
            catch
            {
                return View(FillDropDownList("Сamel"));
            }
        }

        // GET: Breeding/CamelComingDelete/1
        public ActionResult CamelComingDelete(int id)
        {
            return View(_breedingService.GetCamelComingById(id));
        }

        // POST: Breeding/CamelComingDelete/1
        [HttpPost]
        public ActionResult CamelComingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteCamelComingById(id);
                Thread.Sleep(300);
                return RedirectToAction("CamelComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region CamelCharges

        // GET: Breeding/CamelCharges
        public ActionResult CamelCharges()
        {
            return View(_breedingService.GetCamelCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CamelChargesCreate
        public ActionResult CamelChargesCreate()
        {
            return View();
        }
        // POST: Breeding/CamelChargesCreate
        [HttpPost]
        public ActionResult CamelChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _breedingService.AddNewCamelCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("CamelCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CamelChargesEdit/1
        public ActionResult CamelChargesEdit(int id)
        {
            return View(_breedingService.GetCamelChargesById(id));
        }

        // POST: Breeding/CamelChargesEdit/1
        [HttpPost]
        public ActionResult CamelChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetCamelChargesById(id));

                _breedingService.AddNewCamelChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CamelCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CamelChargesDelete/1
        public ActionResult CamelChargesDelete(int id)
        {
            return View(_breedingService.GetCamelChargesById(id));
        }

        // POST: Breeding/CamelChargesDelete/1
        [HttpPost]

        public ActionResult CamelChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteCamelChargesById(id);

                return RedirectToAction("CamelCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region CamelDaily

        // GET: Breeding/CamelDailyProfits
        public ActionResult CamelDailyProfits()
        {
            return View(_breedingService.GetCamelDailyProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CamelDailyProfitCreate
        public ActionResult CamelDailyProfitCreate()
        {
            return View();
        }
        // POST: Breeding/CamelDailyProfitCreate
        [HttpPost]
        public ActionResult CamelDailyProfitCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(ConvertToDailyModel(collection));

                _breedingService.AddNewCamelDailyProfits(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(400);
                return RedirectToAction("CamelDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CamelDailyProfitEdit/1
        public ActionResult CamelDailyProfitEdit(int id)
        {
            return View(_breedingService.GetCamelDailyProfitById(id));
        }

        // POST: Breeding/CamelDailyProfitEdit/1
        [HttpPost]
        public ActionResult CamelDailyProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetCamelDailyProfitById(id));

                _breedingService.AddNewCamelDailyProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CamelDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CamelDailyProfitDelete/1
        public ActionResult CamelDailyProfitDelete(int id)
        {
            return View(_breedingService.GetCamelDailyProfitById(id));
        }

        // POST: Breeding/CamelDailyProfitDelete/1
        [HttpPost]

        public ActionResult CamelDailyProfitDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteCamelDailyProfitById(id);

                return RedirectToAction("CamelDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region CamelRetiring

        // GET: Breeding/CamelProfits
        public ActionResult CamelProfits()
        {
            return View(_breedingService.GetCamelProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CamelProfitEdit/1
        public ActionResult CamelProfitEdit(int id)
        {

            return View(_breedingService.GetCamelProfitById(id));
        }

        // POST: Breeding/CamelProfitEdit/1
        [HttpPost]
        public ActionResult CamelProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetCamelProfitById(id));

                _breedingService.AddNewCamelProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CamelProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region CamelReminding

        // GET: Breeding/CamelRemindings
        public ActionResult CamelRemindings()
        {
            return View(_breedingService.GetCamelRemindings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/CamelRemindingCreate
        public ActionResult CamelRemindingCreate()
        {
            return View();
        }
        // POST: Breeding/CamelRemindingCreate
        [HttpPost]
        public ActionResult CamelRemindingCreate(FormCollection collection)
        {
            try
            {
                _breedingService.AddNewCamelReminding(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("CamelRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CamelRemindingEdit/1
        public ActionResult CamelRemindingEdit(int id)
        {
            return View(_breedingService.GetCamelRemindingById(id));
        }

        // POST: Breeding/CamelRemindingEdit/1
        [HttpPost]
        public ActionResult CamelRemindingEdit(int id, FormCollection collection)
        {
            try
            {
                _breedingService.AddNewCamelRemindingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CamelRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/CamelRemindingDelete/1
        public ActionResult CamelRemindingDelete(int id)
        {
            return View(_breedingService.GetCamelRemindingById(id));
        }

        // POST: Breeding/CamelRemindingDelete/1
        [HttpPost]

        public ActionResult CamelRemindingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteCamelRemindingById(id);

                return RedirectToAction("CamelRemindings");
            }
            catch
            {
                return View();
            }
        }

        #endregion
    }
}