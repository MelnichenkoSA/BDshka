using System.ComponentModel.DataAnnotations;

namespace BDshka.Models
{
    public class Order_MaterialModel
    {
        [Key]
        public int ID_Order { get; set; }
        public int ID_Client { get; set; }
        public DateTime Date_Order { get; set; }
        public int ID_Stat { get; set; }
    }
}
