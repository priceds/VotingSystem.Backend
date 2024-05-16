using VotingSystem.Application.Contracts;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Application.Commands
{
    public record CastVoteCommand : IRequest<int>
    {
        public int VoterId { get; set; }

        public int CandidateId { get; set; }
    }



    public class CastVoteCommandHandler : IRequestHandler<CastVoteCommand, int>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public CastVoteCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> Handle(CastVoteCommand command, CancellationToken cancellationToken)
        {
            var voteToCast = new Vote { VoterId = command.VoterId, CandidateId = command.CandidateId };
            _applicationDbContext.Votes.Add(voteToCast);
            _applicationDbContext.SaveChangesAsync(cancellationToken);
            return voteToCast.VoteId;
        }

    }
}