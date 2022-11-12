using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DesignPattern.SOLID_Principles.OpenClose;
using static DesignPattern.SOLID_Principles.SingleResponsibility;

namespace DesignPattern.SOLID_Principles
{
    public static class CallerClass
    {
        public static void SingleResponsibilityCaller()
        {
            var report = new WorkReport();
            report.AddEntry(new WorkReportEntry { ProjectCode = "123Ds", ProjectName = "Project1", SpentHours = 5 });
            report.AddEntry(new WorkReportEntry { ProjectCode = "987Fc", ProjectName = "Project2", SpentHours = 3 });
            Console.WriteLine(report.ToString());
            var saver = new FileSaver();
            saver.SaveToFile(@"Reports", "WorkReport.txt", report);
        }

        public static void OpenCloseDeveloperSalaryCaller()
        {
            var devCalculations = new List<BaseSalaryCalculator>
            {
                new SeniorDevSalaryCalculator(new DeveloperReport {Id = 1, Name = "Dev1", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 160 }),
                new JuniorDevSalaryCalculator(new DeveloperReport {Id = 2, Name = "Dev2", Level = "Junior developer", HourlyRate = 20, WorkingHours = 150 }),
                new SeniorDevSalaryCalculator(new DeveloperReport {Id = 3, Name = "Dev3", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 180 })
            };
                var calculator = new SalaryCalculator(devCalculations);
                Console.WriteLine($"{Environment.NewLine} Sum of all the developer salaries is {calculator.CalculateTotalSalaries()} dollars");
        }
        public static void OpenCloseMonitorFilterCaller()
        {
            var monitors = new List<ComputerMonitor>
            {
                new ComputerMonitor { Name = "Samsung S345", Screen = Screen.CurvedScreen, Type = MonitorType.OLED },
                new ComputerMonitor { Name = "Philips P532", Screen = Screen.WideScreen, Type = MonitorType.LCD },
                new ComputerMonitor { Name = "LG L888", Screen = Screen.WideScreen, Type = MonitorType.LED },
                new ComputerMonitor { Name = "Samsung S999", Screen = Screen.WideScreen, Type = MonitorType.OLED },
                new ComputerMonitor { Name = "Dell D2J47", Screen = Screen.CurvedScreen, Type = MonitorType.LCD }
            };


            var filter = new MonitorFilter();

            var lcdMonitors = filter.Filter(monitors, new MonitorTypeSpecification(MonitorType.LCD));
            Console.WriteLine($"{Environment.NewLine}All LCD monitors");
            foreach (var monitor in lcdMonitors)
            {
                Console.WriteLine($"Name: {monitor.Name}, Type: {monitor.Type}, Screen: {monitor.Screen}");
            }

            Console.WriteLine($"{Environment.NewLine}All WideScreen Monitors");
            var wideScreenMonitors = filter.Filter(monitors, new ScreenSpecification(Screen.WideScreen));
            foreach (var monitor in wideScreenMonitors)
            {
                Console.WriteLine($"Name: {monitor.Name}, Type: {monitor.Type}, Screen: {monitor.Screen}");
            }
        }
    }
}
