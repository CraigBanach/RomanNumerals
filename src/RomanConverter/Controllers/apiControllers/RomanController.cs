using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RomanConverter.Controllers.apiControllers
{
  [Route("api/[controller]")]
  public class RomanController : ApiController
  {
    // GET: api/values
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET api/values/5
    [HttpGet("{number}")]
    public IActionResult Get( int number )
    {


      return Ok("I");
    }

    // POST api/values
    [HttpPost]
    public void Post( [FromBody]string value )
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put( int id, [FromBody]string value )
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete( int id )
    {
    }
  }
}
