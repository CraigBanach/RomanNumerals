using System;

namespace RomanConverter.Models
{

  internal class InputOutOfRangeException : Exception
  {
    public InputOutOfRangeException()
    {
    }

    public InputOutOfRangeException( string message ) : base(message)
    {
    }

    public InputOutOfRangeException( string message, Exception innerException ) : base(message, innerException)
    {
    }
  }
}
