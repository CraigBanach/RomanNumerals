using RomanConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanConverter.Tests.UnitTests
{
  public class NumberPairComparer : IEqualityComparer<NumberPair>
  {
    public bool Equals(NumberPair pair1, NumberPair pair2)
    {
      if ( !pair1.Base10.Equals(pair2.Base10) )
        return false;

      if ( !pair1.Numeral.Equals(pair2.Numeral) )
        return false;

      return true;
    }

    public int GetHashCode(NumberPair numberPair )
    {
      return numberPair.GetHashCode();
    }
  }
}
