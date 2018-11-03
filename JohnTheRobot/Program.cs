using System;

namespace JohnTheRobot
{
    class Program
    {
        private static void Main(string[] args)
        {
            var john = new Humanoid(new Dancing());
            Console.WriteLine(john.ShowSkill()); //print dancing

            var alex = new Humanoid(new Cooking());
            Console.WriteLine(alex.ShowSkill());//print cooking

            var bob = new Humanoid();
            Console.WriteLine(bob.ShowSkill());//print no skill is defined     

            Console.WriteLine("press any key to exit ...");
            Console.ReadKey();
        }

        private class Humanoid
        {
            private Dancing dancing;
            private Cooking cooking;           

            public Humanoid(Dancing dancing)
            {
                this.dancing = dancing;
            }
            public Humanoid(Cooking cooking)
            {
                this.cooking = cooking;
            }
            public Humanoid() { }
           

            public virtual string ShowSkill()
            {
                if (this.dancing != null)
                    return this.dancing.ShowSkill();
                else if (this.cooking != null)
                    return this.cooking.ShowSkill();               
                else
                    return "no skill is defined";              

            }
        }

        class Dancing : Humanoid
        {
            public override string ShowSkill()
            {
                return "dancing";
            }
        }

        class Cooking : Humanoid
        {
            public override string ShowSkill()
            {
                return "cooking";
            }
        }      

    }
}
