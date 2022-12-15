using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Common.Filters
{
    public class GamePartiesFilter
    {
        public string? GameName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? GamePlaceId { get; set; }
        public bool? Created { get; set; }
        public Guid? PlayerId { get; set; }
    }
}
