using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    //Enforces attribute routing.  Also auto-validates requests.
    [ApiController]
   
    //ControllerBase: controllers inherits from this base class. Gives access to HTTP responses and actions.
    //Does not have view support. Just Controller has view support. We will not be using it. View Support will be handled by angular.
    public class ValuesController : ControllerBase
    {
        //injects DataContext in controller
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            this._context = context;
        }

        // GET http requests
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            //gets Values from database and stores into list
            var values = await _context.Values.ToListAsync();

            //Ok is an http request value, which is why this is an IActionResult function
            return Ok(values);
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            //FirstorDefault better than First. First will throw exception if value = null. FirstorDefault will return null.
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}