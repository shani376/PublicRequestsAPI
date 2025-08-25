using AutoMapper;
using PublicRequestsAPI.Application.DTOs;
using PublicRequestsAPI.Application.Interfaces;
using PublicRequestsAPI.Domain.Interfaces;

namespace PublicRequestsAPI.Application.Implementation
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _repository;
        private readonly IMapper _mapper;

        public RequestService(IRequestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Request>> GetRequestsAsync()
        {
            var dbRequests = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<Request>>(dbRequests);
        }

        public async Task<Request> CreateRequestAsync(Request request)
        {
            var dbRequest = _mapper.Map<Domain.DbModel.Request>(request);
            dbRequest.CreateDate = DateTime.UtcNow;

            var createdRequest = await _repository.AddAsync(dbRequest);
            return _mapper.Map<Request>(createdRequest);
        }
    }
}