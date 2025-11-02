
namespace CA_Shop
{
    public class Customer : User
    {
        public List<Tuple<Product,int>> Cart {  get; private set; }

        public Customer(string name) : base(name, "Customer") 
        {
            this.Cart = new();
        }

        public void AddToCart(Product product, int quantity)
        {
            if (quantity < 1)
            {
                Console.WriteLine("The quantity of the product can't be negative or zero");
                return;
            }

            if(quantity > product.StockQuantity)
            {
                Console.WriteLine("The Stock Quantity of the product isn't enough");
                return;
            }

            var tuple = FindTuple(product.Name);

            if (tuple is null)
            {
                Cart.Add(Tuple.Create(product, quantity));
            }
                
            else
            {
                Cart.Remove(tuple);
                Cart.Add(Tuple.Create(product, quantity+tuple.Item2));
            }               

            product.UpdateStock(-quantity);
        }

        public void RemoveFromCart(string productName)
        {
            Tuple<Product, int> tuple = FindTuple(productName);
           
            if (tuple == null)
            {
                Console.WriteLine("The product doesn't exists on the Cart");
                return;
            }

            tuple.Item1.UpdateStock(tuple.Item2);
            Cart.Remove(tuple);
        }

        public List<Tuple<Product, int>> ViewCart()
        {
            return Cart;
        }

        public decimal GenerateBill()
        {
            decimal bill = 0.0m;

            foreach (var item in Cart)
                bill += item.Item1.CalculateTotalPrice(item.Item2);

            return bill;
        }

        private Tuple<Product, int> FindTuple(string productName)
        {
            foreach (var item in Cart)
            {
                if (item.Item1.Name == productName)
                {
                    return item;
                }
            }
            return null;
        }

    }

}
