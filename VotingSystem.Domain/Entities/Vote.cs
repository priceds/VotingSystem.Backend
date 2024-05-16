namespace VotingSystem.Domain.Entities
{
    public class Vote
    {
        public int VoteId { get; set; }

        public int VoterId { get; set; }

        public int CandidateId { get; set; }

        public virtual Candidate Candidate { get; set; }

        public virtual Voter Voter { get; set; }
    }
}
