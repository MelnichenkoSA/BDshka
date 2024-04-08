using System.ComponentModel.DataAnnotations;

namespace BDshka.Models
{
    public class WorkersModel
    {
        [Key]
        public int ID_Worker { get; set; }
        public string FIO { get; set; }
        public int Oklad { get; set; }
    }
}
