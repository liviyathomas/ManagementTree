using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayManagementTree
{
	public class Employee
	{
		private int id;
		private string name;
		private int managerId;
		public Employee(int id, string name, int managerId)
		{
			this.id = id;
			this.name = name;
			this.managerId = managerId;
		}
		public virtual int Id
		{
			get
			{
				return id;
			}
			set
			{
				this.id = value;
			}
		}
		public virtual string Name
		{
			get
			{
				return name;
			}
			set
			{
				this.name = value;
			}
		}
		public virtual int ManagerId
		{
			get
			{
				return managerId;
			}
			set
			{
				this.managerId = value;
			}
		}

	}
}
