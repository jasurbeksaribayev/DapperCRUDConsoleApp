using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Service.Exceptions
{
    public class DapperCRUDAppException : Exception
    {
        public DapperCRUDAppException(string message) : base(message)
        {
        }

        public DapperCRUDAppException(int code , string message) : base(message)    
        {
            
        }
    }
}
