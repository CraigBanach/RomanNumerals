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

      Dictionary<Numeral, SByte>[] numeralArray = new Dictionary<Numeral, SByte>[4];

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

    private string pieceTogether( Dictionary<Numeral, SByte>[] numeralArray )
    {
      StringBuilder mapping = new StringBuilder();

      foreach ( Dictionary<Numeral, SByte> dictionary in numeralArray )
      {
        if ( dictionary != null )
        {
          var orderedNumerals = OrderDictionary(dictionary);

          foreach ( var KVP in orderedNumerals )
          {
            mapping.Append(KVP.Key.ToString()[0] , Math.Abs(KVP.Value));
          }
        }
          
      }
      return mapping.ToString();
    }

    private IEnumerable<KeyValuePair<Numeral, SByte>> OrderDictionary( Dictionary<Numeral, SByte> dictionary )
    {
      List<KeyValuePair<Numeral, SByte>> result = new List<KeyValuePair<Numeral, SByte>>();

      if ( dictionary.Values.Min() < 0 )
      {
        var keyAndValue = dictionary.OrderBy(kvp => kvp.Value).First();
        result.Add(keyAndValue);
        dictionary.Remove(keyAndValue.Key);
      }

      foreach ( var KVP in dictionary )
      {
        result.Add(new KeyValuePair<Numeral, SByte>(KVP.Key, KVP.Value));
      }

      return result;
    }

    private Dictionary<Numeral, SByte> CalculateHundreds( int number )
    {
      Dictionary<Numeral, SByte> dictionary = new Dictionary<Numeral, SByte>();

      if ( number > 899 )
      {
        dictionary.Add(Numerals.Numeral.M, 1);
        dictionary.Add(Numerals.Numeral.C, System.Convert.ToSByte(0-1));
      }
      else if ( number > 399 )
      {
        dictionary.Add(Numerals.Numeral.D, 1);
        SByte CToAdd = (SByte) Math.Floor(System.Convert.ToDouble(number - 500) / 100);
        dictionary.Add(Numerals.Numeral.C, CToAdd);
      }
      else if ( number < 400 )
        dictionary.Add(Numerals.Numeral.C, (SByte) (number / 100));

      return dictionary;
    }

    private Dictionary<Numeral, SByte> CalculateThousands( int number )
    {
      return new Dictionary<Numeral, SByte> { [Numerals.Numeral.M] = (SByte) (number / 1000) };
    }
  }
}
