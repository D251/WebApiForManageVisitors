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
            @ViewBag.EmployeeDepartment = false;
            @ViewBag.EmployeeDesignation = true;
        }

        public ActionResult Index()
        {
            CheckViewBagData();
            var Designation = _DbManageVisitorsEntities.tbl_DesignationMaster;
            return View(Designation.ToList());
        }

        // GET: EmployeeDesignation/Details/5
        public ActionResult Details(int id)
        {
            CheckViewBagData();
            var model = _DbManageVisitorsEntities.tbl_DesignationMaster.Where(a => a.DesignationID == id).FirstOrDefault();
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
