using BDshka.Models;
namespace BDshka.ViewModels
{
    public class Registration
    {
        public ClientsModel Clients = new ClientsModel();
        public SecurityModel Security = new SecurityModel();

        public Registration(ClientsModel clients, SecurityModel security) 
        {
            Clients = clients;
            Security = security;
        }
    }
}
