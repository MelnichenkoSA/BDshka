using System.ComponentModel.DataAnnotations;

namespace BDshka.Models
{
    public class Book_of_MaterialModel
    {
        [Key]
        public int ID_Material { get; set; }
        public string Title { get; set; }
        public int Cost { get; set; }
        public int ID_Category { get; set; }
    }
}
