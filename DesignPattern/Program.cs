using DesignPattern.SOLID_Principles;
using DesignPatternSample.Builder;
using System;
using static DesignPatternSample.Program;

namespace DesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CallerClass.SingleResponsibilityCaller();
            CallerClass.OpenCloseDeveloperSalaryCaller();
            CallerClass.OpenCloseMonitorFilterCaller();
            CallerClass.LisKovSubstitution();
            CallerClass.DependencyInversion();

            //#region Singleton
            //Console.WriteLine("***Singleton Pattern Demo***\n");
            ////Console.WriteLine(Singleton.MyInt);
            //// Private Constructor.So,we cannot use 'new' keyword.            
            //Console.WriteLine("Trying to create instance s1.");
            //Singleton s1 = Singleton.Instance;
            //Console.WriteLine("Trying to create instance s2.");
            //Singleton s2 = Singleton.Instance;
            //if (s1 == s2)
            //{
            //    Console.WriteLine("Only one instance exists.");
            //}
            //else
            //{
            //    Console.WriteLine("Different instances exist.");
            //}
            //Console.Read();
            //#endregion
            //#region ProtoType
            //Console.WriteLine("***Prototype Pattern Demo***\n");
            ////Base or Original Copy
            //BasicCar nano_base = new Nano("Green Nano") { Price = 100000 };
            //BasicCar ford_base = new Ford("Ford Yellow") { Price = 500000 };
            //BasicCar bc1;
            ////Nano
            //bc1 = nano_base.Clone();
            //bc1.Price = nano_base.Price + BasicCar.SetPrice();
            //Console.WriteLine("Car is: {0}, and it's price is Rs. {1} ", bc1.ModelName, bc1.Price);
            ////Ford            
            //bc1 = ford_base.Clone();
            //bc1.Price = ford_base.Price + BasicCar.SetPrice();
            //Console.WriteLine("Car is: {0}, and it's price is Rs. {1}", bc1.ModelName, bc1.Price);
            //Console.ReadLine();
            //#endregion
            //#region Builder
            //Console.WriteLine("***Builder Pattern Demo***");
            //Director director = new Director();
            //IBuilder b1 = new Car("Ford");
            //IBuilder b2 = new MotorCycle("Honda");
            //// Making Car
            //director.Construct(b1);
            //Product p1 = b1.GetVehicle();
            //p1.Show();
            ////Making MotorCycle
            //director.Construct(b2);
            //Product p2 = b2.GetVehicle();
            //p2.Show();
            //Console.ReadLine();
            //#endregion
        }
    }
}
