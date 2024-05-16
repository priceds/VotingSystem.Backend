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
    public class VoterController : ControllerBase
    {
        private readonly ISender _sender;
        public VoterController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("GetVoters")]
        public async Task <List<VoterDto>> GetVoters([FromQuery] GetVotersQuery query)
        {
            return await _sender.Send(query);
        }

        [HttpPost("AddVoter")]
        public async Task<int> GetVotes([FromBody] AddVoterCommand command)
        {
            return await _sender.Send(command);
        }
    }
}
