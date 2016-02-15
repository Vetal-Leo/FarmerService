using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Breeding
{

    public partial class BreedingController
    {

        #region СopsdogComing

        // GET: Breeding/СopsdogComing
        public ActionResult СopsdogComing()
        {
            return View(_breedingService.GetСopsdogComings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/СopsdogComingCreate
        public ActionResult СopsdogComingCreate()
        {
            return View(FillDropDownList("Сopsdog"));
        }


        // POST: Breeding/СopsdogComingCreate
        [HttpPost]
        public ActionResult СopsdogComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToAnimalsModel(collection, "Сopsdog"));
                _breedingService.AddNewСopsdogComing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("СopsdogComing");
            }
            catch
            {
                return View(FillDropDownList("Сopsdog"));
            }
        }

        // GET: Breeding/СopsdogComingEdit/1
        public ActionResult СopsdogComingEdit(int id)
        {
            return View(_breedingService.GetСopsdogComingById(id));
        }

        // POST: Breeding/СopsdogComingEdit/1
        [HttpPost]
        public ActionResult СopsdogComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetСopsdogComingById(id));

                _breedingService.AddNewСopsdogComingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("СopsdogComing");
            }
            catch
            {
                return View(FillDropDownList("Сopsdog"));
            }
        }

        // GET: Breeding/СopsdogComingDelete/1
        public ActionResult СopsdogComingDelete(int id)
        {
            return View(_breedingService.GetСopsdogComingById(id));
        }

        // POST: Breeding/СopsdogComingDelete/1
        [HttpPost]
        public ActionResult СopsdogComingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteHoundsdogComingById(id);
                Thread.Sleep(300);
                return RedirectToAction("СopsdogComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region СopsdogCharges

        // GET: Breeding/СopsdogCharges
        public ActionResult СopsdogCharges()
        {
            return View(_breedingService.GetСopsdogCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/СopsdogChargesCreate
        public ActionResult СopsdogChargesCreate()
        {
            return View();
        }
        // POST: Breeding/СopsdogChargesCreate
        [HttpPost]
        public ActionResult СopsdogChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _breedingService.AddNewСopsdogCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("СopsdogCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/СopsdogChargesEdit/1
        public ActionResult СopsdogChargesEdit(int id)
        {
            return View(_breedingService.GetСopsdogChargesById(id));
        }

        // POST: Breeding/СopsdogChargesEdit/1
        [HttpPost]
        public ActionResult СopsdogChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetСopsdogChargesById(id));

                _breedingService.AddNewСopsdogChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("СopsdogCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/СopsdogChargesDelete/1
        public ActionResult СopsdogChargesDelete(int id)
        {
            return View(_breedingService.GetСopsdogChargesById(id));
        }

        // POST: Breeding/СopsdogChargesDelete/1
        [HttpPost]

        public ActionResult СopsdogChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteСopsdogChargesById(id);

                return RedirectToAction("СopsdogCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region СopsdogRetiring

        // GET: Breeding/СopsdogProfits
        public ActionResult СopsdogProfits()
        {
            return View(_breedingService.GetСopsdogProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/СopsdogProfitEdit/1
        public ActionResult СopsdogProfitEdit(int id)
        {

            return View(_breedingService.GetСopsdogProfitById(id));
        }

        // POST: Breeding/СopsdogProfitEdit/1
        [HttpPost]
        public ActionResult СopsdogProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetСopsdogProfitById(id));

                _breedingService.AddNewСopsdogProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("СopsdogProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region СopsdogReminding

        // GET: Breeding/СopsdogRemindings
        public ActionResult СopsdogRemindings()
        {
            return View(_breedingService.GetСopsdogRemindings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/СopsdogRemindingCreate
        public ActionResult СopsdogRemindingCreate()
        {
            return View();
        }
        // POST: Breeding/СopsdogRemindingCreate
        [HttpPost]
        public ActionResult СopsdogRemindingCreate(FormCollection collection)
        {
            try
            {
                _breedingService.AddNewСopsdogReminding(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("СopsdogRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/СopsdogRemindingEdit/1
        public ActionResult СopsdogRemindingEdit(int id)
        {
            return View(_breedingService.GetСopsdogRemindingById(id));
        }

        // POST: Breeding/СopsdogRemindingEdit/1
        [HttpPost]
        public ActionResult СopsdogRemindingEdit(int id, FormCollection collection)
        {
            try
            {
                _breedingService.AddNewСopsdogRemindingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("СopsdogRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/СopsdogRemindingDelete/1
        public ActionResult СopsdogRemindingDelete(int id)
        {
            return View(_breedingService.GetСopsdogRemindingById(id));
        }

        // POST: Breeding/СopsdogRemindingDelete/1
        [HttpPost]

        public ActionResult СopsdogRemindingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteСopsdogRemindingById(id);

                return RedirectToAction("СopsdogRemindings");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}