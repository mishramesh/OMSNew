using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.OleDb;
using System.Web.Mvc;

namespace OMS_NEW.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Employee ID is required")]
        [Display(Name = "Employere ID")]
        public string Emp_ID { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        public DataTable Login(LoginModel Login)
        {
            try
            {

                Employee_registration reg = new Employee_registration();
                DataTable dt = reg.Emp_login_data(Login);
                return dt;
            }
            catch (OleDbException e)
            {
                throw e;
            }
        }

    }

    public class User_reg_Model
    {
        [Required(ErrorMessage = "CA No is required")]
        [Display(Name = "User CA No")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "9 Digit CA number is required")]
        public string CA_NO { get; set; }

        [Required(ErrorMessage = "One Mobile is Mandatory")]
        [Range(1000000000, 9999999999, ErrorMessage = "10 digit mobile number only without spaces and without country code")]
        [Display(Name = "Mobile No1")]
        public Int64 Mob1 { get; set; }

        [Display(Name = "Mobile No2")]
        [Range(1000000000, 9999999999, ErrorMessage = "10 digit mobile number only without spaces and without country code")]
        public Int64 Mob2 { get; set; }

        [Display(Name = "Mobile No3")]
        [Range(1000000000, 9999999999, ErrorMessage = "10 digit mobile number only without spaces and without country code")]
        public Int64 Mob3 { get; set; }

        [Display(Name = "Mobile No4")]
        [Range(1000000000, 9999999999, ErrorMessage = "10 digit mobile number only without spaces and without country code")]
        public Int64 Mob4 { get; set; }

        [Display(Name = "Mobile No5")]
        [Range(1000000000, 9999999999, ErrorMessage = "10 digit mobile number only without spaces and without country code")]
        public Int64 Mob5 { get; set; }

        public void User_reg(User_reg_Model reg_module)
        {
            try
            {
                User_registration reg = new User_registration();
                reg.User_Mobile_reg(reg_module);
            }
            catch (OleDbException e) { throw e; }
        }

    }

    public class User_update_detail
    {
        [Required(ErrorMessage = "CA No is required")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "9 Digit CA number is required")]
        [Display(Name = "User CA No")]
        public string CA_NO { get; set; }

        [Required(ErrorMessage = "One Mobile Number is Mandatory")]
        [Range(1000000000, 9999999999, ErrorMessage = "10 digit mobile number only without spaces and without country code")]
        [Display(Name = "Mobile No1")]
        public Int64 Mob1 { get; set; }

        [Range(1000000000, 9999999999, ErrorMessage = "10 digit mobile number only without spaces and without country code")]
        [Display(Name = "Mobile No2")]
        public Int64 Mob2 { get; set; }

        [Range(1000000000, 9999999999, ErrorMessage = "10 digit mobile number only without spaces and without country code")]
        [Display(Name = "Mobile No3")]
        public Int64 Mob3 { get; set; }

        [Range(1000000000, 9999999999, ErrorMessage = "10 digit mobile number only without spaces and without country code")]
        [Display(Name = "Mobile No4")]
        public Int64 Mob4 { get; set; }

        [Range(1000000000, 9999999999, ErrorMessage = "10 digit mobile number only without spaces and without country code")]
        [Display(Name = "Mobile No5")]
        public Int64 Mob5 { get; set; }

        public DataTable User_retrive_data(User_update_detail user_update_detail)
        {
            try
            {
                User_registration reg = new User_registration();
                DataTable dt = reg.User_retrive_data(user_update_detail);
                return dt;
            }
            catch (OleDbException e)
            {
                throw e;
            }
        }
        public void User_update_data(User_update_detail user_update_detail)
        {
            try
            {
                User_registration reg = new User_registration();
                reg.User_update_data(user_update_detail);

            }
            catch (OleDbException e)
            {
                throw e;

            }
        }
    }

    public class User_Login_form
    {
        [Required(ErrorMessage = "Use one of previously registered Mobile Numbers for Login ")]
        [Range(1000000000, 9999999999, ErrorMessage = "10 digit mobile number only without spaces and without country code")]
        [Display(Name = "Mobile No1")]
        public Int64 Mobile { get; set; }

        public DataTable User_Login_data(User_Login_form user_Login_detail)
        {
            try
            {
                User_registration reg = new User_registration();
                DataTable dt = reg.User_login_data(user_Login_detail);
                return dt;
            }
            catch (OleDbException e)
            {
                throw e;
            }
        }

    }

    public class employeeRegistration
    {
        [Required(ErrorMessage = "Employee ID is Mandatory ")]
        [Display(Name = "Employee ID")]
        public string Emp_ID { get; set; }

        [Required(ErrorMessage = "Employee Name is Mandatory ")]
        [Display(Name = "Employee Name")]
        public string Emp_Name { get; set; }

        [Required(ErrorMessage = "Department Name is Mandatory")]
        [Display(Name = "Department Name")]
        public List<SelectListItem> Dept_Name { get; set; }

        [Required(ErrorMessage = "Select COMPANY NAME")]
        [Display(Name = "Company Name")]
        public List<SelectListItem> CMP_Name { get; set; }

        [Display(Name = "Circle Name")]
        public int CIR_Name { get; set; }

        [Display(Name = "Division Name")]
        public int DIV_Name { get; set; }

        [Display(Name = "Sub Division Name")]
        public int SUB_DIV_Name { get; set; }

        [Display(Name = "Substation Name")]
        public int SUB_STAT_Name { get; set; }

        [Required(ErrorMessage = "Mobile Number is Mandatory")]
        [Display(Name = "Mobile No")]
        public int Mob { get; set; }

        [Required(ErrorMessage = "Add complaint Center Name")]
        [Display(Name = "Complaint Center Name")]
        public int Comp_center { get; set; }

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

        public DataTable Emp_registration(employeeRegistration emp_reg)
        {
            try
            {
                Employee_registration reg = new Employee_registration();
                DataTable dt = reg.Emp_dept_data();
                return dt;
            }
            catch (OleDbException e)
            {
                throw e;
            }
        }

    }

    public class user_complain_reg
    {
        [Required(ErrorMessage = "CA No is required")]
        [Display(Name = "User CA No")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "9 Digit CA number is required")]
        public string CA_NO { get; set; }

        [Required(ErrorMessage = "Consumer Name")]
        [Display(Name = "Consumer Name")]
        public string Consumer_name { get; set; }

        [Required(ErrorMessage = "Mobile one is Mandatory")]
        [Range(1000000000, 9999999999, ErrorMessage = "10 digit mobile number only without spaces and without country code")]
        [Display(Name = "Mobile No")]
        public Int64 Mob { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = " Select Fault Type from dropdown list")]
        [Display(Name = "Fault Type")]
        public string typeoffault { get; set; }
        [Display(Name = "Remark if any")]
        public string Remark { get; set; }




        public DataTable User_detail(User_Login_form user_login)
        {
            try
            {
                User_detail reg = new User_detail();
                DataTable dt = reg.get_User_detail(user_login);
                return dt;
            }
            catch (OleDbException e)
            {
                throw e;
            }
        }
        public void User_Web_comp_reg(user_complain_reg user_complain, string[] detail)
        {
            try
            {

                User_Complain_reg reg = new User_Complain_reg();
                reg.User_Web_comp_reg(user_complain, detail);

            }
            catch (OleDbException e)
            {
                throw e;
            }
        }
        public DataTable User_prev_comp_status(string CA_NO)
        {
            try
            {
                User_Complain_reg reg = new User_Complain_reg();
                DataTable dt = reg.User_prev_comp_status(CA_NO);
                return dt;
            }
            catch (OleDbException e)
            {
                throw e;
            }
        }
        public DataTable Get_complaint_NO(string CA_NO)
        {
            try
            {
                User_Complain_reg reg = new User_Complain_reg();
                DataTable dt = reg.Get_complaint_NO(CA_NO);
                return dt;
            }
            catch (OleDbException e)
            {
                throw e;
            }
        }


    }

    public class user_complain_Status
    {
        [Required(ErrorMessage = "Complain Number is required")]
        [Display(Name = "Complaint No")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "15 Digit Complain number is required")]
        public string Comp_NO { get; set; }
    }

    public class fault_type
    {
        public DataTable Get_fault_type()
        {
            try
            {
                get_LT_NC_fault reg = new get_LT_NC_fault();
                DataTable dt = reg.Get_fault_type();
                return dt;
            }
            catch (OleDbException e)
            {
                throw e;
            }
        }
    }

    public class complaints_center
    {

        public DataTable get_complaints_center(string Sub_div)
        {
            try
            {
                Sub_Div_complaints_center_ reg = new Sub_Div_complaints_center_();
                DataTable dt = reg.get_complaints_center(Sub_div);
                return dt;
            }
            catch (OleDbException e)
            {
                throw e;
            }
        }

    }

}

