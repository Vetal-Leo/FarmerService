using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Breeding
{

    public partial class BreedingController
    {

        #region PinscherdogComing

        // GET: Breeding/PinscherdogComing
        public ActionResult PinscherdogComing()
        {
            return View(_breedingService.GetPinscherdogComings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/PinscherdogComingCreate
        public ActionResult PinscherdogComingCreate()
        {
            return View(FillDropDownList("Pinscherdog"));
        }


        // POST: Breeding/PinscherdogComingCreate
        [HttpPost]
        public ActionResult PinscherdogComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToAnimalsModel(collection, "Pinscherdog"));
                _breedingService.AddNewPinscherdogComing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("PinscherdogComing");
            }
            catch
            {
                return View(FillDropDownList("Pinscherdog"));
            }
        }

        // GET: Breeding/PinscherdogComingEdit/1
        public ActionResult PinscherdogComingEdit(int id)
        {
            return View(_breedingService.GetPinscherdogComingById(id));
        }

        // POST: Breeding/PinscherdogComingEdit/1
        [HttpPost]
        public ActionResult PinscherdogComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetPinscherdogComingById(id));

                _breedingService.AddNewPinscherdogComingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("PinscherdogComing");
            }
            catch
            {
                return View(FillDropDownList("Pinscherdog"));
            }
        }

        // GET: Breeding/PinscherdogComingDelete/1
        public ActionResult PinscherdogComingDelete(int id)
        {
            return View(_breedingService.GetPinscherdogComingById(id));
        }

        // POST: Breeding/PinscherdogComingDelete/1
        [HttpPost]
        public ActionResult PinscherdogComingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeletePinscherdogComingById(id);
                Thread.Sleep(300);
                return RedirectToAction("PinscherdogComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region PinscherdogCharges

        // GET: Breeding/PinscherdogCharges
        public ActionResult PinscherdogCharges()
        {
            return View(_breedingService.GetPinscherdogCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/PinscherdogChargesCreate
        public ActionResult PinscherdogChargesCreate()
        {
            return View();
        }
        // POST: Breeding/PinscherdogChargesCreate
        [HttpPost]
        public ActionResult PinscherdogChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _breedingService.AddNewPinscherdogCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("PinscherdogCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/PinscherdogChargesEdit/1
        public ActionResult PinscherdogChargesEdit(int id)
        {
            return View(_breedingService.GetPinscherdogChargesById(id));
        }

        // POST: Breeding/PinscherdogChargesEdit/1
        [HttpPost]
        public ActionResult PinscherdogChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetPinscherdogChargesById(id));

                _breedingService.AddNewPinscherdogChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("PinscherdogCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/PinscherdogChargesDelete/1
        public ActionResult PinscherdogChargesDelete(int id)
        {
            return View(_breedingService.GetPinscherdogChargesById(id));
        }

        // POST: Breeding/PinscherdogChargesDelete/1
        [HttpPost]

        public ActionResult PinscherdogChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeletePinscherdogChargesById(id);

                return RedirectToAction("PinscherdogCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region PinscherdogRetiring

        // GET: Breeding/PinscherdogProfits
        public ActionResult PinscherdogProfits()
        {
            return View(_breedingService.GetPinscherdogProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/PinscherdogProfitEdit/1
        public ActionResult PinscherdogProfitEdit(int id)
        {

            return View(_breedingService.GetPinscherdogProfitById(id));
        }

        // POST: Breeding/PinscherdogProfitEdit/1
        [HttpPost]
        public ActionResult PinscherdogProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetPinscherdogProfitById(id));

                _breedingService.AddNewPinscherdogProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("PinscherdogProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region PinscherdogReminding

        // GET: Breeding/PinscherdogRemindings
        public ActionResult PinscherdogRemindings()
        {
            return View(_breedingService.GetPinscherdogRemindings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/PinscherdogRemindingCreate
        public ActionResult PinscherdogRemindingCreate()
        {
            return View();
        }
        // POST: Breeding/PinscherdogRemindingCreate
        [HttpPost]
        public ActionResult PinscherdogRemindingCreate(FormCollection collection)
        {
            try
            {
                _breedingService.AddNewPinscherdogReminding(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("PinscherdogRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/PinscherdogRemindingEdit/1
        public ActionResult PinscherdogRemindingEdit(int id)
        {
            return View(_breedingService.GetPinscherdogRemindingById(id));
        }

        // POST: Breeding/PinscherdogRemindingEdit/1
        [HttpPost]
        public ActionResult PinscherdogRemindingEdit(int id, FormCollection collection)
        {
            try
            {
                _breedingService.AddNewPinscherdogRemindingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("PinscherdogRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/PinscherdogRemindingDelete/1
        public ActionResult PinscherdogRemindingDelete(int id)
        {
            return View(_breedingService.GetPinscherdogRemindingById(id));
        }

        // POST: Breeding/PinscherdogRemindingDelete/1
        [HttpPost]

        public ActionResult PinscherdogRemindingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeletePinscherdogRemindingById(id);

                return RedirectToAction("PinscherdogRemindings");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}