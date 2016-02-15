using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Breeding
{

    public partial class BreedingController
    {

        #region TeplovyeFishComing

        // GET: Breeding/TeplovyeFishComing
        public ActionResult TeplovyeFishComing()
        {
            return View(_breedingService.GetTeplovyeFishComings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/TeplovyeFishComingCreate
        public ActionResult TeplovyeFishComingCreate()
        {
            return View(FillDropDownListForFish("TeplovyeFish"));
        }


        // POST: Breeding/TeplovyeFishComingCreate
        [HttpPost]
        public ActionResult TeplovyeFishComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFishes(collection);
                if (!ModelState.IsValid) return View(ConvertToFishesModel(collection, "TeplovyeFish"));
                _breedingService.AddNewTeplovyeFishComing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("TeplovyeFishComing");
            }
            catch
            {
                return View(FillDropDownListForFish("TeplovyeFish"));
            }
        }

        // GET: Breeding/TeplovyeFishComingEdit/1
        public ActionResult TeplovyeFishComingEdit(int id)
        {
            return View(_breedingService.GetTeplovyeFishComingById(id));
        }

        // POST: Breeding/TeplovyeFishComingEdit/1
        [HttpPost]
        public ActionResult TeplovyeFishComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFishes(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetTeplovyeFishComingById(id));

                _breedingService.AddNewTeplovyeFishComingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("TeplovyeFishComing");
            }
            catch
            {
                return View(FillDropDownListForFish("TeplovyeFish"));
            }
        }

        // GET: Breeding/TeplovyeFishComingDelete/1
        public ActionResult TeplovyeFishComingDelete(int id)
        {
            return View(_breedingService.GetTeplovyeFishComingById(id));
        }

        // POST: Breeding/TeplovyeFishComingDelete/1
        [HttpPost]
        public ActionResult TeplovyeFishComingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteTeplovyeFishComingById(id);
                Thread.Sleep(300);
                return RedirectToAction("TeplovyeFishComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region TeplovyeFishCharges

        // GET: Breeding/TeplovyeFishCharges
        public ActionResult TeplovyeFishCharges()
        {
            return View(_breedingService.GetTeplovyeFishCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/TeplovyeFishChargesCreate
        public ActionResult TeplovyeFishChargesCreate()
        {
            return View();
        }
        // POST: Breeding/TeplovyeFishChargesCreate
        [HttpPost]
        public ActionResult TeplovyeFishChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _breedingService.AddNewTeplovyeFishCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("TeplovyeFishCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/TeplovyeFishChargesEdit/1
        public ActionResult TeplovyeFishChargesEdit(int id)
        {
            return View(_breedingService.GetTeplovyeFishChargesById(id));
        }

        // POST: Breeding/TeplovyeFishChargesEdit/1
        [HttpPost]
        public ActionResult TeplovyeFishChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetTeplovyeFishChargesById(id));

                _breedingService.AddNewTeplovyeFishChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("TeplovyeFishCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/TeplovyeFishChargesDelete/1
        public ActionResult TeplovyeFishChargesDelete(int id)
        {
            return View(_breedingService.GetTeplovyeFishChargesById(id));
        }

        // POST: Breeding/TeplovyeFishChargesDelete/1
        [HttpPost]

        public ActionResult TeplovyeFishChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteTeplovyeFishChargesById(id);

                return RedirectToAction("TeplovyeFishCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region TeplovyeFishRetiring

        // GET: Breeding/TeplovyeFishProfits
        public ActionResult TeplovyeFishProfits()
        {
            return View(_breedingService.GetTeplovyeFishProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/TeplovyeFishProfitEdit/1
        public ActionResult TeplovyeFishProfitEdit(int id)
        {

            return View(_breedingService.GetTeplovyeFishProfitById(id));
        }

        // POST: Breeding/TeplovyeFishProfitEdit/1
        [HttpPost]
        public ActionResult TeplovyeFishProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetTeplovyeFishProfitById(id));

                _breedingService.AddNewTeplovyeFishProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("TeplovyeFishProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region TeplovyeFishReminding

        // GET: Breeding/TeplovyeFishRemindings
        public ActionResult TeplovyeFishRemindings()
        {
            return View(_breedingService.GetTeplovyeFishRemindings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/TeplovyeFishRemindingCreate
        public ActionResult TeplovyeFishRemindingCreate()
        {
            return View();
        }
        // POST: Breeding/TeplovyeFishRemindingCreate
        [HttpPost]
        public ActionResult TeplovyeFishRemindingCreate(FormCollection collection)
        {
            try
            {
                _breedingService.AddNewTeplovyeFishReminding(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("TeplovyeFishRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/TeplovyeFishRemindingEdit/1
        public ActionResult TeplovyeFishRemindingEdit(int id)
        {
            return View(_breedingService.GetTeplovyeFishRemindingById(id));
        }

        // POST: Breeding/TeplovyeFishRemindingEdit/1
        [HttpPost]
        public ActionResult TeplovyeFishRemindingEdit(int id, FormCollection collection)
        {
            try
            {
                _breedingService.AddNewTeplovyeFishRemindingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("TeplovyeFishRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/TeplovyeFishRemindingDelete/1
        public ActionResult TeplovyeFishRemindingDelete(int id)
        {
            return View(_breedingService.GetTeplovyeFishRemindingById(id));
        }

        // POST: Breeding/TeplovyeFishRemindingDelete/1
        [HttpPost]

        public ActionResult TeplovyeFishRemindingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteTeplovyeFishRemindingById(id);

                return RedirectToAction("TeplovyeFishRemindings");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}