using System.ComponentModel.DataAnnotations;

namespace BDshka.Models
{
    public class ClientsModel
    {
        [Key]
        public int ID_Client { get; set; }
        [Required(ErrorMessage = "Не указан ФИО")]
        public string FIO { get; set; }
        [Required(ErrorMessage = "Не указан Номер")]
        public string Phone_Number { get; set; }
        [Required(ErrorMessage = "Не указана Роль (А нужна ли она?)")]
        public int ID_Role { get; set; }

        //public ClientsModel(string name, int phone)
        //{
        //    FIO = name;
        //    Phone_Number = phone;
        //}
    }
}
