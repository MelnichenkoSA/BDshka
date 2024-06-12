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
        public void AddRemont_NotNull_Test()
        {
            //arrange

            AdminController accountc = new AdminController(_context);

            RemontsModel model = new RemontsModel{ ID_Remont = 1, ID_Spec = 1, Title = "TestTitle", Cost = 100};

            //act

            accountc.AddRemont(model);

            //result

            Assert.NotEmpty(_context.Remonts);
        }
        [Fact]
        public void AddRemont_Equal_Test()
        {
            //arrange

            AdminController accountc = new AdminController(_context);

            RemontsModel model = new RemontsModel { ID_Remont = 1, ID_Spec = 1, Title = "TestTitle", Cost = 100 };

            //act

            accountc.AddRemont(model);

            //result

            Assert.Equal(model, _context.Remonts.FirstOrDefault(p => p.ID_Remont == 1));
        }
        [Fact]
        public void Edit_Equal_Test()
        {
            //arrange

            AdminController accountc = new AdminController(_context);

            ClientsModel modelOld = new ClientsModel { ID_Client = 1, FIO = "Test", ID_Role = 1, Phone_Number = "12345678"};
            ClientsModel modelNew = new ClientsModel { ID_Client = 1, FIO = "Testo", ID_Role = 1, Phone_Number = "23456789" };

            _context.Clients.Add(modelOld);

            //act

            accountc.Edit(modelNew);

            //result

            Assert.Equal(modelNew, _context.Clients.FirstOrDefault(p => p.ID_Client == 1));
        }
        [Fact]
        public void DeleteTest()
        {
            //arrange

            AdminController accountc = new AdminController(_context);

            ClientsModel model = new ClientsModel { ID_Client = 1, FIO = "Test", ID_Role = 1, Phone_Number = "12345678" };

            _context.Clients.Add(model);

            int id = 1; 
            //act

            accountc.Delete(id);

            //result

            Assert.False(_context.Clients.FirstOrDefault(p => p.ID_Client == 1));
        }


    }
}
