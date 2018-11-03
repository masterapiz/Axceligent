using System;
using System.Collections.Generic;
using System.Threading;

namespace UserClass
{
    class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                var user = new User();
                Console.WriteLine("please enter the username, or q to exit");
                var userName = Console.ReadLine();
                if (userName == "q")
                {
                    break;
                }

                user.Add(userName);
                Console.WriteLine($"number of addedUser {user.GetUsersCount()}");
            }
        }
    }
    class User
    {
        public static List<string> userData = new List<string>();
        public void Add(string userName)
        {
            userData.Add(userName);
        }

        public int GetUsersCount()
        {
            return userData.Count;
        }
    }




}
