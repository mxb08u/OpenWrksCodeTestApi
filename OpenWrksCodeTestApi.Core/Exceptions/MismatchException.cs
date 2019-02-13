using System;

namespace OpenWrksCodeTestApi.Core.Exceptions
{
    public class MismatchException : Exception
    {
        public MismatchException(string message) : base(message)
        {

        }
    }
}
