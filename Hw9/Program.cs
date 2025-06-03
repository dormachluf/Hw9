using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw9
{
    internal class Program 
    {
        const double nav_tax = 1.12;
        const double soc_tax = 1.13;

        static void Main(string[] args)
        {
            MobileDevice my_device = null;
            while (true) {
                Console.Write("Please enter your desired username: ");
                string user_name = Console.ReadLine();
                Console.Write("Please enter your desired password: ");
                string pass = Console.ReadLine();

                // System.Threading.Thread.Sleep(15000);
                try {
                    my_device = new MobileDevice(user_name, pass);
                    break;
                }
                catch (ArgumentException ex) {
                    Console.WriteLine(ex.Message);
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            Login(my_device);

            bool is_running = true;
            while (is_running)
            {
                Console.Clear();
                Console.WriteLine("===== Main Menu =====");
                Console.WriteLine("1. Download a new app");
                Console.WriteLine("2. View most used navigation app");
                Console.WriteLine("3. Navigate using app");
                Console.WriteLine("4. Print device specifications");
                Console.WriteLine("5. Sort installed apps");
                Console.WriteLine("6. Shut down device");
                Console.Write("Choose an option (1-6): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("\n-- App Type Selection --");
                        Console.WriteLine(" 1 - Navigation App");
                        Console.WriteLine(" 2 - Social App");
                        Console.WriteLine(" Any other key - Back to Menu");
                        Console.Write("Your selection: ");
                        string selction = Console.ReadLine();
                        if (selction == "1" || selction == "2")
                        {
                            try {
                                MakeApp(ref my_device, selction);
                            }
                            catch (ArgumentException ex) {
                                Console.WriteLine(ex.Message);
                            }
                            
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine(my_device.PopularNavigationApp());
                        break;
                    case "3":
                        Console.Clear();
                        AddLocation(my_device);
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine(my_device);
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("app sorted by name");
                        my_device.SortApps();
                        break;
                    case "6":
                        Console.WriteLine("\nShutting down... Goodbye!");
                        is_running = false;
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice. Please select 1-6.");
                        break;
                }

                if (is_running)
                {
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                }
            }
        }

        private static void AddLocation(MobileDevice my_device) {
            bool is_found = false;
            my_device.showListAppNavigation();

            Console.WriteLine("Enter the name of the app you want to use.");
            string use_name = Console.ReadLine();

            foreach (AppSystem app in my_device.AppSystemKatan) {
                if (use_name == app.Name) {
                    Console.WriteLine(((Navigation)app).Manager);

                    Console.Write("Please enter where you wanna go: ");
                    ((Navigation)app).Manager.AddAddress(Console.ReadLine());
                    is_found = true;
                    Console.WriteLine("Have a safe drive!");
                }
            }
            if (!is_found)
                Console.WriteLine("No nav app with this name");
        }

        private static void MakeApp(ref MobileDevice my_device,string selction)
        {
            AppSystem app = null;

            Console.WriteLine("\n============================");
            Console.WriteLine("||   App Creation         ||");
            Console.WriteLine("============================");

            Console.Write("--> Enter a name for the app: ");
            string name = Console.ReadLine();

            Console.Write("--> Please enter the price: ");
            float price = float.Parse(Console.ReadLine());

            if (selction == "1")
            {
                
                Console.WriteLine("\n----------------------------");
                Console.WriteLine(" Select Type of Vehicle");
                Console.WriteLine("----------------------------");
                Console.WriteLine("  1 - Private Car");
                Console.WriteLine("  2 - Bike");
                Console.WriteLine("  3 - Taxi");
                Console.Write("Your choice: ");

                int temp = int.Parse(Console.ReadLine());

                if (temp >= 1 && temp <= 3)
                {
                    Cars car = (Cars)temp;

                    Console.Write("--> Enter your current location: ");
                    string curr_location = Console.ReadLine();

                    NavigationManager navm = new NavigationManager(car, curr_location);
                    app = new Navigation(navm, name, price);
                    ((Navigation)app).AddVat(nav_tax);
                    my_device.AddApp(app);
                }
                else
                {
                    Console.WriteLine("[Error] Please enter a number between 1 and 3.");
                }
            }
            else
            {
                Console.Write("--> Is the app corporate? (Yes/No): ");
                string corp = Console.ReadLine();

                bool is_corp = false;
                if (corp.ToLower() == "yes")
                    is_corp = true;

                try
                {
                    Console.Write("--> What is the rating of the app? (1-5): ");
                    int rating = int.Parse(Console.ReadLine());

                    app = new Social(is_corp, rating, name, price);
                    ((Social)app).AddVat(soc_tax);
                    my_device.AddApp(app);


                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("[Argument Error] " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[Error] Please enter valid input.");

                }

            }
        }

        private static void Login(MobileDevice my_device)
        {
            string user_name, pass;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Welcome to the App =====");
                Console.Write("Username: ");
                user_name = Console.ReadLine();
                Console.Write("Password: ");
                pass = Console.ReadLine();
                try
                {
                    if (my_device.login(user_name, pass))
                    {
                        Console.WriteLine("You have logged in. \n");
                        System.Threading.Thread.Sleep(2000);
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Your username or password was incorrect, please try again\n" +
                            $"loggedin attempts: {my_device.Connect_num} you will be blocked at 9 attempts.");
                        System.Threading.Thread.Sleep(3000);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }
    }
}
