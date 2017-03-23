using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiForManageVisitors.Models;

namespace WebApiForManageVisitors.Controllers
{
    public class VisitorRegistrationController : Controller
    {
        ManageVisitorsEntities _DbManageVisitorsEntities = new ManageVisitorsEntities();
        public void CheckViewBagData()
        {
            @ViewBag.EmployeeRegistration = false;
            @ViewBag.VisitorRegistration = true;
            @ViewBag.EmployeeDepartment = false;
            @ViewBag.EmployeeDesignation = false;
        }
        // GET: VisitorRegistration
        public ActionResult Index()
        {
            CheckViewBagData();
            var _objVisitorUserRegistration = _DbManageVisitorsEntities.tbl_VisitorUserRegistration.ToList();
            return View(_objVisitorUserRegistration.ToList());
        }

        // GET: VisitorRegistration/Details/5
        public ActionResult Details(int id)
        {
            CheckViewBagData();
            var model = _DbManageVisitorsEntities.tbl_VisitorUserRegistration.Where(a => a.VisitorSrNo == id).FirstOrDefault();
            return View(model);
        }

        // GET: VisitorRegistration/Create
        public ActionResult Create()
        {
            CheckViewBagData();
            return View();
        }

        // POST: VisitorRegistration/Create
        [HttpPost]
        public ActionResult Create(tbl_VisitorUserRegistration collection)
        {
            try
            {
                CheckViewBagData();
                collection.VisitorRegistrationDate = DateTime.Now;
                _DbManageVisitorsEntities.tbl_VisitorUserRegistration.Add(collection);
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

        // GET: VisitorRegistration/Edit/5
        public ActionResult Edit(int id)
        {
            CheckViewBagData();
            tbl_VisitorUserRegistration data = _DbManageVisitorsEntities.tbl_VisitorUserRegistration.Find(id);
            return View(data);
        }

        // POST: VisitorRegistration/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, tbl_VisitorUserRegistration collection)
        {
            try
            {
                // TODO: Add update logic here
                CheckViewBagData();
                var data = _DbManageVisitorsEntities.tbl_VisitorUserRegistration.Where(b => b.VisitorSrNo == id).FirstOrDefault();
                //data.EmployeeSrNo = collection.EmployeeSrNo;
                data.VisitorUserID = collection.VisitorUserID;
                data.VisitorName = collection.VisitorName;
                data.VisitorAddress = collection.VisitorAddress;
                data.VisitorContactNo = collection.VisitorContactNo;
                data.VisitorEmailID = collection.VisitorEmailID;
                data.VisitorNatureOfWork = collection.VisitorNatureOfWork;
                data.VisitorContractor = collection.VisitorContractor;
                data.VisitorContractorCoNo = collection.VisitorContractorCoNo;
                data.VisitorPassword = collection.VisitorPassword;
                _DbManageVisitorsEntities.Entry(data).State = EntityState.Modified;
                _DbManageVisitorsEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: VisitorRegistration/Delete/5
        public ActionResult Delete(int id)
        {
            CheckViewBagData();
            var model = _DbManageVisitorsEntities.tbl_VisitorUserRegistration.Where(a => a.VisitorSrNo == id).FirstOrDefault();
            return View(model);
        }

        // POST: VisitorRegistration/Delete/5
       
        public ActionResult DeleteNow(int id)
        {
            try
            {
                CheckViewBagData();
                var model = _DbManageVisitorsEntities.tbl_VisitorUserRegistration.Where(a => a.VisitorSrNo == id).FirstOrDefault();
                _DbManageVisitorsEntities.tbl_VisitorUserRegistration.Remove(model);
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
