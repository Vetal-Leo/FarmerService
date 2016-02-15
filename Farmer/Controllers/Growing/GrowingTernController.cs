using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Growing
{

    public partial class GrowingController
    {


        #region TernComing

        // GET: Growing/TernComing
        public ActionResult TernComing()
        {
            return View(_growingFruitService.GetTernComings(User.Identity.GetUserId<int>()));
        }


        // GET: Growing/TernComingCreate
        public ActionResult TernComingCreate()
        {
            return View(FillFruitDropDownList("Tern"));
        }



        // POST: Growing/TernComingCreate
        [HttpPost]
        public ActionResult TernComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFruitCrops(collection);
                if (!ModelState.IsValid) return View(ConvertToFruitModel(collection, "Tern"));

                _growingFruitService.AddNewTern(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("TernComing");
            }
            catch
            {
                return View(FillFruitDropDownList("Tern"));
            }
        }


        // GET: Growing/TernComingEdit/1
        public ActionResult TernComingEdit(int id)
        {
            return View(_growingFruitService.GetTernComingById(id));
        }

        // POST: Growing/TernComingEdit/1
        [HttpPost]
        public ActionResult TernComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFruitCrops(collection);
                if (!ModelState.IsValid) return View(_growingFruitService.GetTernComingById(id));

                _growingFruitService.AddNewTernById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("TernComing");
            }
            catch
            {
                return View(FillFruitDropDownList("Tern"));
            }

        }


        // GET: Growing/TernComingDelete/1
        public ActionResult TernComingDelete(int id)
        {
            return View(_growingFruitService.GetTernComingById(id));
        }

        // POST: Growing/TernComingDelete/1
        [HttpPost]
        public ActionResult TernComingDelete(int id, FormCollection collection)
        {
            try
            {
                _growingFruitService.DeleteTernById(id);
                Thread.Sleep(300);
                DeleteEmptyDocumentsFromServer();
                return RedirectToAction("TernComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region TernCharges

        // GET: Growing/TernCharges
        public ActionResult TernCharges()
        {
            return View(_growingFruitService.GetTernCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/TernChargesCreate
        public ActionResult TernChargesCreate()
        {
            return View();
        }
        // POST: Growing/TernChargesCreate
        [HttpPost]
        public ActionResult TernChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _growingFruitService.AddNewTernCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("TernCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/TernChargesEdit/1
        public ActionResult TernChargesEdit(int id)
        {
            return View(_growingFruitService.GetTernChargesById(id));
        }

        // POST: Growing/TernChargesEdit/1
        [HttpPost]
        public ActionResult TernChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_growingFruitService.GetTernChargesById(id));

                _growingFruitService.AddNewTernChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("TernCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/TernChargesDelete/1
        public ActionResult TernChargesDelete(int id)
        {
            return View(_growingFruitService.GetTernChargesById(id));
        }

        // POST: Growing/TernChargesDelete/1
        [HttpPost]

        public ActionResult TernChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _growingFruitService.DeleteTernChargesById(id);

                return RedirectToAction("TernCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion




        #region TernRetiring

        // GET: Growing/TernProfits
        public ActionResult TernProfits()
        {
            return View(_growingFruitService.GetTernProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/TernProfitEdit/1
        public ActionResult TernProfitEdit(int id)
        {
            return View(_growingFruitService.GetTernProfitById(id));
        }

        // POST: Growing/TernProfitEdit/1
        [HttpPost]
        public ActionResult TernProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_growingFruitService.GetTernProfitById(id));

                _growingFruitService.AddNewTernProfitById(id, collection);

                return RedirectToAction("TernProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion

     
    }

}
