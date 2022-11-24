namespace BoardGameManager1.Common.Exceptions
{
    public class DoublicateException : Exception
    {
        public DoublicateException(string name) 
            : base(String.Format(" Already exist:{0}", name))
        {

        }
    }
}
