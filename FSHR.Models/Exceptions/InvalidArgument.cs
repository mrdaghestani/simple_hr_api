using System;

namespace FSHR.Models.Exceptions
{
    public class InvalidArgument : FSHR.Common.ExceptionBase
    {
        public InvalidArgument(string fieldName)
            : base(101, 400, "Invalid value at `{0}`.", new[] { fieldName })
        {
        }
    }
}