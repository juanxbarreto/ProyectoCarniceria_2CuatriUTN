using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCarniceria
{
    public class ExceptionDatabase : Exception
    {
        public List<Exception> InnerExceptions { get; }

        public ExceptionDatabase(string message, List<Exception> innerExceptions) : base(message)
        {
            InnerExceptions = innerExceptions;
        }
    }
}
