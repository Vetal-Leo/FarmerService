using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Breeding
{

    public partial class BreedingController
    {

        #region HoundsdogComing

        // GET: Breeding/HoundsdogComing
        public ActionResult HoundsdogComing()
        {
            return View(_breedingService.GetHoundsdogComings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/HoundsdogComingCreate
        public ActionResult HoundsdogComingCreate()
        {
            return View(FillDropDownList("Houndsdog"));
        }


        // POST: Breeding/HoundsdogComingCreate
        [HttpPost]
        public ActionResult HoundsdogComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToAnimalsModel(collection, "Houndsdog"));
                _breedingService.AddNewHoundsdogComing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("HoundsdogComing");
            }
            catch
            {
                return View(FillDropDownList("Houndsdog"));
            }
        }

        // GET: Breeding/HoundsdogComingEdit/1
        public ActionResult HoundsdogComingEdit(int id)
        {
            return View(_breedingService.GetHoundsdogComingById(id));
        }

        // POST: Breeding/HoundsdogComingEdit/1
        [HttpPost]
        public ActionResult HoundsdogComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetHoundsdogComingById(id));

                _breedingService.AddNewHoundsdogComingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("HoundsdogComing");
            }
            catch
            {
                return View(FillDropDownList("Houndsdog"));
            }
        }

        // GET: Breeding/HoundsdogComingDelete/1
        public ActionResult HoundsdogComingDelete(int id)
        {
            return View(_breedingService.GetHoundsdogComingById(id));
        }

        // POST: Breeding/HoundsdogComingDelete/1
        [HttpPost]
        public ActionResult HoundsdogComingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteHoundsdogComingById(id);
                Thread.Sleep(300);
                return RedirectToAction("HoundsdogComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region HoundsdogCharges

        // GET: Breeding/HoundsdogCharges
        public ActionResult HoundsdogCharges()
        {
            return View(_breedingService.GetHoundsdogCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/HoundsdogChargesCreate
        public ActionResult HoundsdogChargesCreate()
        {
            return View();
        }
        // POST: Breeding/HoundsdogChargesCreate
        [HttpPost]
        public ActionResult HoundsdogChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _breedingService.AddNewHoundsdogCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("HoundsdogCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/HoundsdogChargesEdit/1
        public ActionResult HoundsdogChargesEdit(int id)
        {
            return View(_breedingService.GetHoundsdogChargesById(id));
        }

        // POST: Breeding/HoundsdogChargesEdit/1
        [HttpPost]
        public ActionResult HoundsdogChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetHoundsdogChargesById(id));

                _breedingService.AddNewHoundsdogChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("HoundsdogCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/HoundsdogChargesDelete/1
        public ActionResult HoundsdogChargesDelete(int id)
        {
            return View(_breedingService.GetHoundsdogChargesById(id));
        }

        // POST: Breeding/HoundsdogChargesDelete/1
        [HttpPost]

        public ActionResult HoundsdogChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteHoundsdogChargesById(id);

                return RedirectToAction("HoundsdogCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region HoundsdogRetiring

        // GET: Breeding/HoundsdogProfits
        public ActionResult HoundsdogProfits()
        {
            return View(_breedingService.GetHoundsdogProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/HoundsdogProfitEdit/1
        public ActionResult HoundsdogProfitEdit(int id)
        {

            return View(_breedingService.GetHoundsdogProfitById(id));
        }

        // POST: Breeding/HoundsdogProfitEdit/1
        [HttpPost]
        public ActionResult HoundsdogProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetHoundsdogProfitById(id));

                _breedingService.AddNewHoundsdogProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("HoundsdogProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region HoundsdogReminding

        // GET: Breeding/HoundsdogRemindings
        public ActionResult HoundsdogRemindings()
        {
            return View(_breedingService.GetHoundsdogRemindings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/HoundsdogRemindingCreate
        public ActionResult HoundsdogRemindingCreate()
        {
            return View();
        }
        // POST: Breeding/HoundsdogRemindingCreate
        [HttpPost]
        public ActionResult HoundsdogRemindingCreate(FormCollection collection)
        {
            try
            {
                _breedingService.AddNewHoundsdogReminding(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("HoundsdogRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/HoundsdogRemindingEdit/1
        public ActionResult HoundsdogRemindingEdit(int id)
        {
            return View(_breedingService.GetHoundsdogRemindingById(id));
        }

        // POST: Breeding/HoundsdogRemindingEdit/1
        [HttpPost]
        public ActionResult HoundsdogRemindingEdit(int id, FormCollection collection)
        {
            try
            {
                _breedingService.AddNewHoundsdogRemindingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("HoundsdogRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/HoundsdogRemindingDelete/1
        public ActionResult HoundsdogRemindingDelete(int id)
        {
            return View(_breedingService.GetHoundsdogRemindingById(id));
        }

        // POST: Breeding/HoundsdogRemindingDelete/1
        [HttpPost]

        public ActionResult HoundsdogRemindingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteHoundsdogRemindingById(id);

                return RedirectToAction("HoundsdogRemindings");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}