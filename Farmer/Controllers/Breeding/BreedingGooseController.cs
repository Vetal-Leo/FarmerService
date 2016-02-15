using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Breeding
{

    public partial class BreedingController
    {


        #region GooseComing

        // GET: Breeding/GooseComing
        public ActionResult GooseComing()
        {
            return View(_breedingService.GetGooseComings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/GooseComingCreate
        public ActionResult GooseComingCreate()
        {
            return View(FillDropDownList("Goose"));
        }


        // POST: Breeding/GooseComingCreate
        [HttpPost]
        public ActionResult GooseComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToAnimalsModel(collection, "Goose"));
                _breedingService.AddNewGooseComing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("GooseComing");
            }
            catch
            {
                return View(FillDropDownList("Goose"));
            }
        }

        // GET: Breeding/GooseComingEdit/1
        public ActionResult GooseComingEdit(int id)
        {
            return View(_breedingService.GetGooseComingById(id));
        }

        // POST: Breeding/GooseComingEdit/1
        [HttpPost]
        public ActionResult GooseComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetGooseComingById(id));

                _breedingService.AddNewGooseComingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("GooseComing");
            }
            catch
            {
                return View(FillDropDownList("Goose"));
            }
        }

        // GET: Breeding/GooseComingDelete/1
        public ActionResult GooseComingDelete(int id)
        {
            return View(_breedingService.GetGooseComingById(id));
        }

        // POST: Breeding/GooseComingDelete/1
        [HttpPost]
        public ActionResult GooseComingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteGooseComingById(id);
                Thread.Sleep(300);
                return RedirectToAction("GooseComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region GooseCharges

        // GET: Breeding/GooseCharges
        public ActionResult GooseCharges()
        {
            return View(_breedingService.GetGooseCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/GooseChargesCreate
        public ActionResult GooseChargesCreate()
        {
            return View();
        }
        // POST: Breeding/GooseChargesCreate
        [HttpPost]
        public ActionResult GooseChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _breedingService.AddNewGooseCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("GooseCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/GooseChargesEdit/1
        public ActionResult GooseChargesEdit(int id)
        {
            return View(_breedingService.GetGooseChargesById(id));
        }

        // POST: Breeding/GooseChargesEdit/1
        [HttpPost]
        public ActionResult GooseChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetGooseChargesById(id));

                _breedingService.AddNewGooseChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("GooseCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/GooseChargesDelete/1
        public ActionResult GooseChargesDelete(int id)
        {
            return View(_breedingService.GetGooseChargesById(id));
        }

        // POST: Breeding/GooseChargesDelete/1
        [HttpPost]

        public ActionResult GooseChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteGooseChargesById(id);

                return RedirectToAction("GooseCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region GooseDaily

        // GET: Breeding/GooseDailyProfits
        public ActionResult GooseDailyProfits()
        {
            return View(_breedingService.GetGooseDailyProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/GooseDailyProfitCreate
        public ActionResult GooseDailyProfitCreate()
        {
            return View();
        }
        // POST: Breeding/GooseDailyProfitCreate
        [HttpPost]
        public ActionResult GooseDailyProfitCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(ConvertToDailyModel(collection));

                _breedingService.AddNewGooseDailyProfits(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(400);
                return RedirectToAction("GooseDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/GooseDailyProfitEdit/1
        public ActionResult GooseDailyProfitEdit(int id)
        {
            return View(_breedingService.GetGooseDailyProfitById(id));
        }

        // POST: Breeding/GooseDailyProfitEdit/1
        [HttpPost]
        public ActionResult GooseDailyProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForDaily(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetGooseDailyProfitById(id));

                _breedingService.AddNewGooseDailyProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("GooseDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/GooseDailyProfitDelete/1
        public ActionResult GooseDailyProfitDelete(int id)
        {
            return View(_breedingService.GetGooseDailyProfitById(id));
        }

        // POST: Breeding/GooseDailyProfitDelete/1
        [HttpPost]

        public ActionResult GooseDailyProfitDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteGooseDailyProfitById(id);

                return RedirectToAction("GooseDailyProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region GooseRetiring

        // GET: Breeding/GooseProfits
        public ActionResult GooseProfits()
        {
            return View(_breedingService.GetGooseProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/GooseProfitEdit/1
        public ActionResult GooseProfitEdit(int id)
        {

            return View(_breedingService.GetGooseProfitById(id));
        }

        // POST: Breeding/GooseProfitEdit/1
        [HttpPost]
        public ActionResult GooseProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetGooseProfitById(id));

                _breedingService.AddNewGooseProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("GooseProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region GooseReminding

        // GET: Breeding/GooseRemindings
        public ActionResult GooseRemindings()
        {
            return View(_breedingService.GetGooseRemindings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/GooseRemindingCreate
        public ActionResult GooseRemindingCreate()
        {
            return View();
        }
        // POST: Breeding/GooseRemindingCreate
        [HttpPost]
        public ActionResult GooseRemindingCreate(FormCollection collection)
        {
            try
            {
                _breedingService.AddNewGooseReminding(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("GooseRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/GooseRemindingEdit/1
        public ActionResult GooseRemindingEdit(int id)
        {
            return View(_breedingService.GetGooseRemindingById(id));
        }

        // POST: Breeding/GooseRemindingEdit/1
        [HttpPost]
        public ActionResult GooseRemindingEdit(int id, FormCollection collection)
        {
            try
            {
                _breedingService.AddNewGooseRemindingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("GooseRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/GooseRemindingDelete/1
        public ActionResult GooseRemindingDelete(int id)
        {
            return View(_breedingService.GetGooseRemindingById(id));
        }

        // POST: Breeding/GooseRemindingDelete/1
        [HttpPost]

        public ActionResult GooseRemindingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteGooseRemindingById(id);

                return RedirectToAction("GooseRemindings");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}