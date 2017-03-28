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

            List<DesignationMasterModel> _objListRequestProcessModel = new List<DesignationMasterModel>();
            var _objAllRequestProcessModel = _DbManageVisitorsEntities.tbl_DesignationMaster.ToList();

            foreach (var item in _objAllRequestProcessModel)
            {
                DesignationMasterModel _class = new DesignationMasterModel();

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
            tbl_DesignationMasterModel _objDesignationModel = new tbl_DesignationMasterModel();
            var model = _DbManageVisitorsEntities.tbl_DesignationMaster.Where(a => a.DesignationID == id).FirstOrDefault();
            {
                var _objDepartmentEmployeeRegistration = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == model.DepartmentID).FirstOrDefault();
                _objDesignationModel.DesignationID = model.DesignationID;
                _objDesignationModel.DesignationName = model.DesignationName;
                _objDesignationModel.DepartmentName = _objDepartmentEmployeeRegistration.DepartmentName;
                _objDesignationModel.DepartmentID = model.DepartmentID;
                _objDesignationModel.DesignationCreateDate = model.DesignationCreateDate;
            };
            return View(_objDesignationModel);
          
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
        public ActionResult Create(DesignationMasterModel collection,int DepartmentCombo)
        {
            try
            {
                CheckViewBagData();
                var data = new tbl_DesignationMaster
                {
                    DepartmentID = DepartmentCombo,
                    DesignationName = collection.DesignationName,
                    DesignationCreateDate = DateTime.Now
                };
                _DbManageVisitorsEntities.tbl_DesignationMaster.Add(data);
                _DbManageVisitorsEntities.SaveChanges();

                return RedirectToAction("Index");
               
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: EmployeeDesignation/Edit/5
        public ActionResult Edit(int id)
        {
            CheckViewBagData();
            tbl_DesignationMasterModel _objDesignationModel = new tbl_DesignationMasterModel();
            var model = _DbManageVisitorsEntities.tbl_DesignationMaster.Where(a => a.DesignationID == id).FirstOrDefault();
            {
                var _objDepartmentEmployeeRegistration = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == model.DepartmentID).FirstOrDefault();
                _objDesignationModel.DesignationCreateDate = model.DesignationCreateDate;
                _objDesignationModel.DesignationID = model.DesignationID;
                _objDesignationModel.DepartmentID = model.DepartmentID;
                _objDesignationModel.DesignationName = model.DesignationName;
                _objDesignationModel.DepartmentName = _objDepartmentEmployeeRegistration.DepartmentName;
                //_objDesignationModel.DesignationCreateDate = model.DesignationCreateDate;
                //_objDesignationModel.DesignationCreateDate = model.DesignationCreateDate;
            };
            ViewBag.DepartmentCombo1 = new SelectList(_DbManageVisitorsEntities.tbl_DepartmentMaster, "DepartmentID", "DepartmentName", model.DepartmentID);
            return View(_objDesignationModel);
        }

        // POST: EmployeeDesignation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, tbl_DesignationMasterModel collection)
        {
            try
            {
                CheckViewBagData();
                // TODO: Add update logic here
               
                var data = _DbManageVisitorsEntities.tbl_DesignationMaster.Where(b => b.DesignationID == id).FirstOrDefault();
                {
                    data.DesignationID = collection.DesignationID;
                    data.DepartmentID = collection.DepartmentID;
                    data.DesignationName = collection.DesignationName;
                    data.DesignationCreateDate = collection.DesignationCreateDate;
                    _DbManageVisitorsEntities.Entry(data).State = EntityState.Modified;
                    _DbManageVisitorsEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: EmployeeDesignation/Delete/5
        public ActionResult Delete(int id)
        {
            CheckViewBagData();
            tbl_DesignationMasterModel _objtbl_DesignationMasterModel = new tbl_DesignationMasterModel();
            var model = _DbManageVisitorsEntities.tbl_DesignationMaster.Where(a => a.DesignationID == id).FirstOrDefault();
            var _objDepartmentEmployeeRegistration = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == model.DepartmentID).FirstOrDefault();

            _objtbl_DesignationMasterModel.DesignationID = model.DesignationID;
            _objtbl_DesignationMasterModel.DepartmentID = model.DepartmentID;
            _objtbl_DesignationMasterModel.DepartmentName = _objDepartmentEmployeeRegistration.DepartmentName;
            _objtbl_DesignationMasterModel.DesignationName = (model.DesignationName);
            _objtbl_DesignationMasterModel.DesignationCreateDate = (model.DesignationCreateDate);

            return View(_objtbl_DesignationMasterModel);
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
