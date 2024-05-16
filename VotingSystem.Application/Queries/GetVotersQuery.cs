using VotingSystem.Application.Contracts;
using VotingSystem.Application.Dto;

namespace VotingSystem.Application.Queries
{
    public record GetVotersQuery:IRequest<List<VoterDto>>    
    {
        
    }


    public class GetVotersQueryHandler:IRequestHandler<GetVotersQuery,List<VoterDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetVotersQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<List<VoterDto>> Handle(GetVotersQuery query, CancellationToken cancellationToken)
        {
            var result = await _applicationDbContext.Voters.ToListAsync(cancellationToken);
            return _mapper.Map<List<VoterDto>>(result);
        }
    }
}
