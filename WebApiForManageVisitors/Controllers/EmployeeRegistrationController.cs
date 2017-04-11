using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApiForManageVisitors.Areas.Admin.Controllers;
using WebApiForManageVisitors.Models;

namespace WebApiForManageVisitors.Controllers
{
    public class EmployeeRegistrationController : Controller
    {
        ManageVisitorsEntities _DbManageVisitorsEntities = new ManageVisitorsEntities();
        // GET: EmployeeRegistration
        public void CheckViewBagData()
        {
            @ViewBag.EmployeeRegistration = true;
            @ViewBag.Account = false;
            @ViewBag.VisitorRegistration = false;
            @ViewBag.EmployeeDepartment = false;
            @ViewBag.EmployeeDesignation = false;
            @ViewBag.ContractorMaster = false;
            @ViewBag.RequestDetails = false;
        }

        public ActionResult Index()
        {
            CheckViewBagData();
            List<DepartmentEmployeeRegistrationModel> _objEmployeeModel = new List<DepartmentEmployeeRegistrationModel>();
            var Employee = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.ToList();

            foreach (var item in Employee)
            {
                DepartmentEmployeeRegistrationModel _objEmployeeModelItem = new DepartmentEmployeeRegistrationModel();
                var _objEmployee = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeSrNo == item.EmployeeSrNo).FirstOrDefault();
                _objEmployeeModelItem.EmployeeSrNo = _objEmployee.EmployeeSrNo;
                _objEmployeeModelItem.EmployeeTokenNo = _objEmployee.EmployeeTokenNo;
                _objEmployeeModelItem.EmployeeName = _objEmployee.EmployeeName;
                _objEmployeeModelItem.EmployeeAddress = _objEmployee.EmployeeAddress;
                _objEmployeeModelItem.EmployeeContactNo = _objEmployee.EmployeeContactNo;
                _objEmployeeModelItem.EmployeeDepartmentID = _objEmployee.EmployeeDepartmentID;
                _objEmployeeModelItem.EmployeeDesignationID = _objEmployee.EmployeeDesignationID;
                _objEmployeeModelItem.EmployeeEmailID = _objEmployee.EmployeeEmailID;
                _objEmployeeModelItem.EmployeePassword = _objEmployee.EmployeePassword;
                _objEmployeeModelItem.Date = _objEmployee.Date;
                _objEmployeeModel.Add(_objEmployeeModelItem);
            }

            return View(_objEmployeeModel.ToList());

        }

        // GET: EmployeeRegistration/Details/5
        public ActionResult Details(int id)
        {
            CheckViewBagData();

            var _objEmployee = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeSrNo == id).FirstOrDefault();
            var _objDesignation = _DbManageVisitorsEntities.tbl_DesignationMaster.Where(a => a.DesignationID == _objEmployee.EmployeeDesignationID).FirstOrDefault();
            var _objDepartment = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == _objEmployee.EmployeeDepartmentID).FirstOrDefault();

            DepartmentEmployeeRegistrationModel _objEmployeeModelItem = new DepartmentEmployeeRegistrationModel();
            _objEmployeeModelItem.EmployeeSrNo = _objEmployee.EmployeeSrNo;
            _objEmployeeModelItem.EmployeeTokenNo = _objEmployee.EmployeeTokenNo;
            _objEmployeeModelItem.EmployeeName = _objEmployee.EmployeeName;
            _objEmployeeModelItem.EmployeeAddress = _objEmployee.EmployeeAddress;
            _objEmployeeModelItem.EmployeeContactNo = _objEmployee.EmployeeContactNo;
            _objEmployeeModelItem.EmployeeDepartmentID = _objEmployee.EmployeeDepartmentID;
            _objEmployeeModelItem.EmployeeDesignationID = _objEmployee.EmployeeDesignationID;
            _objEmployeeModelItem.DepartmentName = _objDepartment.DepartmentName;
            _objEmployeeModelItem.DesignationName = _objDesignation.DesignationName;
            _objEmployeeModelItem.EmployeeEmailID = _objEmployee.EmployeeEmailID;
            _objEmployeeModelItem.EmployeePassword = _objEmployee.EmployeePassword;
            _objEmployeeModelItem.Date = _objEmployee.Date;

            return View(_objEmployeeModelItem);
        }

        // GET: EmployeeRegistration/Create
        public ActionResult Create()
        {
            CheckViewBagData();
            ViewBag.DepartmentCombo = new SelectList(_DbManageVisitorsEntities.tbl_DepartmentMaster, "DepartmentID", "DepartmentName");
            ViewBag.DesignationCombo1 = new SelectList(_DbManageVisitorsEntities.tbl_DesignationMaster, "DesignationID", "DesignationName");
            return View();

            //other Way

            //ViewBag.DepartmentCombo = _DbManageVisitorsEntities.tbl_DepartmentMaster;
            //var model = new DepartmentEmployeeRegistrationModel();
            //return View(model);

        }


        public JsonResult GetDesignationByID(int id)
        {
            CheckViewBagData();
            _DbManageVisitorsEntities.Configuration.ProxyCreationEnabled = false;
            //var R = Json(_DbManageVisitorsEntities.tbl_DesignationMaster.Where(P => P.DepartmentID == id), JsonRequestBehavior.AllowGet);
            var Designationlist = (_DbManageVisitorsEntities.tbl_DesignationMaster.Where(P => P.DepartmentID == id));
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(Designationlist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Create(DepartmentEmployeeRegistrationModel collection, int? DesignationCombo)
        {
            try
            {
                CheckViewBagData();
                if (ModelState.IsValid)
                {
                    var data = new tbl_DepartmentEmployeeRegistration()
                    {
                        EmployeeTokenNo = collection.EmployeeTokenNo,
                        EmployeeAddress = collection.EmployeeAddress,
                        EmployeeContactNo = collection.EmployeeContactNo,
                        EmployeeDepartmentID = collection.EmployeeDepartmentID,
                        // EmployeeDesignationID = collection.EmployeeDesignationID,
                        EmployeeDesignationID =Convert.ToInt32(collection.DesignationCombo1),
                        EmployeeEmailID = collection.EmployeeEmailID,
                        EmployeeName = collection.EmployeeName,
                        EmployeePassword = collection.EmployeePassword,
                        // Date = DateTime.Now
                    };
                    _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Add(data);
                    if (!_DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Any(p => p.EmployeeTokenNo == collection.EmployeeTokenNo))
                    {

                        _DbManageVisitorsEntities.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["ErrorTokenNo"] = "Token No. Already Present !!!";
                    }

                  
                }
                //other way
               //ViewBag.DepartmentCombo = _DbManageVisitorsEntities.tbl_DepartmentMaster;

               ViewBag.DepartmentCombo = new SelectList(_DbManageVisitorsEntities.tbl_DepartmentMaster, "DepartmentID", "DepartmentName");
                //ViewBag.DesignationCombo = new SelectList(_DbManageVisitorsEntities.tbl_DesignationMaster, "DesignationID", "DesignationName");
                return View();
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
        public ActionResult Edit(int id, int id1)
        {
            CheckViewBagData();
           var Designation=_DbManageVisitorsEntities.tbl_DesignationMaster.Where(e => e.DepartmentID == id1).FirstOrDefault();
          
            DepartmentEmployeeRegistrationModel _objEmployeeModel = new DepartmentEmployeeRegistrationModel();
            var _objEmployee = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Where(E => E.EmployeeSrNo == id).FirstOrDefault();
            {
                var Department = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(e => e.DepartmentID == _objEmployee.EmployeeDepartmentID).FirstOrDefault();
               // _objEmployeeModel.EmployeeSrNo = _objEmployee.EmployeeSrNo;
                _objEmployeeModel.EmployeeTokenNo = _objEmployee.EmployeeTokenNo;
                _objEmployeeModel.EmployeeName = _objEmployee.EmployeeName;
                _objEmployeeModel.EmployeeAddress = _objEmployee.EmployeeAddress;
                _objEmployeeModel.EmployeeContactNo = _objEmployee.EmployeeContactNo;
                _objEmployeeModel.EmployeeEmailID = _objEmployee.EmployeeEmailID;
                _objEmployeeModel.EmployeeDepartmentID = _objEmployee.EmployeeDepartmentID;
               _objEmployeeModel.DeviceTokenId = _objEmployee.DeviceTokenId;
                _objEmployeeModel.DesignationCombo1 =Convert.ToString( _objEmployee.EmployeeDesignationID);
               // _objEmployeeModel.DepartmentName = Department.DepartmentName;
                //_objEmployeeModel.DesignationName = Designation.DesignationName;
                // _objEmployeeModel.Date = _objEmployee.Date;
                _objEmployeeModel.EmployeePassword = _objEmployee.EmployeePassword;

            };

            ViewBag.DepartmentCombo1 = new SelectList(_DbManageVisitorsEntities.tbl_DepartmentMaster, "DepartmentID", "DepartmentName", _objEmployeeModel.EmployeeDepartmentID);
            ViewBag.DesignationCombo1 = new SelectList(_DbManageVisitorsEntities.tbl_DesignationMaster.Where(e => e.DepartmentID == id1), "DesignationID", "DesignationName", _objEmployeeModel.EmployeeDesignationID);
            return View(_objEmployeeModel);

        }

        // POST: EmployeeRegistration/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DepartmentEmployeeRegistrationModel collection, int? DesignationCombo1)
        {
            try
            {
                // TODO: Add update logic here
                CheckViewBagData();
                if (ModelState.IsValid)
                {
                    var data = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Where(b => b.EmployeeSrNo == id).FirstOrDefault();
                    {
                        //data.EmployeeSrNo = collection.EmployeeSrNo;
                        data.EmployeeName = collection.EmployeeName;
                        data.EmployeeTokenNo = collection.EmployeeTokenNo;
                        data.EmployeeAddress = collection.EmployeeAddress;
                        data.EmployeeContactNo = collection.EmployeeContactNo;
                        data.EmployeeEmailID = collection.EmployeeEmailID;
                        data.EmployeeDepartmentID = collection.EmployeeDepartmentID;
                        data.EmployeeDesignationID = Convert.ToInt32(collection.DesignationCombo1);
                        data.EmployeePassword = collection.EmployeePassword;

                    };

                    _DbManageVisitorsEntities.Entry(data).State = EntityState.Modified;
                    _DbManageVisitorsEntities.SaveChanges();
                     return RedirectToAction("Index");
                  
                }

                ViewBag.DepartmentCombo1 = new SelectList(_DbManageVisitorsEntities.tbl_DepartmentMaster, "DepartmentID", "DepartmentName", collection.EmployeeDepartmentID);
                ViewBag.DesignationCombo1 = new SelectList(_DbManageVisitorsEntities.tbl_DesignationMaster.Where(e => e.DepartmentID == collection.EmployeeDepartmentID), "DesignationID", "DesignationName", collection.EmployeeDesignationID);
                //  SendPushNotification();
                // var resultade = new AdminApiForMVController().SendPushNotification("f","f","f");
               // var r = new AdminApiForMVController().SendPushNotification(collection.DeviceTokenId, collection.EmployeeName, "Emp");
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: EmployeeRegistration/Delete/5
        public ActionResult Delete(int id)
        {
            CheckViewBagData();

            var _objEmployee = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeSrNo == id).FirstOrDefault();
            var _objDesignation = _DbManageVisitorsEntities.tbl_DesignationMaster.Where(a => a.DesignationID == _objEmployee.EmployeeDesignationID).FirstOrDefault();
            var _objDepartment = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == _objEmployee.EmployeeDepartmentID).FirstOrDefault();

            DepartmentEmployeeRegistrationModel _objEmployeeModelItem = new DepartmentEmployeeRegistrationModel();
            _objEmployeeModelItem.EmployeeSrNo = _objEmployee.EmployeeSrNo;
            _objEmployeeModelItem.EmployeeTokenNo = _objEmployee.EmployeeTokenNo;
            _objEmployeeModelItem.EmployeeName = _objEmployee.EmployeeName;
            _objEmployeeModelItem.EmployeeAddress = _objEmployee.EmployeeAddress;
            _objEmployeeModelItem.EmployeeContactNo = _objEmployee.EmployeeContactNo;
            _objEmployeeModelItem.EmployeeDepartmentID = _objEmployee.EmployeeDepartmentID;
            _objEmployeeModelItem.EmployeeDesignationID = _objEmployee.EmployeeDesignationID;
            _objEmployeeModelItem.DepartmentName = _objDepartment.DepartmentName;
            _objEmployeeModelItem.DesignationName = _objDesignation.DesignationName;
            _objEmployeeModelItem.EmployeeEmailID = _objEmployee.EmployeeEmailID;
            _objEmployeeModelItem.EmployeePassword = _objEmployee.EmployeePassword;
            _objEmployeeModelItem.Date = _objEmployee.Date;

            return View(_objEmployeeModelItem);
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
        
    }
}
