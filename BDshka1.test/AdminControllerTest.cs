using BDshka.Controllers;
using BDshka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDshka1.test
{
    public class AdminControllerTest
    {

        
        [Fact]
        public void AddRemont_NotNull_Test()
        {

            //arrange
             BDContext _context = new BDContext();
             RolesModel b = new RolesModel { ID = 1, Title = "gtfg" };
             AdminController accountc = new AdminController(_context);

            RemontsModel model = new RemontsModel{ ID_Remont = 1, ID_Spec = 1, Title = "TestTitle", Cost = 100};

            //act

            accountc.AddRemont(model);
            _context.SaveChanges();
            //result

            Assert.NotEmpty(_context.Remonts);
            _context.SaveChanges();
        }
        [Fact]
        public void AddRemont_Equal_Test()
        {
            //arrange
            BDContext _context = new BDContext();
            RolesModel b = new RolesModel { ID = 1, Title = "gtfg" };
            AdminController accountc = new AdminController(_context);

            RemontsModel model = new RemontsModel { ID_Remont = 1, ID_Spec = 1, Title = "TestTitle", Cost = 100 };

            //act

            accountc.AddRemont(model);
            _context.SaveChanges();
            //result

            Assert.Equal(model, _context.Remonts.FirstOrDefault(p => p.ID_Remont == 1));
            _context.SaveChanges();
        }
        [Fact]
        public void Edit_Equal_Test()
        {
            //arrange
            BDContext _context = new BDContext();
            RolesModel b = new RolesModel { ID = 1, Title = "gtfg" };
            AdminController accountc = new AdminController(_context);

            ClientsModel modelOld = new ClientsModel { ID_Client = 1, FIO = "Test", ID_Role = 1, Phone_Number = "12345678"};
            ClientsModel modelNew = new ClientsModel { ID_Client = 1, FIO = "Testo", ID_Role = 1, Phone_Number = "23456789" };

            _context.Clients.Add(modelOld);
            _context.SaveChanges();
            //act

            accountc.Edit(modelNew);
            _context.SaveChanges();
            //result

            Assert.Equal(modelNew, _context.Clients.FirstOrDefault(p => p.ID_Client == 1));
            _context.SaveChanges();
        }
        [Fact]
        public void DeleteTest()
        {
            //arrange
            BDContext _context = new BDContext();
            RolesModel b = new RolesModel { ID = 1, Title = "gtfg" };
            AdminController accountc = new AdminController(_context);

            ClientsModel model = new ClientsModel { ID_Client = 1, FIO = "Test", ID_Role = 1, Phone_Number = "12345678" };

            _context.Clients.Add(model);
            _context.SaveChanges();
            int id = 1; 
            //act

            accountc.Delete(id);
            _context.SaveChanges();
            //result

            Assert.Null(_context.Clients.FirstOrDefault(p => p.ID_Client == 1));
            _context.SaveChanges();
        }


    }
}
