namespace BoardGameManager1.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name)
        : base(String.Format("not found:{0}", name))
        {
        }
    }
}
