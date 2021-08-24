using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetStore.Web;
using PetStore.Web.Controllers;
using PetStore.Web.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStore.Test
{
    [TestClass]
    public class UnitTestPets
    {
        [TestMethod]
        public async Task TestGetAllPets()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer("server=(local);database=PetsStore;Trusted_Connection=True;");
            var controller = new PetsApiController(new AppDbContext(options.Options));

            var result = await controller.GetAll();
            var pets = (List<Pet>)(result as OkObjectResult).Value;

            Assert.IsTrue(pets != null && pets.Count > 0);
        }
    }
}
