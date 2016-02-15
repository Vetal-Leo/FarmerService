using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Breeding
{

    public partial class BreedingController
    {

        #region BorzoidogComing

        // GET: Breeding/BorzoidogComing
        public ActionResult BorzoidogComing()
        {
            return View(_breedingService.GetBorzoidogComings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/BorzoidogComingCreate
        public ActionResult BorzoidogComingCreate()
        {
            return View(FillDropDownList("Borzoidog"));
        }


        // POST: Breeding/BorzoidogComingCreate
        [HttpPost]
        public ActionResult BorzoidogComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToAnimalsModel(collection, "Borzoidog"));
                _breedingService.AddNewBorzoidogComing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("BorzoidogComing");
            }
            catch
            {
                return View(FillDropDownList("Borzoidog"));
            }
        }

        // GET: Breeding/BorzoidogComingEdit/1
        public ActionResult BorzoidogComingEdit(int id)
        {
            return View(_breedingService.GetBorzoidogComingById(id));
        }

        // POST: Breeding/BorzoidogComingEdit/1
        [HttpPost]
        public ActionResult BorzoidogComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetBorzoidogComingById(id));

                _breedingService.AddNewBorzoidogComingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("BorzoidogComing");
            }
            catch
            {
                return View(FillDropDownList("Borzoidog"));
            }
        }

        // GET: Breeding/BorzoidogComingDelete/1
        public ActionResult BorzoidogComingDelete(int id)
        {
            return View(_breedingService.GetBorzoidogComingById(id));
        }

        // POST: Breeding/BorzoidogComingDelete/1
        [HttpPost]
        public ActionResult BorzoidogComingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteBorzoidogComingById(id);
                Thread.Sleep(300);
                return RedirectToAction("BorzoidogComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region BorzoidogCharges

        // GET: Breeding/BorzoidogCharges
        public ActionResult BorzoidogCharges()
        {
            return View(_breedingService.GetBorzoidogCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/BorzoidogChargesCreate
        public ActionResult BorzoidogChargesCreate()
        {
            return View();
        }
        // POST: Breeding/BorzoidogChargesCreate
        [HttpPost]
        public ActionResult BorzoidogChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _breedingService.AddNewBorzoidogCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("BorzoidogCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/BorzoidogChargesEdit/1
        public ActionResult BorzoidogChargesEdit(int id)
        {
            return View(_breedingService.GetBorzoidogChargesById(id));
        }

        // POST: Breeding/BorzoidogChargesEdit/1
        [HttpPost]
        public ActionResult BorzoidogChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetBorzoidogChargesById(id));

                _breedingService.AddNewBorzoidogChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("BorzoidogCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/BorzoidogChargesDelete/1
        public ActionResult BorzoidogChargesDelete(int id)
        {
            return View(_breedingService.GetBorzoidogChargesById(id));
        }

        // POST: Breeding/BorzoidogChargesDelete/1
        [HttpPost]

        public ActionResult BorzoidogChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteBorzoidogChargesById(id);

                return RedirectToAction("BorzoidogCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region BorzoidogRetiring

        // GET: Breeding/BorzoidogProfits
        public ActionResult BorzoidogProfits()
        {
            return View(_breedingService.GetBorzoidogProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/BorzoidogProfitEdit/1
        public ActionResult BorzoidogProfitEdit(int id)
        {

            return View(_breedingService.GetBorzoidogProfitById(id));
        }

        // POST: Breeding/BorzoidogProfitEdit/1
        [HttpPost]
        public ActionResult BorzoidogProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetBorzoidogProfitById(id));

                _breedingService.AddNewBorzoidogProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("BorzoidogProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region BorzoidogReminding

        // GET: Breeding/BorzoidogRemindings
        public ActionResult BorzoidogRemindings()
        {
            return View(_breedingService.GetBorzoidogRemindings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/BorzoidogRemindingCreate
        public ActionResult BorzoidogRemindingCreate()
        {
            return View();
        }
        // POST: Breeding/BorzoidogRemindingCreate
        [HttpPost]
        public ActionResult BorzoidogRemindingCreate(FormCollection collection)
        {
            try
            {
                _breedingService.AddNewBorzoidogReminding(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("BorzoidogRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/BorzoidogRemindingEdit/1
        public ActionResult BorzoidogRemindingEdit(int id)
        {
            return View(_breedingService.GetBorzoidogRemindingById(id));
        }

        // POST: Breeding/BorzoidogRemindingEdit/1
        [HttpPost]
        public ActionResult BorzoidogRemindingEdit(int id, FormCollection collection)
        {
            try
            {
                _breedingService.AddNewBorzoidogRemindingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("BorzoidogRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/BorzoidogRemindingDelete/1
        public ActionResult BorzoidogRemindingDelete(int id)
        {
            return View(_breedingService.GetBorzoidogRemindingById(id));
        }

        // POST: Breeding/BorzoidogRemindingDelete/1
        [HttpPost]

        public ActionResult BorzoidogRemindingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteBorzoidogRemindingById(id);

                return RedirectToAction("BorzoidogRemindings");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}