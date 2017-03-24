using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiForManageVisitors.Models;

namespace WebApiForManageVisitors.Controllers
{
    public class EmployeeDesignationController : Controller
    {
        ManageVisitorsEntities _DbManageVisitorsEntities = new ManageVisitorsEntities();
        // GET: EmployeeDesignation
        public void CheckViewBagData()
        {
            @ViewBag.EmployeeRegistration = false;
            @ViewBag.VisitorRegistration = false;
            @ViewBag.EmployeeDepartment = false;
            @ViewBag.EmployeeDesignation = true;
            @ViewBag.RequestDetails = false;
        }

        public ActionResult Index()
        {
            CheckViewBagData();
            //var Designation = _DbManageVisitorsEntities.tbl_DesignationMaster;
            //return View(Designation.ToList());
            List<tbl_DesignationMasterModel> _objListRequestProcessModel = new List<tbl_DesignationMasterModel>();


            var _objAllRequestProcessModel = _DbManageVisitorsEntities.tbl_DesignationMaster.ToList();

            foreach (var item in _objAllRequestProcessModel)
            {
                tbl_DesignationMasterModel _class = new tbl_DesignationMasterModel();

                var _objDepartmentEmployeeRegistration = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == item.DepartmentID).FirstOrDefault();

                _class.DesignationID = item.DesignationID;
                _class.DepartmentID = item.DepartmentID;
                _class.DepartmentName = _objDepartmentEmployeeRegistration.DepartmentName;
                _class.DesignationName = (item.DesignationName);
                _class.DesignationCreateDate = (item.DesignationCreateDate);
                _objListRequestProcessModel.Add(_class);
            }
            return View(_objListRequestProcessModel.ToList());
        }

        // GET: EmployeeDesignation/Details/5
        public ActionResult Details(int id)
        {
            CheckViewBagData();
            var model = _DbManageVisitorsEntities.tbl_DesignationMaster.Where(a => a.DesignationID == id).FirstOrDefault();

            var _objDepartmentEmployeeRegistration = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == model.DepartmentID).FirstOrDefault();

            model.DesignationID = model.DesignationID;
            model.DepartmentID = model.DepartmentID;
            model.DepartmentName = _objDepartmentEmployeeRegistration.DepartmentName;
            model.DesignationName = (model.DesignationName);
            model.DesignationCreateDate = (model.DesignationCreateDate);
            
            return View(model);
          
        }

        // GET: EmployeeDesignation/Create
        public ActionResult Create()
        {
            CheckViewBagData();
            ViewBag.DepartmentCombo = new SelectList(_DbManageVisitorsEntities.tbl_DepartmentMaster, "DepartmentID", "DepartmentName");
            return View();
        }

        // POST: EmployeeDesignation/Create
        [HttpPost]
        public ActionResult Create(tbl_DesignationMaster collection,int DepartmentCombo)
        {
            try
            {
                CheckViewBagData();
                // TODO: Add insert logic here
                collection.DepartmentID = DepartmentCombo;
                collection.DesignationCreateDate = DateTime.Now;
                _DbManageVisitorsEntities.tbl_DesignationMaster.Add(collection);
                _DbManageVisitorsEntities.SaveChanges();
                return RedirectToAction("Index");
               
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeDesignation/Edit/5
        public ActionResult Edit(int id)
        {
            CheckViewBagData();
            var model = _DbManageVisitorsEntities.tbl_DesignationMaster.Where(a => a.DesignationID == id).FirstOrDefault();

            var _objDepartmentEmployeeRegistration = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == model.DepartmentID).FirstOrDefault();

            model.DesignationID = model.DesignationID;
            model.DepartmentID = model.DepartmentID;
            model.DepartmentName = _objDepartmentEmployeeRegistration.DepartmentName;
            model.DesignationName = (model.DesignationName);
            model.DesignationCreateDate = (model.DesignationCreateDate);

            ViewBag.DepartmentCombo1 = new SelectList(_DbManageVisitorsEntities.tbl_DepartmentMaster, "DepartmentID", "DepartmentName", model.DepartmentID);

            return View(model);
        }

        // POST: EmployeeDesignation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, tbl_DesignationMaster collection)
        {
            try
            {
                CheckViewBagData();
                // TODO: Add update logic here
                var data = _DbManageVisitorsEntities.tbl_DesignationMaster.Where(b => b.DesignationID == id).FirstOrDefault();
                data.DepartmentID = collection.DepartmentID;
                data.DesignationName = collection.DesignationName;
                _DbManageVisitorsEntities.Entry(data).State = EntityState.Modified;
                _DbManageVisitorsEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeDesignation/Delete/5
        public ActionResult Delete(int id)
        {
             CheckViewBagData();
            var model = _DbManageVisitorsEntities.tbl_DesignationMaster.Where(a => a.DesignationID == id).FirstOrDefault();
            var _objDepartmentEmployeeRegistration = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == model.DepartmentID).FirstOrDefault();

            model.DesignationID = model.DesignationID;
            model.DepartmentID = model.DepartmentID;
            model.DepartmentName = _objDepartmentEmployeeRegistration.DepartmentName;
            model.DesignationName = (model.DesignationName);
            model.DesignationCreateDate = (model.DesignationCreateDate);

            return View(model);
        }

        // POST: EmployeeDesignation/Delete/5
        
        public ActionResult DeleteNow(int id)
        {
            try
            {
                CheckViewBagData();
                // TODO: Add delete logic here
                var model = _DbManageVisitorsEntities.tbl_DesignationMaster.Where(a => a.DesignationID == id).FirstOrDefault();
                _DbManageVisitorsEntities.tbl_DesignationMaster.Remove(model);
                _DbManageVisitorsEntities.SaveChanges();
                return RedirectToAction("Index");
              
            }
            catch
            {
                return View();
            }
        }
    }
}
