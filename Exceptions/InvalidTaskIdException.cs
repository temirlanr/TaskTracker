using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Exceptions
{
    public class InvalidTaskIdException : Exception
    {
        public InvalidTaskIdException() { }
        public InvalidTaskIdException(string message) : base(message) { }
        public InvalidTaskIdException(string message, Exception exception) : base(message, exception) { }
    }
}
