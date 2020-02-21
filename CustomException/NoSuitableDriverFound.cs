using System;

namespace SeleniumWebdriver.CustomException
{
    public class NoSuitableDriverFound : Exception
    {
        public NoSuitableDriverFound(string msg) : base(msg)
        {

        }

    }
}
