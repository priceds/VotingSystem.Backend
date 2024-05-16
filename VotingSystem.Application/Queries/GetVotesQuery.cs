using VotingSystem.Application.Contracts;
using VotingSystem.Application.Dto;

namespace VotingSystem.Application.Queries
{
    public record GetVotesQuery : IRequest<List<VoteDto>>
    {
        public int VoterId { get; set; }

        public int CandidateId { get; set; }
    }


    public class GetVotesQueryHandler:IRequestHandler<GetVotesQuery,List<VoteDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public GetVotesQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<VoteDto>> Handle(GetVotesQuery request, CancellationToken cancellationToken)
        {
            var result = _applicationDbContext.Votes.ToListAsync(cancellationToken);
            return _mapper.Map<List<VoteDto>>(result);
        }
    }
}
