using System;

namespace OpenWrksCodeTestApi.Core.Exceptions
{
    public class NotUniqueException : Exception
    {
        public NotUniqueException(string message) : base(message)
        {

        }
    }
}
