using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Breeding
{

    public partial class BreedingController
    {

        #region СoldwaterFishComing

        // GET: Breeding/СoldwaterFishComing
        public ActionResult СoldwaterFishComing()
        {
            return View(_breedingService.GetСoldwaterFishComings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/СoldwaterFishComingCreate
        public ActionResult СoldwaterFishComingCreate()
        {
            return View(FillDropDownListForFish("СoldwaterFish"));
        }


        // POST: Breeding/СoldwaterFishComingCreate
        [HttpPost]
        public ActionResult СoldwaterFishComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFishes(collection);
                if (!ModelState.IsValid) return View(ConvertToFishesModel(collection, "СoldwaterFish"));
                _breedingService.AddNewСoldwaterFishComing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("СoldwaterFishComing");
            }
            catch
            {
                return View(FillDropDownListForFish("СoldwaterFish"));
            }
        }

        // GET: Breeding/СoldwaterFishComingEdit/1
        public ActionResult СoldwaterFishComingEdit(int id)
        {
            return View(_breedingService.GetСoldwaterFishComingById(id));
        }

        // POST: Breeding/СoldwaterFishComingEdit/1
        [HttpPost]
        public ActionResult СoldwaterFishComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFishes(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetСoldwaterFishComingById(id));

                _breedingService.AddNewСoldwaterFishComingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("СoldwaterFishComing");
            }
            catch
            {
                return View(FillDropDownListForFish("СoldwaterFish"));
            }
        }

        // GET: Breeding/СoldwaterFishComingDelete/1
        public ActionResult СoldwaterFishComingDelete(int id)
        {
            return View(_breedingService.GetСoldwaterFishComingById(id));
        }

        // POST: Breeding/СoldwaterFishComingDelete/1
        [HttpPost]
        public ActionResult СoldwaterFishComingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteСoldwaterFishComingById(id);
                Thread.Sleep(300);
                return RedirectToAction("СoldwaterFishComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region СoldwaterFishCharges

        // GET: Breeding/СoldwaterFishCharges
        public ActionResult СoldwaterFishCharges()
        {
            return View(_breedingService.GetСoldwaterFishCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/СoldwaterFishChargesCreate
        public ActionResult СoldwaterFishChargesCreate()
        {
            return View();
        }
        // POST: Breeding/СoldwaterFishChargesCreate
        [HttpPost]
        public ActionResult СoldwaterFishChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _breedingService.AddNewСoldwaterFishCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("СoldwaterFishCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/СoldwaterFishChargesEdit/1
        public ActionResult СoldwaterFishChargesEdit(int id)
        {
            return View(_breedingService.GetСoldwaterFishChargesById(id));
        }

        // POST: Breeding/СoldwaterFishChargesEdit/1
        [HttpPost]
        public ActionResult СoldwaterFishChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetСoldwaterFishChargesById(id));

                _breedingService.AddNewСoldwaterFishChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("СoldwaterFishCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/СoldwaterFishChargesDelete/1
        public ActionResult СoldwaterFishChargesDelete(int id)
        {
            return View(_breedingService.GetСoldwaterFishChargesById(id));
        }

        // POST: Breeding/СoldwaterFishChargesDelete/1
        [HttpPost]

        public ActionResult СoldwaterFishChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteСoldwaterFishChargesById(id);

                return RedirectToAction("СoldwaterFishCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region СoldwaterFishRetiring

        // GET: Breeding/СoldwaterFishProfits
        public ActionResult СoldwaterFishProfits()
        {
            return View(_breedingService.GetСoldwaterFishProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/СoldwaterFishProfitEdit/1
        public ActionResult СoldwaterFishProfitEdit(int id)
        {

            return View(_breedingService.GetСoldwaterFishProfitById(id));
        }

        // POST: Breeding/СoldwaterFishProfitEdit/1
        [HttpPost]
        public ActionResult СoldwaterFishProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetСoldwaterFishProfitById(id));

                _breedingService.AddNewСoldwaterFishProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("СoldwaterFishProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region СoldwaterFishReminding

        // GET: Breeding/СoldwaterFishRemindings
        public ActionResult СoldwaterFishRemindings()
        {
            return View(_breedingService.GetСoldwaterFishRemindings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/СoldwaterFishRemindingCreate
        public ActionResult СoldwaterFishRemindingCreate()
        {
            return View();
        }
        // POST: Breeding/СoldwaterFishRemindingCreate
        [HttpPost]
        public ActionResult СoldwaterFishRemindingCreate(FormCollection collection)
        {
            try
            {
                _breedingService.AddNewСoldwaterFishReminding(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("СoldwaterFishRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/СoldwaterFishRemindingEdit/1
        public ActionResult СoldwaterFishRemindingEdit(int id)
        {
            return View(_breedingService.GetСoldwaterFishRemindingById(id));
        }

        // POST: Breeding/СoldwaterFishRemindingEdit/1
        [HttpPost]
        public ActionResult СoldwaterFishRemindingEdit(int id, FormCollection collection)
        {
            try
            {
                _breedingService.AddNewСoldwaterFishRemindingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("СoldwaterFishRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/СoldwaterFishRemindingDelete/1
        public ActionResult СoldwaterFishRemindingDelete(int id)
        {
            return View(_breedingService.GetСoldwaterFishRemindingById(id));
        }

        // POST: Breeding/СoldwaterFishRemindingDelete/1
        [HttpPost]

        public ActionResult СoldwaterFishRemindingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteСoldwaterFishRemindingById(id);

                return RedirectToAction("СoldwaterFishRemindings");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}