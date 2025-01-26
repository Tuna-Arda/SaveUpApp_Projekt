using System.Collections.ObjectModel;
using SaveUpApp.Models;
using SaveUpApp.Services;

namespace SaveUpApp.ViewModels
{
    public class AddProductViewModel
    {
        private readonly ObservableCollection<Product> _products;

        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime SavedDate { get; set; } = DateTime.Now;

        public AddProductViewModel(ObservableCollection<Product> products)
        {
            _products = products;
        }

        public bool SaveProduct()
        {
            if (!string.IsNullOrWhiteSpace(Description) && Price > 0)
            {
                var newProduct = new Product
                {
                    Description = Description,
                    Price = Price,
                    SavedDate = SavedDate
                };

                _products.Add(newProduct);
                DataService.Save(_products);
                return true;
            }
            return false;
        }
    }
}
