
namespace CA_Shop
{
    public class Product
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public string Category { get; private set; }

        public Product(string name, decimal price, int stockQuantity, string category)
        {            
            this.Name = name;
            this.Price = price;
            this.StockQuantity = stockQuantity;
            this.Category = category;
        }

        public void UpdateStock(int quantity)
        {
            this.StockQuantity += quantity;
        }

        public string GetDetails()
        {
            return $"{Name} {Price} {StockQuantity} {Category}";       
        }

        public decimal CalculateTotalPrice(int quantity)
        {
            if (quantity < 0)
            {
                Console.WriteLine("The quantity can't be negative");
                return 0;
            }

            return Price * quantity;
        }

    }

}
