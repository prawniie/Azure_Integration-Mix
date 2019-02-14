using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemNet_Azure.Models
{
    public class TimeTempVm
    {
        [Range(55.2013,69.036)]
        public decimal Latitude { get; set; }

        [Range(10.5727,24.100)]
        public decimal Longitude { get; set; }

        public List<TimeTemp> TimeTemps { get; set; }
        public TimeTemp TimeTemp { get; set; }
    }
}
