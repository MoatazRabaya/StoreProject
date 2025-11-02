
namespace CA_Shop
{
    using System;
    using System.Collections.Generic;
    using CA_Shop;

    namespace CA_Shop
    {
        internal class Program
        {
            static Vendor vendor = new Vendor("John (Vendor)");
            static Customer customer = new Customer("Alice (Customer)");

            static void Main(string[] args)
            {
                Console.Title = "CA_Shop Console App";
                Console.WriteLine("=== Welcome to CA_Shop Interactive Demo ===");

                while (true)
                {
                    Console.WriteLine("\nMain Menu:");
                    Console.WriteLine("1. Vendor Menu");
                    Console.WriteLine("2. Customer Menu");
                    Console.WriteLine("3. Exit");
                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            VendorMenu();
                            break;
                        case "2":
                            CustomerMenu();
                            break;
                        case "3":
                            Console.WriteLine("Exiting application...");
                            return;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
            }

            static void VendorMenu()
            {
                while (true)
                {
                    Console.WriteLine("\nVendor Menu:");
                    Console.WriteLine("1. Add Category");
                    Console.WriteLine("2. View All Categories");
                    Console.WriteLine("3. Delete Category");
                    Console.WriteLine("4. Add Product to Category");
                    Console.WriteLine("5. Update Product in Category");
                    Console.WriteLine("6. View Products in Category");
                    Console.WriteLine("7. Back to Main Menu");
                    Console.Write("Enter your choice: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1": AddCategory(); break;
                        case "2": ViewAllCategories(); break;
                        case "3": DeleteCategory(); break;
                        case "4": AddProductToCategory(); break;
                        case "5": UpdateProductInCategory(); break;
                        case "6": ViewProductsInCategory(); break;
                        case "7": return;
                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
            }

            static void CustomerMenu()
            {
                while (true)
                {
                    Console.WriteLine("\nCustomer Menu:");
                    Console.WriteLine("1. View All Categories");
                    Console.WriteLine("2. View Products in a Category");
                    Console.WriteLine("3. Add Product to Cart");
                    Console.WriteLine("4. Remove Product from Cart");
                    Console.WriteLine("5. View Cart");
                    Console.WriteLine("6. Generate Bill");
                    Console.WriteLine("7. Back to Main Menu");
                    Console.Write("Enter your choice: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1": ViewAllCategories(); break;
                        case "2": ViewProductsInCategory(); break;
                        case "3": AddToCart(); break;
                        case "4": RemoveFromCart(); break;
                        case "5": ViewCart(); break;
                        case "6": GenerateBill(); break;
                        case "7": return;
                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
            }

            static void AddCategory()
            {
                Console.Write("Enter new category name: ");
                string name = Console.ReadLine();
                vendor.AddCategory(new Category(name));
                Console.WriteLine($"Category '{name}' added successfully!");
            }

            static void ViewAllCategories()
            {
                var categories = vendor.ViewAllCategories();
                if (categories.Count == 0)
                {
                    Console.WriteLine("No categories found.");
                    return;
                }

                Console.WriteLine("\nCategories:");
                foreach (var c in categories)
                {
                    Console.WriteLine($"- {c.CategoryName}");
                }
            }

            static void DeleteCategory()
            {
                Console.Write("Enter category name to delete: ");
                string name = Console.ReadLine();
                vendor.DeleteCategory(name);
            }

            static void AddProductToCategory()
            {
                Console.Write("Enter category name: ");
                string catName = Console.ReadLine();
                var category = vendor.ViewCategory(catName);

                if (category == null) return;

                Console.Write("Enter product name: ");
                string name = Console.ReadLine();
                Console.Write("Enter price: ");
                decimal price = decimal.Parse(Console.ReadLine());
                Console.Write("Enter stock quantity: ");
                int qty = int.Parse(Console.ReadLine());

                var product = new Product(name, price, qty, catName);
                category.AddProduct(product);
                Console.WriteLine("Product added successfully!");
            }

            static void UpdateProductInCategory()
            {
                Console.Write("Enter category name: ");
                string catName = Console.ReadLine();
                var category = vendor.ViewCategory(catName);
                if (category == null) return;

                Console.Write("Enter product name to update: ");
                string oldName = Console.ReadLine();

                Console.Write("Enter new product name: ");
                string name = Console.ReadLine();
                Console.Write("Enter new price: ");
                decimal price = decimal.Parse(Console.ReadLine());
                Console.Write("Enter new stock quantity: ");
                int qty = int.Parse(Console.ReadLine());

                var updated = new Product(name, price, qty, catName);
                category.UpdateProduct(oldName, updated);
                Console.WriteLine("Product updated successfully!");
            }

            static void ViewProductsInCategory()
            {
                Console.Write("Enter category name: ");
                string catName = Console.ReadLine();
                var category = vendor.ViewCategory(catName);
                if (category == null) return;

                var products = category.ViewProducts();
                if (products.Count == 0)
                {
                    Console.WriteLine("No products in this category.");
                    return;
                }

                Console.WriteLine($"\nProducts in '{catName}':");
                foreach (var p in products)
                {
                    Console.WriteLine(p.GetDetails());
                }
            }

            static void AddToCart()
            {
                Console.Write("Enter category name: ");
                string catName = Console.ReadLine();
                var category = vendor.ViewCategory(catName);
                if (category == null) return;

                Console.Write("Enter product name: ");
                string name = Console.ReadLine();
                var product = category.ViewProducts().Find(p => p.Name == name);
                if (product == null)
                {
                    Console.WriteLine("Product not found.");
                    return;
                }

                Console.Write("Enter quantity: ");
                int qty = int.Parse(Console.ReadLine());

                customer.AddToCart(product, qty);
                Console.WriteLine($"{qty} {name}(s) added to cart.");
            }

            static void RemoveFromCart()
            {
                Console.Write("Enter product name to remove: ");
                string name = Console.ReadLine();
                customer.RemoveFromCart(name);
            }

            static void ViewCart()
            {
                var cart = customer.ViewCart();
                if (cart.Count == 0)
                {
                    Console.WriteLine("Your cart is empty.");
                    return;
                }

                Console.WriteLine("\nYour Cart:");
                foreach (var item in cart)
                {
                    Console.WriteLine($"{item.Item1.Name} x {item.Item2} = {item.Item1.Price * item.Item2:C}");
                }
            }

            static void GenerateBill()
            {
                decimal total = customer.GenerateBill();
                Console.WriteLine($"\nTotal Bill: {total:C}");
            }
        }
    }


}
