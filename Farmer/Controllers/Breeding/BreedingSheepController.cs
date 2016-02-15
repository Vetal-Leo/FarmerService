using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Breeding
{

    public partial class BreedingController
    {

        #region SheepYoung

        // GET: Breeding/SheepYoung
        public ActionResult SheepYoung()
        {
            return View(_breedingService.GetSheepYoungs(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/SheepYoungCreate
        public ActionResult SheepYoungCreate()
        {
            return View(FillYoungDropDownList("Sheep"));
        }

        // POST: Breeding/SheepYoungCreate
        [HttpPost]
        public ActionResult SheepYoungCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToYoungModel(collection, "Sheep"));
                _breedingService.AddNewSheepYoung(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("SheepYoung");
            }
            catch
            {
                return View(FillYoungDropDownList("Sheep"));
            }
        }

        // GET: Breeding/SheepYoungEdit/1
        public ActionResult SheepYoungEdit(int id)
        {
            return View(_breedingService.GetSheepYoungById(id));
        }

        // POST: Breeding/SheepYoungEdit/1
        [HttpPost]
        public ActionResult SheepYoungEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetSheepYoungById(id));

                _breedingService.AddNewSheepYoungById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("SheepYoung");
            }
            catch
            {
                return View(FillYoungDropDownList("Sheep"));
            }
        }

        // GET: Breeding/SheepYoungDelete/1
        public ActionResult SheepYoungDelete(int id)
        {
            return View(_breedingService.GetSheepYoungById(id));
        }

        // POST: Breeding/SheepYoungDelete/1
        [HttpPost]
        public ActionResult SheepYoungDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteSheepYoungById(id);
                Thread.Sleep(300);
                return RedirectToAction("SheepYoung");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region SheepComing

        // GET: Breeding/SheepComing
        public ActionResult SheepComing()
        {
            return View(_breedingService.GetSheepComings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/SheepComingCreate
        public ActionResult SheepComingCreate()
        {
            return View(FillDropDownList("Sheep"));
        }


        // POST: Breeding/SheepComingCreate
        [HttpPost]
        public ActionResult SheepComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToAnimalsModel(collection, "Sheep"));
                _breedingService.AddNewSheepComing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("SheepComing");
            }
            catch
            {
                return View(FillDropDownList("Sheep"));
            }
        }

        // GET: Breeding/SheepComingEdit/1
        public ActionResult SheepComingEdit(int id)
        {
            return View(_breedingService.GetSheepComingById(id));
        }

        // POST: Breeding/SheepComingEdit/1
        [HttpPost]
        public ActionResult SheepComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetSheepComingById(id));

                _breedingService.AddNewSheepComingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("SheepComing");
            }
            catch
            {
                return View(FillDropDownList("Sheep"));
            }
        }

        // GET: Breeding/SheepComingDelete/1
        public ActionResult SheepComingDelete(int id)
        {
            return View(_breedingService.GetSheepComingById(id));
        }

        // POST: Breeding/SheepComingDelete/1
        [HttpPost]
        public ActionResult SheepComingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteSheepComingById(id);
                Thread.Sleep(300);
                return RedirectToAction("SheepComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region SheepCharges

        // GET: Breeding/SheepCharges
        public ActionResult SheepCharges()
        {
            return View(_breedingService.GetSheepCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/SheepChargesCreate
        public ActionResult SheepChargesCreate()
        {
            return View();
        }
        // POST: Breeding/SheepChargesCreate
        [HttpPost]
        public ActionResult SheepChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _breedingService.AddNewSheepCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("SheepCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/SheepChargesEdit/1
        public ActionResult SheepChargesEdit(int id)
        {
            return View(_breedingService.GetSheepChargesById(id));
        }

        // POST: Breeding/SheepChargesEdit/1
        [HttpPost]
        public ActionResult SheepChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetSheepChargesById(id));

                _breedingService.AddNewSheepChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("SheepCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/SheepChargesDelete/1
        public ActionResult SheepChargesDelete(int id)
        {
            return View(_breedingService.GetSheepChargesById(id));
        }

        // POST: Breeding/SheepChargesDelete/1
        [HttpPost]

        public ActionResult SheepChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteSheepChargesById(id);

                return RedirectToAction("SheepCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region SheepDaily

        // GET: Breeding/SheepDailyProfits
        public ActionResult SheepDailyProfits()
        {
            return View(_breedingService.GetSheepDailyProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/SheepDailyProfitCreate
        public ActionResult SheepDailyProfitCreate()
        {
            return View();
        }
        // POST: Breeding/SheepDailyProfitCreate
        [HttpPost]
        public ActionResult SheepDailyProfitCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(ConvertToDailyModel(collection));

                _breedingService.AddNewSheepDailyProfits(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(400);
                return RedirectToAction("SheepDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/SheepDailyProfitEdit/1
        public ActionResult SheepDailyProfitEdit(int id)
        {
            return View(_breedingService.GetSheepDailyProfitById(id));
        }

        // POST: Breeding/SheepDailyProfitEdit/1
        [HttpPost]
        public ActionResult SheepDailyProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetSheepDailyProfitById(id));

                _breedingService.AddNewSheepDailyProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("SheepDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/SheepDailyProfitDelete/1
        public ActionResult SheepDailyProfitDelete(int id)
        {
            return View(_breedingService.GetSheepDailyProfitById(id));
        }

        // POST: Breeding/SheepDailyProfitDelete/1
        [HttpPost]

        public ActionResult SheepDailyProfitDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteSheepDailyProfitById(id);

                return RedirectToAction("SheepDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region SheepRetiring

        // GET: Breeding/SheepProfits
        public ActionResult SheepProfits()
        {
            return View(_breedingService.GetSheepProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/SheepProfitEdit/1
        public ActionResult SheepProfitEdit(int id)
        {

            return View(_breedingService.GetSheepProfitById(id));
        }

        // POST: Breeding/SheepProfitEdit/1
        [HttpPost]
        public ActionResult SheepProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetSheepProfitById(id));

                _breedingService.AddNewSheepProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("SheepProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region SheepReminding

        // GET: Breeding/SheepRemindings
        public ActionResult SheepRemindings()
        {
            return View(_breedingService.GetSheepRemindings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/SheepRemindingCreate
        public ActionResult SheepRemindingCreate()
        {
            return View();
        }
        // POST: Breeding/SheepRemindingCreate
        [HttpPost]
        public ActionResult SheepRemindingCreate(FormCollection collection)
        {
            try
            {
                _breedingService.AddNewSheepReminding(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("SheepRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/SheepRemindingEdit/1
        public ActionResult SheepRemindingEdit(int id)
        {
            return View(_breedingService.GetSheepRemindingById(id));
        }

        // POST: Breeding/SheepRemindingEdit/1
        [HttpPost]
        public ActionResult SheepRemindingEdit(int id, FormCollection collection)
        {
            try
            {
                _breedingService.AddNewSheepRemindingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("SheepRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/SheepRemindingDelete/1
        public ActionResult SheepRemindingDelete(int id)
        {
            return View(_breedingService.GetSheepRemindingById(id));
        }

        // POST: Breeding/SheepRemindingDelete/1
        [HttpPost]

        public ActionResult SheepRemindingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteSheepRemindingById(id);

                return RedirectToAction("SheepRemindings");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}