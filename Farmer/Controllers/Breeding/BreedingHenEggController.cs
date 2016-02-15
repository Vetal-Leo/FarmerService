using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Breeding
{

    public partial class BreedingController
    {


        #region HenEggComing

        // GET: Breeding/HenEggComing
        public ActionResult HenEggComing()
        {
            return View(_breedingService.GetHenEggComings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/HenEggComingCreate
        public ActionResult HenEggComingCreate()
        {
            return View(FillDropDownList("HenEgg"));
        }


        // POST: Breeding/HenEggComingCreate
        [HttpPost]
        public ActionResult HenEggComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToAnimalsModel(collection, "HenEgg"));
                _breedingService.AddNewHenEggComing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("HenEggComing");
            }
            catch
            {
                return View(FillDropDownList("HenEgg"));
            }
        }

        // GET: Breeding/HenEggComingEdit/1
        public ActionResult HenEggComingEdit(int id)
        {
            return View(_breedingService.GetHenEggComingById(id));
        }

        // POST: Breeding/HenEggComingEdit/1
        [HttpPost]
        public ActionResult HenEggComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetHenEggComingById(id));

                _breedingService.AddNewHenEggComingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("HenEggComing");
            }
            catch
            {
                return View(FillDropDownList("HenEgg"));
            }
        }

        // GET: Breeding/HenEggComingDelete/1
        public ActionResult HenEggComingDelete(int id)
        {
            return View(_breedingService.GetHenEggComingById(id));
        }

        // POST: Breeding/HenEggComingDelete/1
        [HttpPost]
        public ActionResult HenEggComingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteHenEggComingById(id);
                Thread.Sleep(300);
                return RedirectToAction("HenEggComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region HenEggCharges

        // GET: Breeding/HenEggCharges
        public ActionResult HenEggCharges()
        {
            return View(_breedingService.GetHenEggCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/HenEggChargesCreate
        public ActionResult HenEggChargesCreate()
        {
            return View();
        }
        // POST: Breeding/HenEggChargesCreate
        [HttpPost]
        public ActionResult HenEggChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _breedingService.AddNewHenEggCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("HenEggCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/HenEggChargesEdit/1
        public ActionResult HenEggChargesEdit(int id)
        {
            return View(_breedingService.GetHenEggChargesById(id));
        }

        // POST: Breeding/HenEggChargesEdit/1
        [HttpPost]
        public ActionResult HenEggChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetHenEggChargesById(id));

                _breedingService.AddNewHenEggChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("HenEggCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/HenEggChargesDelete/1
        public ActionResult HenEggChargesDelete(int id)
        {
            return View(_breedingService.GetHenEggChargesById(id));
        }

        // POST: Breeding/HenEggChargesDelete/1
        [HttpPost]

        public ActionResult HenEggChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteHenEggChargesById(id);

                return RedirectToAction("HenEggCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region HenEggDaily

        // GET: Breeding/HenEggDailyProfits
        public ActionResult HenEggDailyProfits()
        {
            return View(_breedingService.GetHenEggDailyProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/HenEggDailyProfitCreate
        public ActionResult HenEggDailyProfitCreate()
        {
            return View();
        }
        // POST: Breeding/HenEggDailyProfitCreate
        [HttpPost]
        public ActionResult HenEggDailyProfitCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(ConvertToDailyModel(collection));

                _breedingService.AddNewHenEggDailyProfits(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(400);
                return RedirectToAction("HenEggDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/HenEggDailyProfitEdit/1
        public ActionResult HenEggDailyProfitEdit(int id)
        {
            return View(_breedingService.GetHenEggDailyProfitById(id));
        }

        // POST: Breeding/HenEggDailyProfitEdit/1
        [HttpPost]
        public ActionResult HenEggDailyProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetHenEggDailyProfitById(id));

                _breedingService.AddNewHenEggDailyProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("HenEggDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/HenEggDailyProfitDelete/1
        public ActionResult HenEggDailyProfitDelete(int id)
        {
            return View(_breedingService.GetHenEggDailyProfitById(id));
        }

        // POST: Breeding/HenEggDailyProfitDelete/1
        [HttpPost]

        public ActionResult HenEggDailyProfitDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteHenEggDailyProfitById(id);

                return RedirectToAction("HenEggDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region HenEggRetiring

        // GET: Breeding/HenEggProfits
        public ActionResult HenEggProfits()
        {
            return View(_breedingService.GetHenEggProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/HenEggProfitEdit/1
        public ActionResult HenEggProfitEdit(int id)
        {

            return View(_breedingService.GetHenEggProfitById(id));
        }

        // POST: Breeding/HenEggProfitEdit/1
        [HttpPost]
        public ActionResult HenEggProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetHenEggProfitById(id));

                _breedingService.AddNewHenEggProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("HenEggProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region HenEggReminding

        // GET: Breeding/HenEggRemindings
        public ActionResult HenEggRemindings()
        {
            return View(_breedingService.GetHenEggRemindings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/HenEggRemindingCreate
        public ActionResult HenEggRemindingCreate()
        {
            return View();
        }
        // POST: Breeding/HenEggRemindingCreate
        [HttpPost]
        public ActionResult HenEggRemindingCreate(FormCollection collection)
        {
            try
            {
                _breedingService.AddNewHenEggReminding(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("HenEggRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/HenEggRemindingEdit/1
        public ActionResult HenEggRemindingEdit(int id)
        {
            return View(_breedingService.GetHenEggRemindingById(id));
        }

        // POST: Breeding/HenEggRemindingEdit/1
        [HttpPost]
        public ActionResult HenEggRemindingEdit(int id, FormCollection collection)
        {
            try
            {
                _breedingService.AddNewHenEggRemindingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("HenEggRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/HenEggRemindingDelete/1
        public ActionResult HenEggRemindingDelete(int id)
        {
            return View(_breedingService.GetHenEggRemindingById(id));
        }

        // POST: Breeding/HenEggRemindingDelete/1
        [HttpPost]

        public ActionResult HenEggRemindingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteHenEggRemindingById(id);

                return RedirectToAction("HenEggRemindings");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}