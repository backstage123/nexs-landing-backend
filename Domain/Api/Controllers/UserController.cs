using Application.Requests;
using Application.Responses;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

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

        //[HttpGet("/")]
        //// GET: HomeController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: HomeController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: HomeController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

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
            Exception ex = null;
            try
            {
                var isUserCreated = await _services.CreateAsync(request.UserName, request.ProviderName);
                var message = "";
                if (isUserCreated)
                {
                    message = "User Created Successfully.";
                }
                else
                {
                    message = "User Creation Failed.";
                }
                var response = new Response<string>
                {
                    Success = isUserCreated,
                    Message = message,
                    Data = null
                };
                return Ok(response);
            }
            catch (ArgumentException e)
            {
                ex = e;
                //System.Diagnostics.Debug.WriteLine("-----------Exceptions in UserController's Create Method----------");
                //System.Diagnostics.Debug.WriteLine(ex);
                //System.Diagnostics.Debug.WriteLine("-------------------------------------------------------------------");
                //var response = new Response<string>
                //{
                //    Success = false,
                //    Message = "Exception Occured! User Creation Failed.",
                //    Data = null
                //};
                return BadRequest("Please recheck your request and resubmit.");
                //return new BadRequestObjectResult(response);
            }
            catch(DbException e)
            {
                ex = e;
                return StatusCode(500, "An error occurred related to storage. Please try again after some time or contact suppot.");
            }
            catch (Exception e)
            {
                ex = e;
                return StatusCode(500, "An error occurred at the server. Please try again after some time or contact suppot.");
            }
            finally
            {
                if(ex != null)
                {
                    System.Diagnostics.Debug.WriteLine($"ex: {ex.InnerException}");
                }
            } 
        }

        // GET: HomeController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: HomeController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [HttpDelete("{username}")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete([FromRoute] string username)
        {
            try
            {
                //return RedirectToAction(nameof(Index));
                //return NoContent();
                var isUserDeleted = await _services.RemoveAsync(username);
                if (isUserDeleted)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
                
            }
            catch
            {
                //return View();
                return NotFound();
            }
        }
    }
}
