namespace BDshka.Models
{
    public class SecurityModel
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public SecurityModel(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
