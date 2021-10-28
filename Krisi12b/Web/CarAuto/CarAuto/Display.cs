using Business;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAuto
{
    public class Display
    {
        private int closeOperationId = 8;
        private CarsBusiness carsBusiness = new CarsBusiness();
        public Display()
        {
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 18) + "MENU" + new string('-', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add new Owner");
            Console.WriteLine("2. Update Owner");
            Console.WriteLine("3. Add new models cars");
            Console.WriteLine("4. Show all models");
            Console.WriteLine("5. Show all Owners models");
            Console.WriteLine("6. Show current models by ID");
            Console.WriteLine("7. Update models");
            Console.WriteLine("8. Delete models");
            Console.WriteLine("9. Exit");
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
                    case 1: AddOwner(); break;
                    case 2: UpdateOwner(); break;
                    case 3: AddCars(); break;
                    case 4: ShowModels(); break;
                    case 5: GetOwner(); break;
                    case 6: ShowModelsId(); break;
                    case 7: UpdateModels(); break;
                    case 8: Delete(); break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }
        private void AddOwner()
        {
            CarOwner carOwner = new CarOwner();
            Console.WriteLine("Enter Id: ");
            carOwner.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter First Name: ");
            carOwner.FirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            carOwner.LastName = Console.ReadLine();
            Console.WriteLine("Enter Town: ");
            carOwner.Town = Console.ReadLine();
            carsBusiness.AddOwner(carOwner);
        }

        private void UpdateOwner()
        {
            CarOwner carOwner = new CarOwner();
            Console.WriteLine("Update Id: ");
            carOwner.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Update First Name: ");
            carOwner.FirstName = Console.ReadLine();
            Console.WriteLine("Update Last Name: ");
            carOwner.LastName = Console.ReadLine();
            Console.WriteLine("Update Town: ");
            carOwner.Town = Console.ReadLine();
            carsBusiness.UpdateOwner(carOwner);
        }

        private void AddCars()
        {
            Cars cars = new Cars();
            Console.WriteLine("Add Id: ");
            cars.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Add Models: ");
            cars.Models = Console.ReadLine();
            Console.WriteLine("Add Year: ");
            cars.Year = int.Parse(Console.ReadLine());
            Console.WriteLine("Add CarsYear: ");
            cars.CarsOwnerId = int.Parse(Console.ReadLine());
            carsBusiness.AddCars(cars);
        }

        private void ShowModels()
        {
            Console.WriteLine(carsBusiness.GetModels());
        }

        private void GetOwner()
        {
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(carsBusiness.GetOwner(id));
        }

        private void ShowModelsId()
        {
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(carsBusiness.ShowModels(id));
        }

        private void UpdateModels()
        {
            Cars cars = new Cars();
            Console.WriteLine("Update Id: ");
            cars.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Update Models: ");
            cars.Models = Console.ReadLine();
            Console.WriteLine("Update Year: ");
            cars.Year = int.Parse(Console.ReadLine());
            Console.WriteLine("Update Cars Owner Id: ");
            cars.CarsOwnerId = int.Parse(Console.ReadLine());
            carsBusiness.UpdateModels(cars);
        }

        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            carsBusiness.Delete(id);
            Console.WriteLine("Done.");
        }
    }
}
