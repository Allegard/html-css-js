using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.DAO
{
    public class EmployeeDAO
    {
        static IList<Employee> EmployeeList = new List<Employee>() {
        new Employee() { ID = 1, FirstName = "John", Lastname = "Smith", Email = "Jhon@gmail.com" } ,
        new Employee() { ID = 2, FirstName = "Steve",  Lastname = "Snow", Email = "Steve@gmail.com" } ,
        new Employee() { ID = 3, FirstName = "Bill",  Lastname = "Gates", Email = "Bill@gmail.com" } ,
        new Employee() { ID = 4, FirstName = "Ram" , Lastname = "Ses", Email = "Ram@gmail.com" } ,
        new Employee() { ID = 5, FirstName = "Ron" , Lastname = "Weasley", Email = "Ron@gmail.com" }
        };

        public static void AddEmployee(Employee newEmployee)
        {
            try
            {
                EmployeeList.Add(newEmployee);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static IList<Employee> GetEmployees()
        {
            return EmployeeList;
        }

        public static void DeleteEmployee(int employeeID)
        {
            try
            {
                Employee emp = EmployeeList.First(x => x.ID == employeeID);
                EmployeeList.Remove(emp);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void UpdateEmployee(Employee employee)
        {
            try
            {
                foreach (Employee emp in EmployeeList) {
                    //Employee emp = EmployeeList.First(x => x.ID == employee.ID);
                    if (emp.ID == employee.ID) {
                        emp.FirstName = employee.FirstName;
                        emp.Lastname = employee.Lastname;
                        emp.Email = employee.Email;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
