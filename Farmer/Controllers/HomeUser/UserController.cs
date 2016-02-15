using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Domain.Context;
using Domain.Entities.User;
using Infrastructure.Repository.Breeding;
using Infrastructure.Repository.Growing;
using Infrastructure.Repository.Users;
using Microsoft.AspNet.Identity;
using Servises.Interfaces;
using Servises.Users;

namespace Farmer.Controllers.HomeUser
{
    [System.Web.Http.Authorize]
    public class UserController : BaseApiController
    {
        private readonly IPhotoService _photoservice;
        private readonly IProfileService _profileservice;
        private readonly IUsersService _usersservice;
        private readonly IUsersService _sendservice;

        private readonly DatabaseContext _context = new DatabaseContext();
        public static HttpServerUtilityBase FarmerServer { get; set; }

        public UserController()
        {
            _photoservice = new PhotoService(new PhotoRepository(_context));
            _profileservice = new ProfileService(new ProfilesRepository(_context), new UsersRepository(_context));
            _sendservice = new UsersService(new UsersRepository(_context));
            _usersservice = new UsersService(new RemindingRepository(_context));

        }



        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public async Task SetEmptyPhotos(int id)
        {
            _context.Photos.Add(new Photo { Id = id, Avatar = "Empty.jpg", Growing = "Empty2.jpg", Breeding = "Empty2.jpg", Technique = "Empty2.jpg", Product = "Empty2.jpg" });
            _context.Profiles.Add(new Profile { Id = id });
            await _context.SaveChangesAsync();
        }

        [System.Web.Http.HttpPost]
        public async Task SetRemindState(bool remindState)
        {
            var user = _context.Users.Find(ApplicationUser.Id);
            user.Remind = remindState;
            await _context.SaveChangesAsync();
        }

        [System.Web.Http.HttpGet]
        public string[] GetUser()
        {
            var avatar = string.Empty; string name; string lastname; string patronymic; var age = "0"; bool remind;
            try
            {
                avatar = ApplicationUser.Photo.Avatar;
            }
            catch (NullReferenceException)
            {
            }
            try
            {
                name = ApplicationUser.Profile.Name;
            }
            catch (NullReferenceException)
            {
                name = string.Empty;
            }
            try
            {
                lastname = ApplicationUser.Profile.LastName;
            }
            catch (NullReferenceException)
            {
                lastname = string.Empty;
            }
            try
            {
                patronymic = ApplicationUser.Profile.Patronymic;
            }
            catch (NullReferenceException)
            {
                patronymic = string.Empty;
            }

            try
            {
                var birthday = ApplicationUser.Profile.Birthday;
                if (birthday.HasValue)
                {
                    if ((DateTime.Now.Month < birthday.Value.Month) || (DateTime.Now.Month == birthday.Value.Month && DateTime.Now.Day < birthday.Value.Day))
                        age = (DateTime.Now.Year - birthday.Value.Year - 1).ToString();
                    else age = (DateTime.Now.Year - birthday.Value.Year).ToString();
                }
            }
            catch (NullReferenceException)
            {
                age = "0";
            }
            try
            {
                remind = ApplicationUser.Remind;
            }
            catch (NullReferenceException)
            {
                remind = true;
            }

            return new[] { avatar, name, lastname, patronymic, age, remind.ToString() };
        }


        [System.Web.Http.HttpGet]
        public string[] GetPhotosAndData()
        {
            var avatar = string.Empty;
            var growing = string.Empty;
            var breeding = string.Empty;
            var technic = string.Empty;
            var product = string.Empty;
            string login;
            string name;
            string lastname;
            string patronymic;
            var birthday = string.Empty;
            string phone;
            try
            {
                avatar = ApplicationUser.Photo.Avatar;
            }
            catch (NullReferenceException)
            {
            }
            try
            {
                growing = ApplicationUser.Photo.Growing;
            }
            catch (NullReferenceException)
            {
            }
            try
            {
                breeding = ApplicationUser.Photo.Breeding;
            }
            catch (NullReferenceException)
            {
            }
            try
            {
                technic = ApplicationUser.Photo.Technique;
            }
            catch (NullReferenceException)
            {
            }
            try
            {
                product = ApplicationUser.Photo.Product;
            }
            catch (NullReferenceException)
            {
            }
            try
            {
                login = ApplicationUser.Email;
            }
            catch (NullReferenceException)
            {
                login = string.Empty;
            }
            try
            {
                name = ApplicationUser.Profile.Name;
            }
            catch (NullReferenceException)
            {
                name = string.Empty;
            }
            try
            {
                lastname = ApplicationUser.Profile.LastName;
            }
            catch (NullReferenceException)
            {
                lastname = string.Empty;
            }
            try
            {
                patronymic = ApplicationUser.Profile.Patronymic;
            }
            catch (NullReferenceException)
            {
                patronymic = string.Empty;
            }
            try
            {
                if (ApplicationUser.Profile.Birthday != null)
                    birthday = ApplicationUser.Profile.Birthday.Value.ToString("dd.MM.yyyy");
            }
            catch (NullReferenceException)
            {
                birthday = new DateTime(1, 1, 1).ToString("dd.MM.yyyy");
            }
            try
            {
                phone = ApplicationUser.PhoneNumber;
            }
            catch (NullReferenceException)
            {
                phone = string.Empty;
            }

            return new[] { avatar, growing, breeding, technic, product, login, name, lastname, patronymic, birthday, phone };
        }

        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> AddTempPhoto()
        {

            if (!Request.Content.IsMimeMultipartContent())
                return BadRequest();

            var provider = new MultipartMemoryStreamProvider();
            // путь к папке на сервере
            var root = HttpContext.Current.Server.MapPath("/StoreImages/Temp/");
            await Request.Content.ReadAsMultipartAsync(provider);
            foreach (var file in provider.Contents)
            {
                var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                filename = Path.GetFileName(filename);
                var fileArray = await file.ReadAsByteArrayAsync();
                try
                {
                    using (var fs = new FileStream(root + filename, FileMode.Create))
                    {
                        await fs.WriteAsync(fileArray, 0, fileArray.Length);
                    }
                }
                catch (Exception)
                {
                    //ignored;
                }
            }

            return Ok();
        }

        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> AddPhotoByServer(string article, string userfilename, int posX, int posY, int rateW, int rateH)
        {
            try
            {

                if (userfilename == null || rateW == 0 || rateH == 0) throw new ArgumentNullException("userfilename");

                //Create a new image from the specified location to 
                userfilename = Path.GetFileName(userfilename);
                var sourceFile = HttpContext.Current.Server.MapPath("/StoreImages/Temp/" + userfilename);
                var oImage = Image.FromFile(sourceFile);
                // Create a new bitmap with specified parameters
                var bmp = new Bitmap(rateW, rateH, oImage.PixelFormat);
                var g = Graphics.FromImage(bmp);
                g.DrawImage(oImage, new Rectangle(0, 0, rateW, rateH),
                new Rectangle(posX, posY, rateW, rateH), GraphicsUnit.Pixel);
                var frm = oImage.RawFormat;
                oImage.Dispose();
                //  Сохранение имени фото в базу.
                userfilename = Guid.NewGuid() + "_" + DateTime.Now.ToString("yyyyMMMMdd") + "_" + userfilename;
                var oldimage = _photoservice.SavePhotoNameInDataBase(article, ApplicationUser.Id, userfilename);
                await DeleteOldFileFromServerAsync(oldimage);
                var destFile = HttpContext.Current.Server.MapPath("/StoreImages/StoreImages/" + userfilename);
                // Save cropped image
                bmp.Save(destFile, frm);
                Thread.Sleep(300);

                return Ok();
            }
            catch
            {
                //ignored;
            }
            return null;
        }



        [System.Web.Http.HttpPost]
        [System.Web.Http.Authorize]
        public async Task<int> SaveName(string name, string lastname, string patronymic, string birthday, string phone)
        {
            return await _profileservice.SaveName(ApplicationUser.Id, name, lastname, patronymic, birthday, phone);
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Authorize]
        public async Task<bool> ChangeLogin(string password, string newlogin)
        {
            if (password == null) return false;
            var user = UserManager.Find(ApplicationUser.Email, password);
            if (user == null) return false;

            //Изменение Login и деактивация аккаунта.
            await _sendservice.UpdateUserEmail(ApplicationUser.Id, newlogin);
            var emailservice = new EmailService();
            var identy = new IdentityMessage { Destination = newlogin };
            var callbackUrl = @Url.Content("~/UserSimple/ConfirmLogin?id=1&newlogin=" + newlogin);
            identy.Subject = "Подтверждение изменения Login.";
            identy.Body = "<h2>Farmer.</h2>Благодарим Вас за выбор сервиса \"Farmer\".<br/>" +
                          "<h3>Ваш Логин : " + newlogin + "<br/>Ваш пароль : " + password +
                          "</h3>Для завершения изменения Вашего Login перейдите по ссылке: " +
                          " <a href=\"" + callbackUrl + "\">Завершить изменения Login</a>";
            await emailservice.SendAsync(identy);

            return true;
        }

        [System.Web.Http.HttpGet]
        public bool GetRemiding()
        {
            var remindersPresence = _usersservice.GetRemindings(ApplicationUser.Id);
            return remindersPresence.Count != 0;

        }


        private static async Task DeleteOldFileFromServerAsync(string oldimage)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(oldimage)) return;
                if (oldimage.Equals("Empty.jpg") || oldimage.Equals("Empty2.jpg")) return;
                var fullPath = UserSimpleController.FarmerServer.MapPath("/StoreImages/StoreImages/" + oldimage);
                File.Delete(fullPath);
                await ClierTempDirectoryAsync();
            }
            catch
            {
                //ignored;
            }
        }

        private static Task ClierTempDirectoryAsync()
        {
            try
            {
                var dir = UserSimpleController.FarmerServer.MapPath("/StoreImages/Temp/");
                if (dir == null) throw new ArgumentNullException("dir");
                var di = new DirectoryInfo(dir);
                foreach (var file in di.GetFiles()) file.Delete();
            }
            catch
            {
                //ignored
            }
            return null;
        }

        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> AddNewPdf()
        {
            if (!Request.Content.IsMimeMultipartContent())
                return BadRequest();

            var provider = new MultipartMemoryStreamProvider();
            // путь к папке на сервере
            var root = HttpContext.Current.Server.MapPath("~/Storefiles/");
            await Request.Content.ReadAsMultipartAsync(provider);
            foreach (var file in provider.Contents)
            {
                var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                var temp = filename.Substring(filename.Length - 4);
                if (!temp.Equals(".pdf")) continue;
                var fileArray = await file.ReadAsByteArrayAsync();
                try
                {
                    using (var fs = new FileStream(root + filename, FileMode.Create))
                    {
                        await fs.WriteAsync(fileArray, 0, fileArray.Length);
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
                return Ok();
            }

            return BadRequest();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _photoservice.Dispose();
                _profileservice.Dispose();
            }
            base.Dispose(disposing);
        }
    }



    public class UserSimpleController : Controller
    {
        private readonly IUsersService _usersservice;
        public static HttpServerUtilityBase FarmerServer { get; set; }
        private readonly DatabaseContext _context = new DatabaseContext();

        public UserSimpleController()
        {
            _usersservice = new UsersService(new GrowingFieldProfitsRepository(_context), new GrowingFruitProfitsRepository(_context),
                            new BreedingRemindingRepository(_context), new RemindingRepository(_context), new UsersRepository(_context));
        }

        // GET: UserSimple
        public ActionResult Index()
        {
            _usersservice.RemindingFill(User.Identity.GetUserId<int>());
            return User.IsInRole("Admin") ? View("Admin") : View();
        }

        // GET: UserSimple
        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Cabinet()
        {
            FarmerServer = Server;
            return View();
        }
        public ActionResult ChangeLogin()
        {
            return View();
        }

        public ActionResult ConfirmLogin(string newlogin)
        {
            //Активация аккаунта после изменения Login
            _usersservice.ActivateAccount(newlogin);
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult Reminding()
        {
            return View(_usersservice.GetRemindings(User.Identity.GetUserId<int>()));
        }


        public ActionResult Users()
        {
            return View(_usersservice.GetAllUsers(User.Identity.GetUserId<int>()));
        }

        // GET: UserSimple/UserEdit/1
        public ActionResult UserEdit(int id)
        {
            return View(_usersservice.GetUsersById(id));
        }

        // POST: UserSimple/UserEdit/1
        [System.Web.Mvc.HttpPost]
        public ActionResult UserEdit(int id, FormCollection collection)
        {
            try
            {            
                _usersservice.AddNewUsersById(id, collection);
                Thread.Sleep(300);
                return RedirectToAction("Users");
            }
            catch
            {
                return View(_usersservice.GetUsersById(id));
            }
        }

    }
}
