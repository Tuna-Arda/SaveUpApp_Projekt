using System.Collections.ObjectModel;
using System.Linq;
using SaveUpApp.Models;
using SaveUpApp.Services;

namespace SaveUpApp.ViewModels
{
    public class ListViewModel
    {
        private ObservableCollection<Product> _products;

        public ObservableCollection<Product> Products
        {
            get => _products;
            set => _products = value;
        }

        public decimal TotalPrice => _products.Sum(x => x.Price);

        public ListViewModel(ObservableCollection<Product> products)
        {
            _products = products;
        }

        public void RemoveProduct(Product product)
        {
            if (product != null && _products.Contains(product))
            {
                _products.Remove(product);
                DataService.Save(_products);
            }
        }

        public void ClearAll()
        {
            _products.Clear();
            DataService.Save(_products);
        }
    }
}
