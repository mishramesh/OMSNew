using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace OMS_NEW.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Employee ID is Mandatory")]
        [Display(Name = "Employee ID")]
        public string ID { get; set; }

        [Required(ErrorMessage = "Employee Name is Mandatory")]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }

        [RegularExpression(@"^([1-9]{1})([0-9]{9})$", ErrorMessage = "Enter a valid Mobile No.")]
        [Display(Name = "Mobile No")]
        public long MobileNo { get; set; }

        [Required(ErrorMessage = "Select Department")]
        [Display(Name = "Department Name")]
        public List<SelectListItem> Department { get; set; }

        [Required(ErrorMessage = "Select Company")]
        [Display(Name = "Company Name")]
        public List<SelectListItem> Company { get; set; }

        [Display(Name = "Select Circle")]
        public int Circle { get; set; }

        [Display(Name = "Select Division")]
        public int Division { get; set; }

        [Display(Name = "Select Sub-Division")]
        public int SubDivision { get; set; }

        [Display(Name = "Select Substation")]
        public int Substation { get; set; }

        [Required(ErrorMessage = "Select Complaint-Center")]
        [Display(Name = "Complaint-Center")]
        public int ComplaintCenter { get; set; }

        //public Employee()
        //{
        //    ID = "";
        //    Name = "";
        //    MobileNo = 1111111111;
        //    Department = new List<SelectListItem>();
        //    Department.Add(new SelectListItem() { Text = "Dept", Value = "ONM" });
        //    Company = new List<SelectListItem>();
        //    Company.Add(new SelectListItem() { Text = "Company1", Value = "BYPL" });
        //    ComplaintCenter = 1;
        //}

        public DataTable Emp_Dept_data()
        {
            try
            {
                Employee_registration reg = new Employee_registration();
                DataTable dt = reg.Emp_dept_data();
                return dt;
            }
            catch (OleDbException e)
            { throw e; }
        }
    }
}