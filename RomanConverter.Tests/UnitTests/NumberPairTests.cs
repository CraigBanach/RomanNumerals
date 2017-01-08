using Microsoft.Extensions.Configuration;
using RomanConverter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Diagnostics;

namespace RomanConverter.Tests.UnitTests
{
  public class NumberPairTests
  {
    private List<NumberPair> TestPairs = new List<NumberPair>();
    public IConfigurationRoot Configuration;

    public NumberPairTests()
    {

      TestPairs.Add(new NumberPair() { Base10 = 3900, Numeral = "MMMCM" });
      TestPairs.Add(new NumberPair() { Base10 = 1000, Numeral = "M" });
      TestPairs.Add(new NumberPair() { Base10 = 2000, Numeral = "MM" });
      TestPairs.Add(new NumberPair() { Base10 = 3000, Numeral = "MMM" });
      TestPairs.Add(new NumberPair() { Base10 = 900, Numeral = "CM" });
      TestPairs.Add(new NumberPair() { Base10 = 800, Numeral = "DCCC" });
      TestPairs.Add(new NumberPair() { Base10 = 700, Numeral = "DCC" });
      TestPairs.Add(new NumberPair() { Base10 = 600, Numeral = "DC" });
      TestPairs.Add(new NumberPair() { Base10 = 500, Numeral = "D" });
      TestPairs.Add(new NumberPair() { Base10 = 400, Numeral = "CD" });
      TestPairs.Add(new NumberPair() { Base10 = 300, Numeral = "CCC" });
      TestPairs.Add(new NumberPair() { Base10 = 200, Numeral = "CC" });
      TestPairs.Add(new NumberPair() { Base10 = 100, Numeral = "C" });
      TestPairs.Add(new NumberPair() { Base10 = 90, Numeral = "XC" });
      TestPairs.Add(new NumberPair() { Base10 = 80, Numeral = "LXXX" });
      TestPairs.Add(new NumberPair() { Base10 = 70, Numeral = "LXX" });
      TestPairs.Add(new NumberPair() { Base10 = 60, Numeral = "LX" });
      TestPairs.Add(new NumberPair() { Base10 = 50, Numeral = "L" });
      TestPairs.Add(new NumberPair() { Base10 = 40, Numeral = "XL" });
      TestPairs.Add(new NumberPair() { Base10 = 30, Numeral = "XXX" });
      TestPairs.Add(new NumberPair() { Base10 = 20, Numeral = "XX" });
      TestPairs.Add(new NumberPair() { Base10 = 10, Numeral = "X" });
      TestPairs.Add(new NumberPair() { Base10 = 9, Numeral = "IX" });
      TestPairs.Add(new NumberPair() { Base10 = 8, Numeral = "VIII" });
      TestPairs.Add(new NumberPair() { Base10 = 7, Numeral = "VII" });
      TestPairs.Add(new NumberPair() { Base10 = 6, Numeral = "VI" });
      TestPairs.Add(new NumberPair() { Base10 = 5, Numeral = "V" });
      TestPairs.Add(new NumberPair() { Base10 = 4, Numeral = "IV" });
      TestPairs.Add(new NumberPair() { Base10 = 3, Numeral = "III" });
      TestPairs.Add(new NumberPair() { Base10 = 2, Numeral = "II" });
      TestPairs.Add(new NumberPair() { Base10 = 1, Numeral = "I" });
      TestPairs.Add(new NumberPair() { Base10 = 3999, Numeral = "MMMCMXCIX" });
      TestPairs.Add(new NumberPair() { Base10 = 2777, Numeral = "MMDCCLXXVII" });
      TestPairs.Add(new NumberPair() { Base10 = 1111, Numeral = "MCXI" });
    }

    [Fact]
    public void ConvertsBase10ToNumerals()
    {

      // Tests all milestone numeral conversions
      for (int i = 0 ; i < TestPairs.Count ; i++ )
      {
        NumberPair testNumberPair = new NumberPair() { Base10 = TestPairs[i].Base10 };

        testNumberPair.Convert();

        Assert.Equal(TestPairs[i], testNumberPair, new NumberPairComparer());
      }
    }

    [Fact]
    public void ConvertsNumeralsToBase10()
    {

      // Tests all milestone numeral conversions
      for ( int i = 0 ; i < TestPairs.Count ; i++ )
      {
        NumberPair testNumberPair = new NumberPair() { Numeral = TestPairs[i].Numeral };

        testNumberPair.Convert();

        Assert.Equal(TestPairs[i], testNumberPair, new NumberPairComparer());
      }
    }
  }
}
