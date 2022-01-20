using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Exceptions
{
    public class ProjectNotFoundException : Exception
    {
        public ProjectNotFoundException() { }
        public ProjectNotFoundException(string message) : base(message) { }
        public ProjectNotFoundException(string message, Exception exception) : base(message, exception) { }
    }
}
