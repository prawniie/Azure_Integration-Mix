using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemNet_Azure.Models
{
    public class TimeTempVm
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public List<TimeTemp> TimeTemps { get; set; }
        public TimeTemp TimeTemp { get; set; }
    }
}
