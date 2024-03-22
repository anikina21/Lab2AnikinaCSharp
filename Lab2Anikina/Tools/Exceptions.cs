using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Anikina.Tools
{

    public class NotCapsLetterAtStartException : Exception
    {
        public NotCapsLetterAtStartException(string message) : base(message) { }
    } 

    public class InvalidFutureDateException : Exception
    {
        public InvalidFutureDateException(string message) : base(message) { }
    }

    public class TooOldDateException : Exception
    {
        public TooOldDateException(string message) : base(message) { }
    }

    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string message) : base(message) { }
    }
}