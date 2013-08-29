using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMS_NEW.Models;
using System.Data;
using OMS_NEW.gis_reference;

namespace OMS_NEW.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Main/

        [HttpGet]
        public ActionResult EmployeeRegistration()
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
                ViewData["Company"] = new SelectList(Company, "Value", "Text", "Select Company");

                List<SelectListItem> dept = new List<SelectListItem>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dept.Add(new SelectListItem()
                    {
                        Text = dt.Rows[i]["DEPT_NAME"].ToString(),
                        Value = dt.Rows[i]["DEPT_ID"].ToString()
                    });
                }
                ViewData["Dept_name"] = new SelectList(dept, "Value", "Text", "Select Department");
            }
            catch
            { }
            return View();
        }

    }
}
