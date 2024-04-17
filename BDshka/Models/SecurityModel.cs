using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace BDshka.Models
{
    public class  SecurityModel
    {
        [Key]
        public int ID_Client { get; set; }
        [Required(ErrorMessage = "Не указан Login")]
        public string Log_in { get; set; }
        [Required(ErrorMessage = "Не указан Пароль")]
        public string Pass_word { get; set; }

    }
}
