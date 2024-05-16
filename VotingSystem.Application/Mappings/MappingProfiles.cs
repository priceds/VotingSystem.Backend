using VotingSystem.Application.Dto;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Application.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Voter, VoterDto>().ReverseMap();
            CreateMap<Candidate, CandidateDto>().ReverseMap();
            CreateMap<Vote, VoteDto>().ReverseMap();
        }
    }
}
