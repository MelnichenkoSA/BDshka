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
        public int ID_Role { get; set; }

        [Required(ErrorMessage = "Не указан Login")]
        //[RegularExpression("/^([a - zA - Z0 - 9])$/", ErrorMessage = "Некоректный ввод, необходимы: A-Z a-z 0-9")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Длина строки должна быть от 8 до 16 символов")]
        //[Remote(action: "CheckEmail", controller: "Account", ErrorMessage = "Login уже используется")]
        public string Log_in { get; set; }

        [Required(ErrorMessage = "Не указан Пароль")]
        //[RegularExpression(@"[A-Za-z0-9._%+-]", ErrorMessage = "Некоректный ввод, необходимы: A-Z a-z 0-9 ._%+-")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Длина строки должна быть от 8 до 16 символов")]
        public string Pass_word { get; set; }

        //public ClientsModel(string name, int phone)
        //{
        //    FIO = name;
        //    Phone_Number = phone;
        //}
    }
}
