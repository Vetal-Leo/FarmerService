using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Breeding
{

    public partial class BreedingController
    {


        #region RabbitMeatComing

        // GET: Breeding/RabbitMeatComing
        public ActionResult RabbitMeatComing()
        {
            return View(_breedingService.GetRabbitMeatComings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/RabbitMeatComingCreate
        public ActionResult RabbitMeatComingCreate()
        {
            return View(FillDropDownList("RabbitMeat"));
        }


        // POST: Breeding/RabbitMeatComingCreate
        [HttpPost]
        public ActionResult RabbitMeatComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(ConvertToAnimalsModel(collection, "RabbitMeat"));
                _breedingService.AddNewRabbitMeatComing(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("RabbitMeatComing");
            }
            catch
            {
                return View(FillDropDownList("RabbitMeat"));
            }
        }

        // GET: Breeding/RabbitMeatComingEdit/1
        public ActionResult RabbitMeatComingEdit(int id)
        {
            return View(_breedingService.GetRabbitMeatComingById(id));
        }

        // POST: Breeding/RabbitMeatComingEdit/1
        [HttpPost]
        public ActionResult RabbitMeatComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForAnimals(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetRabbitMeatComingById(id));

                _breedingService.AddNewRabbitMeatComingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("RabbitMeatComing");
            }
            catch
            {
                return View(FillDropDownList("RabbitMeat"));
            }
        }

        // GET: Breeding/RabbitMeatComingDelete/1
        public ActionResult RabbitMeatComingDelete(int id)
        {
            return View(_breedingService.GetRabbitMeatComingById(id));
        }

        // POST: Breeding/RabbitMeatComingDelete/1
        [HttpPost]
        public ActionResult RabbitMeatComingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteRabbitSkinComingById(id);
                Thread.Sleep(300);
                return RedirectToAction("RabbitMeatComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region RabbitMeatCharges

        // GET: Breeding/RabbitMeatCharges
        public ActionResult RabbitMeatCharges()
        {
            return View(_breedingService.GetRabbitMeatCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/RabbitMeatChargesCreate
        public ActionResult RabbitMeatChargesCreate()
        {
            return View();
        }
        // POST: Breeding/RabbitMeatChargesCreate
        [HttpPost]
        public ActionResult RabbitMeatChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _breedingService.AddNewRabbitMeatCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("RabbitMeatCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/RabbitMeatChargesEdit/1
        public ActionResult RabbitMeatChargesEdit(int id)
        {
            return View(_breedingService.GetRabbitMeatChargesById(id));
        }

        // POST: Breeding/RabbitMeatChargesEdit/1
        [HttpPost]
        public ActionResult RabbitMeatChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetRabbitMeatChargesById(id));

                _breedingService.AddNewRabbitMeatChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("RabbitMeatCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/RabbitMeatChargesDelete/1
        public ActionResult RabbitMeatChargesDelete(int id)
        {
            return View(_breedingService.GetRabbitMeatChargesById(id));
        }

        // POST: Breeding/RabbitMeatChargesDelete/1
        [HttpPost]

        public ActionResult RabbitMeatChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteRabbitMeatChargesById(id);

                return RedirectToAction("RabbitMeatCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region RabbitMeatRetiring

        // GET: Breeding/RabbitMeatProfits
        public ActionResult RabbitMeatProfits()
        {
            return View(_breedingService.GetRabbitMeatProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/RabbitMeatProfitEdit/1
        public ActionResult RabbitMeatProfitEdit(int id)
        {

            return View(_breedingService.GetRabbitMeatProfitById(id));
        }

        // POST: Breeding/RabbitMeatProfitEdit/1
        [HttpPost]
        public ActionResult RabbitMeatProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_breedingService.GetRabbitMeatProfitById(id));

                _breedingService.AddNewRabbitMeatProfitById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("RabbitMeatProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region RabbitMeatReminding

        // GET: Breeding/RabbitMeatRemindings
        public ActionResult RabbitMeatRemindings()
        {
            return View(_breedingService.GetRabbitMeatRemindings(User.Identity.GetUserId<int>()));
        }

        // GET: Breeding/RabbitMeatRemindingCreate
        public ActionResult RabbitMeatRemindingCreate()
        {
            return View();
        }
        // POST: Breeding/RabbitMeatRemindingCreate
        [HttpPost]
        public ActionResult RabbitMeatRemindingCreate(FormCollection collection)
        {
            try
            {
                _breedingService.AddNewRabbitMeatReminding(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("RabbitMeatRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/RabbitMeatRemindingEdit/1
        public ActionResult RabbitMeatRemindingEdit(int id)
        {
            return View(_breedingService.GetRabbitMeatRemindingById(id));
        }

        // POST: Breeding/RabbitMeatRemindingEdit/1
        [HttpPost]
        public ActionResult RabbitMeatRemindingEdit(int id, FormCollection collection)
        {
            try
            {
                _breedingService.AddNewRabbitMeatRemindingById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("RabbitMeatRemindings");
            }
            catch
            {
                return View();
            }
        }

        // GET: Breeding/RabbitMeatRemindingDelete/1
        public ActionResult RabbitMeatRemindingDelete(int id)
        {
            return View(_breedingService.GetRabbitMeatRemindingById(id));
        }

        // POST: Breeding/RabbitMeatRemindingDelete/1
        [HttpPost]

        public ActionResult RabbitMeatRemindingDelete(int id, FormCollection collection)
        {
            try
            {
                _breedingService.DeleteRabbitMeatRemindingById(id);

                return RedirectToAction("RabbitMeatRemindings");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}