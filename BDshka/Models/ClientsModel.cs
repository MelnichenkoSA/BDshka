using System.ComponentModel.DataAnnotations;

namespace BDshka.Models
{
    public class ClientsModel
    {
        [Key]
        public int ID_Client { get; set; }
        public string FIO { get; set; }
        public int Phone_Number { get; set; }
        public int ID_Role { get; set; }

        //public ClientsModel(string name, int phone)
        //{
        //    FIO = name;
        //    Phone_Number = phone;
        //}
    }
}
