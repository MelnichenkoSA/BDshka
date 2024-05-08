using System.ComponentModel.DataAnnotations;

namespace BDshka.Models
{
    public class RemontsModel
    {
        [Key]
        public int ID_Remont { get; set; }
        [Required(ErrorMessage = "Не указано Название")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Не указана Стоимость")]
        public int Cost { get; set; }
        [Required(ErrorMessage = "Не указана Специальность")]
        public int ID_Spec { get; set; }
    }
}
