using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;

namespace BLL
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
    }
}
