using Microsoft.EntityFrameworkCore;
using PublicRequestsAPI.Domain.DbModel;
using PublicRequestsAPI.Domain.Interfaces;
using PublicRequestsAPI.Infrastructure.Database;

namespace PublicRequestsAPI.Infrastructure.Implementations
{
    public class RequestRepository : IRequestRepository
    {
        private readonly RequestsDbContext _context;

        public RequestRepository(RequestsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Request>> GetAllAsync()
        {
            return await _context.Requests.ToListAsync();
        }

        public async Task<Request?> GetByIdAsync(int id)
        {
            return await _context.Requests.FindAsync(id);
        }

        public async Task<Request> AddAsync(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<Request> UpdateAsync(Request request)
        {
            _context.Requests.Update(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task DeleteAsync(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request != null)
            {
                _context.Requests.Remove(request);
                await _context.SaveChangesAsync();
            }
        }
    }
}