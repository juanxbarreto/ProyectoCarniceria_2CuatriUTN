using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCarniceria
{
    public class ExceptionArchivos : Exception
    {
        public List<Exception> InnerExceptions { get; }

        public ExceptionArchivos(string message, List<Exception> innerExceptions) : base(message)
        {
            InnerExceptions = innerExceptions;
        }

    }
}
