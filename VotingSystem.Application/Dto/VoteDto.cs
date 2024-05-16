namespace VotingSystem.Application.Dto
{
    public record VoteDto
    {
        public int VoteId { get; set; }

        public int VoterId { get; set; }

        public int CandidateId { get; set; }
    }
}
