using System;
using System.Net.Http;
using System.Web.Http;
using Domain.Entities.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Farmer.Controllers
{
    public class BaseApiController : ApiController
    {
        #region Declarations
        private ApplicationUserManager _userManager;
        #endregion

        #region Properties
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
      
        public FarmerUser ApplicationUser
        {

            get
            {
                try
                {
                    return UserManager.FindById(User.Identity.GetUserId<int>());
                }
                catch (Exception)
                {             
                    //ignor
                }

                return null;
            }
        }
        
        #endregion

        #region Ctors
        public BaseApiController()
        {
        }

        public BaseApiController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }
        #endregion

     

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager = null;
            }
            base.Dispose(disposing);
        }
    }
}