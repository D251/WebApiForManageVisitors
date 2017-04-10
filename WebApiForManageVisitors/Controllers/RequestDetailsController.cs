using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiForManageVisitors.Models;

namespace WebApiForManageVisitors.Controllers
{
    public class RequestDetailsController : Controller
    {
        ManageVisitorsEntities _DbManageVisitorsEntities = new ManageVisitorsEntities();
        public void CheckViewBagData()
        {
            @ViewBag.Account = false;
            @ViewBag.EmployeeRegistration = false;
            @ViewBag.VisitorRegistration = false;
            @ViewBag.EmployeeDepartment = false;
            @ViewBag.EmployeeDesignation = false;
            @ViewBag.ContractorMaster = false;
            @ViewBag.RequestDetails = true;
        }

        // GET: RequestDetails
        public ActionResult Index()
        {
            CheckViewBagData();
            List<ProcessRequestDetailsByRequestIDModel> _objProcessRequestDetailsByRequestIDModel = new List<ProcessRequestDetailsByRequestIDModel>();

            var RequestProcess = _DbManageVisitorsEntities.tbl_RequestProcess.ToList();

            foreach (var item in RequestProcess)
            {
                ProcessRequestDetailsByRequestIDModel _objProcessRequestDetailsByRequestID = new ProcessRequestDetailsByRequestIDModel();


                var _objAllRequestProcessModel = _DbManageVisitorsEntities.tbl_RequestProcess.Where(p => p.RequestProcessSrNo == item.RequestProcessSrNo).FirstOrDefault();

                var _objDepartmentEmployeeRegistration = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeSrNo == _objAllRequestProcessModel.EmployeeId).FirstOrDefault();

                var _objDepartmentMaster = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == _objDepartmentEmployeeRegistration.EmployeeDepartmentID).FirstOrDefault();

                var _objVisitorUserRegistration = _DbManageVisitorsEntities.tbl_VisitorUserRegistration.Where(p => p.VisitorSrNo == _objAllRequestProcessModel.VisitorSrNo).FirstOrDefault();

                var _objContractor = _DbManageVisitorsEntities.tbl_ContractorMaster.Where(p => p.ContractorSrNo == _objVisitorUserRegistration.VisitorContractorSrNo).FirstOrDefault();

                _objProcessRequestDetailsByRequestID.RequestProcessSrNo = _objAllRequestProcessModel.RequestProcessSrNo;
                _objProcessRequestDetailsByRequestID.EmployeeTokenNo = _objDepartmentEmployeeRegistration.EmployeeTokenNo;
                _objProcessRequestDetailsByRequestID.EmployeeName = _objDepartmentEmployeeRegistration.EmployeeName;
                _objProcessRequestDetailsByRequestID.EmployeeDepartmentName = _objDepartmentMaster.DepartmentName;
                _objProcessRequestDetailsByRequestID.VisitorName = _objVisitorUserRegistration.VisitorName;
                _objProcessRequestDetailsByRequestID.ContractorName = _objContractor.ContractorName;
                _objProcessRequestDetailsByRequestID.VisitStartTime = Convert.ToDateTime(_objAllRequestProcessModel.VisitStartTime);
                _objProcessRequestDetailsByRequestID.VisitEndTime = Convert.ToDateTime(_objAllRequestProcessModel.VisitEndTime);
                _objProcessRequestDetailsByRequestID.NatureOfWork = _objVisitorUserRegistration.VisitorNatureOfWork;
                _objProcessRequestDetailsByRequestID.NoOfVisitors = _objAllRequestProcessModel.NoOfVisitors;
                _objProcessRequestDetailsByRequestID.VisitorVisitResons = _objAllRequestProcessModel.VisitorVisitResons;
                _objProcessRequestDetailsByRequestID.EmployeeId = _objAllRequestProcessModel.EmployeeId;
                _objProcessRequestDetailsByRequestID.VisitorSrNo = _objAllRequestProcessModel.VisitorSrNo;
                _objProcessRequestDetailsByRequestID.EmployeeDepartmentID = _objAllRequestProcessModel.EmployeeDepartmentID;
                _objProcessRequestDetailsByRequestID.VisitorAccessories = _objAllRequestProcessModel.VisitorAccessories;
                _objProcessRequestDetailsByRequestID.RequestProcessDate = _objAllRequestProcessModel.RequestProcessDate;
                _objProcessRequestDetailsByRequestID.ActivityOwnerStatus = _objAllRequestProcessModel.ActivityOwnerStatus;
                _objProcessRequestDetailsByRequestID.AreaOwnerStatus = _objAllRequestProcessModel.AreaOwnerStatus;
                _objProcessRequestDetailsByRequestID.SafetyStatus = _objAllRequestProcessModel.SafetyStatus;
                _objProcessRequestDetailsByRequestID.ContractorStatus = _objAllRequestProcessModel.ContractorStatus;

                _objProcessRequestDetailsByRequestIDModel.Add(_objProcessRequestDetailsByRequestID);
            }

            return View(_objProcessRequestDetailsByRequestIDModel.ToList());

        }

        // GET: RequestDetails/Details/5
        public ActionResult Details(int id)
        {
            CheckViewBagData();
            ProcessRequestDetailsByRequestIDModel _objProcessRequestDetailsByRequestID = new ProcessRequestDetailsByRequestIDModel();


            var _objAllRequestProcessModel = _DbManageVisitorsEntities.tbl_RequestProcess.Where(p => p.RequestProcessSrNo == id).FirstOrDefault();

            var _objDepartmentEmployeeRegistration = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeSrNo == _objAllRequestProcessModel.EmployeeId).FirstOrDefault();

            var _objDepartmentMaster = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == _objDepartmentEmployeeRegistration.EmployeeDepartmentID).FirstOrDefault();

            var _objVisitorUserRegistration = _DbManageVisitorsEntities.tbl_VisitorUserRegistration.Where(p => p.VisitorSrNo == _objAllRequestProcessModel.VisitorSrNo).FirstOrDefault();

            var _objContractor = _DbManageVisitorsEntities.tbl_ContractorMaster.Where(p => p.ContractorSrNo == _objVisitorUserRegistration.VisitorContractorSrNo).FirstOrDefault();

            _objProcessRequestDetailsByRequestID.RequestProcessSrNo = _objAllRequestProcessModel.RequestProcessSrNo;
            _objProcessRequestDetailsByRequestID.EmployeeTokenNo = _objDepartmentEmployeeRegistration.EmployeeTokenNo;
            _objProcessRequestDetailsByRequestID.EmployeeName = _objDepartmentEmployeeRegistration.EmployeeName;
            _objProcessRequestDetailsByRequestID.EmployeeDepartmentName = _objDepartmentMaster.DepartmentName;
            _objProcessRequestDetailsByRequestID.VisitorName = _objVisitorUserRegistration.VisitorName;
            _objProcessRequestDetailsByRequestID.ContractorName = _objContractor.ContractorName;
            _objProcessRequestDetailsByRequestID.VisitStartTime = Convert.ToDateTime(_objAllRequestProcessModel.VisitStartTime);
            _objProcessRequestDetailsByRequestID.VisitEndTime = Convert.ToDateTime(_objAllRequestProcessModel.VisitEndTime);
            _objProcessRequestDetailsByRequestID.NatureOfWork = _objVisitorUserRegistration.VisitorNatureOfWork;
            _objProcessRequestDetailsByRequestID.NoOfVisitors = _objAllRequestProcessModel.NoOfVisitors;
            _objProcessRequestDetailsByRequestID.VisitorVisitResons = _objAllRequestProcessModel.VisitorVisitResons;
            _objProcessRequestDetailsByRequestID.EmployeeId = _objAllRequestProcessModel.EmployeeId;
            _objProcessRequestDetailsByRequestID.VisitorSrNo = _objAllRequestProcessModel.VisitorSrNo;
            _objProcessRequestDetailsByRequestID.EmployeeDepartmentID = _objAllRequestProcessModel.EmployeeDepartmentID;
            _objProcessRequestDetailsByRequestID.VisitorAccessories = _objAllRequestProcessModel.VisitorAccessories;
            _objProcessRequestDetailsByRequestID.RequestProcessDate = _objAllRequestProcessModel.RequestProcessDate;
            _objProcessRequestDetailsByRequestID.ActivityOwnerStatus = _objAllRequestProcessModel.ActivityOwnerStatus;
            _objProcessRequestDetailsByRequestID.AreaOwnerStatus = _objAllRequestProcessModel.AreaOwnerStatus;
            _objProcessRequestDetailsByRequestID.SafetyStatus = _objAllRequestProcessModel.SafetyStatus;
            _objProcessRequestDetailsByRequestID.ContractorStatus = _objAllRequestProcessModel.ContractorStatus;

            return View(_objProcessRequestDetailsByRequestID);
        }

        // GET: RequestDetails/Create
        public ActionResult Create()
        {
            CheckViewBagData();
            return View();
        }

        // POST: RequestDetails/Create
        [HttpPost]
        public ActionResult Create(tbl_RequestProcess collection)
        {
            try
            {
                // TODO: Add insert logic here
                CheckViewBagData();

                collection.RequestProcessDate = DateTime.Now;
                _DbManageVisitorsEntities.tbl_RequestProcess.Add(collection);
                _DbManageVisitorsEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RequestDetails/Edit/5
        public ActionResult Edit(int id)
        {
            CheckViewBagData();

            ProcessRequestDetailsByRequestIDModel _objProcessRequestDetailsByRequestID = new ProcessRequestDetailsByRequestIDModel();


            var _objAllRequestProcessModel = _DbManageVisitorsEntities.tbl_RequestProcess.Where(p => p.RequestProcessSrNo == id).FirstOrDefault();

            var _objDepartmentEmployeeRegistration = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeSrNo == _objAllRequestProcessModel.EmployeeId).FirstOrDefault();

            var _objDepartmentMaster = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == _objDepartmentEmployeeRegistration.EmployeeDepartmentID).FirstOrDefault();

            var _objVisitorUserRegistration = _DbManageVisitorsEntities.tbl_VisitorUserRegistration.Where(p => p.VisitorSrNo == _objAllRequestProcessModel.VisitorSrNo).FirstOrDefault();

            var _objContractor = _DbManageVisitorsEntities.tbl_ContractorMaster.Where(p => p.ContractorSrNo == _objVisitorUserRegistration.VisitorContractorSrNo).FirstOrDefault();

            _objProcessRequestDetailsByRequestID.RequestProcessSrNo = _objAllRequestProcessModel.RequestProcessSrNo;
            _objProcessRequestDetailsByRequestID.EmployeeTokenNo = _objDepartmentEmployeeRegistration.EmployeeTokenNo;
            _objProcessRequestDetailsByRequestID.EmployeeName = _objDepartmentEmployeeRegistration.EmployeeName;
            _objProcessRequestDetailsByRequestID.EmployeeDepartmentName = _objDepartmentMaster.DepartmentName;
            _objProcessRequestDetailsByRequestID.VisitorName = _objVisitorUserRegistration.VisitorName;
            _objProcessRequestDetailsByRequestID.ContractorName = _objContractor.ContractorName;
            _objProcessRequestDetailsByRequestID.VisitStartTime = Convert.ToDateTime(_objAllRequestProcessModel.VisitStartTime);
            _objProcessRequestDetailsByRequestID.VisitEndTime = Convert.ToDateTime(_objAllRequestProcessModel.VisitEndTime);
            _objProcessRequestDetailsByRequestID.NatureOfWork = _objVisitorUserRegistration.VisitorNatureOfWork;
            _objProcessRequestDetailsByRequestID.NoOfVisitors = _objAllRequestProcessModel.NoOfVisitors;
            _objProcessRequestDetailsByRequestID.VisitorVisitResons = _objAllRequestProcessModel.VisitorVisitResons;
            _objProcessRequestDetailsByRequestID.EmployeeId = _objAllRequestProcessModel.EmployeeId;
            _objProcessRequestDetailsByRequestID.VisitorSrNo = _objAllRequestProcessModel.VisitorSrNo;
            _objProcessRequestDetailsByRequestID.EmployeeDepartmentID = _objAllRequestProcessModel.EmployeeDepartmentID;
            _objProcessRequestDetailsByRequestID.VisitorAccessories = _objAllRequestProcessModel.VisitorAccessories;
            _objProcessRequestDetailsByRequestID.RequestProcessDate = _objAllRequestProcessModel.RequestProcessDate;
            _objProcessRequestDetailsByRequestID.ActivityOwnerStatus = _objAllRequestProcessModel.ActivityOwnerStatus;
            _objProcessRequestDetailsByRequestID.AreaOwnerStatus = _objAllRequestProcessModel.AreaOwnerStatus;
            _objProcessRequestDetailsByRequestID.SafetyStatus = _objAllRequestProcessModel.SafetyStatus;
            _objProcessRequestDetailsByRequestID.ContractorStatus = _objAllRequestProcessModel.ContractorStatus;

            return View(_objProcessRequestDetailsByRequestID);
        }

        // POST: RequestDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProcessRequestDetailsByRequestIDModel collection)
        {
            try
            {
                // TODO: Add update logic here
                CheckViewBagData();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RequestDetails/Delete/5
        public ActionResult Delete(int id)
        {
            CheckViewBagData();
            ProcessRequestDetailsByRequestIDModel _objProcessRequestDetailsByRequestID = new ProcessRequestDetailsByRequestIDModel();


            var _objAllRequestProcessModel = _DbManageVisitorsEntities.tbl_RequestProcess.Where(p => p.RequestProcessSrNo == id).FirstOrDefault();

            var _objDepartmentEmployeeRegistration = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeSrNo == _objAllRequestProcessModel.EmployeeId).FirstOrDefault();

            var _objDepartmentMaster = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == _objDepartmentEmployeeRegistration.EmployeeDepartmentID).FirstOrDefault();

            var _objVisitorUserRegistration = _DbManageVisitorsEntities.tbl_VisitorUserRegistration.Where(p => p.VisitorSrNo == _objAllRequestProcessModel.VisitorSrNo).FirstOrDefault();

            var _objContractor = _DbManageVisitorsEntities.tbl_ContractorMaster.Where(p => p.ContractorSrNo == _objVisitorUserRegistration.VisitorContractorSrNo).FirstOrDefault();


            _objProcessRequestDetailsByRequestID.RequestProcessSrNo = _objAllRequestProcessModel.RequestProcessSrNo;
            _objProcessRequestDetailsByRequestID.EmployeeTokenNo = _objDepartmentEmployeeRegistration.EmployeeTokenNo;
            _objProcessRequestDetailsByRequestID.EmployeeName = _objDepartmentEmployeeRegistration.EmployeeName;
            _objProcessRequestDetailsByRequestID.EmployeeDepartmentName = _objDepartmentMaster.DepartmentName;
            _objProcessRequestDetailsByRequestID.VisitorName = _objVisitorUserRegistration.VisitorName;
            _objProcessRequestDetailsByRequestID.ContractorName = _objContractor.ContractorName;
            _objProcessRequestDetailsByRequestID.VisitStartTime = Convert.ToDateTime(_objAllRequestProcessModel.VisitStartTime);
            _objProcessRequestDetailsByRequestID.VisitEndTime = Convert.ToDateTime(_objAllRequestProcessModel.VisitEndTime);
            _objProcessRequestDetailsByRequestID.NatureOfWork = _objVisitorUserRegistration.VisitorNatureOfWork;
            _objProcessRequestDetailsByRequestID.NoOfVisitors = _objAllRequestProcessModel.NoOfVisitors;
            _objProcessRequestDetailsByRequestID.VisitorVisitResons = _objAllRequestProcessModel.VisitorVisitResons;
            _objProcessRequestDetailsByRequestID.EmployeeId = _objAllRequestProcessModel.EmployeeId;
            _objProcessRequestDetailsByRequestID.VisitorSrNo = _objAllRequestProcessModel.VisitorSrNo;
            _objProcessRequestDetailsByRequestID.EmployeeDepartmentID = _objAllRequestProcessModel.EmployeeDepartmentID;
            _objProcessRequestDetailsByRequestID.VisitorAccessories = _objAllRequestProcessModel.VisitorAccessories;
            _objProcessRequestDetailsByRequestID.RequestProcessDate = _objAllRequestProcessModel.RequestProcessDate;
            _objProcessRequestDetailsByRequestID.ActivityOwnerStatus = _objAllRequestProcessModel.ActivityOwnerStatus;
            _objProcessRequestDetailsByRequestID.AreaOwnerStatus = _objAllRequestProcessModel.AreaOwnerStatus;
            _objProcessRequestDetailsByRequestID.SafetyStatus = _objAllRequestProcessModel.SafetyStatus;
            _objProcessRequestDetailsByRequestID.ContractorStatus = _objAllRequestProcessModel.ContractorStatus;

            return View(_objProcessRequestDetailsByRequestID);
        }

        // POST: RequestDetails/Delete/5

        public ActionResult DeleteNow(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                CheckViewBagData();
                var model = _DbManageVisitorsEntities.tbl_RequestProcess.Where(a => a.RequestProcessSrNo == id).FirstOrDefault();
                _DbManageVisitorsEntities.tbl_RequestProcess.Remove(model);
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
