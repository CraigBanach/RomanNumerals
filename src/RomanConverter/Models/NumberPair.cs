using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RomanConverter.Models.Numerals;

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
      } else
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

      if ( number > Numerals.RomanLimit )
        throw new InputOutOfRangeException();

      Dictionary<Numeral, byte>[] numeralArray = new Dictionary<Numeral, byte>[4];

      if ( number > 999 )
      {
        // Do thousand Stuff
        numeralArray[0] = CalculateThousands(number);
        number = number % 1000;
      }
      if ( number > 99 )
      {
        // Do hundreds stuff
        numeralArray[1] = CalculateHundreds(number);
        number = number % 100;
      }
      if ( number > 9)
      {
        // Do hundreds stuff
      }
      if ( number != 0 )
      {
        // Do units stuff
      }

      Numeral = pieceTogether(numeralArray);
    }

    private string pieceTogether( Dictionary<Numeral, byte>[] numeralArray )
    {
      StringBuilder mapping = new StringBuilder();

      foreach ( Dictionary<Numeral, byte> dictionary in numeralArray )
      {
        if ( dictionary != null)
          mapping.Append(Enum.GetName(typeof(Numeral), 1000)[0], dictionary[Numerals.Numeral.M]);
      }
      return mapping.ToString();
    }

    private Dictionary<Numeral, byte> CalculateHundreds( int number )
    {
      Dictionary<Numeral, byte> dictionary = new Dictionary<Numeral, byte>();

      if ( number > 899 )
      {
        dictionary.Add(Numerals.Numeral.M, 1);
        dictionary.Add(Numerals.Numeral.C, System.Convert.ToByte(- 1));
      }
      if ( number > 399 )
      {
        dictionary.Add(Numerals.Numeral.D, 1);
        byte CToAdd = (byte) Math.Floor(System.Convert.ToDouble(number - 500) / 100);
        dictionary.Add(Numerals.Numeral.C, CToAdd);
      }
      if ( number < 400 )
        dictionary.Add(Numerals.Numeral.C, (byte) (number / 100));

      return dictionary;
    }

    private Dictionary<Numeral, byte> CalculateThousands( int number )
    {
      return new Dictionary<Numeral, byte> { [Numerals.Numeral.M] = (byte) (number / 1000) };
    }
  }
}
