using System.ComponentModel.DataAnnotations;

namespace BDshka.Models
{
    public class Category_of_Remonts
    {
        [Key]
        public int ID_CoR { get; set; }
        public int ID_Remont { get; set; }
        public int ID_Category { get; set; }
    }
}
