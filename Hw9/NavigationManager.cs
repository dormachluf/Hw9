using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hw9
{
    enum Cars { private_car = 1, bike, taxi }
    internal class NavigationManager
    {
        Cars car;
        string curr_place;
        string[] des_place;
        int des_num;

        public NavigationManager(Cars car, string curr_place)
        {
            Curr_place = curr_place;
            Car = car;
        }

        public string Curr_place { get => curr_place; set => curr_place = value; }
        public string[] Des_place { get => des_place; set => des_place = value; }
        internal Cars Car { get => car; set => car = value; }
        public override string ToString()
        {
            return $"Vehicle: {car}\nFrom: {des_place[0]}\nCurr Place: {curr_place}\nAmount of Destinations: {des_num}";
        }

        public void ShowRecentLocations()
        {
            foreach (string location in Des_place)
            {
                Console.Write($"{location} ");
            }
        }
        public void AddAddress(string addres)
        {
            if (!des_place.Contains(addres))
            {
                Array.Resize(ref des_place, des_place.Length + 1);
                des_place[des_place.Length - 1] = addres;
            }   
            
        }
    }
}
