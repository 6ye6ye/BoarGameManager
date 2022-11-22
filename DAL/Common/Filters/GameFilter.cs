using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Common.Filters
{
    public class GameFilter
    {
        public string? Name { get; set; }
        public int MinRate { get; set; }
        public int MaxRate { get; set; }
        public int ReleaseYear { get; set; }
        public bool ShowAdded { get; set; }
    }
}
