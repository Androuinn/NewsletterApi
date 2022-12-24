using Microsoft.EntityFrameworkCore;
using NewsletterApi.Domain.Context;
using NewsletterApi.Domain.Models;

namespace NewsletterApi.Domain.Persistence
{
    public class NewsletterRepository : INewsletterRepository
    {
        private readonly NewsletterDbContext _dbContext;

        public NewsletterRepository(NewsletterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Subscriber>> GetAllSubscribersAsync()
        {
            return await _dbContext.Subscribers.ToListAsync();
        }

        public async Task AddSubscriberAsync(Subscriber subscriber)
        {
            await _dbContext.Subscribers.AddAsync(subscriber);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteSubscriberAsync(int subscriberId)
        {
            var subscriber = await _dbContext.Subscribers.FindAsync(subscriberId);
            if (subscriber != null)
            {
                _dbContext.Subscribers.Remove(subscriber);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteSubscriberAsync(string email)
        {
            var subscriber = await _dbContext.Subscribers.FirstOrDefaultAsync(s => s.Email == email);
            if (subscriber != null)
            {
                _dbContext.Subscribers.Remove(subscriber);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
