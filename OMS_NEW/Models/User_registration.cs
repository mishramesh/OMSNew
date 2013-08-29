using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Data.OleDb;
using System.Threading;
using System.Net;
using System.Timers;
using System.Diagnostics;
using System.Xml;
using OMS_NEW.Models;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace OMS_NEW.Models
{
    public class User_registration
    {
        public int User_Mobile_reg(User_reg_Model reg_module)
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase();
                using (DbCommand dbcmd = db.GetSqlStringCommand(Query.User_reg_Qry(reg_module)))
                {
                    int i = Convert.ToInt16(db.ExecuteNonQuery(dbcmd));
                    return i;
                }
            }
            catch (OleDbException e)
            {
                throw e;
            }
        }
        public DataTable User_retrive_data(User_update_detail user_update_detail)
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase();
                using (DbCommand dbcmd = db.GetSqlStringCommand(Query.User_retrive_data(user_update_detail)))
                {
                    return db.ExecuteDataSet(dbcmd).Tables[0];
                }
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

                Database db = DatabaseFactory.CreateDatabase();
                using (DbCommand dbcmd = db.GetSqlStringCommand(Query.User_update_Qry(user_update_detail)))
                {
                    db.ExecuteDataSet(dbcmd);

                }
            }
            catch (OleDbException e)
            {
                throw e;
            }
        }
        public DataTable User_login_data(User_Login_form user_login_detail)
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase();
                using (DbCommand dbcmd = db.GetSqlStringCommand(Query.User_login_data(user_login_detail)))
                {
                    DataTable dt = db.ExecuteDataSet(dbcmd).Tables[0];
                    return dt;
                }
            }
            catch (OleDbException e)
            {
                throw e;
            }
        }

    }
    public class Employee_registration
    {
        public DataTable Emp_login_data(LoginModel reg_module)
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase();
                using (DbCommand dbcmd = db.GetSqlStringCommand(Query.Emp_login_data(reg_module)))
                {
                    DataTable dt = db.ExecuteDataSet(dbcmd).Tables[0];
                    return dt;
                }
            }
            catch (OleDbException e)
            {
                throw e;
            }
        }

        public DataTable Emp_dept_data()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbCommand dbcmd = db.GetSqlStringCommand(Query.Get_dept_data()))
                {
                    DataTable dt = db.ExecuteDataSet(dbcmd).Tables[0];
                    return dt;
                }
            }
            catch (OleDbException e)
            {
                throw e;
            }
        }
        public void Emp_Registration()
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase();
                using (DbCommand dbcmd = db.GetSqlStringCommand(Query.Emp_reg_Qry()))
                {
                    db.ExecuteDataSet(dbcmd);

                }
            }
            catch (OleDbException e)
            {
                throw e;
            }
        }
    }
    public class User_detail
    {
        public DataTable get_User_detail(User_Login_form reg_module)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbCommand dbcmd = db.GetSqlStringCommand(Query.User_detail_Qry(reg_module)))
                {
                    DataTable dt = db.ExecuteDataSet(dbcmd).Tables[0];
                    return dt;
                }
            }
            catch (OleDbException e)
            {
                throw e;
            }
        }
    }
    public class User_Complain_reg
    {
        public void User_Web_comp_reg(user_complain_reg user_complain, string[] detail)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbCommand dbcmd = db.GetSqlStringCommand(Query.User_Web_comp_reg(user_complain,detail)))
                {
                    db.ExecuteDataSet(dbcmd);
                   
                }
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
                Database db = DatabaseFactory.CreateDatabase();
                using (DbCommand dbcmd = db.GetSqlStringCommand(Query.User_prev_comp_status(CA_NO)))
                {
                   DataTable dt= db.ExecuteDataSet(dbcmd).Tables[0];
                   return dt;
                }
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
                Database db = DatabaseFactory.CreateDatabase();
                using (DbCommand dbcmd = db.GetSqlStringCommand(Query.Get_complaint_NO(CA_NO)))
                {
                    DataTable dt = db.ExecuteDataSet(dbcmd).Tables[0];
                    return dt;
                }
            }
            catch (OleDbException e)
            {
                throw e;
            }
        }

        }
    public class get_LT_network_detail
    {
        public DataTable get_network_detail(string CA_NO)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("SSMSConString1");
                using (DbCommand dbcmd = db.GetSqlStringCommand(Query.get_LT_network_detail(CA_NO)))
                {
                    DataTable dt=db.ExecuteDataSet(dbcmd).Tables[0];
                    return dt;
                }
            }
            catch (OleDbException e)
            {
                throw e;
            }
        }
    
    }
    public class get_LT_NC_fault
    {
        public DataTable Get_fault_type()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbCommand dbcmd = db.GetSqlStringCommand(Query.Get_fault_type()))
                {
                    DataTable dt = db.ExecuteDataSet(dbcmd).Tables[0];
                    return dt;
                }
            }
            catch (OleDbException e)
            {
                throw e;
            }
        }
    }
    public class Sub_Div_complaints_center_
    {

        public DataTable get_complaints_center(string Sub_div)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbCommand dbcmd = db.GetSqlStringCommand(Query.get_complaints_center(Sub_div)))
                {
                    DataTable dt = db.ExecuteDataSet(dbcmd).Tables[0];
                    return dt;
                }
            }
            catch (OleDbException e)
            {
                throw e;
            }
        }
    }
}