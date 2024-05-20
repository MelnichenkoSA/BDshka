using BDshka.Models;
using System.ComponentModel.DataAnnotations;
namespace BDshka.ViewModels
{
    public class AutorizationModel
    {
        [Required(ErrorMessage = "Не указан Login")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Длина строки должна быть от 8 до 16 символов")]
        public string Log_in { get; set; }


        [Required(ErrorMessage = "Не указан Пароль")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Длина строки должна быть от 8 до 16 символов")]
        public string Pass_word { get; set; }
    }
}
