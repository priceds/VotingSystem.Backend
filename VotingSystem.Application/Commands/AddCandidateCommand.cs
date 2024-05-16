using VotingSystem.Application.Contracts;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Application.Commands
{
    public record AddCandidateCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string State { get; set; }
    }

    public class AddCandidateCommandHandler : IRequestHandler<AddCandidateCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public AddCandidateCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddCandidateCommand command, CancellationToken cancellationToken)
        {
            var candidateToAdd = new Candidate { FirstName = command.FirstName, LastName = command.LastName, State = command.State };
            _context.Candidates.Add(candidateToAdd);
            await _context.SaveChangesAsync(cancellationToken);
            return candidateToAdd.CandidateId;
        }

    }
}
