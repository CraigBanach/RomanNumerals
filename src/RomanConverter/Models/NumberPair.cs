using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanConverter.Models
{
  public class NumberPair
  {

    public int? Base10 { get; set; }
    public String Numeral { get; set; }

    public void Convert()
    {
      if ( Base10 != null )
      {
        ConvertToRoman();
      } 
      else
      {
        ConvertToBase10();
      }
    }

    private void ConvertToBase10()
    {
      //throw new NotImplementedException();
    }

    private void ConvertToRoman()
    {
      int number = (int) Base10;
      StringBuilder mapping = new StringBuilder();

      for ( int i = 6 ; i >= 0 ; i-- )
      {
        int multiples = number / NumeralMappings.number[i];

        // If the number is greater than 3 times the current numeral,

        if ( NumeralMappings.number[i] * 3 < number )
        {
          int currentValue = NumeralMappings.number[i + 1];
          int numberOfNumerals = NumeralMappings.number[i] / (currentValue - number);

          mapping.Append(NumeralMappings.numeral[i], numberOfNumerals);
          mapping.Append(NumeralMappings.numeral[i + 1]);
          
          number += NumeralMappings.number[i + 1];
          number -= numberOfNumerals * NumeralMappings.number[i];
        } else
        {

          // Work out what to add



          // Else



          mapping.Append(NumeralMappings.numeral[i], multiples);
          number -= multiples * NumeralMappings.number[i];
        }
      }

      Numeral = mapping.ToString();
    }
  }
}
