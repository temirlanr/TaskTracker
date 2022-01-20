using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Exceptions
{
    public class TaskNotFoundException : Exception
    {
        public TaskNotFoundException() { }
        public TaskNotFoundException(string message) : base(message) { }
        public TaskNotFoundException(string message, Exception exception) : base(message, exception) { }
    }
}
