using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw9
{
    internal abstract class AppSystem :IComparable<AppSystem>
    {
        static uint _uint;
        uint serial;
        string name;
        float price;
        DateTime date;
        public AppSystem(string name, float price)
        {
            date = DateTime.Now;
            Name = name;
            Price = price;
            serial = ++Uint;
        }

        public static uint Uint { get => _uint; set => _uint = value; }
        public string Name
        {
            get => name;
            set
            {
                if (value == null)
                    throw new ArgumentNullException("App needs a name.");
                name = value;
                
            }
        }

        public float Price
        {
            get => price;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Price has to be bigger than 0.");
                price = value;
            }
        }

        public override string ToString()
        {
            return $"App name: {Name}\nSerial num: {serial}\nApp price: {Price}\nDate of installing: {date}";
        }
        public abstract string AppSystemPurpose();

        public int CompareTo(AppSystem other)
        {
            return name.CompareTo(other.name);
        }
    }
}
