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

        [HttpGet("allusers")]
        // GET: HomeController
        public async Task<ActionResult> GetAll()
        {
            var users = await _services.FetchAllAsync();
            //var response = new Response<string>
            //{
            //    Success = true,
            //    Message = null,
            //    Data = users
            //};
            if(users.Any())
            {
               return Ok(users);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: HomeController/Create
        [HttpPost("create")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserCreationRequest request)
        { 
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
                return BadRequest("Please recheck your request and resubmit.");
            }
            //catch(DbException e)
            //{
            //    ex = e;
            //    return StatusCode(500, "An error occurred related to storage. Please try again after some time or contact suppot.");
            //}
            //catch (Exception e)
            //{
            //    ex = e;
            //    return StatusCode(500, "An error occurred at the server. Please try again after some time or contact suppot.");
            //}
            //finally
            //{
            //    if(ex != null)
            //    {
            //        System.Diagnostics.Debug.WriteLine($"ex: {ex.InnerException}");
            //    }
            //} 
        }

        [HttpDelete("{username}")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete([FromRoute] string username)
        {            
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
    }
}
