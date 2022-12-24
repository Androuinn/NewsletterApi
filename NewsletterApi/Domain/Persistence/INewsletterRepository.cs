using NewsletterApi.Domain.Models;

namespace NewsletterApi.Domain.Persistence
{
    public interface INewsletterRepository
    {
        Task<IEnumerable<Subscriber>> GetAllSubscribersAsync();
        Task AddSubscriberAsync(Subscriber subscriber);
        Task DeleteSubscriberAsync(int subscriberId);
        Task DeleteSubscriberAsync(string email);
    }
}
