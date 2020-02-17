using System;

namespace FSHR.Common.UnitTests.Mock
{
    public class ExceptionBaseMock : FSHR.Common.ExceptionBase
    {
        public ExceptionBaseMock(int code, int httpStatusCode, string defaultMessage = null, object[] messageParams = null, Exception innerException = null)
        : base(code, httpStatusCode, defaultMessage, messageParams, innerException)
        {
        }
    }
}