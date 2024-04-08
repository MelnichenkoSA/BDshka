using System.ComponentModel.DataAnnotations;

namespace BDshka.Models
{
    public class RemontsModel
    {
        [Key]
        public int ID_Remont { get; set; }
        public string Title { get; set; }
        public int Cost { get; set; }
        public int ID_Spec { get; set; }
    }
}
