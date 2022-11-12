using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.SOLID_Principles
{
    public class DependencyInversion
    {
        public enum Gender
        {
            Male,
            Female
        }
        public enum Position
        {
            Administrator,
            Manager,
            Executive
        }
        public class Employee
        {
            public string Name { get; set; }
            public Gender Gender { get; set; }
            public Position Position { get; set; }
        }
        public interface IEmployeeSearchable
        {
            IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position);
        }
        public class EmployeeManager : IEmployeeSearchable
        {
            private readonly List<Employee> _employees;

            public EmployeeManager()
            {
                _employees = new List<Employee>();
            }

            public void AddEmployee(Employee employee)
            {
                _employees.Add(employee);
            }

            public IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position)
                => _employees.Where(emp => emp.Gender == gender && emp.Position == position);
        }
        public class EmployeeStatistics
        {
            private readonly IEmployeeSearchable _emp;

            public EmployeeStatistics(IEmployeeSearchable emp)
            {
                _emp = emp;
            }

            public int CountFemaleManagers() =>
            _emp.GetEmployeesByGenderAndPosition(Gender.Female, Position.Manager).Count();
        }
    }
}
