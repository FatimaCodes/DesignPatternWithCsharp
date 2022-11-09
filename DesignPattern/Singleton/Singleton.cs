using System;

namespace DesignPatternSample
{
    partial class Program
    {
        public sealed class Singleton
        {
            private static readonly Singleton instance = new Singleton();
            private int numberOfInstances = 0;
            //Private constructor is used to prevent
            //creation of instances with 'new' keyword outside this class
            private Singleton()
            {
                Console.WriteLine("Instantiating inside the private constructor.");
                numberOfInstances++;
                Console.WriteLine("Number of instances ={0}", numberOfInstances);
            }
            public static Singleton Instance
            {
                get
                {
                    Console.WriteLine("We already have an instance now.Use it.");
                    return instance;
                }
            }
            public static int MyInt = 25;
        }
    }
}
