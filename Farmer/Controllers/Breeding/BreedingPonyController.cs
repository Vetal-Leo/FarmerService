using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Breeding
{

    public partial class BreedingController
    {

        #region PonyYoung

        // GET: Breeding/PonyYoung
        public ActionResult PonyYoung()
        {
            return View(_breedingService.GetPonyYoungs(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/PonyYoungCreate
        public ActionResult PonyYoungCreate()
        {
            return View(FillYoungDropDownList("Pony"));
        }

        // POST: Breeding/PonyYoungCreate
        [HttpPost]
        public ActionResult PonyYoungCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToYoungModel(collection, "Pony"));
                _breedingService.AddNewPonyYoung(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("PonyYoung");
            }
            catch
            {
                return View(FillYoungDropDownList("Pony"));
            }
        }

        // GET: Breeding/PonyYoungEdit/1
        public ActionResult PonyYoungEdit(int id)
        {
            return View(_breedingService.GetPonyYoungById(id));
        }

        // POST: Breeding/PonyYoungEdit/1
        [HttpPost]
        public ActionResult PonyYoungEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetPonyYoungById(id));

                _breedingService.AddNewPonyYoungById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("PonyYoung");
            }
            catch
            {
                return View(FillYoungDropDownList("Pony"));
            }
        }

        // GET: Breeding/PonyYoungDelete/1
        public ActionResult PonyYoungDelete(int id)
        {
            return View(_breedingService.GetPonyYoungById(id));
        }

        // POST: Breeding/PonyYoungDelete/1
        [HttpPost]
        public ActionResult PonyYoungDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeletePonyYoungById(id);
                Thread.Sleep(300);
                return RedirectToAction("PonyYoung");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region PonyComing

        // GET: Breeding/PonyComing
        public ActionResult PonyComing()
        {
            return View(_breedingService.GetPonyComings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/PonyComingCreate
        public ActionResult PonyComingCreate()
        {
            return View(FillDropDownList("Pony"));
        }


        // POST: Breeding/PonyComingCreate
        [HttpPost]
        public ActionResult PonyComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToAnimalsModel(collection, "Pony"));
                _breedingService.AddNewPonyComing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("PonyComing");
            }
            catch
            {
                return View(FillDropDownList("Pony"));
            }
        }

        // GET: Breeding/PonyComingEdit/1
        public ActionResult PonyComingEdit(int id)
        {
            return View(_breedingService.GetPonyComingById(id));
        }

        // POST: Breeding/PonyComingEdit/1
        [HttpPost]
        public ActionResult PonyComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetPonyComingById(id));

                _breedingService.AddNewPonyComingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("PonyComing");
            }
            catch
            {
                return View(FillDropDownList("Pony"));
            }
        }

        // GET: Breeding/PonyComingDelete/1
        public ActionResult PonyComingDelete(int id)
        {
            return View(_breedingService.GetPonyComingById(id));
        }

        // POST: Breeding/PonyComingDelete/1
        [HttpPost]
        public ActionResult PonyComingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeletePonyComingById(id);
                Thread.Sleep(300);
                return RedirectToAction("PonyComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region PonyCharges

        // GET: Breeding/PonyCharges
        public ActionResult PonyCharges()
        {
            return View(_breedingService.GetPonyCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/PonyChargesCreate
        public ActionResult PonyChargesCreate()
        {
            return View();
        }
        // POST: Breeding/PonyChargesCreate
        [HttpPost]
        public ActionResult PonyChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _breedingService.AddNewPonyCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("PonyCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/PonyChargesEdit/1
        public ActionResult PonyChargesEdit(int id)
        {
            return View(_breedingService.GetPonyChargesById(id));
        }

        // POST: Breeding/PonyChargesEdit/1
        [HttpPost]
        public ActionResult PonyChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetPonyChargesById(id));

                _breedingService.AddNewPonyChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("PonyCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/PonyChargesDelete/1
        public ActionResult PonyChargesDelete(int id)
        {
            return View(_breedingService.GetPonyChargesById(id));
        }

        // POST: Breeding/PonyChargesDelete/1
        [HttpPost]

        public ActionResult PonyChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeletePonyChargesById(id);

                return RedirectToAction("PonyCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region PonyDaily

        // GET: Breeding/PonyDailyProfits
        public ActionResult PonyDailyProfits()
        {
            return View(_breedingService.GetPonyDailyProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/PonyDailyProfitCreate
        public ActionResult PonyDailyProfitCreate()
        {
            return View();
        }
        // POST: Breeding/PonyDailyProfitCreate
        [HttpPost]
        public ActionResult PonyDailyProfitCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(ConvertToDailyModel(collection));

                _breedingService.AddNewPonyDailyProfits(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(400);
                return RedirectToAction("PonyDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/PonyDailyProfitEdit/1
        public ActionResult PonyDailyProfitEdit(int id)
        {
            return View(_breedingService.GetPonyDailyProfitById(id));
        }

        // POST: Breeding/PonyDailyProfitEdit/1
        [HttpPost]
        public ActionResult PonyDailyProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetPonyDailyProfitById(id));

                _breedingService.AddNewPonyDailyProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("PonyDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/PonyDailyProfitDelete/1
        public ActionResult PonyDailyProfitDelete(int id)
        {
            return View(_breedingService.GetPonyDailyProfitById(id));
        }

        // POST: Breeding/PonyDailyProfitDelete/1
        [HttpPost]

        public ActionResult PonyDailyProfitDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeletePonyDailyProfitById(id);

                return RedirectToAction("PonyDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region PonyRetiring

        // GET: Breeding/PonyProfits
        public ActionResult PonyProfits()
        {
            return View(_breedingService.GetPonyProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/PonyProfitEdit/1
        public ActionResult PonyProfitEdit(int id)
        {

            return View(_breedingService.GetPonyProfitById(id));
        }

        // POST: Breeding/PonyProfitEdit/1
        [HttpPost]
        public ActionResult PonyProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetPonyProfitById(id));

                _breedingService.AddNewPonyProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("PonyProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region PonyReminding

        // GET: Breeding/PonyRemindings
        public ActionResult PonyRemindings()
        {
            return View(_breedingService.GetPonyRemindings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/PonyRemindingCreate
        public ActionResult PonyRemindingCreate()
        {
            return View();
        }
        // POST: Breeding/PonyRemindingCreate
        [HttpPost]
        public ActionResult PonyRemindingCreate(FormCollection collection)
        {
            try
            {
                _breedingService.AddNewPonyReminding(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("PonyRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/PonyRemindingEdit/1
        public ActionResult PonyRemindingEdit(int id)
        {
            return View(_breedingService.GetPonyRemindingById(id));
        }

        // POST: Breeding/PonyRemindingEdit/1
        [HttpPost]
        public ActionResult PonyRemindingEdit(int id, FormCollection collection)
        {
            try
            {
                _breedingService.AddNewPonyRemindingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("PonyRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/PonyRemindingDelete/1
        public ActionResult PonyRemindingDelete(int id)
        {
            return View(_breedingService.GetPonyRemindingById(id));
        }

        // POST: Breeding/PonyRemindingDelete/1
        [HttpPost]

        public ActionResult PonyRemindingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeletePonyRemindingById(id);

                return RedirectToAction("PonyRemindings");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}