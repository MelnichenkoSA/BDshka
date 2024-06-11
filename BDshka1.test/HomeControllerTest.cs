using BDshka.Controllers;
using BDshka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDshka1.test
{
    public class HomeControllerTest
    {
        private BDContext _context;
        [Fact]
        public void Null_AutorizationTest()
        {
            AccountController accountc = new AccountController(_context);
        }
    }
}
