namespace BDshka.Models
{
    public class RolesModel
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public RolesModel(string title)
        {
            Title = title;
        }
    }
}
