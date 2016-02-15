using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Breeding
{

    public partial class BreedingController
    {


        #region RabbitSkinComing

        // GET: Breeding/RabbitSkinComing
        public ActionResult RabbitSkinComing()
        {
            return View(_breedingService.GetRabbitSkinComings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/RabbitSkinComingCreate
        public ActionResult RabbitSkinComingCreate()
        {
            return View(FillDropDownList("RabbitSkin"));
        }


        // POST: Breeding/RabbitSkinComingCreate
        [HttpPost]
        public ActionResult RabbitSkinComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToAnimalsModel(collection, "RabbitSkin"));
                _breedingService.AddNewRabbitSkinComing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("RabbitSkinComing");
            }
            catch
            {
                return View(FillDropDownList("RabbitSkin"));
            }
        }

        // GET: Breeding/RabbitSkinComingEdit/1
        public ActionResult RabbitSkinComingEdit(int id)
        {
            return View(_breedingService.GetRabbitSkinComingById(id));
        }

        // POST: Breeding/RabbitSkinComingEdit/1
        [HttpPost]
        public ActionResult RabbitSkinComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetRabbitSkinComingById(id));

                _breedingService.AddNewRabbitSkinComingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("RabbitSkinComing");
            }
            catch
            {
                return View(FillDropDownList("RabbitSkin"));
            }
        }

        // GET: Breeding/RabbitSkinComingDelete/1
        public ActionResult RabbitSkinComingDelete(int id)
        {
            return View(_breedingService.GetRabbitSkinComingById(id));
        }

        // POST: Breeding/RabbitSkinComingDelete/1
        [HttpPost]
        public ActionResult RabbitSkinComingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteRabbitSkinComingById(id);
                Thread.Sleep(300);
                return RedirectToAction("RabbitSkinComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region RabbitSkinCharges

        // GET: Breeding/RabbitSkinCharges
        public ActionResult RabbitSkinCharges()
        {
            return View(_breedingService.GetRabbitSkinCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/RabbitSkinChargesCreate
        public ActionResult RabbitSkinChargesCreate()
        {
            return View();
        }
        // POST: Breeding/RabbitSkinChargesCreate
        [HttpPost]
        public ActionResult RabbitSkinChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _breedingService.AddNewRabbitSkinCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("RabbitSkinCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/RabbitSkinChargesEdit/1
        public ActionResult RabbitSkinChargesEdit(int id)
        {
            return View(_breedingService.GetRabbitSkinChargesById(id));
        }

        // POST: Breeding/RabbitSkinChargesEdit/1
        [HttpPost]
        public ActionResult RabbitSkinChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetRabbitSkinChargesById(id));

                _breedingService.AddNewRabbitSkinChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("RabbitSkinCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/RabbitSkinChargesDelete/1
        public ActionResult RabbitSkinChargesDelete(int id)
        {
            return View(_breedingService.GetRabbitSkinChargesById(id));
        }

        // POST: Breeding/RabbitSkinChargesDelete/1
        [HttpPost]

        public ActionResult RabbitSkinChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteRabbitSkinChargesById(id);

                return RedirectToAction("RabbitSkinCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region RabbitSkinRetiring

        // GET: Breeding/RabbitSkinProfits
        public ActionResult RabbitSkinProfits()
        {
            return View(_breedingService.GetRabbitSkinProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/RabbitSkinProfitEdit/1
        public ActionResult RabbitSkinProfitEdit(int id)
        {

            return View(_breedingService.GetRabbitSkinProfitById(id));
        }

        // POST: Breeding/RabbitSkinProfitEdit/1
        [HttpPost]
        public ActionResult RabbitSkinProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetRabbitSkinProfitById(id));

                _breedingService.AddNewRabbitSkinProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("RabbitSkinProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region RabbitSkinReminding

        // GET: Breeding/RabbitSkinRemindings
        public ActionResult RabbitSkinRemindings()
        {
            return View(_breedingService.GetRabbitSkinRemindings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/RabbitSkinRemindingCreate
        public ActionResult RabbitSkinRemindingCreate()
        {
            return View();
        }
        // POST: Breeding/RabbitSkinRemindingCreate
        [HttpPost]
        public ActionResult RabbitSkinRemindingCreate(FormCollection collection)
        {
            try
            {
                _breedingService.AddNewRabbitSkinReminding(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("RabbitSkinRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/RabbitSkinRemindingEdit/1
        public ActionResult RabbitSkinRemindingEdit(int id)
        {
            return View(_breedingService.GetRabbitSkinRemindingById(id));
        }

        // POST: Breeding/RabbitSkinRemindingEdit/1
        [HttpPost]
        public ActionResult RabbitSkinRemindingEdit(int id, FormCollection collection)
        {
            try
            {
                _breedingService.AddNewRabbitSkinRemindingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("RabbitSkinRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/RabbitSkinRemindingDelete/1
        public ActionResult RabbitSkinRemindingDelete(int id)
        {
            return View(_breedingService.GetRabbitSkinRemindingById(id));
        }

        // POST: Breeding/RabbitSkinRemindingDelete/1
        [HttpPost]

        public ActionResult RabbitSkinRemindingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteRabbitSkinRemindingById(id);

                return RedirectToAction("RabbitSkinRemindings");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}