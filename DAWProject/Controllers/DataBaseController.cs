using System;
using System.Linq;
using System.Threading.Tasks;
using DAWProject.Data;
using DAWProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DAWProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataBaseController : ControllerBase
    {
        private readonly DawAppContext _context;

       public DataBaseController(DawAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.DataBaseModels.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] dynamic bodyObject)
        {
            DataBaseModel newObj = new DataBaseModel
            {
                Id = bodyObject.Id,
                Title = bodyObject.Title
            };

            await _context.DataBaseModels.AddAsync(newObj);
            _context.SaveChanges();
            return Ok();
            //return Ok(_context.DataBaseModels.ToList());
        }
    }
}
