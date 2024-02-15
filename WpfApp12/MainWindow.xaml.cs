// MainWindow.xaml.cs
using System;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using WpfApp12.DataAccsess;
using WpfApp12.Entities;

namespace WpfApp12
{
    public partial class MainWindow : Window
    {
        private readonly MyContext dbContext;
        private readonly CarFilter carFilter;

        public MainWindow()
        {
            InitializeComponent();
            dbContext = new MyContext();
            carFilter = new CarFilter(dbContext);
            AddInitialData();
            
        }

        private void AddInitialData()
        {
            if (!dbContext.Cars.Any())
            {
                dbContext.Cars.Add(new Car
                {
                    Brand = "Toyota",
                    Condition = "Used",
                    Category = "Sedan",
                    Kilometers = 50000,
                    ReleaseDate = DateTime.Parse("2020-01-01"),
                    Color = "Blue",
                    Price = 25000,
                    FuelType = "Gasoline"
                });

                dbContext.Cars.Add(new Entities.Car
                {
                    Brand = "Honda",
                    Condition = "New",
                    Category = "SUV",
                    Kilometers = 20000,
                    ReleaseDate = DateTime.Parse("2021-05-01"),
                    Color = "Red",
                    Price = 30000,
                    FuelType = "Diesel"
                });

                dbContext.Cars.Add(new Entities.Car
                {
                    Brand = "Ford",
                    Condition = "Used",
                    Category = "Truck",
                    Kilometers = 80000,
                    ReleaseDate = DateTime.Parse("2019-03-01"),
                    Color = "Black",
                    Price = 20000,
                    FuelType = "Gasoline"
                });

                dbContext.Cars.Add(new Entities.Car
                {
                    Brand = "Chevrolet",
                    Condition = "New",
                    Category = "Convertible",
                    Kilometers = 10000,
                    ReleaseDate = DateTime.Parse("2022-02-15"),
                    Color = "Yellow",
                    Price = 35000,
                    FuelType = "Electric"
                });

                dbContext.Cars.Add(new Entities.Car
                {
                    Brand = "Nissan",
                    Condition = "Used",
                    Category = "Hatchback",
                    Kilometers = 60000,
                    ReleaseDate = DateTime.Parse("2020-07-01"),
                    Color = "Green",
                    Price = 18000,
                    FuelType = "Hybrid"
                });

                dbContext.SaveChanges();
            }
        }
        private void LoadCars()
        {
            var cars = dbContext.Cars.ToList();
            dataGrid.ItemsSource = cars;
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            string selectedBrand = brandTextBox.Text;
            string selectedCondition = conditionTextBox.Text;
            string selectedCategory = categoryTextBox.Text;
            int minKilometers = string.IsNullOrEmpty(kilometersTextBox.Text) ? 0 : Convert.ToInt32(kilometersTextBox.Text);
            int maxKilometers = int.MaxValue; 
            if (!string.IsNullOrEmpty(kilometersTextBox.Text))
            {
                maxKilometers = Convert.ToInt32(kilometersTextBox.Text);
            }
            DateTime? minReleaseDate = releaseDateMinDatePicker.SelectedDate;
            DateTime? maxReleaseDate = releaseDateMaxDatePicker.SelectedDate;
            string selectedColor = colorTextBox.Text;
            decimal minPrice = string.IsNullOrEmpty(priceMinTextBox.Text) ? 0 : Convert.ToDecimal(priceMinTextBox.Text);
            decimal maxPrice = decimal.MaxValue; 
            if (!string.IsNullOrEmpty(priceMaxTextBox.Text))
            {
                maxPrice = Convert.ToDecimal(priceMaxTextBox.Text);
            }
            string selectedFuelType = fuelTypeTextBox.Text;

            var filteredCars = carFilter.ApplyFilters(selectedBrand, selectedCondition, selectedCategory, minKilometers, maxKilometers, minReleaseDate, maxReleaseDate, selectedColor, minPrice, maxPrice, selectedFuelType);

            
            filteredCars = filteredCars.OrderBy(c => c.CarId).ToList();

            dataGrid.ItemsSource = filteredCars;
        }

        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            LoadCars();
        }
    }
}
