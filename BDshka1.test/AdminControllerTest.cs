using BDshka.Controllers;
using BDshka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDshka1.test
{
    public class AdminControllerTest
    {
        private BDContext _context;
        [Fact]
        public void Null_AddRemontTest()
        {
            AccountController accountc = new AccountController(_context);
        }
        [Fact]
        public void Null_AddWorkerTest()
        {
            AccountController accountc = new AccountController(_context);
        }
        [Fact]
        public void DeleteTest()
        {
            AccountController accountc = new AccountController(_context);
        }
    }
}
