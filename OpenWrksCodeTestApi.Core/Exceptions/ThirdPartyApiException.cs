using System;

namespace OpenWrksCodeTestApi.Core.Exceptions
{
    public class ThirdPartyApiException : Exception
    {
        public ThirdPartyApiException(string message) : base(message)
        {

        }
    }
}
