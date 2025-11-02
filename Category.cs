
namespace CA_Shop
{
    public class Category
    {
        public string CategoryName { get; private set; }
        public List<Product> Products { get; private set; }

        public Category(string categoryName) 
        { 
            this.CategoryName=categoryName;
            this.Products = new();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(string productName)
        {
            Product product = FindProduct(productName);
            if(product is null)
            {
                Console.WriteLine("This product doesn't exists");
                return;
            }

            Products.Remove(product);    
        }

        public void UpdateProduct(string productName, Product updatedProduct)
        {
            Product product = FindProduct(productName);
            if (product is null)
            {
                Console.WriteLine("This product doesn't exists");
                return;
            }

            int index = Products.IndexOf(product);
            Products[index] = updatedProduct;
        }

        public List<Product> ViewProducts()
        {
            return Products;
        }

        private Product FindProduct(string productName) => Products.Find((Product p) => p.Name == productName);


    }

}
