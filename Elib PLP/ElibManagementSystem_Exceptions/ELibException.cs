using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElibManagementSystem_Exceptions
{
    public class ELibException : ApplicationException
    {
        public ELibException()
        {
        }

        public ELibException(string message) : base(message)
        {
        }

        public ELibException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
