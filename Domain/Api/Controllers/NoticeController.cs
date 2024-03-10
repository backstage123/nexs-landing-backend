using Application.Requests;
using Application.Responses;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/notice")]
    [ApiController]
    public class NoticeController : Controller
    {
        private readonly NoticeService _service;

        public NoticeController(NoticeService service)
        {
            _service = service;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost("create")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NoticeCreationRequest request)
        {
            Exception ex = null;
            try
            {
                var isNoticeCreated = await _service.CreateAsync(request.Title, request.AuthorName);
                var message = "";
                if (isNoticeCreated)
                {
                    message = "Notice Created Successfully.";
                }
                else
                {
                    message = "Notice Creation Failed.";
                }
                var response = new Response<string>
                {
                    Success = isNoticeCreated,
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
            catch(DbUpdateException e)
            {
                ex = e;
                return BadRequest("Please recheck your request. Hint: Check if the authorName exists. Else contact support.");
            }
        }

        [HttpGet("allusers")]
        // GET: HomeController
        public async Task<ActionResult> GetAll()
        {
            var users = await _service.FetchAllAsync();
            //var response = new Response<string>
            //{
            //    Success = true,
            //    Message = null,
            //    Data = users
            //};
            if (users.Any())
            {
                return Ok(users);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
