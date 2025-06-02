using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Hw9
{
    internal class MobileDevice
    {
        string user_name;
        int total_apps;
        public string Password { get; set; }
        public bool Is_active { get; set; }
        public int Connect_num { get; set; }
        AppSystem[] appSystemKatan;

        public MobileDevice(string user_name, string password)
        {
            User_name = user_name;
            Password = password;
            appSystemKatan = new AppSystem[0];
            Total_apps = 0;
        }
        public void SortApps()
        {
            Array.Sort(appSystemKatan);
        }
        public string User_name
        {
            get => user_name;
            set
            {
                foreach (char ch in value)
                {
                    if (!(char.IsLetter(ch)))
                        throw new ArgumentException("your username must includ only letters");
                }
                user_name = value;
            }
        }

        public int Total_apps
        {
            get => total_apps;
            set => total_apps = value;
        }

        public void AddApp(AppSystem app)
        {
            foreach (AppSystem System in appSystemKatan)
            {
                if (System.Name == app.Name)
                {
                    throw new ArgumentException("The app is all ready installed");
                }
            }
            Array.Resize(ref appSystemKatan, appSystemKatan.Length + 1);
            appSystemKatan[appSystemKatan.Length - 1] = app;
        }
        public void showListAppNavigation()
        {
            foreach (AppSystem app in appSystemKatan)
            {
                if (app is Navigation nav_app)
                    Console.WriteLine($"App name: {nav_app.Name} App seiral num: {nav_app.Serial}");
            }
        }
        public override string ToString()
        {
            string apps_name = null;
            foreach (AppSystem app in appSystemKatan)
            {
                apps_name += $"the name of the app is: {app.Name}\n";
            }
            return $"user name: {User_name}\npassword: {Password}\nis the user logged in: {Is_active}\napp installed: {Total_apps}\n" +
                $"the amount of login attempts: {Connect_num}\nAPPS:\n{apps_name}";
        }
        public Navigation PopularNavigationApp()
        {
            Navigation highest = null;

            foreach (AppSystem app in appSystemKatan)
            {
                if (app is Navigation nav_app)
                {
                    if (highest.Manager.Des_place.Length < nav_app.Manager.Des_place.Length || highest == null)
                    {
                        highest = nav_app;
                    }

                }

            }
            if (highest == null)
                Console.WriteLine("the are no navigation app in the device");
            return highest;
        }
        public bool login(string user_name, string password)
        {
            Connect_num++;
            if (Connect_num > 8)
            {
                throw new Exception("user is blocked, the system is shutting down.");

            }
            if (user_name == User_name && password == Password)
                return true;
            if (Connect_num > 2)
                System.Threading.Thread.Sleep(15000);

            return false;
        }
    }
}
