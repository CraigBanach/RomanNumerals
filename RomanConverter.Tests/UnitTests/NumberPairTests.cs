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
    private NumberPair[] TestPairs = new NumberPair[7];
    public IConfigurationRoot Configuration;

    public NumberPairTests() {

      TestPairs[0] = new NumberPair() { Base10 = 1, Numeral = "I" };
      TestPairs[1] = new NumberPair() { Base10 = 5, Numeral = "V" };
      TestPairs[2] = new NumberPair() { Base10 = 10, Numeral = "X" };
      TestPairs[3] = new NumberPair() { Base10 = 50, Numeral = "L" };
      TestPairs[4] = new NumberPair() { Base10 = 100, Numeral = "C" };
      TestPairs[5] = new NumberPair() { Base10 = 500, Numeral = "D" };
      TestPairs[6] = new NumberPair() { Base10 = 100, Numeral = "M" };
    }
    
    [Fact]
    public void ConvertsBase10ToNumerals()
    {

      //Arrange
      for (int i = 0 ; i < 7 ; i++ )
      {
        NumberPair testNumberPair = new NumberPair() { Base10 = TestPairs[i].Base10 };

        //Act
        testNumberPair.Convert();

        //Assert
        Assert.Equal(testNumberPair, TestPairs[i], new NumberPairComparer());
      }
    }
  }
}
