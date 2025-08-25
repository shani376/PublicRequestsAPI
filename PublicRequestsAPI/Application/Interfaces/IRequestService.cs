using PublicRequestsAPI.Application.DTOs;

namespace PublicRequestsAPI.Application.Interfaces
{
    public interface IRequestService
    {
        Task<IEnumerable<Request>> GetRequestsAsync();
        Task<Request> CreateRequestAsync(Request request);
    }
}