using NewsletterApi.Domain.Models;
using NewsletterApi.Domain.Persistence;
using NewsletterApi.Domain.Providers;

namespace NewsletterApi.Domain.Services
{
    public class NewsletterService : INewsletterService
    {
        private readonly INewsletterRepository _repository;
        private readonly IEmailSender _emailSender;

        public NewsletterService(INewsletterRepository repository, IEmailSender emailSender)
        {
            _repository = repository;
            _emailSender = emailSender;
        }

        public async Task<IEnumerable<Subscriber>> GetAllSubscribersAsync()
        {
            return await _repository.GetAllSubscribersAsync();
        }

        public async Task AddSubscriberAsync(Subscriber subscriber)
        {
            await _repository.AddSubscriberAsync(subscriber);
        }

        public async Task DeleteSubscriberAsync(int subscriberId)
        {
            await _repository.DeleteSubscriberAsync(subscriberId);
        }

        public async Task DeleteSubscriberAsync(string email)
        {
            await _repository.DeleteSubscriberAsync(email);
        }

        public async Task SendNewsletterAsync(string subject, string body)
        {
            var subscribers = await _repository.GetAllSubscribersAsync();
            foreach (var subscriber in subscribers)
            {
                await _emailSender.SendEmailAsync(subscriber.Email, subject, body);
            }
        }
    }
}
