using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Contracts;
using VotingSystem.Application.Dto;

namespace VotingSystem.Application.Queries
{
    public record GetCandidateVoteQuery : IRequest<List<CandidateVoteDto>>
    {

    }


    public class GetCandidateVoteQueryHandler : IRequestHandler<GetCandidateVoteQuery, List<CandidateVoteDto>>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCandidateVoteQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CandidateVoteDto>> Handle(GetCandidateVoteQuery request, CancellationToken cancellationToken)
        {
            var candidateVotes = await _context.Candidates
                .GroupJoin(_context.Votes, 
                    candidate => candidate.CandidateId,
                    vote => vote.CandidateId,
                    (candidate, votes) => new CandidateVoteDto
                    {
                        Name = $"{candidate.FirstName} {candidate.LastName}",
                        Votes = votes.Count() 
                    })
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<CandidateVoteDto>>(candidateVotes);
        }

    }
}
