using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayManagementTree
{

    public class Program
    {
        internal static int depth = 1;
        public static void Main(string[] args)
        {
            // TODO Auto-generated method stub
            Employee emp = new Employee(10, "Tom", 0);
            Employee emp1 = new Employee(2, "Mikey", 10);
            Employee emp2 = new Employee(3, "Jerry", 10);
            Employee emp3 = new Employee(7, "John", 2);
            Employee emp4 = new Employee(5, "Sarah", 10);



            IList<Employee> employeeList = new List<Employee>();
            employeeList.Add(emp);
            employeeList.Add(emp1);
            employeeList.Add(emp2);
            employeeList.Add(emp3);
            employeeList.Add(emp4);


            Console.WriteLine("Here is the management tree\n");
		    displayManagementTree(employeeList);
		}
		public static void displayManagementTree(IList<Employee> employeeList)
		{

			Dictionary<int, List<string>> employeeMap = new Dictionary<int, List<string>>();
			IList<Employee> childList = new List<Employee>();
			int employeeId = 0;
			string arrow = "";

			foreach (Employee emp in employeeList)
			{
				childList = getEmployeeChild(employeeList, emp.Id);
				List<string> childEmployeeList = new List<string>();
				if (childList != null)
				{
					foreach (Employee emp1 in childList)
					{
						childEmployeeList.Add(emp1.Name);
					}
				}
				employeeMap[emp.Id] = childEmployeeList;
			}


			foreach (Employee employee in employeeList)
			{
				if (employee.ManagerId == 0)
				{
					employeeId = employee.Id;
					Console.WriteLine("->" + employee.Name);
				}
			}


			IList<string> employeeChildList = employeeMap[employeeId];
			int empId = 0;

			if (employeeChildList != null)
			{
				depth++;
				while (employeeChildList != null)
				{
					foreach (string employeeName in employeeChildList)
					{

						for (int i = 1; i <= depth; i++)
						{
							arrow += "->";
						}
						Console.WriteLine(arrow + employeeName);
						arrow = "";
						foreach (Employee emp in employeeList)
						{
							if (emp.Name.Equals(employeeName))
							{
								empId = emp.Id;
							}
						}
						employeeChildList = employeeMap[empId];

					}
				}

			}


		}

		public static IList<Employee> getEmployeeChild(IList<Employee> employeeList, int employeeId)
		{
			IList<Employee> childList = new List<Employee>();
			foreach (Employee employee in employeeList)
			{
				if (employee.ManagerId == employeeId)
				{

					childList.Add(employee);
				}
			}
			if (childList.Count == 0)
			{
				return null;
			}

			return childList.OrderBy(x => x.Name).ToList();
		}

	}

}
