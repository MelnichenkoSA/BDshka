using System.ComponentModel.DataAnnotations;

namespace BDshka.Models
{
    public class Material_NaborModel
    {
        [Key]
        public int ID_Nabor { get; set; }
        public int ID_Material { get; set; }
        public int ID_Order { get; set; }
        public int Kol_vo { get; set; }
    }
}
