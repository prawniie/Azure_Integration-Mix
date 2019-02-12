using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemNet.Models
{
    public class HousingCooperative
    {
        public int Id { get; set; }

        // Beteckning (t.ex Stigberget 34:6 och 34:7)
        public string Name { get; set; }

        // T.ex "Beskrivning(Fastigheterna utgör ett gårdskvarter i landshövdingestil med en lummig innergård..."
        public string Description { get; set; }
    }
}

