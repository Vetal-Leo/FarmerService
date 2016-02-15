using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Breeding
{

    public partial class BreedingController
    {

        #region SwineYoung

        // GET: Breeding/SwineYoung
        public ActionResult SwineYoung()
        {
            return View(_breedingService.GetSwineYoungs(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/SwineYoungCreate
        public ActionResult SwineYoungCreate()
        {
            return View(FillYoungDropDownList("Swine"));
        }

        // POST: Breeding/SwineYoungCreate
        [HttpPost]
        public ActionResult SwineYoungCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToYoungModel(collection, "Swine"));
                _breedingService.AddNewSwineYoung(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("SwineYoung");
            }
            catch
            {
                return View(FillYoungDropDownList("Swine"));
            }
        }

        // GET: Breeding/SwineYoungEdit/1
        public ActionResult SwineYoungEdit(int id)
        {
            return View(_breedingService.GetSwineYoungById(id));
        }

        // POST: Breeding/SwineYoungEdit/1
        [HttpPost]
        public ActionResult SwineYoungEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetSwineYoungById(id));

                _breedingService.AddNewSwineYoungById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("SwineYoung");
            }
            catch
            {
                return View(FillYoungDropDownList("Swine"));
            }
        }

        // GET: Breeding/SwineYoungDelete/1
        public ActionResult SwineYoungDelete(int id)
        {
            return View(_breedingService.GetSwineYoungById(id));
        }

        // POST: Breeding/SwineYoungDelete/1
        [HttpPost]
        public ActionResult SwineYoungDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteSwineYoungById(id);
                Thread.Sleep(300);
                return RedirectToAction("SwineYoung");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region SwineComing

        // GET: Breeding/SwineComing
        public ActionResult SwineComing()
        {
            return View(_breedingService.GetSwineComings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/SwineComingCreate
        public ActionResult SwineComingCreate()
        {
            return View(FillDropDownList("Swine"));
        }


        // POST: Breeding/SwineComingCreate
        [HttpPost]
        public ActionResult SwineComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToAnimalsModel(collection, "Swine"));
                _breedingService.AddNewSwineComing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("SwineComing");
            }
            catch
            {
                return View(FillDropDownList("Swine"));
            }
        }

        // GET: Breeding/SwineComingEdit/1
        public ActionResult SwineComingEdit(int id)
        {
            return View(_breedingService.GetSwineComingById(id));
        }

        // POST: Breeding/SwineComingEdit/1
        [HttpPost]
        public ActionResult SwineComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetSwineComingById(id));

                _breedingService.AddNewSwineComingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("SwineComing");
            }
            catch
            {
                return View(FillDropDownList("Swine"));
            }
        }

        // GET: Breeding/SwineComingDelete/1
        public ActionResult SwineComingDelete(int id)
        {
            return View(_breedingService.GetSwineComingById(id));
        }

        // POST: Breeding/SwineComingDelete/1
        [HttpPost]
        public ActionResult SwineComingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteSwineComingById(id);
                Thread.Sleep(300);
                return RedirectToAction("SwineComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region SwineCharges

        // GET: Breeding/SwineCharges
        public ActionResult SwineCharges()
        {
            return View(_breedingService.GetSwineCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/SwineChargesCreate
        public ActionResult SwineChargesCreate()
        {
            return View();
        }
        // POST: Breeding/SwineChargesCreate
        [HttpPost]
        public ActionResult SwineChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _breedingService.AddNewSwineCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("SwineCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/SwineChargesEdit/1
        public ActionResult SwineChargesEdit(int id)
        {
            return View(_breedingService.GetSwineChargesById(id));
        }

        // POST: Breeding/SwineChargesEdit/1
        [HttpPost]
        public ActionResult SwineChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetSwineChargesById(id));

                _breedingService.AddNewSwineChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("SwineCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/SwineChargesDelete/1
        public ActionResult SwineChargesDelete(int id)
        {
            return View(_breedingService.GetSwineChargesById(id));
        }

        // POST: Breeding/SwineChargesDelete/1
        [HttpPost]

        public ActionResult SwineChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteSwineChargesById(id);

                return RedirectToAction("SwineCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region SwineRetiring

        // GET: Breeding/SwineProfits
        public ActionResult SwineProfits()
        {
            return View(_breedingService.GetSwineProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/SwineProfitEdit/1
        public ActionResult SwineProfitEdit(int id)
        {

            return View(_breedingService.GetSwineProfitById(id));
        }

        // POST: Breeding/SwineProfitEdit/1
        [HttpPost]
        public ActionResult SwineProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetSwineProfitById(id));

                _breedingService.AddNewSwineProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("SwineProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region SwineReminding

        // GET: Breeding/SwineRemindings
        public ActionResult SwineRemindings()
        {
            return View(_breedingService.GetSwineRemindings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/SwineRemindingCreate
        public ActionResult SwineRemindingCreate()
        {
            return View();
        }
        // POST: Breeding/SwineRemindingCreate
        [HttpPost]
        public ActionResult SwineRemindingCreate(FormCollection collection)
        {
            try
            {
                _breedingService.AddNewSwineReminding(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("SwineRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/SwineRemindingEdit/1
        public ActionResult SwineRemindingEdit(int id)
        {
            return View(_breedingService.GetSwineRemindingById(id));
        }

        // POST: Breeding/SwineRemindingEdit/1
        [HttpPost]
        public ActionResult SwineRemindingEdit(int id, FormCollection collection)
        {
            try
            {
                _breedingService.AddNewSwineRemindingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("SwineRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/SwineRemindingDelete/1
        public ActionResult SwineRemindingDelete(int id)
        {
            return View(_breedingService.GetSwineRemindingById(id));
        }

        // POST: Breeding/SwineRemindingDelete/1
        [HttpPost]

        public ActionResult SwineRemindingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteSwineRemindingById(id);

                return RedirectToAction("SwineRemindings");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}