using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OMS_NEW.Models
{
    public class cms
    {
        [Required]
        public string faultcategory { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        public string complaint_id { get; set; }
        public string crn { get; set; }
        public string ca { get; set; }
        public string consumer_name { get; set; }
        [Required]
        public string caller_name { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string contact1 { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string contact2 { get; set; }
        public string address { get; set; }
        public string landmark { get; set; }
        public string area { get; set; }
        [Required]
        public string complaintcentre { get; set; }
        [Required]
        public string typeoffault { get; set; }
        public string reason { get; set; }
        public string poleno { get; set; }
    }


    public class openNcc
    {
        public int EmpId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeDep { get; set; }
    }





}