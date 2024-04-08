using System.ComponentModel.DataAnnotations;

namespace BDshka.Models
{
    public class Spec_of_WorkersModel
    {
        [Key]
        public int ID_SoW { get; set; }
        public int ID_Spec { get; set; }
        public int ID_Worker { get; set; }
    }
}
