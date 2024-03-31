using Application.Requests;
using Application.Responses;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/notices")]
    [ApiController]
    public class NoticeController : Controller
    {
        private readonly NoticeService _noticeservice;

        public NoticeController(NoticeService noticeservice)
        {
            _noticeservice = noticeservice;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost()]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NoticeCreationRequest request)
        {
            Exception ex = null;
            try
            {
                var noticeId = await _noticeservice.CreateAsync(request.Title, request.Content, request.AuthorName, request.Publish);                
                return Created(new Uri($"/api/notices/{noticeId}", UriKind.Relative), noticeId);
            }
            catch (ArgumentNullException e)
            {
                ex = e;
                return BadRequest("One or more necessary field(s) contain(s) null value. Please recheck your request and resubmit.");
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

        [HttpGet()]
        // GET: HomeController
        public async Task<ActionResult> GetAll()
        {
            var notices = await _noticeservice.FindAllAsync();
            //var response = new Response<string>
            //{
            //    Success = true,
            //    Message = null,
            //    Data = users
            //};
            if (notices.Any())
            {
                return Ok(notices);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        // GET: HomeController
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var notice = await _noticeservice.FindNoticeAsync(id);
            if (notice != null)
            {
                return Ok(notice);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Put([FromRoute] int id, [FromBody] NoticeUpdateRequest request)
        {
            var isUpdated = await _noticeservice.ModifyAsync(id, request.Content, request.AuthorName, request.Publish);

            if (isUpdated)
            {
                return Ok("Successfully Updated!");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var isNoticeDeleted = await _noticeservice.RemoveAsync(id);

            if (isNoticeDeleted)
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
