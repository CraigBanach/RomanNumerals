using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanConverter.Models
{
  public static class NumeralMappings
  {

    

    public readonly static int[] number = new int[]
    {
      1,
      5,
      10,
      50,
      100,
      500,
      1000
    };

    public readonly static char[] numeral = new char[]
    {
      'I',
      'V',
      'X',
      'L',
      'C',
      'D',
      'M'
    };

  }
}
