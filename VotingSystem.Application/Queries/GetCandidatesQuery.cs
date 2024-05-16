using VotingSystem.Application.Contracts;
using VotingSystem.Application.Dto;

namespace VotingSystem.Application.Queries
{
    public record GetCandidatesQuery :IRequest<List<CandidateDto>>
    {
    
    }

    public class GetCandidatesQueryHandler : IRequestHandler<GetCandidatesQuery, List<CandidateDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetCandidatesQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<List<CandidateDto>> Handle(GetCandidatesQuery request, CancellationToken cancellationToken)
        {
            var result = await _applicationDbContext.Candidates.ToListAsync(cancellationToken);
            return _mapper.Map<List<CandidateDto>>(result);
        }
    }
}
