using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Http;
using Domain.Context;
using Infrastructure.Repository.Breeding;
using Servises.Breeding;
using Servises.Interfaces;

namespace Farmer.Controllers.Breeding
{
    [Authorize]
    public class BreedingApiController : BaseApiController
    {
        private readonly IBreedingService _breedingService;
        private readonly IBreedingService _beeService;
        private readonly IBreedingService _fishService;
        private readonly DatabaseContext _context = new DatabaseContext();

        public BreedingApiController()
        {
            _breedingService = new BreedingService(new BreedingComingsRepository(_context));
            _beeService = new BreedingService(new BeeComingsRepository(_context));
            _fishService = new BreedingService(new FishComingsRepository(_context));
        }


        [HttpGet]
        public List<string> GetCamelNames()
        {
            try
            {
                return _breedingService.GetCamelNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetGoatNames()
        {
            try
            {
                return _breedingService.GetGoatNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetHorseNames()
        {
            try
            {
                return _breedingService.GetHorseNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetPonyNames()
        {
            try
            {
                return _breedingService.GetPonyNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetRabbitSkinNames()
        {
            try
            {
                return _breedingService.GetRabbitSkinNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetRabbitMeatNames()
        {
            try
            {
                return _breedingService.GetRabbitMeatNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetSheepNames()
        {
            try
            {
                return _breedingService.GetSheepNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetHenMeatNames()
        {
            try
            {
                return _breedingService.GetHenMeatNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetHenEggNames()
        {
            try
            {
                return _breedingService.GetHenEggNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetGooseNames()
        {
            try
            {
                return _breedingService.GetGooseNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetQuailNames()
        {
            try
            {
                return _breedingService.GetQuailNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetBeeNames()
        {
            try
            {
                return _beeService.GetBeeNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }


        [HttpGet]
        public List<string> GetTeplovyeFishNames()
        {
            try
            {
                return _fishService.GetTeplovyeFishNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetСoldwaterFishNames()
        {
            try
            {
                return _fishService.GetСoldwaterFishNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetSwineNames()
        {
            try
            {
                return _breedingService.GetSwineNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetCattlemeatNames()
        {
            try
            {
                return _breedingService.GetCattlemeatNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }


        [HttpGet]
        public List<string> GetCattlemilkNames()
        {
            try
            {
                return _breedingService.GetCattlemilkNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetCattlemixedNames()
        {
            try
            {
                return _breedingService.GetCattlemixedNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }


        [HttpGet]
        public List<string> GetPinscherdogNames()
        {
            try
            {
                return _breedingService.GetPinscherdogNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetHoundsdogNames()
        {
            try
            {
                return _breedingService.GetHoundsdogNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetСopsdogNames()
        {
            try
            {
                return _breedingService.GetСopsdogNamesById(ApplicationUser.Id);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        [HttpGet]
        public List<string> GetBorzoidogNames()
        {
            try
            {
                return _breedingService.GetBorzoidogNamesById(ApplicationUser.Id);
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
                _breedingService.Dispose();
                _beeService.Dispose();
                _fishService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
