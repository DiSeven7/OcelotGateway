using MediatR;
using UsersAPI.Models;

namespace UsersAPI.Queries
{
    public class GetUserQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}
