using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw9
{
    internal class Navigation : AppSystem , Iapp
    {
        NavigationManager manager;
        public void AddVat(double tax)
        {
            Price *= (float)tax;
        }
        public Navigation(NavigationManager manager,string name,float price):base (name,price)
        {
            this.manager = manager;
            
        }
        public override string ToString() {
            return base.ToString();
        }
        public override string AppSystemPurpose()
        {
            return "Catch The Road - Choose The Best Way";

        }



    }
}
