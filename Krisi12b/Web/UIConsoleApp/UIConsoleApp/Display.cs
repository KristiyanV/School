using Business;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIConsoleApp
{
    public class Display
    {
        private int closeOperationId = 8;
        private ProductBusiness productBusiness = new ProductBusiness();
        public Display()
        {
            Input();
        }
        
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 18) + "MENU" + new string('-', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new product");
            Console.WriteLine("3. Uptade Entry");
            Console.WriteLine("4. Fetch product by ID");
            Console.WriteLine("5. Delete product byID");
            Console.WriteLine("6. Add new store");
            Console.WriteLine("7. Update stock by storeId and productId");
            Console.WriteLine("8. Exit");
        }

        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1: ListAll(); break;
                    case 2: AddProduct(); break;
                    case 3: UpdateProduct(); break;
                    case 4: Fetch(); break;
                    case 5: Delete(); break;
                    case 6: AddStore(); break;
                    case 7: UpdateStock(); break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }

        private void AddStore()
        {
            Store store = new Store();
            Console.WriteLine("Enter name: ");
            store.Name = Console.ReadLine();
            Console.WriteLine("Enter town: ");
            store.Town = Console.ReadLine();
            Console.WriteLine("Enter address: ");
            store.Address = Console.ReadLine();
            Console.WriteLine("Enter phone: ");
            store.Phone = Console.ReadLine();
            productBusiness.AddStore(store);
        }

        private void UpdateStock()
        {
            Console.WriteLine("Enter StoreID to update: ");
            int storeId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter ProductID to update: ");
            int productID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter quantity: ");
            int count = int.Parse(Console.ReadLine());
            productBusiness.UpdateStock(storeId, productID, count);
        }

        private void AddProduct()
        {
            Product product = new Product();
            Console.WriteLine("Enter name: ");
            product.Name = Console.ReadLine();
            Console.WriteLine("Enter price: ");
            product.Price = decimal.Parse(Console.ReadLine());
            Category category = new Category();
            Console.WriteLine("Enter category: ");
            category.Name = Console.ReadLine();
            productBusiness.AddProduct(product, category);

        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 16) + "PRODUCTS" + new string('-', 16));
            Console.WriteLine(new string('-', 40));
            var products = productBusiness.GetAll();
            Console.WriteLine(products);
        }

        private void UpdateProduct()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Product product = productBusiness.GetProduct(id);
            if (product != null)
            {
                Console.WriteLine("Enter name: ");
                product.Name = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                product.Price = decimal.Parse(Console.ReadLine());
                Category category = new Category();
                Console.WriteLine("Enter category: ");
                category.Name = Console.ReadLine();
                productBusiness.UpdateProduct(product, category);
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Product product = productBusiness.GetProduct(id);
            Category category = productBusiness.GetCategory(product.CategoryId);
            if (product != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + product.Id);
                Console.WriteLine("Name: " + product.Name);
                Console.WriteLine("Price: " + product.Price);
                Console.WriteLine("Ctaegory: " + product.CategoryId + " " + category.Name);
                Console.WriteLine(new string('-', 40));
            }
        }

        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            productBusiness.Delete(id);
            Console.WriteLine("Done.");
        }
    }
}
