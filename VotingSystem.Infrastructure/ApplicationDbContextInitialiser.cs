using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Domain.Entities;
using VotingSystem.Infrastructure.Data;

namespace VotingSystem.Infrastructure
{
    public static class InitialiserExtensions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

            await initialiser.InitialiseAsync();

            await initialiser.SeedAsync();
        }
    }

    public class ApplicationDbContextInitialiser
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ApplicationDbContextInitialiser> _logger;
        public ApplicationDbContextInitialiser(ApplicationDbContext context, ILogger<ApplicationDbContextInitialiser> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "A error occured while applying migration");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "A error occured while seeding the database");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            if (!_context.Voters.Any() || !_context.Candidates.Any() || !_context.Votes.Any())
            {
                var listOfDummyVoters = new Faker<Voter>()
              .Ignore(e => e.VoterId)
              .RuleFor(e => e.FirstName, f => f.Person.FirstName)
              .RuleFor(e => e.LastName, f => f.Person.LastName)
              .Generate(100);

                var listOfDummyCandidates = new Faker<Candidate>()
                    .Ignore(e => e.CandidateId)
                    .RuleFor(e => e.FirstName, f => f.Person.FirstName)
                    .RuleFor(e => e.LastName, f => f.Person.LastName)
                    .RuleFor(e => e.State, f => f.Address.StateAbbr())
                    .Generate(100);
                _context.Voters.AddRange(listOfDummyVoters);
                _context.Candidates.AddRange(listOfDummyCandidates);

                await _context.SaveChangesAsync();
            }
        }
    }

}
