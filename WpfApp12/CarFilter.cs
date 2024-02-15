// CarFilter.cs
using System;
using System.Collections.Generic;
using System.Linq;
using WpfApp12.DataAccsess;
using WpfApp12.Entities;

namespace WpfApp12
{
    public class CarFilter
    {
        private readonly MyContext dbContext;

        public CarFilter(MyContext context)
        {
            dbContext = context;
        }

        public IEnumerable<Car> ApplyFilters(string selectedBrand, string selectedCondition, string selectedCategory, int minKilometers, int maxKilometers, DateTime? minReleaseDate, DateTime? maxReleaseDate, string selectedColor, decimal minPrice, decimal maxPrice, string selectedFuelType)
        {
            var query = dbContext.Cars.AsQueryable();

            if (!string.IsNullOrEmpty(selectedBrand))
            {
                query = query.Where(c => c.Brand == selectedBrand);
            }

            if (!string.IsNullOrEmpty(selectedCondition))
            {
                query = query.Where(c => c.Condition == selectedCondition);
            }

            if (!string.IsNullOrEmpty(selectedCategory))
            {
                query = query.Where(c => c.Category == selectedCategory);
            }

            query = query.Where(c => c.Kilometers >= minKilometers && c.Kilometers <= maxKilometers);

            if (minReleaseDate != null)
            {
                query = query.Where(c => c.ReleaseDate >= minReleaseDate.Value);
            }

            if (maxReleaseDate != null)
            {
                query = query.Where(c => c.ReleaseDate <= maxReleaseDate.Value);
            }

            if (!string.IsNullOrEmpty(selectedColor))
            {
                query = query.Where(c => c.Color == selectedColor);
            }

            query = query.Where(c => c.Price >= minPrice && c.Price <= maxPrice);

            if (!string.IsNullOrEmpty(selectedFuelType))
            {
                query = query.Where(c => c.FuelType == selectedFuelType);
            }

            return query.ToList();
        }
    }
}
