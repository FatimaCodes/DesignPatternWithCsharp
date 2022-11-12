using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.SOLID_Principles
{

    /// <summary>
    /// Single responsibility principle states that a class should only have one reason to change, in other words like it should do only one thing.
    /// In this code, every responsibility is done by indevidual class 
    /// </summary>
    internal class SingleResponsibility
    {
        public class WorkReportEntry
        {
            public string ProjectCode { get; set; }
            public string ProjectName { get; set; }
            public int SpentHours { get; set; }
        }
        public class WorkReport
        {
            private readonly List<WorkReportEntry> _entries;

            public WorkReport()
            {
                _entries = new List<WorkReportEntry>();
            }

            public void AddEntry(WorkReportEntry entry) => _entries.Add(entry);

            public void RemoveEntryAt(int index) => _entries.RemoveAt(index);

            public override string ToString() =>
                string.Join(Environment.NewLine, _entries.Select(x => $"Code: {x.ProjectCode}, Name: {x.ProjectName}, Hours: {x.SpentHours}"));
        }

        public class FileSaver
        {
            public void SaveToFile(string directoryPath, string fileName, WorkReport report)
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                File.WriteAllText(Path.Combine(directoryPath, fileName), report.ToString());
            }
        }
    }
}
