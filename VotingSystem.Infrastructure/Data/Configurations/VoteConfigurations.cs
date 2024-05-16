using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Infrastructure.Data.Configurations
{
    public class VoteConfigurations:IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder) 
        {
            builder.Property(e => e.VoteId).ValueGeneratedOnAdd();
            builder.HasKey(e => e.VoteId);
            builder.HasOne(v => v.Candidate)
                .WithMany().HasForeignKey(v => v.CandidateId).IsRequired();

        }
    }
}
