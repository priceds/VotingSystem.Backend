using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.Application.Commands;
using VotingSystem.Application.Dto;
using VotingSystem.Application.Queries;

namespace VotingSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ISender _sender;
        public CandidateController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("GetCandidates")]
        public async Task<List<CandidateDto>> GetCandidates([FromQuery] GetCandidatesQuery query)
        {
            return await _sender.Send(query);
        }

        [HttpPost("AddCandidate")]
        public async Task<int> AddCandidate([FromBody] AddCandidateCommand command)
        {
            return await _sender.Send(command);
        }
    }
}
