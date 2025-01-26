using System.Collections.ObjectModel;
using System.Linq;
using Microcharts;
using SkiaSharp;
using SaveUpApp.Models;

namespace SaveUpApp.ViewModels
{
    public class ChartViewModel
    {
        private readonly ObservableCollection<Product> _products;

        public bool HasNoData => _products.Count == 0;

        public Chart ProductChart { get; private set; } = null!;

        public ChartViewModel(ObservableCollection<Product> products)
        {
            _products = products;
            BuildChart();
        }

        private void BuildChart()
        {
            var entries = _products.Select((p, index) => new ChartEntry((float)p.Price)
            {
                Label = p.Description ?? "",
                ValueLabel = p.Price.ToString("F2"),
                Color = GetColor(index)
            })
            .ToList();

            ProductChart = new DonutChart
            {
                Entries = entries,
                HoleRadius = 0.5f,
                LabelTextSize = 32,
            };
        }

        private SKColor GetColor(int index)
        {
            var colors = new SKColor[]
            {
                SKColors.Red,
                SKColors.Green,
                SKColors.Blue,
                SKColors.Orange,
                SKColors.Purple,
                SKColors.Teal,
                SKColors.Brown
            };
            return colors[index % colors.Length];
        }
    }
}
