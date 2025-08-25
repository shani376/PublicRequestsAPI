using Microsoft.AspNetCore.Mvc;
using PublicRequestsAPI.Application.DTOs;
using PublicRequestsAPI.Application.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class RequestsController : ControllerBase
{
    private readonly IRequestService _requestService;

    public RequestsController(IRequestService requestService)
    {
        _requestService = requestService;
    }

    [HttpGet]
    public async Task<IActionResult> GetRequests()
    {
        var requests = await _requestService.GetRequestsAsync();
        return Ok(requests);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRequest([FromBody] Request request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdRequest = await _requestService.CreateRequestAsync(request);
        return CreatedAtAction(nameof(GetRequests), new { id = createdRequest.Id }, createdRequest);
    }
}
