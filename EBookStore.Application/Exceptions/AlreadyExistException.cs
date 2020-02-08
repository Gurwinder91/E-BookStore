using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Application.Exceptions
{
    public class AlreadyExistException: Exception
    {
        public AlreadyExistException(string message) : base(message)
        {

        }
    }
}
