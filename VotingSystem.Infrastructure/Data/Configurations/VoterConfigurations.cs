
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Infrastructure.Data.Configurations
{
    public class VoterConfigurations :IEntityTypeConfiguration<Voter>
    {
        public void Configure(EntityTypeBuilder<Voter> builder)
        {
            builder.Property(t => t.VoterId).ValueGeneratedOnAdd().IsRequired();
            builder.HasKey(e => e.VoterId);
            builder.Property(t => t.FirstName).HasMaxLength(100);
            builder.Property(t => t.LastName).HasMaxLength(100);                     
        }
    }
}
