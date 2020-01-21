namespace FSHR.Common
{
    public abstract class ExceptionBase : System.Exception
    {
        public ExceptionBase(int code, string defaultMessage = null, object[] messageParams = null, System.Exception innerException = null)
        : base(defaultMessage, innerException)
        {
            Code = code;
            MessageParams = messageParams;
        }
        public int Code { get; private set; }
        public object[] MessageParams { get; private set; }
    }
}