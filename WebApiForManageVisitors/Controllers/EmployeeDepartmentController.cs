using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiForManageVisitors.Models;

namespace WebApiForManageVisitors.Controllers
{
    public class EmployeeDepartmentController : Controller
    {
        ManageVisitorsEntities _DbManageVisitorsEntities = new ManageVisitorsEntities();
        // GET: EmployeeDepartment
        public ActionResult Index()
        {
            var Department = _DbManageVisitorsEntities.tbl_DepartmentMaster;
            return View(Department.ToList());
           
        }

        // GET: EmployeeDepartment/Details/5
        public ActionResult Details(int id)
        {
            var model = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(a => a.DepartmentID == id).FirstOrDefault();
            return View(model);
        }

        // GET: EmployeeDepartment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeDepartment/Create
        [HttpPost]
        public ActionResult Create(tbl_DepartmentMaster collection)
        {
            try
            {
                // TODO: Add insert logic here
                _DbManageVisitorsEntities.tbl_DepartmentMaster.Add(collection);
                _DbManageVisitorsEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeDepartment/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(a => a.DepartmentID == id).FirstOrDefault();
            return View(model);

        }

        // POST: EmployeeDepartment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, tbl_DepartmentMaster collection)
        {
            try
            {
                // TODO: Add update logic here
                var data = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(b => b.DepartmentID == id).FirstOrDefault();
                data.DepartmentName = collection.DepartmentName;
               _DbManageVisitorsEntities.Entry(data).State = EntityState.Modified;
                _DbManageVisitorsEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeDepartment/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(a => a.DepartmentID == id).FirstOrDefault();
            return View(model);

            
        }

        // POST: EmployeeDepartment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, tbl_DepartmentMaster collection)
        {
            try
            {
                // TODO: Add delete logic here
                var model = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(a => a.DepartmentID == id).FirstOrDefault();
                _DbManageVisitorsEntities.tbl_DepartmentMaster.Remove(model);
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
