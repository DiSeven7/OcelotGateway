namespace UsersAPI.Models
{
    public class User
    {

        public int Id { get; private set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool Active {  get; set; }

    }
}
