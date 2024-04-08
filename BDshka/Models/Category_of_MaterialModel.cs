using System.ComponentModel.DataAnnotations;

namespace BDshka.Models
{
    public class Category_of_MaterialModel
    {
        [Key]
        public int ID_Category { get; set; }
        public string Title { get; set; }

    }
}
