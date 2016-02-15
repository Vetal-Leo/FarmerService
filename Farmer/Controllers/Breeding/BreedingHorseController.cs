using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Breeding
{

    public partial class BreedingController
    {

        #region HorseYoung

        // GET: Breeding/HorseYoung
        public ActionResult HorseYoung()
        {
            return View(_breedingService.GetHorseYoungs(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/HorseYoungCreate
        public ActionResult HorseYoungCreate()
        {
            return View(FillYoungDropDownList("Horse"));
        }

        // POST: Breeding/HorseYoungCreate
        [HttpPost]
        public ActionResult HorseYoungCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToYoungModel(collection, "Horse"));
                _breedingService.AddNewHorseYoung(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("HorseYoung");
            }
            catch
            {
                return View(FillYoungDropDownList("Horse"));
            }
        }

        // GET: Breeding/HorseYoungEdit/1
        public ActionResult HorseYoungEdit(int id)
        {
            return View(_breedingService.GetHorseYoungById(id));
        }

        // POST: Breeding/HorseYoungEdit/1
        [HttpPost]
        public ActionResult HorseYoungEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetHorseYoungById(id));

                _breedingService.AddNewHorseYoungById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("HorseYoung");
            }
            catch
            {
                return View(FillYoungDropDownList("Horse"));
            }
        }

        // GET: Breeding/HorseYoungDelete/1
        public ActionResult HorseYoungDelete(int id)
        {
            return View(_breedingService.GetHorseYoungById(id));
        }

        // POST: Breeding/HorseYoungDelete/1
        [HttpPost]
        public ActionResult HorseYoungDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteHorseYoungById(id);
                Thread.Sleep(300);
                return RedirectToAction("HorseYoung");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region HorseComing

        // GET: Breeding/HorseComing
        public ActionResult HorseComing()
        {
            return View(_breedingService.GetHorseComings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/HorseComingCreate
        public ActionResult HorseComingCreate()
        {
            return View(FillDropDownList("Horse"));
        }


        // POST: Breeding/HorseComingCreate
        [HttpPost]
        public ActionResult HorseComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToAnimalsModel(collection, "Horse"));
                _breedingService.AddNewHorseComing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("HorseComing");
            }
            catch
            {
                return View(FillDropDownList("Horse"));
            }
        }

        // GET: Breeding/HorseComingEdit/1
        public ActionResult HorseComingEdit(int id)
        {
            return View(_breedingService.GetHorseComingById(id));
        }

        // POST: Breeding/HorseComingEdit/1
        [HttpPost]
        public ActionResult HorseComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetHorseComingById(id));

                _breedingService.AddNewHorseComingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("HorseComing");
            }
            catch
            {
                return View(FillDropDownList("Horse"));
            }
        }

        // GET: Breeding/HorseComingDelete/1
        public ActionResult HorseComingDelete(int id)
        {
            return View(_breedingService.GetHorseComingById(id));
        }

        // POST: Breeding/HorseComingDelete/1
        [HttpPost]
        public ActionResult HorseComingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteHorseComingById(id);
                Thread.Sleep(300);
                return RedirectToAction("HorseComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region HorseCharges

        // GET: Breeding/HorseCharges
        public ActionResult HorseCharges()
        {
            return View(_breedingService.GetHorseCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/HorseChargesCreate
        public ActionResult HorseChargesCreate()
        {
            return View();
        }
        // POST: Breeding/HorseChargesCreate
        [HttpPost]
        public ActionResult HorseChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _breedingService.AddNewHorseCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("HorseCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/HorseChargesEdit/1
        public ActionResult HorseChargesEdit(int id)
        {
            return View(_breedingService.GetHorseChargesById(id));
        }

        // POST: Breeding/HorseChargesEdit/1
        [HttpPost]
        public ActionResult HorseChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetHorseChargesById(id));

                _breedingService.AddNewHorseChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("HorseCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/HorseChargesDelete/1
        public ActionResult HorseChargesDelete(int id)
        {
            return View(_breedingService.GetHorseChargesById(id));
        }

        // POST: Breeding/HorseChargesDelete/1
        [HttpPost]

        public ActionResult HorseChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteHorseChargesById(id);

                return RedirectToAction("HorseCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region HorseDaily

        // GET: Breeding/HorseDailyProfits
        public ActionResult HorseDailyProfits()
        {
            return View(_breedingService.GetHorseDailyProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/HorseDailyProfitCreate
        public ActionResult HorseDailyProfitCreate()
        {
            return View();
        }
        // POST: Breeding/HorseDailyProfitCreate
        [HttpPost]
        public ActionResult HorseDailyProfitCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(ConvertToDailyModel(collection));

                _breedingService.AddNewHorseDailyProfits(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(400);
                return RedirectToAction("HorseDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/HorseDailyProfitEdit/1
        public ActionResult HorseDailyProfitEdit(int id)
        {
            return View(_breedingService.GetHorseDailyProfitById(id));
        }

        // POST: Breeding/HorseDailyProfitEdit/1
        [HttpPost]
        public ActionResult HorseDailyProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetHorseDailyProfitById(id));

                _breedingService.AddNewHorseDailyProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("HorseDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/HorseDailyProfitDelete/1
        public ActionResult HorseDailyProfitDelete(int id)
        {
            return View(_breedingService.GetHorseDailyProfitById(id));
        }

        // POST: Breeding/HorseDailyProfitDelete/1
        [HttpPost]

        public ActionResult HorseDailyProfitDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteHorseDailyProfitById(id);

                return RedirectToAction("HorseDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region CamelRetiring

        // GET: Breeding/HorseProfits
        public ActionResult HorseProfits()
        {
            return View(_breedingService.GetHorseProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/HorseProfitEdit/1
        public ActionResult HorseProfitEdit(int id)
        {

            return View(_breedingService.GetHorseProfitById(id));
        }

        // POST: Breeding/HorseProfitEdit/1
        [HttpPost]
        public ActionResult HorseProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetHorseProfitById(id));

                _breedingService.AddNewHorseProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("HorseProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region HorseReminding

        // GET: Breeding/HorseRemindings
        public ActionResult HorseRemindings()
        {
            return View(_breedingService.GetHorseRemindings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/HorseRemindingCreate
        public ActionResult HorseRemindingCreate()
        {
            return View();
        }
        // POST: Breeding/HorseRemindingCreate
        [HttpPost]
        public ActionResult HorseRemindingCreate(FormCollection collection)
        {
            try
            {
                _breedingService.AddNewHorseReminding(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("HorseRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/HorseRemindingEdit/1
        public ActionResult HorseRemindingEdit(int id)
        {
            return View(_breedingService.GetHorseRemindingById(id));
        }

        // POST: Breeding/HorseRemindingEdit/1
        [HttpPost]
        public ActionResult HorseRemindingEdit(int id, FormCollection collection)
        {
            try
            {
                _breedingService.AddNewHorseRemindingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("HorseRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/HorseRemindingDelete/1
        public ActionResult HorseRemindingDelete(int id)
        {
            return View(_breedingService.GetHorseRemindingById(id));
        }

        // POST: Breeding/HorseRemindingDelete/1
        [HttpPost]

        public ActionResult HorseRemindingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteHorseRemindingById(id);

                return RedirectToAction("HorseRemindings");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}