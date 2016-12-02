using RomanConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanConverter.Tests.UnitTests
{
  public class NumberPairComparer : IEqualityComparer<NumberPair>
  {
    public bool Equals(NumberPair TestPair, NumberPair ReferencePair)
    {
      if ( !TestPair.Base10.Equals(ReferencePair.Base10) )
        return false;

      if ( !TestPair.Numeral.Equals(ReferencePair.Numeral) )
        return false;

      return true;
    }

    public int GetHashCode(NumberPair numberPair )
    {
      return numberPair.GetHashCode();
    }
  }
}
