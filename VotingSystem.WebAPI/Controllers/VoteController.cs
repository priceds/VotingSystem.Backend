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
    public class VoteController : ControllerBase
    {
        private readonly ISender _sender;
        public VoteController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("CastVote")]
        public async Task<int> GetVotes([FromBody] CastVoteCommand command)
        {
            return await _sender.Send(command);
        }

        [HttpGet("GetVotes")]
        public async Task<List<VoteDto>> GetVotes([FromBody] GetVotesQuery query)
        {
            return await _sender.Send(query);
        }

    }
}
