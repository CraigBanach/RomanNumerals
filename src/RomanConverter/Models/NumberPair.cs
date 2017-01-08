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
      String query = Numeral;

      int result = 0;

      if ( query[0] == 'M' )
      {
        Tuple<int, string> thousandsResult = CalculateNumbers(query, new char[] { 'M' });
        result += thousandsResult.Item1;
        query = thousandsResult.Item2;
      }
      if ( query[0] == 'C' || query[0] == 'D' )
      {
        Tuple<int, string> hundredsResult = CalculateNumbers(query, new char[] { 'M', 'C', 'D' });
        result += hundredsResult.Item1;
        query = hundredsResult.Item2;
      }
      if ( query[0] == 'X' || query[0] == 'L' )
      {
        Tuple<int, string> tensResult = CalculateNumbers(query, new char[] { 'C', 'X', 'L' });
        result += tensResult.Item1;
        query = tensResult.Item2;
      }
      if ( query[0] == 'V' || query[0] == 'I' )
      {
        Tuple<int, string> unitsResult = CalculateNumbers(query, new char[] { 'X', 'V', 'I' });
        result += unitsResult.Item1;
        query = unitsResult.Item2;
      }
      Base10 = result;
    }

    private Tuple<int, string> CalculateNumbers( string query, char[] array )
    {
      int result = 0;
      while ( Array.IndexOf(array, query[0]) != -1 )
      {
        int modifier = 1;
        int currentValue = 0;
        Numerals.Numeral TestEnum;
        if ( Enum.TryParse(query[0].ToString(), out TestEnum) )
        {
          currentValue = (int) TestEnum;
        }
        try
        {
          int nextValue = 0;
          if ( Enum.TryParse(query[1].ToString(), out TestEnum) )
          {
            nextValue = (int) TestEnum;
          }
          if ( currentValue < nextValue )
            modifier = -1;
        }
        catch ( IndexOutOfRangeException )
        {
          // modifier remains as 1
          // This catch block will run if query is only one character in length and therefore,
          // the currentValue should be added to the sum.
        }
        result += currentValue * modifier;
        query = query.Substring(1);

        if ( query.Length == 0 )
          query = "i";
      }

      return Tuple.Create(result, query);
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
        numeralArray[0] = romCalculateThousands(number);
        number = number % 1000;
      }
      if ( number > 99 )
      {
        // Do hundreds stuff
        numeralArray[1] = romCalculateHundreds(number);
        number = number % 100;
      }
      if ( number > 9)
      {
        numeralArray[2] = romCalculateTens(number);
        number = number % 10;
      }
      if ( number != 0 )
      {
        // Do units stuff
        numeralArray[3] = romCalculateUnits(number);
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

    private Dictionary<Numeral, sbyte> romCalculateUnits( int number )
    {
      Dictionary<Numeral, SByte> dictionary = new Dictionary<Numeral, SByte>();

      if ( number > 8 )
      {
        dictionary.Add(Numerals.Numeral.X, 1);
        dictionary.Add(Numerals.Numeral.I, System.Convert.ToSByte(0 - 1));
      }
      else if ( number > 3 )
      {
        dictionary.Add(Numerals.Numeral.V, 1);
        SByte CToAdd = (SByte) Math.Floor(System.Convert.ToDouble(number - 5) / 1);
        dictionary.Add(Numerals.Numeral.I, CToAdd);
      }
      else if ( number < 4 )
        dictionary.Add(Numerals.Numeral.I, (SByte) (number / 1));

      return dictionary;
    }

    private Dictionary<Numeral, sbyte> romCalculateTens( int number )
    {
      Dictionary<Numeral, SByte> dictionary = new Dictionary<Numeral, SByte>();

      if ( number > 89 )
      {
        dictionary.Add(Numerals.Numeral.C, 1);
        dictionary.Add(Numerals.Numeral.X, System.Convert.ToSByte(0 - 1));
      }
      else if ( number > 39 )
      {
        dictionary.Add(Numerals.Numeral.L, 1);
        SByte CToAdd = (SByte) Math.Floor(System.Convert.ToDouble(number - 50) / 10);
        dictionary.Add(Numerals.Numeral.X, CToAdd);
      }
      else if ( number < 40 )
        dictionary.Add(Numerals.Numeral.X, (SByte) (number / 10));

      return dictionary;
    }

    private Dictionary<Numeral, SByte> romCalculateHundreds( int number )
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

    private Dictionary<Numeral, SByte> romCalculateThousands( int number )
    {
      return new Dictionary<Numeral, SByte> { [Numerals.Numeral.M] = (SByte) (number / 1000) };
    }
  }
}
