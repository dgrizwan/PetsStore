using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetStore.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsApiController : ControllerBase
    {
        AppDbContext _dbContext;
        public PetsApiController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        [Route("GetAllPets")]
        public async Task<IActionResult> GetAll()
        {
            try {
                var pets = await _dbContext.Pets.ToListAsync();

                return Ok(pets);
            }
            catch 
            {
                return Ok(new List<Pet>());
            }
    } }
}
