using Microsoft.EntityFrameworkCore;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Application.Contracts
{
    public interface IApplicationDbContext
    {
        DbSet<Voter> Voters { get;}
        DbSet<Candidate> Candidates { get;}
        DbSet<Vote> Votes { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
