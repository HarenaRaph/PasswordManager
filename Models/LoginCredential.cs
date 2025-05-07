

using SQLite;

namespace PasswordManager.Models
{
    public class LoginCredential
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Plateform { get; set; }

        public string  Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
