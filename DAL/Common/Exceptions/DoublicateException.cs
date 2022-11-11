namespace BoardGameManager1.Common.Exceptions
{
    public class DoublicateException : Exception
    {
        public DoublicateException(string message) : base(message)
        {
            message = message + " already exist";
        }
    }
}
