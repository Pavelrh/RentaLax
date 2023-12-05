using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rentaLax.Controllers;
using rentaLax.Data;
using rentaLax.Models;

namespace RentaLaxTesting
{
    [TestClass]
    public class ItemTypesControllerTests
    {
        ApplicationDbContext _context;
        ItemTypesController controller;

        [TestInitialize]
        public void TestInitialize() 
        {
           var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);

            var itemType = new ItemType { ItemTypeId = 200, Name = "Pav", PriceType = "None", Abbreviation = "Pav" };
            _context.ItemTypes.Add(itemType);

            itemType = new ItemType { ItemTypeId = 201, Name = "Eel", PriceType = "Free", Abbreviation = "Eel" };
            _context.ItemTypes.Add(itemType);

            itemType = new ItemType { ItemTypeId = 202, Name = "Phone", PriceType = "Dollars", Abbreviation = "Ph" };
            _context.ItemTypes.Add(itemType);

            _context.SaveChanges();

            controller = new ItemTypesController(_context);

        }

        [TestMethod]
        public void DeleteNullIdReturnsError()
        {
            var result = (ViewResult)controller.Delete(null).Result;

            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteInvalidIdReturnsError()
        {
            var result = (ViewResult)controller.Delete(-202).Result;

            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteValidIdReturnsDeleteView()
        {
            var result = (ViewResult)controller.Delete(200).Result;

            Assert.AreEqual("Delete", result.ViewName);
        }

        [TestMethod]
        public void DeleteValidIdReturnsCorrectItemType()
        {
            var result = (ViewResult)controller.Delete(200).Result;
            var model = (ItemType)result.Model;

            Assert.AreEqual(_context.ItemTypes.Find(200), model);
        }

        [TestMethod]
        public void DeleteConfirmedRemovesItemFromDatabase()
        {
            var initialCount = _context.ItemTypes.Count();
            var result = (RedirectToActionResult)controller.DeleteConfirmed(202).Result;

            Assert.AreEqual(initialCount - 1, _context.ItemTypes.Count());
        }

        [TestMethod]
        public void DeleteConfirmedRedirectsToIndex()
        {
            var result = (RedirectToActionResult)controller.DeleteConfirmed(200).Result;
            
            Assert.AreEqual("Index", result.ActionName);
        }
    }
}
