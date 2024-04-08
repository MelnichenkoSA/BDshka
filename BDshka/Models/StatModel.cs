using System.ComponentModel.DataAnnotations;

namespace BDshka.Models
{
    public class StatModel
    {
        [Key]
        public int ID_Status { get; set; }
        public string Title { get; set; }

    }
}
