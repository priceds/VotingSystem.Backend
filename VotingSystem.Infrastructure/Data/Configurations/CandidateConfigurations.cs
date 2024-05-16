using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Infrastructure.Data.Configurations
{
    public class CandidateConfigurations
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.Property(e => e.CandidateId).ValueGeneratedOnAdd();
            builder.HasKey(e => e.CandidateId);
            builder.Property(t => t.FirstName).HasMaxLength(100);
            builder.Property(t => t.LastName).HasMaxLength(100);

        }
    }
}
