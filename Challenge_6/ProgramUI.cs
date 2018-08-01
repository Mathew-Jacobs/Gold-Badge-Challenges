using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_6
{
    public class ProgramUI
    {
        CarRepository _carRepo = new CarRepository();

        public void Run()
        {
            InitCars();
            bool loop = true;
            while (loop)
            {
                string menu = ConsoleMenu();
                switch (menu)
                {
                    case "1":
                        CreateCar();
                        break;
                    case "2":
                        EditCar();
                        break;
                    case "3":
                        ViewCar();
                        break;
                    case "4":
                        ViewTypeCars();
                        break;
                    default:
                        break;
                }
            }
        }



        private void InitCars()
        {
            Car[] car = new Car[9];
            car[0] = new Car("Tesla", "Model S", 2017, 125.00m, CarTypes.Electric);
            car[1] = new Car("Nissan", "Leaf", 2018, 125.00m, CarTypes.Electric);
            car[2] = new Car("Volkswagon", "e-Golf", 2017, 126.00m, CarTypes.Electric);
            car[3] = new Car("Toyota", "Prius", 2017, 43.00m, CarTypes.Hybrid);
            car[4] = new Car("Ford", "Fusion", 2018, 34.00m, CarTypes.Hybrid);
            car[5] = new Car("Honda", "Accord", 2018, 38.00m, CarTypes.Hybrid);
            car[6] = new Car("Honda", "Civic", 2018, 32.00m, CarTypes.Gas);
            car[7] = new Car("Ford", "Mustang", 2019, 21.00m, CarTypes.Gas);
            car[8] = new Car("Chrysler", "Pacifica", 2019, 19.00m, CarTypes.Gas);

            for (int i = 0; i < car.Length; i++)
            {
                _carRepo.AddCar(car[i]);
            }
        }

        private string ConsoleMenu()
        {
            Console.WriteLine($"\r\nWhat would you like to do?\r\n" +
                $"\r\n" +
                $"[1] Add new Car\r\n" +
                $"[2] Edit existing Car information\n" +
                $"[3] View Car\n" +
                $"[4] View Cars by Type\n" +
                $"[X] Exit\n");
            System.ConsoleKeyInfo input = Console.ReadKey();
            Console.Clear();
            return input.KeyChar.ToString();
        }

        private void CreateCar()
        {
            Console.Clear();
            Console.WriteLine("\nWhat type of car is this?\n" +
                "[1] Electric\n" +
                "[2] Hybrid\n" +
                "[3] Gas\n" +
                "[4] Cancel\n");
            System.ConsoleKeyInfo input = Console.ReadKey();
            Console.Clear();
            int type = int.Parse(input.KeyChar.ToString());
            if (type == 1 || type == 2 || type == 3)
            {
                Console.WriteLine("\nEnter the make:");
                string make = Console.ReadLine();
                Console.WriteLine("\nEnter the model:");
                string model = Console.ReadLine();
                Console.WriteLine("\nEnter the year:");
                int year = int.Parse(Console.ReadLine());
                Console.WriteLine("\nEnter the MPG / MPGe:");
                decimal mpg = decimal.Parse(Console.ReadLine());
                Car newCar = new Car(make, model, year, mpg, (CarTypes)type - 1);
                _carRepo.AddCar(newCar);
            }
            Console.Clear();
        }

        private void EditCar()
        {
            Console.Clear();
            Console.WriteLine("\nWhat type of car is this?\n" +
                "[1] Electric\n" +
                "[2] Hybrid\n" +
                "[3] Gas\n" +
                "[4] Cancel\n");
            System.ConsoleKeyInfo input = Console.ReadKey();
            Console.Clear();
            int type = int.Parse(input.KeyChar.ToString());
            if (type == 1 || type == 2 || type == 3)
            {
                List<Car> search = _carRepo.GetCars((CarTypes)type - 1);
                Console.WriteLine("\nEnter the make:");
                string make = Console.ReadLine();
                Console.WriteLine("\nEnter the model:");
                string model = Console.ReadLine();
                Console.WriteLine("\nEnter the year:");
                int year = int.Parse(Console.ReadLine());

                Console.Clear();
                foreach (Car car in search)
                {
                    if (car.Make == make && car.Model == model && car.Year == year)
                    {
                        bool loop = true;
                        while (loop)
                        {
                            Console.WriteLine("Make\t\tModel\t\tYear\t\tMPG\t\tType\n");
                            Console.WriteLine(car);
                            Console.WriteLine("\n" +
                                "What would you like to update?\n" +
                                "[1] Make\n" +
                                "[2] Model\n" +
                                "[3] Year\n" +
                                "[4] Miles per Gallon\n" +
                                "[5] Type of Car\n" +
                                "[6] Delete Car\n" +
                                "[7] Nothing\n");
                            System.ConsoleKeyInfo editInput = Console.ReadKey();
                            Console.Clear();
                            int edit = int.Parse(editInput.KeyChar.ToString());
                            if (edit == 1 || edit == 2 || edit == 3 || edit == 4 || edit == 5 || edit == 6)
                            {
                                UpdateCar(car, edit);
                            }
                            else
                            {
                                loop = false;
                                break;
                            }
                        }
                    }
                }
                Console.Read();
            }
        }

        private void ViewCar()
        {
            Console.Clear();
            Console.WriteLine("\nWhat type of car is this?\n" +
                "[1] Electric\n" +
                "[2] Hybrid\n" +
                "[3] Gas\n" +
                "[4] Cancel\n");
            System.ConsoleKeyInfo input = Console.ReadKey();
            Console.Clear();
            int type = int.Parse(input.KeyChar.ToString());
            if (type == 1 || type == 2 || type == 3)
            {
                List<Car> search = _carRepo.GetCars((CarTypes)type - 1);
                Console.WriteLine("\nEnter the make:");
                string make = Console.ReadLine();
                Console.WriteLine("\nEnter the model:");
                string model = Console.ReadLine();
                Console.WriteLine("\nEnter the year:");
                int year = int.Parse(Console.ReadLine());

                Console.Clear();
                foreach (Car car in search)
                {
                    if (car.Make == make && car.Model == model && car.Year == year)
                    {
                        Console.WriteLine("Make\t\tModel\t\tYear\t\tMPG\t\tType\n");
                        Console.WriteLine(car);
                        Console.WriteLine("\n\n" +
                            "Press Any Key to Continue:");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
        }

        private void ViewTypeCars()
        {
            Console.Clear();
            Console.WriteLine("\nWhat type of car?\n" +
                "[1] Electric\n" +
                "[2] Hybrid\n" +
                "[3] Gas\n" +
                "[4] Cancel\n");
            System.ConsoleKeyInfo input = Console.ReadKey();
            Console.Clear();
            int type = int.Parse(input.KeyChar.ToString());
            if (type == 1 || type == 2 || type == 3)
            {
                List<Car> search = _carRepo.GetCars((CarTypes)type - 1);
                Console.Clear();
                Console.WriteLine("Make\t\tModel\t\tYear\t\tMPG\t\tType\n");
                foreach (Car car in search)
                {
                    Console.WriteLine(car);
                }
                Console.WriteLine("\n\n" +
                    "Press Any Key to Continue:");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void UpdateCar(Car editCar, int editChoice1to6)
        {
            switch (editChoice1to6)
            {
                case 1:
                    //--Edit Make
                    _carRepo.RemoveCar(editCar);
                    Console.WriteLine("Enter the new Make:");
                    string make = Console.ReadLine();
                    editCar.Make = make;
                    Console.Clear();

                    _carRepo.AddCar(editCar);
                    break;
                case 2:
                    //--Edit Model
                    _carRepo.RemoveCar(editCar);
                    Console.WriteLine("Enter the new Model:");
                    string model = Console.ReadLine();
                    editCar.Model = model;
                    Console.Clear();

                    _carRepo.AddCar(editCar);
                    break;
                case 3:
                    //--Edit Year
                    _carRepo.RemoveCar(editCar);
                    Console.WriteLine("Enter the new Year:");
                    int year = int.Parse(Console.ReadLine());
                    editCar.Year = year;
                    Console.Clear();

                    _carRepo.AddCar(editCar);
                    break;
                case 4:
                    //--Edit MPG
                    _carRepo.RemoveCar(editCar);
                    Console.WriteLine("Enter the new MPG:");
                    decimal mpg = decimal.Parse(Console.ReadLine());
                    editCar.MPG = mpg;
                    Console.Clear();

                    _carRepo.AddCar(editCar);
                    break;
                case 5:
                    //--Edit Type
                    Console.WriteLine("\nWhat new type of car is this?\n" +
                        "[1] Electric\n" +
                        "[2] Hybrid\n" +
                        "[3] Gas\n" +
                        "[4] Cancel\n");
                    System.ConsoleKeyInfo input = Console.ReadKey();
                    int type = int.Parse(input.KeyChar.ToString());
                    if (type == 1 || type == 2 || type == 3)
                    {
                        _carRepo.RemoveCar(editCar);
                        editCar.CarType = (CarTypes)type - 1;
                        _carRepo.AddCar(editCar);

                    }
                    Console.Clear();

                    break;
                case 6:
                    //--Delete Car
                    Console.WriteLine("Are you sure?\n" +
                        "y/n\n");
                    System.ConsoleKeyInfo ans = Console.ReadKey();
                    string answer = ans.KeyChar.ToString();
                    switch (answer)
                    {
                        case "y":
                            _carRepo.RemoveCar(editCar);
                            break;

                        default:
                            break;
                    }
                    Console.Clear();
                    break;
                default:
                    break;
            }

        }
    }
}

