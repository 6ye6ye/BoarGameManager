namespace BoardGameManager1.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message)
        : base(message)
        {
            message = message + " not found";
        }
    }
}
