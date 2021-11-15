using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenHR.Model
{
	public class Employee {
		[Key]
		public int Id {get;set;}
		public string FirstName{get;set;}
		public string LastName {get;set;}
		public string Email { get; set; }
		public DateTime DateOfBirth { get; set; }

		public bool IsActive { get; set; }
		[ForeignKey("DepartmentId")]
		public Department BelongingDepartment { get; set; }

		[InverseProperty("Manager")]
		public Department ManagingDepartment { get; set; }
	}



	public class Department
    {
		public int Id { get; set; }
		public string Name { get; set; }
		[InverseProperty("BelongingDepartment")]
		public virtual List<Employee> Employees  { get; set; }
		[ForeignKey("EmployeeId")]
		public Employee Manager { get; set; }
		public virtual List<DepartmentProject> DepartmentProjects { get; set; }

	}


	public class Project
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual List<DepartmentProject> DepartmentProjects { get; set; }

	}


	public class DepartmentProject
    {
		public int Id { get; set; }
		public Department Department { get; set; }
		public virtual Project Project { get; set; }
	}
	 
}
