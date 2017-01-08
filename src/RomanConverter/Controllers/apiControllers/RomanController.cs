using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using RomanConverter.Models;
using System.Text.RegularExpressions;

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

    // GET api/roman/5
    [HttpGet("{input}")]
    public IActionResult Get( string input )
    {
      int number = 0;
      NumberPair answer;
      bool result = int.TryParse(input, out number);
      if ( result )
      {
        if ( number > 4000 || number < 1 )
          return BadRequest("The value supplied is outside of the range of possible values of Roman Numerals. Allowed range is natural numbers 1-3999 inclusive.");

        answer = new NumberPair() { Base10 = number };
      }
      else
      {
        if ( input.Length > 15 )
          return BadRequest("An invalid Roman Numeral has been supplied. Valid Roman Numerals have a maximum lenght of 15 characters.");

        Regex rgx = new Regex(@"[^ixvldcm]", RegexOptions.IgnoreCase);
        if ( rgx.IsMatch(input) )
          return BadRequest("An invalid Roman Numeral has been supplied. Valid Roman Numerals can contain only the letters I, V, X, L, C, D, M.");

        answer = new NumberPair() { Numeral = input.ToUpper() };
      }

      answer.Convert();

      if ( answer.Base10 == 0 )
        return BadRequest("The value supplied is outside of the range of possible values of Roman Numerals. Allowed range is natural numbers 1-3999 inclusive.");

      return Ok(answer);
    }
  }
}
