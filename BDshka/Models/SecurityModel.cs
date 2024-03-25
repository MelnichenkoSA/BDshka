using Microsoft.EntityFrameworkCore;

namespace BDshka.Models
{
    [Keyless]
    public class  SecurityModel
    {
        
        public int ID_Client { get; set; }
        public string Log_in { get; set; }
        public string Pass_word { get; set; }

        //public SecurityModel(string login, string password)
        //{
        //    Login = login;
        //    Password = password;
        //}
    }
}
