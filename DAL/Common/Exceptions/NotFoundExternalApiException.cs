using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Common.Exceptions
{
    public class NotFoundExternalApiException : Exception
    {
        public NotFoundExternalApiException(string url, string entityType)
        : base(String.Format("No response data: type - {0}, url - {1} ",entityType, url))
        {
        } 
    }
}
