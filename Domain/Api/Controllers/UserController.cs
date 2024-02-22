using Application.Requests;
using Application.Responses;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserServices _services;

        public UserController(UserServices services)
        {
            _services = services;
        }

        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost("create")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserCreationRequest request)
        {
            //try
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
            try
            {
                var isUserCreated = await _services.CreateAsync(request.UserName, request.ProviderName);
                var message = "";
                if (isUserCreated)
                {
                    message = "User Created Successfully";
                }
                else
                {
                    message = "User Creation Failed";
                }
                var response = new Response<string>
                {
                    Success = isUserCreated,
                    Message = message,
                    Data = null
                };
                return Ok(response);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("-----------Exceptions in UserController's Create Method----------");
                System.Diagnostics.Debug.WriteLine(ex);
                System.Diagnostics.Debug.WriteLine("-------------------------------------------------------------------");
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
