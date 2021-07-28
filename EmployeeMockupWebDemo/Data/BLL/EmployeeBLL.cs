using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeMockupWebDemo.Data.DAL.Model;
using EmployeeMockupWebDemo.Data.DAO;

namespace EmployeeMockupWebDemo.Data.BLL
{
    public class EmployeeBLL
    {

        public static IList<Employee> GetAll()
        {
            return EmployeeDAO.GetEmployees();
        }

        public static void AddEmployee(Employee employee)
        {
            EmployeeDAO.AddEmployee(employee);
        }

        public static void UpdateEmployee(Employee employee)
        {
            EmployeeDAO.UpdateEmployee(employee);
        }

        public static void DeleteEmployee(int employeeID)
        {
            EmployeeDAO.DeleteEmployee(employeeID);

        }

        public static Employee GetEmployee(int employeeID)
        {
            return EmployeeDAO.GetEmployee(employeeID);
        }
    }
}
