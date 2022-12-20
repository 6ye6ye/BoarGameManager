using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GameGetFromApiParams
    {
        public class ParamsWithCount
        {
            public int Count { get; set; }
        }

        public class ParamsWithName
        {
            public string Name { get; set; }
        }

        public class ParamsWithCountAndUser
        {
            public string UserName { get; set; }
            public int Count { get; set; }
        }
    }
}
