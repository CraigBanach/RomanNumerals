using RomanConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RomanConverter.Tests.UnitTests
{
  public class NumberPairTests
  {
    //Arrange
    private NumberPair testNumberPair;

    public NumberPairTests() {

      testNumberPair = new NumberPair()
      {
        Base10 = 1,
      };
    }

    [Fact]
    public void ConvertsBase10ToNumerals()
    {
      //Act
      testNumberPair.Convert();

      //Assert
      Assert.Equal( testNumberPair, new NumberPair{ Base10 = 1, Numeral = "I" }, new NumberPairComparer());
    }
  }
}
