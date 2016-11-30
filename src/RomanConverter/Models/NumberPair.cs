using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanConverter.Models
{
  public class NumberPair
  {

    public int? Base10 { get; set; }
    public String Numeral { get; set; }

    public void Convert()
    {
      Numeral = "I";
    }
  }
}
