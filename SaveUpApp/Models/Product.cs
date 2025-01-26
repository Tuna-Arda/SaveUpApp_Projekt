namespace SaveUpApp.Models
{
    public class Product
    {
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime SavedDate { get; set; } = DateTime.Now;

        public Product() { }
    }
}
