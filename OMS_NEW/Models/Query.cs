using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;
using OMS_NEW.Models;
namespace OMS_NEW.Models
{
    public class Query
    {
        public static string User_reg_Qry(User_reg_Model reg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into User_Moible_No values('" + reg.CA_NO + "','" + reg.Mob1 + "," + reg.Mob2 + "," + reg.Mob3 + "," + reg.Mob4 + "," + reg.Mob5 + "') ");
            return sb.ToString();
        }
        public static string User_detail_Qry(User_Login_form reg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from USER_MOIBLE_NO where substr(MOBILE_NO,1,10)='" + reg.Mobile + "' or substr(MOBILE_NO,12,10)='" + reg.Mobile + "' or substr(MOBILE_NO,23,10)='" + reg.Mobile + "' or substr(MOBILE_NO,34,10)='" + reg.Mobile + "' or substr(MOBILE_NO,45,10)='" + reg.Mobile + "'");
            return sb.ToString();
        }
        public static string User_update_Qry(User_update_detail reg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update User_Moible_No set MOBILE_NO='" + reg.Mob1 + "," + reg.Mob2 + "," + reg.Mob3 + "," + reg.Mob4 + "," + reg.Mob5 + "' where CA_NO='" + reg.CA_NO + "' ");
            return sb.ToString();
        }
        public static string User_retrive_data(User_update_detail reg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select substr(MOBILE_NO,1,10) mob1,substr(MOBILE_NO,12,10)mob2,substr(MOBILE_NO,23,10) mob3,substr(MOBILE_NO,34,10) mob4,substr(MOBILE_NO,45,10)mob5 from USER_MOIBLE_NO where CA_NO='" + reg.CA_NO + "' ");
            return sb.ToString();
        }
        public static string User_login_data(User_Login_form reg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from USER_MOIBLE_NO where substr(MOBILE_NO,1,10)='" + reg.Mobile + "'or substr(MOBILE_NO,12,10)='" + reg.Mobile + "' or substr(MOBILE_NO,23,10)='" + reg.Mobile + "' or substr(MOBILE_NO,34,10)='" + reg.Mobile + "' or substr(MOBILE_NO,45,10)='" + reg.Mobile + "' ");
            return sb.ToString();
        }
        public static string Emp_login_data(LoginModel reg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select * from OMS_RIGHTS where EMP_ID='" + reg.Emp_ID + "' and PASSWORD ='" + reg.Password + " ");
            return sb.ToString();
        }
        public static string Get_dept_data()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select * from OMS_DEPT");
            return sb.ToString();
        }
        public static string Emp_reg_Qry()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("Insert into User_Moible_No values('" + reg.CA_NO + "','" + reg.Mob1 + "," + reg.Mob2 + "," + reg.Mob3 + "," + reg.Mob4 + "," + reg.Mob5 + "') ");
            return sb.ToString();
        }
        public static string User_Web_comp_reg(user_complain_reg user_complain, string[] detail)
        {
            StringBuilder sd = new StringBuilder();
            sd.Append(" insert into OMS_NC_IN(CA_NO,CALLER_NAME,CONSUMER_NAME,CONSUMER_NO,ADDRESS,TYPE_OF_FAULT,COMP_REASON,COMP_OPEN_BY,POLE_ID,EQUIPMENT_ID,COMPANY,CIRCLE,DIVISION,SUB_DIVISION,SUB_STATION,COMP_CENTER)values('" + user_complain.CA_NO + "','" + user_complain.Consumer_name + "','" + user_complain.Consumer_name + "' ");
            sd.Append(" ,'" + user_complain.Mob + "','" + user_complain.Address + "'," + user_complain.typeoffault + ",'" + user_complain.Remark + "','Web_comp','" + detail[0] + "','" + detail[1] + "','" + detail[2] + "','" + detail[3] + "','" + detail[4] + "','" + detail[5] + "','" + detail[6] + "'," + detail[7] + " ) ");
            return sd.ToString();
        }
        public static string User_prev_comp_status(String CA_NO)
        {
            StringBuilder sd = new StringBuilder();
            sd.Append("select COMP_NO from OMS_NC_IN where CA_NO='" + CA_NO + "' and STATUS=0 ");
            return sd.ToString();
        }
        public static string get_LT_network_detail(String CA_NO)
        {
            StringBuilder sd = new StringBuilder();
            sd.Append("select a.CA_NO, a.POLE_NO, b.sap_eqp_cd DT_CODE, a.DT_ID Substion_id from eaudit.ea_consumer_clus a, dtmetering.sap_dt_master b  where a.CA_NO='" + CA_NO + "' and a.DT_CODE=b.DT_CODE and ROWNUM=1 order by sap_eqp_cd ASC ");
            return sd.ToString();
        }
        public static string Get_complaint_NO(String CA_NO)
        {
            StringBuilder sd = new StringBuilder();
            sd.Append("select COMP_NO from OMS_NC_IN where CA_NO='" + CA_NO + "' and STATUS=0 ");
            return sd.ToString();
        }
        public static string Get_fault_type()
        {
            StringBuilder sd = new StringBuilder();
            sd.Append("select TYPE,CATEGORY from OMS_TYPEOF_FAULT ");
            return sd.ToString();
        }
        public static string get_complaints_center(string Sub_div)
        {
            StringBuilder sd = new StringBuilder();
            sd.Append("select * from OMS_COMP_CEN where SUBDIV_NAME='" + Sub_div + "' ");
            return sd.ToString();
        }
    }
}