namespace VotingSystem.Application.Dto
{
    public record VoterDto
    {
        public int VoterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HasVoted { get; set; }
        public DateTime VoteCastedOn { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
