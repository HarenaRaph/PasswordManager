

using SQLite;

namespace PasswordManager.Models
{
    public class LoginCredential
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique]
        public string Website { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
