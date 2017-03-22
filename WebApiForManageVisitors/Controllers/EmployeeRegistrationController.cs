using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApiForManageVisitors.Models;

namespace WebApiForManageVisitors.Controllers
{
    public class EmployeeRegistrationController : Controller
    {
        ManageVisitorsEntities _DbManageVisitorsEntities = new ManageVisitorsEntities();
        // GET: EmployeeRegistration
        public ActionResult Index()
        {
            CheckViewBagData();
            var Employees = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration;
            return View(Employees.ToList());
        }

        // GET: EmployeeRegistration/Details/5
        public ActionResult Details(int id)
        {
            CheckViewBagData();
            var model = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Where(a => a.EmployeeSrNo == id).FirstOrDefault();
            return View(model);
        }

        // GET: EmployeeRegistration/Create
        public ActionResult Create()
        {
            CheckViewBagData();
            ViewBag.DepartmentCombo = new SelectList(_DbManageVisitorsEntities.tbl_DepartmentMaster, "DepartmentID", "DepartmentName");
            ViewBag.DesignationCombo = new SelectList(_DbManageVisitorsEntities.tbl_DesignationMaster, "DesignationID", "DesignationName");
            return View();
        }


        public JsonResult GetDesignationByID(int id)
        {
            CheckViewBagData();
            _DbManageVisitorsEntities.Configuration.ProxyCreationEnabled = false;
            //var R = Json(_DbManageVisitorsEntities.tbl_DesignationMaster.Where(P => P.DepartmentID == id), JsonRequestBehavior.AllowGet);
            var Designationlist =(_DbManageVisitorsEntities.tbl_DesignationMaster.Where(P => P.DepartmentID == id));
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(Designationlist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetDepartmentNameByID(int id)
        {
            CheckViewBagData();
            _DbManageVisitorsEntities.Configuration.ProxyCreationEnabled = false;
            //var R = Json(_DbManageVisitorsEntities.tbl_DesignationMaster.Where(P => P.DepartmentID == id), JsonRequestBehavior.AllowGet);
            var Departmentname = (_DbManageVisitorsEntities.tbl_DepartmentMaster.Where(P => P.DepartmentID == id));
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(Departmentname);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetDesignationByID(int id)
        //{
        //    List<tbl_DesignationMaster> lstcity = new List<tbl_DesignationMaster>();

        //    var desgignationList = _DbManageVisitorsEntities.tbl_DesignationMaster.Where(P => P.DepartmentID == id).ToList();

        //    lstcity = desgignationList;
        //    JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
        //    string result = javaScriptSerializer.Serialize(lstcity);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        // POST: EmployeeRegistration/Create
        [HttpPost]
        public ActionResult Create(tbl_DepartmentEmployeeRegistration collection,int DesignationCombo)
        {
            try
            {
                CheckViewBagData();
                collection.EmployeeDesignationID = DesignationCombo;
                _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Add(collection);
                _DbManageVisitorsEntities.SaveChanges();
                return RedirectToAction("Index");
               
            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return View();
            }

        }

        // GET: EmployeeRegistration/Edit/5
        public ActionResult Edit(int id)
        {
            CheckViewBagData();
            tbl_DepartmentEmployeeRegistration employee = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Find(id);
            ViewBag.DepartmentCombo1 = new SelectList(_DbManageVisitorsEntities.tbl_DepartmentMaster, "DepartmentID", "DepartmentName",employee.EmployeeDepartmentID);
           // var model = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Where(a => a.EmployeeSrNo == id).FirstOrDefault();
            return View(employee);
          
        }

        // POST: EmployeeRegistration/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, tbl_DepartmentEmployeeRegistration collection)
        {
            try
            {
                // TODO: Add update logic here
                CheckViewBagData();
                var data = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Where(b => b.EmployeeSrNo == id).FirstOrDefault();
                       //data.EmployeeSrNo = collection.EmployeeSrNo;
                       data.EmployeeName = collection.EmployeeName;
                       data.EmployeeTokenNo = collection.EmployeeTokenNo;
                       data.EmployeeAddress = collection.EmployeeAddress;
                       data.EmployeeContactNo = collection.EmployeeContactNo;
                       data.EmployeeEmailID = collection.EmployeeEmailID;
                       data.EmployeeDepartmentID = collection.EmployeeDepartmentID;
                       data.EmployeeDesignationID = collection.EmployeeDesignationID;
                       data.EmployeePassword = collection.EmployeePassword;
                      _DbManageVisitorsEntities.Entry(data).State = EntityState.Modified;
                      _DbManageVisitorsEntities.SaveChanges();
                      return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: EmployeeRegistration/Delete/5
        public ActionResult Delete(int id)
        {
            CheckViewBagData();
            var model = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Where(a => a.EmployeeSrNo == id).FirstOrDefault();
            return View(model);
        }

        // POST: EmployeeRegistration/Delete/5
      
        public ActionResult DeleteNow(int id)
        {
            try
            {
                CheckViewBagData();
                var model = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Where(a => a.EmployeeSrNo == id).FirstOrDefault();
                _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Remove(model);
                _DbManageVisitorsEntities.SaveChanges();
                 return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public void CheckViewBagData()
        {
            @ViewBag.EmployeeRegistration = true;
            @ViewBag.VisitorRegistration = false;
            @ViewBag.EmployeeDepartment = false;
            @ViewBag.EmployeeDesignation = false;
        }
    }
}
