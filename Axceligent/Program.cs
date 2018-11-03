using System;
using System.Collections.Generic;
using System.Linq;

namespace Axceligent
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<int> array = new List<int>();
                int i = 0;
                while (true)
                {
                    Console.WriteLine("Enter a number or 's' to stop and get result");
                    var userInput = Console.ReadLine();
                    if (userInput.ToLower() != "s")
                        array.Add(int.Parse(userInput));
                    else
                        break;

                }
                Calculate cal = new Calculate();
                var result = cal.Challenge(array.ToArray());

                Console.Write(result);              
                Console.Read();
            }
            catch (Exception ex)
            {
                //Logging if required
            }
            finally
            {
                Console.Write("Invalid input. Press any key to exit..");
                Console.ReadKey();
            }

        }


    }

    class Calculate
    {
        public int Challenge(int[] input)
        {
            var M = input.GroupBy(x => x).Select(grp => new { Count = grp.Count() }).Max(x => x.Count);
            var excludeNumbers = input.GroupBy(x => x).Select(grp => new { Key = grp.Key, Count = grp.Count() }).Where(x => x.Count < M - 1).Select(x => x.Key).ToArray();
            input = input.Where(x=> !excludeNumbers.Contains(x)).ToArray();

            List<int> sumPair = new List<int>();

           for(int i=0;i<input.Length;i++)
            {
                if (i + 1 < input.Length)
                    sumPair.Add(input[i] + input[i + 1]);
            }
            return sumPair.Max();
           
        }
    }



}
