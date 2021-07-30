using System;

namespace Common.Exceptions
{
    public class InnerException : Exception
    {
        public string PropertyName { get; set; }
        public InnerException(string message) : base(message) { }
    }
}
