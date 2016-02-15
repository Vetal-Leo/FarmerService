using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Farmer.Controllers.Growing
{

    public partial class GrowingController
    {


        #region CrataeguComing

        // GET: Growing/CrataeguComing
        public ActionResult CrataeguComing()
        {
            return View(_growingFruitService.GetCrataeguComings(User.Identity.GetUserId<int>()));
        }


        // GET: Growing/CrataeguComingCreate
        public ActionResult CrataeguComingCreate()
        {
            return View(FillFruitDropDownList("Crataegu"));
        }

       

        // POST: Growing/CrataeguComingCreate
        [HttpPost]
        public ActionResult CrataeguComingCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFruitCrops(collection);
                if (!ModelState.IsValid) return View(ConvertToFruitModel(collection, "Crataegu"));

                _growingFruitService.AddNewCrataegu(User.Identity.GetUserId<int>(), collection);

                return RedirectToAction("CrataeguComing");
            }
            catch
            {
                return View(FillFruitDropDownList("Crataegu"));
            }
        }


        // GET: Growing/CrataeguComingEdit/1
        public ActionResult CrataeguComingEdit(int id)
        {
            return View(_growingFruitService.GetCrataeguComingById(id));
        }

        // POST: Growing/CrataeguComingEdit/1
        [HttpPost]
        public ActionResult CrataeguComingEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForFruitCrops(collection);
                if (!ModelState.IsValid) return View(_growingFruitService.GetCrataeguComingById(id));

                _growingFruitService.AddNewCrataeguById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CrataeguComing");
            }
            catch
            {
                return View(FillFruitDropDownList("Crataegu"));
            }

        }


        // GET: Growing/CrataeguComingDelete/1
        public ActionResult CrataeguComingDelete(int id)
        {
            return View(_growingFruitService.GetCrataeguComingById(id));
        }

        // POST: Growing/CrataeguComingDelete/1
        [HttpPost]
        public ActionResult CrataeguComingDelete(int id, FormCollection collection)
        {
            try
            {     
                _growingFruitService.DeleteCrataeguById(id);
                Thread.Sleep(300);
                DeleteEmptyDocumentsFromServer();
                return RedirectToAction("CrataeguComing");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region CrataeguCharges

        // GET: Growing/CrataeguCharges
        public ActionResult CrataeguCharges()
        {
            return View(_growingFruitService.GetCrataeguCharges(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/CrataeguChargesCreate
        public ActionResult CrataeguChargesCreate()
        {
            return View();
        }
        // POST: Growing/CrataeguChargesCreate
        [HttpPost]
        public ActionResult CrataeguChargesCreate(FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(ConvertToChargesModel(collection));

                _growingFruitService.AddNewCrataeguCharges(User.Identity.GetUserId<int>(), collection);
                Thread.Sleep(300);
                return RedirectToAction("CrataeguCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/CrataeguChargesEdit/1
        public ActionResult CrataeguChargesEdit(int id)
        {
            return View(_growingFruitService.GetCrataeguChargesById(id));
        }

        // POST: Growing/CrataeguChargesEdit/1
        [HttpPost]
        public ActionResult CrataeguChargesEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForCharges(collection);
                if (!ModelState.IsValid) return View(_growingFruitService.GetCrataeguChargesById(id));

                _growingFruitService.AddNewCrataeguChargesById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("CrataeguCharges");
            }
            catch
            {
                return View();
            }
        }

        // GET: Growing/CrataeguChargesDelete/1
        public ActionResult CrataeguChargesDelete(int id)
        {
            return View(_growingFruitService.GetCrataeguChargesById(id));
        }

        // POST: Growing/CrataeguChargesDelete/1
        [HttpPost]

        public ActionResult CrataeguChargesDelete(int id, FormCollection collection)
        {
            try
            {
                _growingFruitService.DeleteCrataeguChargesById(id);

                return RedirectToAction("CrataeguCharges");
            }
            catch
            {
                return View();
            }
        }

        #endregion




        #region CrataeguRetiring

        // GET: Growing/CrataeguProfits
        public ActionResult CrataeguProfits()
        {
            return View(_growingFruitService.GetCrataeguProfits(User.Identity.GetUserId<int>()));
        }

        // GET: Growing/CrataeguProfitEdit/1
        public ActionResult CrataeguProfitEdit(int id)
        {
            return View(_growingFruitService.GetCrataeguProfitById(id));
        }

        // POST: Growing/CrataeguProfitEdit/1
        [HttpPost]
        public ActionResult CrataeguProfitEdit(int id, FormCollection collection)
        {
            try
            {
                collection = Compatibility(collection);
                ValidationForProfits(collection);
                if (!ModelState.IsValid) return View(_growingFruitService.GetCrataeguProfitById(id));

                _growingFruitService.AddNewCrataeguProfitById(id, collection);

                return RedirectToAction("CrataeguProfits");
            }
            catch
            {
                return View();
            }
        }

        #endregion


    }

}
