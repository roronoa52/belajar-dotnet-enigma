using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Person
    {
        private int id;
        private string name;
        private int price;

        public Person(int id, string name, int price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }


        public int getId()
        {
            return id;
        }

        public string getName()
        {
            return name;
        }

        public int getPrice()
        {
            return price;
        }
    }
}
