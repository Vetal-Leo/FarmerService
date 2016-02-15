using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Breeding
{

    public partial class BreedingController
    {


        #region HenMeatComing

        // GET: Breeding/HenMeatComing
        public ActionResult HenMeatComing()
        {
            return View(_breedingService.GetHenMeatComings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/HenMeatComingCreate
        public ActionResult HenMeatComingCreate()
        {
            return View(FillDropDownList("HenMeat"));
        }


        // POST: Breeding/HenMeatComingCreate
        [HttpPost]
        public ActionResult HenMeatComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToAnimalsModel(collection, "HenMeat"));
                _breedingService.AddNewHenMeatComing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("HenMeatComing");
            }
            catch
            {
                return View(FillDropDownList("HenMeat"));
            }
        }

        // GET: Breeding/HenMeatComingEdit/1
        public ActionResult HenMeatComingEdit(int id)
        {
            return View(_breedingService.GetHenMeatComingById(id));
        }

        // POST: Breeding/HenMeatComingEdit/1
        [HttpPost]
        public ActionResult HenMeatComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetHenMeatComingById(id));

                _breedingService.AddNewHenMeatComingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("HenMeatComing");
            }
            catch
            {
                return View(FillDropDownList("HenMeat"));
            }
        }

        // GET: Breeding/HenMeatComingDelete/1
        public ActionResult HenMeatComingDelete(int id)
        {
            return View(_breedingService.GetHenMeatComingById(id));
        }

        // POST: Breeding/HenMeatComingDelete/1
        [HttpPost]
        public ActionResult HenMeatComingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteHenMeatComingById(id);
                Thread.Sleep(300);
                return RedirectToAction("HenMeatComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region HenMeatCharges

        // GET: Breeding/HenMeatCharges
        public ActionResult HenMeatCharges()
        {
            return View(_breedingService.GetHenMeatCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/HenMeatChargesCreate
        public ActionResult HenMeatChargesCreate()
        {
            return View();
        }
        // POST: Breeding/HenMeatChargesCreate
        [HttpPost]
        public ActionResult HenMeatChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _breedingService.AddNewHenMeatCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("HenMeatCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/HenMeatChargesEdit/1
        public ActionResult HenMeatChargesEdit(int id)
        {
            return View(_breedingService.GetHenMeatChargesById(id));
        }

        // POST: Breeding/HenMeatChargesEdit/1
        [HttpPost]
        public ActionResult HenMeatChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetHenMeatChargesById(id));

                _breedingService.AddNewHenMeatChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("HenMeatCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/HenMeatChargesDelete/1
        public ActionResult HenMeatChargesDelete(int id)
        {
            return View(_breedingService.GetHenMeatChargesById(id));
        }

        // POST: Breeding/HenMeatChargesDelete/1
        [HttpPost]

        public ActionResult HenMeatChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteHenMeatChargesById(id);

                return RedirectToAction("HenMeatCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region HenMeatDaily

        // GET: Breeding/HenMeatDailyProfits
        public ActionResult HenMeatDailyProfits()
        {
            return View(_breedingService.GetHenMeatDailyProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/HenMeatDailyProfitCreate
        public ActionResult HenMeatDailyProfitCreate()
        {
            return View();
        }
        // POST: Breeding/HenMeatDailyProfitCreate
        [HttpPost]
        public ActionResult HenMeatDailyProfitCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(ConvertToDailyModel(collection));

                _breedingService.AddNewHenMeatDailyProfits(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(400);
                return RedirectToAction("HenMeatDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/HenMeatDailyProfitEdit/1
        public ActionResult HenMeatDailyProfitEdit(int id)
        {
            return View(_breedingService.GetHenMeatDailyProfitById(id));
        }

        // POST: Breeding/HenMeatDailyProfitEdit/1
        [HttpPost]
        public ActionResult HenMeatDailyProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetHenMeatDailyProfitById(id));

                _breedingService.AddNewHenMeatDailyProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("HenMeatDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/HenMeatDailyProfitDelete/1
        public ActionResult HenMeatDailyProfitDelete(int id)
        {
            return View(_breedingService.GetHenMeatDailyProfitById(id));
        }

        // POST: Breeding/HenMeatDailyProfitDelete/1
        [HttpPost]

        public ActionResult HenMeatDailyProfitDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteHenMeatDailyProfitById(id);

                return RedirectToAction("HenMeatDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region HenMeatRetiring

        // GET: Breeding/HenMeatProfits
        public ActionResult HenMeatProfits()
        {
            return View(_breedingService.GetHenMeatProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/HenMeatProfitEdit/1
        public ActionResult HenMeatProfitEdit(int id)
        {

            return View(_breedingService.GetHenMeatProfitById(id));
        }

        // POST: Breeding/HenMeatProfitEdit/1
        [HttpPost]
        public ActionResult HenMeatProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetHenMeatProfitById(id));

                _breedingService.AddNewGoatProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("HenMeatProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region HenMeatReminding

        // GET: Breeding/HenMeatRemindings
        public ActionResult HenMeatRemindings()
        {
            return View(_breedingService.GetHenMeatRemindings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/HenMeatRemindingCreate
        public ActionResult HenMeatRemindingCreate()
        {
            return View();
        }
        // POST: Breeding/HenMeatRemindingCreate
        [HttpPost]
        public ActionResult HenMeatRemindingCreate(FormCollection collection)
        {
            try
            {
                _breedingService.AddNewHenMeatReminding(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("HenMeatRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/HenMeatRemindingEdit/1
        public ActionResult HenMeatRemindingEdit(int id)
        {
            return View(_breedingService.GetHenMeatRemindingById(id));
        }

        // POST: Breeding/HenMeatRemindingEdit/1
        [HttpPost]
        public ActionResult HenMeatRemindingEdit(int id, FormCollection collection)
        {
            try
            {
                _breedingService.AddNewHenMeatRemindingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("HenMeatRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/HenMeatRemindingDelete/1
        public ActionResult HenMeatRemindingDelete(int id)
        {
            return View(_breedingService.GetHenMeatRemindingById(id));
        }

        // POST: Breeding/HenMeatRemindingDelete/1
        [HttpPost]

        public ActionResult HenMeatRemindingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteHenMeatRemindingById(id);

                return RedirectToAction("HenMeatRemindings");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}