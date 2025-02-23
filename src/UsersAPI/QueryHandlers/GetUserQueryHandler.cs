using System.Reflection.Metadata.Ecma335;
using MediatR;
using UsersAPI.DataContext;
using UsersAPI.Models;
using UsersAPI.Queries;

namespace UsersAPI.QueryHandlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
    {
        private readonly AppDbContext _context;

        public GetUserQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.FindAsync(request.Id);
        }
    }
}
