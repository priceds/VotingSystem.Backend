namespace VotingSystem.Application.Dto
{
    public record CandidateDto
    {
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string State { get; set; }
    }
}
