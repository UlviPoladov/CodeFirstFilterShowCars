// Car.cs
using System;

namespace WpfApp12.Entities
{
    public class Car
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Condition { get; set; }
        public string Category { get; set; }
        public int Kilometers { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string FuelType { get; set; }
    }

   
}
