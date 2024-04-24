using BDshka.Models;

namespace BDshka.ViewModels
{
    public class Autorization
    {
        public SecurityModel Security = new SecurityModel();
        public string Login;
        public string Password;
        public Autorization(SecurityModel security)
        {
            Security = security;
        }
    }
}
