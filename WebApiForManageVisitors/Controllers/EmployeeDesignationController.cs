using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiForWorkPermitSystem.Models;
using WebApiForWorkPermitSystem.Models;

namespace WebApiForWorkPermitSystem.Controllers
{
    public class EmployeeDesignationController : Controller
    {
        WorkPermitSystemEntities _DbWorkPermitSystemEntities = new WorkPermitSystemEntities();
        // GET: EmployeeDesignation
        public void CheckViewBagData()
        {
            @ViewBag.Account = false;
            @ViewBag.EmployeeRegistration = false;
            @ViewBag.VendorRegistration = false;
            @ViewBag.EmployeeDepartment = false;
            @ViewBag.EmployeeDesignation = true;
            @ViewBag.ContractorMaster = false;
            @ViewBag.RequestDetails = false;
        }

        public ActionResult Index()
        {
            CheckViewBagData();

            List<DesignationMasterModel> _objListRequestProcessModel = new List<DesignationMasterModel>();
            var _objAllRequestProcessModel = _DbWorkPermitSystemEntities.tbl_DesignationMaster.ToList();

            foreach (var item in _objAllRequestProcessModel)
            {
                DesignationMasterModel _class = new DesignationMasterModel();

                var _objDepartmentEmployeeRegistration = _DbWorkPermitSystemEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == item.DepartmentID).FirstOrDefault();

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
            DesignationMasterModel _objDesignationModel = new DesignationMasterModel();
            var model = _DbWorkPermitSystemEntities.tbl_DesignationMaster.Where(a => a.DesignationID == id).FirstOrDefault();
            {
                var _objDepartmentEmployeeRegistration = _DbWorkPermitSystemEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == model.DepartmentID).FirstOrDefault();
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
            ViewBag.DepartmentCombo = new SelectList(_DbWorkPermitSystemEntities.tbl_DepartmentMaster, "DepartmentID", "DepartmentName");
            return View();
        }

        // POST: EmployeeDesignation/Create
        [HttpPost]
        public ActionResult Create(DesignationMasterModel collection,int? DepartmentCombo)
        {
          
            CheckViewBagData();
            if (ModelState.IsValid)
            {
                var data = new tbl_DesignationMaster
                {
                    DepartmentID = Convert.ToInt32(collection.DepartmentCombo),
                    DesignationName = collection.DesignationName,
                    DesignationCreateDate = DateTime.Now
                };

                if (!_DbWorkPermitSystemEntities.tbl_DesignationMaster.Any(p => p.DesignationName == collection.DesignationName && p.DepartmentID == DepartmentCombo))
                {
                  
                    try
                    {
                        _DbWorkPermitSystemEntities.tbl_DesignationMaster.Add(data);
                        _DbWorkPermitSystemEntities.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        return View();
                    }

                }
                else
                {
                    ViewBag.Errormessage = "Fail";
                }
                
            }
            ViewBag.DepartmentCombo = new SelectList(_DbWorkPermitSystemEntities.tbl_DepartmentMaster, "DepartmentID", "DepartmentName");
            return View();
        }
           
    
    // GET: EmployeeDesignation/Edit/5
    public ActionResult Edit(int id)
        {
            CheckViewBagData();
            DesignationMasterModel _objDesignationModel = new DesignationMasterModel();
            var model = _DbWorkPermitSystemEntities.tbl_DesignationMaster.Where(a => a.DesignationID == id).FirstOrDefault();
            {
                var _objDepartmentEmployeeRegistration = _DbWorkPermitSystemEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == model.DepartmentID).FirstOrDefault();
                _objDesignationModel.DesignationCreateDate = model.DesignationCreateDate;
                _objDesignationModel.DesignationID = model.DesignationID;
                _objDesignationModel.DepartmentID = model.DepartmentID;
                _objDesignationModel.DesignationName = model.DesignationName;
                _objDesignationModel.DepartmentName = _objDepartmentEmployeeRegistration.DepartmentName;
                //_objDesignationModel.DesignationCreateDate = model.DesignationCreateDate;
                //_objDesignationModel.DesignationCreateDate = model.DesignationCreateDate;
            };
            ViewBag.DepartmentCombo1 = new SelectList(_DbWorkPermitSystemEntities.tbl_DepartmentMaster, "DepartmentID", "DepartmentName", model.DepartmentID);
            return View(_objDesignationModel);
        }

        // POST: EmployeeDesignation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DesignationMasterModel collection)
        {
            try
            {
                CheckViewBagData();
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var data = _DbWorkPermitSystemEntities.tbl_DesignationMaster.Where(b => b.DesignationID == id).FirstOrDefault();
                    {
                        //data.DesignationID = collection.DesignationID;
                        //data.DepartmentID = collection.DepartmentID;
                         data.DesignationName = collection.DesignationName;
                         data.DepartmentID =Convert.ToInt32( collection.DepartmentCombo);
                        //data.DesignationCreateDate = data.DesignationCreateDate;
                        _DbWorkPermitSystemEntities.Entry(data).State = EntityState.Modified;
                        _DbWorkPermitSystemEntities.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
               ViewBag.DepartmentCombo1 = new SelectList(_DbWorkPermitSystemEntities.tbl_DepartmentMaster, "DepartmentID", "DepartmentName", Convert.ToInt32(collection.DepartmentCombo));
                return View();
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
            DesignationMasterModel _objtbl_DesignationMasterModel = new DesignationMasterModel();
            var model = _DbWorkPermitSystemEntities.tbl_DesignationMaster.Where(a => a.DesignationID == id).FirstOrDefault();
            var _objDepartmentEmployeeRegistration = _DbWorkPermitSystemEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == model.DepartmentID).FirstOrDefault();

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
                var model = _DbWorkPermitSystemEntities.tbl_DesignationMaster.Where(a => a.DesignationID == id).FirstOrDefault();
                _DbWorkPermitSystemEntities.tbl_DesignationMaster.Remove(model);
                _DbWorkPermitSystemEntities.SaveChanges();
                return RedirectToAction("Index");
              
            }
            catch
            {
                return View();
            }
        }
    }
}
