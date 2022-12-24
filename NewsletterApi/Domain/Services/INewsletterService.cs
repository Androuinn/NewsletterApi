using NewsletterApi.Domain.Models;

namespace NewsletterApi.Domain.Services
{
    public interface INewsletterService
    {
        Task<IEnumerable<Subscriber>> GetAllSubscribersAsync();
        Task AddSubscriberAsync(Subscriber subscriber);
        Task DeleteSubscriberAsync(int subscriberId);
        Task DeleteSubscriberAsync(string email);
        Task SendNewsletterAsync(string subject, string body);
    }

}
