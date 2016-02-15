using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Breeding
{
    
    public partial class BreedingController 
    {

        #region GoatYoung

        // GET: Breeding/GoatYoung
        public ActionResult GoatYoung()
        {
            return View(_breedingService.GetGoatYoungs(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/GoatYoungCreate
        public ActionResult GoatYoungCreate()
        {
            return View(FillYoungDropDownList("Goat"));
        }

        // POST: Breeding/GoatYoungCreate
        [HttpPost]
        public ActionResult GoatYoungCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToYoungModel(collection, "Goat"));
                _breedingService.AddNewGoatYoung(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("GoatYoung");
            }
            catch
            {
                return View(FillYoungDropDownList("Goat"));
            }
        }

        // GET: Breeding/GoatYoungEdit/1
        public ActionResult GoatYoungEdit(int id)
        {
            return View(_breedingService.GetGoatYoungById(id));
        }

        // POST: Breeding/GoatYoungEdit/1
        [HttpPost]
        public ActionResult GoatYoungEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetGoatYoungById(id));

                _breedingService.AddNewGoatYoungById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("GoatYoung");
            }
            catch
            {
                return View(FillYoungDropDownList("Goat"));
            }
        }

        // GET: Breeding/GoatYoungDelete/1
        public ActionResult GoatYoungDelete(int id)
        {
            return View(_breedingService.GetGoatYoungById(id));
        }

        // POST: Breeding/GoatYoungDelete/1
        [HttpPost]
        public ActionResult GoatYoungDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteGoatYoungById(id);
                Thread.Sleep(300);
                return RedirectToAction("GoatYoung");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region GoatComing

        // GET: Breeding/GoatComing
        public ActionResult GoatComing()
        {
            return View(_breedingService.GetGoatComings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/GoatComingCreate
        public ActionResult GoatComingCreate()
        {
            return View(FillDropDownList("Goat"));
        }


        // POST: Breeding/GoatComingCreate
        [HttpPost]
        public ActionResult GoatComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToAnimalsModel(collection, "Goat"));
                _breedingService.AddNewGoatComing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("GoatComing");
            }
            catch
            {
                return View(FillDropDownList("Goat"));
            }
        }

        // GET: Breeding/GoatComingEdit/1
        public ActionResult GoatComingEdit(int id)
        {
            return View(_breedingService.GetGoatComingById(id));
        }

        // POST: Breeding/GoatComingEdit/1
        [HttpPost]
        public ActionResult GoatComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetGoatComingById(id));

                _breedingService.AddNewGoatComingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("GoatComing");
            }
            catch
            {
                return View(FillDropDownList("Goat"));
            }
        }

        // GET: Breeding/GoatComingDelete/1
        public ActionResult GoatComingDelete(int id)
        {
            return View(_breedingService.GetGoatComingById(id));
        }

        // POST: Breeding/GoatComingDelete/1
        [HttpPost]
        public ActionResult GoatComingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteGoatComingById(id);
                Thread.Sleep(300);
                return RedirectToAction("GoatComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region GoatCharges

        // GET: Breeding/GoatCharges
        public ActionResult GoatCharges()
        {
            return View(_breedingService.GetGoatCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/GoatChargesCreate
        public ActionResult GoatChargesCreate()
        {
            return View();
        }
        // POST: Breeding/GoatChargesCreate
        [HttpPost]
        public ActionResult GoatChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _breedingService.AddNewGoatCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("GoatCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/GoatChargesEdit/1
        public ActionResult GoatChargesEdit(int id)
        {
            return View(_breedingService.GetGoatChargesById(id));
        }

        // POST: Breeding/GoatChargesEdit/1
        [HttpPost]
        public ActionResult GoatChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetGoatChargesById(id));

                _breedingService.AddNewGoatChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("GoatCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/GoatChargesDelete/1
        public ActionResult GoatChargesDelete(int id)
        {
            return View(_breedingService.GetGoatChargesById(id));
        }

        // POST: Breeding/GoatChargesDelete/1
        [HttpPost]

        public ActionResult GoatChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteGoatChargesById(id);

                return RedirectToAction("GoatCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region GoatDaily

        // GET: Breeding/GoatDailyProfits
        public ActionResult GoatDailyProfits()
        {
            return View(_breedingService.GetGoatDailyProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/GoatDailyProfitCreate
        public ActionResult GoatDailyProfitCreate()
        {
            return View();
        }
        // POST: Breeding/GoatDailyProfitCreate
        [HttpPost]
        public ActionResult GoatDailyProfitCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(ConvertToDailyModel(collection));

                _breedingService.AddNewGoatDailyProfits(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(400);
                return RedirectToAction("GoatDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/GoatDailyProfitEdit/1
        public ActionResult GoatDailyProfitEdit(int id)
        {
            return View(_breedingService.GetGoatDailyProfitById(id));
        }

        // POST: Breeding/GoatDailyProfitEdit/1
        [HttpPost]
        public ActionResult GoatDailyProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetGoatDailyProfitById(id));

                _breedingService.AddNewGoatDailyProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("GoatDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/GoatDailyProfitDelete/1
        public ActionResult GoatDailyProfitDelete(int id)
        {
            return View(_breedingService.GetGoatDailyProfitById(id));
        }

        // POST: Breeding/GoatDailyProfitDelete/1
        [HttpPost]

        public ActionResult GoatDailyProfitDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteGoatDailyProfitById(id);

                return RedirectToAction("GoatDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region GoatRetiring

        // GET: Breeding/GoatProfits
        public ActionResult GoatProfits()
        {
            return View(_breedingService.GetGoatProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/GoatProfitEdit/1
        public ActionResult GoatProfitEdit(int id)
        {

            return View(_breedingService.GetGoatProfitById(id));
        }

        // POST: Breeding/GoatProfitEdit/1
        [HttpPost]
        public ActionResult GoatProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetGoatProfitById(id));

                _breedingService.AddNewGoatProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("GoatProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region GoatReminding

        // GET: Breeding/GoatRemindings
        public ActionResult GoatRemindings()
        {
            return View(_breedingService.GetGoatRemindings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/GoatRemindingCreate
        public ActionResult GoatRemindingCreate()
        {
            return View();
        }
        // POST: Breeding/GoatRemindingCreate
        [HttpPost]
        public ActionResult GoatRemindingCreate(FormCollection collection)
        {
            try
            {
                _breedingService.AddNewGoatReminding(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("GoatRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/GoatRemindingEdit/1
        public ActionResult GoatRemindingEdit(int id)
        {
            return View(_breedingService.GetGoatRemindingById(id));
        }

        // POST: Breeding/GoatRemindingEdit/1
        [HttpPost]
        public ActionResult GoatRemindingEdit(int id, FormCollection collection)
        {
            try
            {
                _breedingService.AddNewGoatRemindingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("GoatRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/GoatRemindingDelete/1
        public ActionResult GoatRemindingDelete(int id)
        {
            return View(_breedingService.GetGoatRemindingById(id));
        }

        // POST: Breeding/GoatRemindingDelete/1
        [HttpPost]

        public ActionResult GoatRemindingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteGoatRemindingById(id);

                return RedirectToAction("GoatRemindings");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}