using SkiaSharp;

namespace Microcharts
{
    internal class Entry
    {
        private float price;

        public Entry(float price)
        {
            this.price = price;
        }

        public string Label { get; set; }
        public string ValueLabel { get; set; }
        public SKColor Color { get; set; }







       
    }


}