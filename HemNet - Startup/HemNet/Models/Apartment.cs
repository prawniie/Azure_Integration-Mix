using System.ComponentModel;

namespace HemNet.Models
{
    public class Apartment
    {
        public int Id { get; set; }

        [DisplayName("Number")]
        public int ApartmentNumber { get; set; }

        public decimal Rent { get; set; }
        public decimal Rooms { get; set; }
        public decimal Size { get; set; }
        public decimal Price { get; set; }

        [DisplayName("Operating cost")]
        public decimal OperatingCost { get; set; }

        [DisplayName("Cooperative")]
        public HousingCooperative HousingCooperative { get; set; }
        public int HousingCooperativeId { get; set; }

        public decimal PricePerSquareMeter => Price / Size;

        public string Color { get; set; }
    }
}
