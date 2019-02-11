using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Employee
    {
        private static List<BusinessModels.Employee> Employees = new List<BusinessModels.Employee>();

        public Employee()
        {
            if (Employees.Count == 0)
                TestData();
        }

        public BusinessModels.Employee GetEmployee(Int32 identity)
        {
            return Employees.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.Employee> GetAll()
        {
            return Employees;
        }

        public Boolean Delete(Int32 identity)
        {
            Employees.Remove(Employees.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.Employee Employee)
        {
            Employees.Remove(Employees.Find(p => p.Identity.Equals(Employee.Identity)));
            Employees.Add(Employee);
            return true;
        }

        public Boolean Insert(BusinessModels.Employee Employee)
        {
            Employees.Add(Employee);
            return true;
        }

        public void TestData()
        {

            for (int i = 0; i < 10; i++)
            {
                Employees.Add(
                    new BusinessModels.Employee()
                    {
                        //Address = new BusinessModels.Address() { Line1 = "Line1", Line2 = "Line2", Pincode = "12345" },
                        //EmployeeName = "John",
                        //EmailID = "m@mail.com",
                        //Identity = 1,
                        //Location = "Mumbai",
                        //Profession = "Engg",
                        //Purpose = "Just So",
                        //Quantity = "12"
                    });
               
            }
        }

    }


}
