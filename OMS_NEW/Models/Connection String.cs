using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMS_NEW.Models
{
    public class Connection_String
    {
        public static string Database_name;
        public static string User_name ;
        public static string Pass_word ;
        public string conncetion_string()
        {
            //connectionString="provider=oraoledb.oracle;data source=oms;user id=omsuser;password=oms123 ;User Instance=true;useSessionFormat=True
            return "Provider=oraoledb.oracle;Data Source=" + Database_name + ";User ID=" + User_name + ";Password=" + Pass_word + ";User Instance=true;useSessionFormat=True";
        }
       
    }
}