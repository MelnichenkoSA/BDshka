using BDshka.Controllers;
using BDshka.Models;

namespace BDshka1.test
{
    public class AccountControllerTest
    {
        private BDContext _context;
        [Fact]
        public void Null_AutorizationTest()
        {
            AccountController accountc = new AccountController(_context);
        }
        [Fact]
        public void Role_AutorizationTest()
        {
            AccountController accountc = new AccountController(_context);
        }
        [Fact]
        public void Null_RegistrationTest()
        {
            AccountController accountc = new AccountController(_context);
        }

        [Fact]
        public void EditClientTest()
        {
            AccountController accountc = new AccountController(_context);
        }

    }
}