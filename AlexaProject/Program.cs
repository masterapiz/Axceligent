using System;

namespace AlexaProject
{
    class Program
    {
        private static void Main(string[] args)
        {
            var alexa = new Alexa();
            Console.WriteLine(alexa.Talk()); //print hello, i am Alexa

            alexa.Configure(x =>
            {
                x.GreetingMessage = "Hello {OwnerName}, I'm at your service";
                x.OwnerName = "Bob Marley";
                return x; // Added.
            });

            Console.WriteLine(alexa.Talk()); //print Hello Bob Marley, I'm at your service

            Console.WriteLine("press any key to exit ...");
            Console.ReadKey();

           
        }

    }

    internal class Alexa
    {
        private AlexaSetting _config;

        internal class AlexaSetting
        {
            public string GreetingMessage { get; set; }
            public string OwnerName { get; set; }

            public string GetGreeting()
            {
                return GreetingMessage.Replace($"{{{nameof(OwnerName)}}}", OwnerName);
            }
        }

        public Alexa()
        {
            _config = new AlexaSetting()
            {
                GreetingMessage = $"hello, i am {nameof(Alexa)}"
            };
        }

        public string Talk()
        {
            return _config.GetGreeting();
        }       


        public void Configure(Func<AlexaSetting, AlexaSetting> value)
        {
            value(_config);            
        }



    }
}
