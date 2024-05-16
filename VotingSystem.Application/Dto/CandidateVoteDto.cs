
namespace VotingSystem.Application.Dto
{
    public record CandidateVoteDto
    {
        public string Name { get; set; }

        public int Votes { get; set; }
    }
}
