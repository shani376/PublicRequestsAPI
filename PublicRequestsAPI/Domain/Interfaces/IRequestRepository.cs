using PublicRequestsAPI.Domain.DbModel;

namespace PublicRequestsAPI.Domain.Interfaces
{
    public interface IRequestRepository
    {
        Task<IEnumerable<Request>> GetAllAsync();
        Task<Request?> GetByIdAsync(int id);
        Task<Request> AddAsync(Request request);
        Task<Request> UpdateAsync(Request request);
        Task DeleteAsync(int id);
    }
}