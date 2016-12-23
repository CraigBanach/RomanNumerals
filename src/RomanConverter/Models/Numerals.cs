using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanConverter.Models
{
  public class Numerals
  {

    public readonly static int RomanLimit = 3999;

    public enum Numeral
    {
      I = 1,
      V = 5,
      X = 10,
      L = 50,
      C = 100,
      D = 500,
      M = 1000
    };

    public enum NumberDivision
    {
      Th = 1000,
      H = 100,
      T = 10,
      U = 1
    };

  }
}
