using System;
using System.Collections.Generic;
using System.Linq;

namespace Construction_Game
{
    class Program
    {
        private static void Main(string[] args)
        {
            var myHouse = new Building()
                .AddKitchen()
                .AddBedroom("master")
                .AddBedroom("guest")
                .AddBalcony();

            myHouse.Build();

            //kitchen, master room, guest room, balcony
            Console.WriteLine(myHouse.Describe());

            myHouse.AddKitchen().AddBedroom("another");

            //before build the house description still is as before
            //kitchen, master room, guest room, balcony
            Console.WriteLine(myHouse.Describe());
            myHouse.Build();

            //it only shows the kitchen after build
            //kitchen, master room, guest room, balcony, kitchen, another room
            Console.WriteLine(myHouse.Describe());
            Console.Read();
        }

        public class Building
        {
            public static List<string> propertyName { get; set; } = new List<string>();
            public static List<string> buildValue { get; set; } = new List<string>();
            public static List<string> describe { get; set; } = new List<string>();
            public Building AddKitchen()
            {
                propertyName.Add("kitchen");
                return this;
            }
            public Building AddBedroom(string type)
            {
                propertyName.Add(type + " room");
                return this;
            }
            public Building AddBalcony()
            {
                propertyName.Add("balcony");
                return this;
            }

            public void Build()
            {
                buildValue = propertyName;
                propertyName = new List<string>();
                describe.AddRange(buildValue);
            }

            public string Describe()
            {
                return String.Join(",", describe);
            }

        }


    }
}
