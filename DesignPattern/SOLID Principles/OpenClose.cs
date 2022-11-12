using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.SOLID_Principles
{
    /// <summary>
    /// The Open Closed Principle (OCP) is the SOLID principle which states that the software entities (classes or methods) should be open for extension but closed for modification.
    /// Insteed of using If statement for calculate by type of developers, we should use abstraction to implement
    /// </summary>
    public class OpenClose
    {
        #region DeveloperSalaryCalculator
        public class DeveloperReport
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Level { get; set; }
            public int WorkingHours { get; set; }
            public double HourlyRate { get; set; }
        }
        public abstract class BaseSalaryCalculator
        {
            protected DeveloperReport DeveloperReport { get; private set; }

            public BaseSalaryCalculator(DeveloperReport developerReport)
            {
                DeveloperReport = developerReport;
            }

            public abstract double CalculateSalary();
        }
        public class SeniorDevSalaryCalculator : BaseSalaryCalculator
        {
            public SeniorDevSalaryCalculator(DeveloperReport report)
                : base(report)
            {
            }

            public override double CalculateSalary() => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours * 1.2;
        }
        public class JuniorDevSalaryCalculator : BaseSalaryCalculator
        {
            public JuniorDevSalaryCalculator(DeveloperReport developerReport)
                : base(developerReport)
            {
            }

            public override double CalculateSalary() => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours;
        }
        public class SalaryCalculator
        {
            private readonly IEnumerable<BaseSalaryCalculator> _developerCalculation;

            public SalaryCalculator(IEnumerable<BaseSalaryCalculator> developerCalculation)
            {
                _developerCalculation = developerCalculation;
            }

            public double CalculateTotalSalaries()
            {
                double totalSalaries = 0D;

                foreach (var devCalc in _developerCalculation)
                {
                    totalSalaries += devCalc.CalculateSalary();
                }

                return totalSalaries;
            }
        }
        #endregion
        #region FilterByMonitorType
        public enum MonitorType
        {
            OLED,
            LCD,
            LED
        }
        public enum Screen
        {
            WideScreen,
            CurvedScreen
        }
        public class ComputerMonitor
        {
            public string Name { get; set; }
            public MonitorType Type { get; set; }
            public Screen Screen { get; set; }
        }
        public interface ISpecification<T>
        {
            bool isSatisfied(T item);
        }
        public interface IFilter<T>
        {
            List<T> Filter(IEnumerable<T> monitors, ISpecification<T> specification);
        }
        public class MonitorTypeSpecification : ISpecification<ComputerMonitor>
        {
            private readonly MonitorType _type;
            public MonitorTypeSpecification(MonitorType type)
            {
                _type = type;
            }
            public bool isSatisfied(ComputerMonitor item) => item.Type == _type;
        }
        public class ScreenSpecification : ISpecification<ComputerMonitor>
        {
            private readonly Screen _screen;

            public ScreenSpecification(Screen screen)
            {
                _screen = screen;
            }
            public bool isSatisfied(ComputerMonitor item) => item.Screen == _screen;
        }

        public class MonitorFilter : IFilter<ComputerMonitor>
        {
            public List<ComputerMonitor> Filter(IEnumerable<ComputerMonitor> monitors, ISpecification<ComputerMonitor> specification) =>
                monitors.Where(m => specification.isSatisfied(m)).ToList();
        }

        #endregion
    }
}
