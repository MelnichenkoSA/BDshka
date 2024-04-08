using System.ComponentModel.DataAnnotations;

namespace BDshka.Models
{
    public class Worker_of_RemontModel
    {
        [Key]
        public int ID_WoR { get; set; }
        public int ID_Order { get; set; }
        public int ID_Worker { get; set; }
    }
}
