using MediatR;
using UsersAPI.Commands;
using UsersAPI.DataContext;
using UsersAPI.Models;

namespace UsersAPI.CommandHandlers
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
    {
        private readonly AppDbContext _context;

        public AddUserCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var User = new User()
            {
                Name = request.Name,
                Email = request.Email,
                Active = request.Active,
            };

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return User;
        }
    }
}
