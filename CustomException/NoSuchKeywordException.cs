using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.CustomException
{
    public class NoSuchKeywordException : Exception
    {
        public NoSuchKeywordException(string msg) : base(msg)
        {

        }
    }
}
