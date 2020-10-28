using System;
using System.Collections.Generic;
using System.Text;

namespace LotteryConsole.Entities.Exceptions
{
    class LotteryExceptions : ApplicationException
    {
        public LotteryExceptions(string message) : base(message) { }
    }
}
