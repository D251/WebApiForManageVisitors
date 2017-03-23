using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiForManageVisitors.Models
{
   [ MetadataType(typeof(DepartmentMaster))]
    public partial class tbl_DepartmentMaster
    {
    }
    public class DepartmentMaster
    {
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Display(Name = "Department ID")]
        public string DepartmentID { get; set; }

        [Display(Name = "Department Create Date")]
        public Nullable<System.DateTime> DepartmentCreateDate { get; set; }
    }
}