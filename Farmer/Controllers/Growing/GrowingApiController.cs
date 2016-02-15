using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Http;
using Domain.Context;
using Infrastructure.Repository.Growing;
using Servises.Growing;
using Servises.Interfaces;

namespace Farmer.Controllers.Growing
{
    [Authorize]
    public class GrowingApiController : BaseApiController
    {
        private readonly IGrowingService _growingFieldService;
        private readonly IGrowingService _growingFruitService;
      

        private readonly DatabaseContext _context = new DatabaseContext();

        public GrowingApiController()
        {
            _growingFieldService = new GrowingService(new GrowingFieldComingsRepository(_context));
            _growingFruitService = new GrowingService(new GrowingFruitComingsRepository(_context));
           
        }


        [HttpGet]
        public List<string> GetBreadCultureNames()
        {
            try
            {
                return _growingFieldService.GetBreadNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetLeguminousNames()
        {
            try
            {
                return _growingFieldService.GetLeguminousNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetTuberNames()
        {
            try
            {
                return _growingFieldService.GetTuberNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetSpicyNames()
        {
            try
            {
                return _growingFieldService.GetSpicyNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetMelonNames()
        {
            try
            {
                return _growingFieldService.GetMelonNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetOliveNames()
        {
            try
            {
                return _growingFieldService.GetOliveNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetSilageNames()
        {
            try
            {
                return _growingFieldService.GetSilageNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }


        [HttpGet]
        public List<string> GetFodderNames()
        {
            try
            {
                return _growingFieldService.GetFodderNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetForageNames()
        {
            try
            {
                return _growingFieldService.GetForageNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }


        [HttpGet]
        public List<string> GetBergamotNames()
        {
            try
            {
                return _growingFruitService.GetBergamotNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetKepelNames()
        {
            try
            {
                return _growingFruitService.GetKepelNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetFinikNames()
        {
            try
            {
                return _growingFruitService.GetFinikNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetCrataeguNames()
        {
            try
            {
                return _growingFruitService.GetCrataeguNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetTernNames()
        {
            try
            {
                return _growingFruitService.GetTernNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetStrawberryNames()
        {
            try
            {
                return _growingFruitService.GetStrawberryNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _growingFieldService.Dispose();
                _growingFruitService.Dispose();           
            }
            base.Dispose(disposing);
        }
    }
}
