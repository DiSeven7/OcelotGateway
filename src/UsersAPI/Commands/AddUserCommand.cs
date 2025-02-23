using MediatR;
using UsersAPI.Models;

namespace UsersAPI.Commands
{
    public class AddUserCommand : IRequest<User>
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public bool Active { get; set; }

        public AddUserCommand(string name, string email, bool active)
        {
            Name = name;
            Email = email;
            Active = active;
        }
    }
}
