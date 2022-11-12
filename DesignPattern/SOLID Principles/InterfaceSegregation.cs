using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.SOLID_Principles
{
    public class InterfaceSegregation
    {
        #region Car
        public interface ICar
        {
            void Drive();
        }
        public interface IAirplane
        {
            void Fly();
        }
        public class Car : ICar
        {
            public void Drive()
            {
                //actions to drive a car
                Console.WriteLine("Driving a car");
            }
        }
        public class Airplane : IAirplane
        {
            public void Fly()
            {
                //actions to fly a plane
                Console.WriteLine("Flying a plane");
            }
        }
        public class MultiFunctionalCar : ICar, IAirplane
        {
            public void Drive()
            {
                //actions to start driving car
                Console.WriteLine("Drive a multifunctional car");
            }

            public void Fly()
            {
                //actions to start flying
                Console.WriteLine("Fly a multifunctional car");
            }
        }
        #endregion
        #region Printer
        public interface IPrinterTasks
        {
            void Print(string PrintContent);
            void Scan(string ScanContent);
        }
        interface IFaxTasks
        {
            void Fax(string content);
        }
        interface IPrintDuplexTasks
        {
            void PrintDuplex(string content);
        }

        public class HPLaserJetPrinter : IPrinterTasks, IFaxTasks, IPrintDuplexTasks
        {
            public void Print(string PrintContent)
            {
                Console.WriteLine("Print Done");
            }
            public void Scan(string ScanContent)
            {
                Console.WriteLine("Scan content");
            }
            public void Fax(string FaxContent)
            {
                Console.WriteLine("Fax content");
            }
            public void PrintDuplex(string PrintDuplexContent)
            {
                Console.WriteLine("Print Duplex content");
            }
        }
        public class LiquidInkjetPrinter : IPrinterTasks
        {
            public void Print(string PrintContent)
            {
                Console.WriteLine("Print Done");
            }
            public void Scan(string ScanContent)
            {
                Console.WriteLine("Scan content");
            }
        }
        #endregion
    }
}
