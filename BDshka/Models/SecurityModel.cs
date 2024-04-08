using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace BDshka.Models
{
    public class  SecurityModel
    {
        [Key]
        public int ID_Client { get; set; }
        public string Log_in { get; set; }
        public string Pass_word { get; set; }

    }
}
