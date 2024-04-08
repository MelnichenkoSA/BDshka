using System.ComponentModel.DataAnnotations;

namespace BDshka.Models
{
    public class SpecModel
    {
        [Key]
        public int ID_Spec { get; set; }
        public string Title { get; set; }

    }
}
