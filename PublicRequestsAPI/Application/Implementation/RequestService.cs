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
        private readonly ILogger<RequestService> _logger;

        public RequestService(IRequestRepository repository, IMapper mapper, ILogger<RequestService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<Request>> GetRequestsAsync()
        {
            _logger.LogInformation("Getting all requests");
            var dbRequests = await _repository.GetAllAsync();
            _logger.LogInformation("Retrieved {Count} requests", dbRequests.Count());
            return _mapper.Map<IEnumerable<Request>>(dbRequests);
        }

        public async Task<Request> CreateRequestAsync(Request request)
        {
            _logger.LogInformation("Creating new request with name: {Name}", request.Name);
            var dbRequest = _mapper.Map<Domain.DbModel.Request>(request);
            dbRequest.CreateDate = DateTime.UtcNow;

            var createdRequest = await _repository.AddAsync(dbRequest);
            _logger.LogInformation("Request created successfully with ID: {Id}", createdRequest.Id);
            return _mapper.Map<Request>(createdRequest);
        }
    }
}