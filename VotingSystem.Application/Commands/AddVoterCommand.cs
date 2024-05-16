using VotingSystem.Application.Contracts;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Application.Commands
{
    public record AddVoterCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HasVoted { get; set; }
    }


    public class AddVoterCommandHandler:IRequestHandler<AddVoterCommand,int>
    {
        private readonly IApplicationDbContext _context;
        
        public AddVoterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddVoterCommand command,CancellationToken cancellationToken)
        {
            var voterToAdd = new Voter { FirstName = command.FirstName, LastName = command.LastName,HasVoted=false };
            _context.Voters.Add(voterToAdd);    
            await _context.SaveChangesAsync(cancellationToken);
            return voterToAdd.VoterId;
        }
    }
}
