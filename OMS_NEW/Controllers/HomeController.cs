using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMS_NEW.Models;
using System.Data.OleDb;
using System.Threading;
using System.Data;
using System.Net;
using System.Timers;
using System.Diagnostics;
using System.Xml;
using OMS_NEW.consumerdetails;
using OMS_NEW;
using OMS_NEW.gis_reference;

namespace OMS_NEW.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Employee_reg()
        {
            try
            {
                Employee emp_reg = new Employee();
                DataTable dt = emp_reg.Emp_Dept_data();
                Service1 gis_service = new Service1();
                DataSet ds = new DataSet();
                ds = gis_service._1Get_Company();
                List<SelectListItem> Company = new List<SelectListItem>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Company.Add(new SelectListItem()
                    {
                        Value = ds.Tables[0].Rows[i]["Company"].ToString(),
                        Text = ds.Tables[0].Rows[i]["Company"].ToString()
                    });
                }
                ViewData["Company"] = new SelectList(Company, "Value", "Text", "Select Company name");

                List<SelectListItem> dept = new List<SelectListItem>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dept.Add(new SelectListItem()
                        {
                            Text = dt.Rows[i]["DEPT_NAME"].ToString(),
                            Value = dt.Rows[i]["DEPT_ID"].ToString()
                        });
                }
                ViewData["Dept_name"] = new SelectList(dept, "Value", "Text", "Select Department name");
            }
            catch
            { }
            return View();
        }

        [HttpPost]
        public ActionResult Employee_reg(Employee emp_reg)
        {
            if (ModelState.IsValid)
            {
                try
                {

                }
                catch (Exception) { ModelState.AddModelError("", "Already registered.please update your contact details "); }
            }
            else
            {
                emp_reg = new Employee();
                ViewData["Company"] = new SelectList(emp_reg.Company, "Value", "Text", "Select Company name");
                ViewData["Dept_name"] = new SelectList(emp_reg.Department, "Value", "Text", "Select Department name");
            }
            return View(emp_reg);
        }

        [HttpGet]
        public ActionResult Employee()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Update_user_detail(User_update_detail user_update_detail)
        {
            return View(user_update_detail);
        }

        [HttpGet]
        public ActionResult User_retrive_data()
        {
            return View();
        }

        [HttpPost]
        public ActionResult User_retrive_data(User_update_detail user_update_detail, string command)
        {
            try
            {
                if (command == "Get Detail")
                {
                    DataTable dt = user_update_detail.User_retrive_data(user_update_detail);
                    if (dt.Rows.Count == 0)
                    {
                        ModelState.Clear();
                        ModelState.AddModelError("", "Not Registered,plz register first.");
                        user_update_detail.CA_NO = "";
                        user_update_detail.Mob1 = 0;
                        user_update_detail.Mob2 = 0;
                        user_update_detail.Mob3 = 0;
                        user_update_detail.Mob4 = 0;
                        user_update_detail.Mob5 = 0;
                    }
                    else
                    {
                        ModelState.Clear();
                        user_update_detail.Mob1 = Convert.ToInt64(dt.Rows[0]["MOB1"]);
                        user_update_detail.Mob2 = Convert.ToInt64(dt.Rows[0]["MOB2"]);
                        user_update_detail.Mob3 = Convert.ToInt64(dt.Rows[0]["MOB3"]);
                        user_update_detail.Mob4 = Convert.ToInt64(dt.Rows[0]["MOB4"]);
                        user_update_detail.Mob5 = Convert.ToInt64(dt.Rows[0]["MOB5"]);
                        return RedirectToAction("Update_user_detail", user_update_detail);
                    }
                }
                else
                {
                    ModelState.Clear();
                    user_update_detail.CA_NO = "";
                }
            }
            catch
            {
                ModelState.AddModelError("", "Not Registered,plz register first.");
            }
            return View();

        }

        [HttpPost]
        public ActionResult Update_user_detail(User_update_detail user_update_detail, string command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (command == "Update")
                    {
                        user_update_detail.User_update_data(user_update_detail);
                        ModelState.Clear();
                        ModelState.AddModelError("", "Updation perfromed.Now you can enjoy OMS web application service");
                        user_update_detail.Mob1 = 0;
                        user_update_detail.Mob2 = 0;
                        user_update_detail.Mob3 = 0;
                        user_update_detail.Mob4 = 0;
                        user_update_detail.Mob5 = 0;
                    }
                }
            }
            catch
            {
                ModelState.AddModelError("", "There is some problem in updation,plz try later");
            }
            return View();
        }

        [HttpGet]
        public ActionResult User_login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult user_complain_reg(user_complain_reg reg)
        {
            fault_type();
            return View(reg);
        }

        public void fault_type()
        {
            fault_type type = new fault_type();
            DataTable dt = type.Get_fault_type();
            List<SelectListItem> fault = new List<SelectListItem>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                fault.Add(new SelectListItem()
                {
                    Text = dt.Rows[i]["TYPE"].ToString(),
                    Value = dt.Rows[i]["CATEGORY"].ToString()
                });
            }
            ViewData["type_of_fault"] = new SelectList(fault, "Value", "Text", "Select type of fault");
        }

        [HttpGet]
        public ActionResult User()
        {
            return View();
        }

        [HttpPost]
        public ActionResult User_login(User_Login_form user_login)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    DataTable dt = user_login.User_Login_data(user_login);
                    if (dt.Rows.Count == 0)
                    {
                        ModelState.AddModelError("", "you Mobile number is not registerd.plz register first to avail this service");
                    }
                    else
                    {
                        user_complain_reg reg = new user_complain_reg();
                        DataTable dt1 = reg.User_detail(user_login);
                        reg.CA_NO = dt.Rows[0]["CA_NO"].ToString();
                        ISUService service = new ISUService();
                        DataSet ds = new DataSet();
                        ds = service.Z_BAPI_CMS_ISU_CA_DISPLAY("000" + reg.CA_NO, "", "", "", "", "");
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            ModelState.AddModelError("", "Please Check your CA number.");
                        }
                        else
                        {
                            reg.Address = ds.Tables[0].Rows[0]["House_Number"].ToString() + " " + ds.Tables[0].Rows[0]["Street"].ToString() + " " + ds.Tables[0].Rows[0]["Street2"].ToString() + " " + ds.Tables[0].Rows[0]["Street3"].ToString() + " " + ds.Tables[0].Rows[0]["Street4"].ToString() + ", " + ds.Tables[0].Rows[0]["City"].ToString() + ", PostCode: " + ds.Tables[0].Rows[0]["Post_Code"].ToString() + " .";
                            reg.Consumer_name = ds.Tables[0].Rows[0]["Bp_Name"].ToString();
                            reg.Mob = user_login.Mobile;
                            return RedirectToAction("user_complain_reg", reg);
                        }
                    }
                }
            }
            catch
            {
                ModelState.AddModelError("", "There is some problem in updation,plz try later");
            }
            return View();
        }

        [HttpPost]
        public ActionResult User_complain_reg(user_complain_reg reg)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    string CA_NO = reg.CA_NO.ToString();
                    DataTable dt = reg.User_prev_comp_status(CA_NO);
                    if (dt.Rows.Count != 0)
                    {
                        ModelState.AddModelError("", "Your Complain is already registered.Your Complain number is '" + dt.Rows[0]["COMP_NO"].ToString() + "' ");
                    }
                    else
                    {
                        get_LT_network_detail LT_Network = new get_LT_network_detail();
                        string[] detail = new string[10];
                        DataTable dt1 = LT_Network.get_network_detail(CA_NO);
                        String Sub_station_code = dt1.Rows[0]["Substion_id"].ToString();
                        Service1 gis_service = new Service1();
                        DataSet ds = new DataSet();
                        ds = gis_service._Substation_Div_details(Sub_station_code);
                        detail[0] = dt1.Rows[0]["POLE_NO"].ToString();
                        detail[1] = dt1.Rows[0]["DT_CODE"].ToString();
                        detail[2] = ds.Tables[0].Rows[0]["Company"].ToString();
                        detail[3] = ds.Tables[0].Rows[0]["Circle"].ToString();
                        detail[4] = ds.Tables[0].Rows[0]["DIVISION_1"].ToString();
                        detail[5] = ds.Tables[0].Rows[0]["SUBDIVISIO"].ToString();
                        detail[6] = Sub_station_code;
                        complaints_center comp_cent = new complaints_center();
                        DataTable Center = comp_cent.get_complaints_center(detail[5]);
                        detail[7] = Center.Rows[0]["COMP_CEN_ID"].ToString();
                        reg.User_Web_comp_reg(reg, detail);
                        DataTable dt2 = reg.Get_complaint_NO(CA_NO);
                        ModelState.AddModelError("", "Your Complain is registered.Your Complain number is '" + dt2.Rows[0]["COMP_NO"].ToString() + "' ");

                    }
                }
            }
            catch
            {
                ModelState.AddModelError("", "There is some problem in complain registration,plz try later");
            }
            fault_type();
            User_comp_clear(reg);
            return View();
        }

        public void User_comp_clear(user_complain_reg reg)
        {
            reg.Mob = 0;
            reg.Remark = "";
            reg.Address = "";
            reg.CA_NO = "";
            reg.Consumer_name = "";
        }

        [HttpPost]
        public ActionResult Login(LoginModel module)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DataTable dt = module.Login(module);
                    if (dt.Rows.Count == 0)
                    {
                        ModelState.AddModelError("", "Invaild Login details");
                        return View();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Successful Login");
                        module.Emp_ID = "";
                        module.Password = "";
                        return View();
                    }

                }
                catch (Exception)
                { }
            }
            return View(module);

        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User_reg_Model reg_module)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    reg_module.User_reg(reg_module);
                    ModelState.AddModelError("", "Successful Registration");
                    reg_module.CA_NO = "";
                    reg_module.Mob1 = 0;
                    reg_module.Mob2 = 0;
                    reg_module.Mob3 = 0;
                    reg_module.Mob4 = 0;
                    reg_module.Mob5 = 0;
                    return View();
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "Already registered.please update your contact details ");
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult user_complain_Status()
        {
            return View();
        }

    }
}


