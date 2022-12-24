using Microsoft.AspNetCore.Mvc;
using NewsletterApi.Domain.Models;
using NewsletterApi.Domain.Services;
using NewsletterApi.ViewModels;

namespace NewsletterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsletterController : ControllerBase
    {
        private readonly INewsletterService _newsletterService;

        public NewsletterController(INewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subscriber>>> GetAllSubscribersAsync()
        {
            var subscribers = await _newsletterService.GetAllSubscribersAsync();
            return Ok(subscribers);
        }

        [HttpPost]
        public async Task<ActionResult> AddSubscriberAsync(Subscriber subscriber)
        {
            await _newsletterService.AddSubscriberAsync(subscriber);
            return Ok();
        }


        [HttpDelete("{subscriberId}")]
        public async Task<ActionResult> Unsubscribe(int subscriberId)
        {
            await _newsletterService.DeleteSubscriberAsync(subscriberId);
            return Ok();
        }

        [HttpDelete("[action]/{email}")]
        public async Task<ActionResult> Unsubscribe(string email)
        {
            await _newsletterService.DeleteSubscriberAsync(email);
            return NoContent();
        }

        [HttpPost("send")]
        public async Task<ActionResult> SendNewsletterAsync(SendNewsletterRequest request)
        {
            await _newsletterService.SendNewsletterAsync(request.Subject, request.Body);
            return Ok();
        }
    }

}
