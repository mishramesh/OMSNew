using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMS_NEW.consumerdetails;
using OMS_NEW.gis_reference;
using OMS_NEW.Models;
using System.Data.OleDb;
using System.Data;
namespace OMS_NEW.Controllers
{
    public class CmsController : Controller
    {
        ISUService service = new ISUService();
        Service1 service1 = new Service1();
        static List<openNcc> _lstopenNcc = new List<openNcc>();
        static int faulttype;
        static string faultcat;
        List<string> company = new List<string>();
        List<string[,]> circle = new List<string[,]>();
        List<string[,]> division = new List<string[,]>();
        List<string[,]> subdivision = new List<string[,]>();
        static List<string> typefaulte;

        public List<string> FetchCompany()
        {
            DataSet ds = service1._1Get_Company();
            foreach (DataRow dt in ds.Tables[0].Rows)
            {
                company.Add(dt["Company"].ToString());
            }
            return company;
        }
        public List<string[,]> FetchCircle()
        {
            string[,] temper;
            DataSet ds = service1._2Get_Circle_list("");
            foreach (string temp in company)
            {
                foreach (DataRow dt in ds.Tables[0].Rows)
                {
                    if (temp == dt["Company"].ToString())
                    {
                        temper = new string[,] { { temp, dt["Circle"].ToString() } };
                        circle.Add(temper);

                    }
                }

            }
            return circle;
        }
        public List<string[,]> FetchDivision()
        {
            DataSet ds = service1._4Get_Division_list("");
            string[,] temper;
            foreach (string[,] temp in circle)
            {
                foreach (DataRow dt in ds.Tables[0].Rows)
                {
                    if (temp[0, 1] == dt["Circle"].ToString())
                    {
                        temper = new string[,] { { temp[0, 1], dt["DIVISION_N"].ToString() } };
                        division.Add(temper);

                    }
                }

            }
            return division;

        }
        public List<string[,]> FetchSubdivision()
        {
            DataSet ds = service1._6Get_Sub_Division_list("", "");
            string[,] temper;
            foreach (string[,] temp in division)
            {
                foreach (DataRow dt in ds.Tables[0].Rows)
                {
                    if (temp[0, 1] == dt["DIVISION_N"].ToString())
                    {
                        temper = new string[,] { { temp[0, 1], dt["SUBDIVISIO"].ToString() } };
                        subdivision.Add(temper);

                    }
                }

            }
            return subdivision;

        }
        public List<string[,]> FetchFaultCat()
        {
            string query = "select id,category from oms_fault_cat";
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["omscon"].ToString();
            OleDbConnection con = new OleDbConnection(connection);
            con.Open();
            OleDbCommand cmd = new OleDbCommand(query, con);
            cmd.ExecuteNonQuery();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string[,] temper;
            List<string[,]> faultcate = new List<string[,]>();
            foreach (DataRow dr in dt.Rows)
            {
                temper = new string[,] { { dr["ID"].ToString(), dr["CATEGORY"].ToString() } };
                faultcate.Add(temper);
            }



            return faultcate;
        }
        public List<string> Fetchtypefault(int ctg)
        {
            string query = "select type from oms_typeof_fault where category='" + ctg + "'";
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["omscon"].ToString();
            OleDbConnection con = new OleDbConnection(connection);
            con.Open();
            OleDbCommand cmd = new OleDbCommand(query, con);
            cmd.ExecuteNonQuery();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string temper;
            List<string> set = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                set.Add(dr["TYPE"].ToString());
            }
            return set;
        }

        [HttpGet]
        public ActionResult home(int comtype = 0)
        {
            ModelState.Clear();
            cms cm = new cms();
            faulttype = comtype;
            cm.Date = DateTime.Now;
            List<string[,]> temp = FetchFaultCat();
            foreach (string[,] temper in temp)
            {
                if (faulttype == Int16.Parse(temper[0, 0]))
                {
                    faultcat = cm.faultcategory = temper[0, 1];
                    typefaulte = Fetchtypefault(faulttype);
                }
            }
            ViewData["typeoffault"] = new SelectList(typefaulte);
            return View(cm);
        }

        [HttpPost]
        [ActionName("home")]
        public ActionResult homepost(cms cm)
        {
            ModelState.Clear();
            cm.Date = DateTime.Now;
            cm.faultcategory = faultcat;
            ViewData["typeoffault"] = new SelectList(typefaulte);
            return View(cm);
        }

        [HttpPost]
        public ActionResult homedetails(cms cm)
        {
            ModelState.Clear();
            DataSet ds = new DataSet();
            cm.Date = DateTime.Now;
            if (cm.crn != null)
            {
                ds = service.Z_BAPI_CMS_ISU_CA_DISPLAY("", "", cm.crn, "", "", "");
            }
            if (cm.ca != null)
            {
                ds = service.Z_BAPI_CMS_ISU_CA_DISPLAY(cm.ca, "", "", "", "", "");
            }
            if (cm.contact1 != null)
            {
                ds = service.Z_BAPI_CMS_ISU_CA_DISPLAY("", "", "", cm.contact1, "", "");
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                cm.crn = ds.Tables[0].Rows[0]["Legacy_Acct"].ToString();
                cm.ca = ds.Tables[0].Rows[0]["Ca_Number"].ToString();
                cm.consumer_name = ds.Tables[0].Rows[0]["Bp_Name"].ToString();
                cm.contact1 = ds.Tables[0].Rows[0]["Telephone_No"].ToString();
                cm.address = ds.Tables[0].Rows[0]["House_Number"].ToString() + ds.Tables[0].Rows[0]["House_Number_Sup"].ToString() + ", " + ds.Tables[0].Rows[0]["Floor"].ToString() + ", " + ds.Tables[0].Rows[0]["Street"].ToString() + ", " + ds.Tables[0].Rows[0]["Street2"].ToString() + ", " + ds.Tables[0].Rows[0]["Street3"].ToString() + ", " + ds.Tables[0].Rows[0]["Street4"].ToString() + ", " + ds.Tables[0].Rows[0]["City"].ToString() + ", PostCode: " + ds.Tables[0].Rows[0]["Post_Code"].ToString() + " .";
            }
            cm.faultcategory = faultcat;
            ViewData["typeoffault"] = new SelectList(typefaulte);
            return View("home", cm);
        }


        [HttpPost]
        public ActionResult homesave(cms cm)
        {

            return View("home", cm);
        }


        [HttpPost]
        public ActionResult test(cms cm)
        {
            ModelState.Clear();
            cm.poleno = "jlm10542";
            return View(cm);
        }



        public ActionResult openNcc()
        {
            _lstopenNcc = GetopenNcc();
            return PartialView(_lstopenNcc);

        }
        private List<openNcc> GetopenNcc()
        {
            List<openNcc> _pvtList = new List<openNcc>();
            openNcc mod1 = new openNcc { EmpId = 1, EmployeeName = "Employee1", EmployeeDep = "EmployeeDep1" };
            openNcc mod2 = new openNcc { EmpId = 2, EmployeeName = "Employee2", EmployeeDep = "EmployeeDep2" };
            openNcc mod3 = new openNcc { EmpId = 3, EmployeeName = "Employee3", EmployeeDep = "EmployeeDep3" };
            openNcc mod4 = new openNcc { EmpId = 4, EmployeeName = "Employee4", EmployeeDep = "EmployeeDep4" };
            openNcc mod5 = new openNcc { EmpId = 5, EmployeeName = "Employee5", EmployeeDep = "EmployeeDep4" };
            openNcc mod6 = new openNcc { EmpId = 6, EmployeeName = "Employee6", EmployeeDep = "EmployeeDep4" };
            openNcc mod7 = new openNcc { EmpId = 7, EmployeeName = "Employee7", EmployeeDep = "EmployeeDep4" };
            openNcc mod8 = new openNcc { EmpId = 8, EmployeeName = "Employee8", EmployeeDep = "EmployeeDep4" };
            openNcc mod9 = new openNcc { EmpId = 6, EmployeeName = "Employee6", EmployeeDep = "EmployeeDep4" };
            openNcc mod10 = new openNcc { EmpId = 7, EmployeeName = "Employee7", EmployeeDep = "EmployeeDep4" };
            openNcc mod11 = new openNcc { EmpId = 8, EmployeeName = "Employee8", EmployeeDep = "EmployeeDep4" };
            _pvtList.Add(mod1);
            _pvtList.Add(mod2);
            _pvtList.Add(mod3);
            _pvtList.Add(mod4);
            _pvtList.Add(mod5);
            _pvtList.Add(mod6);
            _pvtList.Add(mod7);
            _pvtList.Add(mod8);
            _pvtList.Add(mod9);
            _pvtList.Add(mod10);
            _pvtList.Add(mod11);
            return _pvtList;
        }
        public ActionResult status()
        {
            _lstopenNcc = GetopenNcc();
            return View(_lstopenNcc);
        }



    }
}
