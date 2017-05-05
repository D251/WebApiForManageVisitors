using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApiForWorkPermitSystem.Models;
using WebApiForWorkPermitSystem.Models;

namespace WebApiForWorkPermitSystem.Controllers
{
    public class RequestDetailsController : Controller
    {
        WorkPermitSystemEntities _DbWorkPermitSystemEntities = new WorkPermitSystemEntities();
        public void CheckViewBagData()
        {
            @ViewBag.Account = false;
            @ViewBag.EmployeeRegistration = false;
            @ViewBag.VendorRegistration = false;
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

            var RequestProcess = _DbWorkPermitSystemEntities.tbl_RequestProcess.ToList();

            foreach (var item in RequestProcess)
            {
                ProcessRequestDetailsByRequestIDModel _objProcessRequestDetailsByRequestID = new ProcessRequestDetailsByRequestIDModel();


                var _objAllRequestProcessModel = _DbWorkPermitSystemEntities.tbl_RequestProcess.Where(p => p.RequestProcessSrNo == item.RequestProcessSrNo).FirstOrDefault();

                var _objDepartmentEmployeeRegistration = _DbWorkPermitSystemEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeSrNo == _objAllRequestProcessModel.EmployeeId).FirstOrDefault();

                var _objDepartmentMaster = _DbWorkPermitSystemEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == _objDepartmentEmployeeRegistration.EmployeeDepartmentID).FirstOrDefault();

                var _objVendorUserRegistration = _DbWorkPermitSystemEntities.tbl_VendorUserRegistration.Where(p => p.VendorSrNo == _objAllRequestProcessModel.VendorSrNo).FirstOrDefault();

                var _objContractor = _DbWorkPermitSystemEntities.tbl_ContractorMaster.Where(p => p.ContractorSrNo == _objVendorUserRegistration.VendorContractorSrNo).FirstOrDefault();

                _objProcessRequestDetailsByRequestID.RequestProcessSrNo = _objAllRequestProcessModel.RequestProcessSrNo;
                _objProcessRequestDetailsByRequestID.EmployeeTokenNo = _objDepartmentEmployeeRegistration.EmployeeTokenNo;
                _objProcessRequestDetailsByRequestID.EmployeeName = _objDepartmentEmployeeRegistration.EmployeeName;
                _objProcessRequestDetailsByRequestID.EmployeeDepartmentName = _objDepartmentMaster.DepartmentName;
                _objProcessRequestDetailsByRequestID.VendorName = _objVendorUserRegistration.VendorName;
                _objProcessRequestDetailsByRequestID.ContractorName = _objContractor.ContractorName;
                _objProcessRequestDetailsByRequestID.VisitStartTime = Convert.ToDateTime(_objAllRequestProcessModel.VisitStartTime);
                _objProcessRequestDetailsByRequestID.VisitEndTime = Convert.ToDateTime(_objAllRequestProcessModel.VisitEndTime);
                _objProcessRequestDetailsByRequestID.NatureOfWork = _objVendorUserRegistration.VendorNatureOfWork;
                _objProcessRequestDetailsByRequestID.NoOfVendors = _objAllRequestProcessModel.NoOfVendors;
                _objProcessRequestDetailsByRequestID.VendorVisitResons = _objAllRequestProcessModel.VendorVisitResons;
                _objProcessRequestDetailsByRequestID.EmployeeId = _objAllRequestProcessModel.EmployeeId;
                _objProcessRequestDetailsByRequestID.VendorSrNo = _objAllRequestProcessModel.VendorSrNo;
                _objProcessRequestDetailsByRequestID.EmployeeDepartmentID = _objAllRequestProcessModel.EmployeeDepartmentID;
                _objProcessRequestDetailsByRequestID.VendorAccessories = _objAllRequestProcessModel.VendorAccessories;
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


            var _objAllRequestProcessModel = _DbWorkPermitSystemEntities.tbl_RequestProcess.Where(p => p.RequestProcessSrNo == id).FirstOrDefault();

            var _objDepartmentEmployeeRegistration = _DbWorkPermitSystemEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeSrNo == _objAllRequestProcessModel.EmployeeId).FirstOrDefault();

            var _objDepartmentMaster = _DbWorkPermitSystemEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == _objDepartmentEmployeeRegistration.EmployeeDepartmentID).FirstOrDefault();

            var _objVendorUserRegistration = _DbWorkPermitSystemEntities.tbl_VendorUserRegistration.Where(p => p.VendorSrNo == _objAllRequestProcessModel.VendorSrNo).FirstOrDefault();

            var _objContractor = _DbWorkPermitSystemEntities.tbl_ContractorMaster.Where(p => p.ContractorSrNo == _objVendorUserRegistration.VendorContractorSrNo).FirstOrDefault();

            _objProcessRequestDetailsByRequestID.RequestProcessSrNo = _objAllRequestProcessModel.RequestProcessSrNo;
            _objProcessRequestDetailsByRequestID.EmployeeTokenNo = _objDepartmentEmployeeRegistration.EmployeeTokenNo;
            _objProcessRequestDetailsByRequestID.EmployeeName = _objDepartmentEmployeeRegistration.EmployeeName;
            _objProcessRequestDetailsByRequestID.EmployeeDepartmentName = _objDepartmentMaster.DepartmentName;
            _objProcessRequestDetailsByRequestID.VendorName = _objVendorUserRegistration.VendorName;
            _objProcessRequestDetailsByRequestID.ContractorName = _objContractor.ContractorName;
            _objProcessRequestDetailsByRequestID.VisitStartTime = Convert.ToDateTime(_objAllRequestProcessModel.VisitStartTime);
            _objProcessRequestDetailsByRequestID.VisitEndTime = Convert.ToDateTime(_objAllRequestProcessModel.VisitEndTime);
            _objProcessRequestDetailsByRequestID.NatureOfWork = _objVendorUserRegistration.VendorNatureOfWork;
            _objProcessRequestDetailsByRequestID.NoOfVendors = _objAllRequestProcessModel.NoOfVendors;
            _objProcessRequestDetailsByRequestID.VendorVisitResons = _objAllRequestProcessModel.VendorVisitResons;
            _objProcessRequestDetailsByRequestID.EmployeeId = _objAllRequestProcessModel.EmployeeId;
            _objProcessRequestDetailsByRequestID.VendorSrNo = _objAllRequestProcessModel.VendorSrNo;
            _objProcessRequestDetailsByRequestID.EmployeeDepartmentID = _objAllRequestProcessModel.EmployeeDepartmentID;
            _objProcessRequestDetailsByRequestID.VendorAccessories = _objAllRequestProcessModel.VendorAccessories;
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
                _DbWorkPermitSystemEntities.tbl_RequestProcess.Add(collection);
                _DbWorkPermitSystemEntities.SaveChanges();
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


            var _objAllRequestProcessModel = _DbWorkPermitSystemEntities.tbl_RequestProcess.Where(p => p.RequestProcessSrNo == id).FirstOrDefault();

            var _objDepartmentEmployeeRegistration = _DbWorkPermitSystemEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeSrNo == _objAllRequestProcessModel.EmployeeId).FirstOrDefault();

            var _objDepartmentMaster = _DbWorkPermitSystemEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == _objDepartmentEmployeeRegistration.EmployeeDepartmentID).FirstOrDefault();

            var _objVendorUserRegistration = _DbWorkPermitSystemEntities.tbl_VendorUserRegistration.Where(p => p.VendorSrNo == _objAllRequestProcessModel.VendorSrNo).FirstOrDefault();

            var _objContractor = _DbWorkPermitSystemEntities.tbl_ContractorMaster.Where(p => p.ContractorSrNo == _objVendorUserRegistration.VendorContractorSrNo).FirstOrDefault();

            _objProcessRequestDetailsByRequestID.RequestProcessSrNo = _objAllRequestProcessModel.RequestProcessSrNo;
            _objProcessRequestDetailsByRequestID.EmployeeTokenNo = _objDepartmentEmployeeRegistration.EmployeeTokenNo;
            _objProcessRequestDetailsByRequestID.EmployeeName = _objDepartmentEmployeeRegistration.EmployeeName;
            _objProcessRequestDetailsByRequestID.EmployeeDepartmentName = _objDepartmentMaster.DepartmentName;
            _objProcessRequestDetailsByRequestID.VendorName = _objVendorUserRegistration.VendorName;
            _objProcessRequestDetailsByRequestID.ContractorName = _objContractor.ContractorName;
            _objProcessRequestDetailsByRequestID.VisitStartTime = Convert.ToDateTime(_objAllRequestProcessModel.VisitStartTime);
            _objProcessRequestDetailsByRequestID.VisitEndTime = Convert.ToDateTime(_objAllRequestProcessModel.VisitEndTime);
            _objProcessRequestDetailsByRequestID.NatureOfWork = _objVendorUserRegistration.VendorNatureOfWork;
            _objProcessRequestDetailsByRequestID.NoOfVendors = _objAllRequestProcessModel.NoOfVendors;
            _objProcessRequestDetailsByRequestID.VendorVisitResons = _objAllRequestProcessModel.VendorVisitResons;
            _objProcessRequestDetailsByRequestID.EmployeeId = _objAllRequestProcessModel.EmployeeId;
            _objProcessRequestDetailsByRequestID.VendorSrNo = _objAllRequestProcessModel.VendorSrNo;
            _objProcessRequestDetailsByRequestID.EmployeeDepartmentID = _objAllRequestProcessModel.EmployeeDepartmentID;
            _objProcessRequestDetailsByRequestID.VendorAccessories = _objAllRequestProcessModel.VendorAccessories;
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


            var _objAllRequestProcessModel = _DbWorkPermitSystemEntities.tbl_RequestProcess.Where(p => p.RequestProcessSrNo == id).FirstOrDefault();

            var _objDepartmentEmployeeRegistration = _DbWorkPermitSystemEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeSrNo == _objAllRequestProcessModel.EmployeeId).FirstOrDefault();

            var _objDepartmentMaster = _DbWorkPermitSystemEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == _objDepartmentEmployeeRegistration.EmployeeDepartmentID).FirstOrDefault();

            var _objVendorUserRegistration = _DbWorkPermitSystemEntities.tbl_VendorUserRegistration.Where(p => p.VendorSrNo == _objAllRequestProcessModel.VendorSrNo).FirstOrDefault();

            var _objContractor = _DbWorkPermitSystemEntities.tbl_ContractorMaster.Where(p => p.ContractorSrNo == _objVendorUserRegistration.VendorContractorSrNo).FirstOrDefault();


            _objProcessRequestDetailsByRequestID.RequestProcessSrNo = _objAllRequestProcessModel.RequestProcessSrNo;
            _objProcessRequestDetailsByRequestID.EmployeeTokenNo = _objDepartmentEmployeeRegistration.EmployeeTokenNo;
            _objProcessRequestDetailsByRequestID.EmployeeName = _objDepartmentEmployeeRegistration.EmployeeName;
            _objProcessRequestDetailsByRequestID.EmployeeDepartmentName = _objDepartmentMaster.DepartmentName;
            _objProcessRequestDetailsByRequestID.VendorName = _objVendorUserRegistration.VendorName;
            _objProcessRequestDetailsByRequestID.ContractorName = _objContractor.ContractorName;
            _objProcessRequestDetailsByRequestID.VisitStartTime = Convert.ToDateTime(_objAllRequestProcessModel.VisitStartTime);
            _objProcessRequestDetailsByRequestID.VisitEndTime = Convert.ToDateTime(_objAllRequestProcessModel.VisitEndTime);
            _objProcessRequestDetailsByRequestID.NatureOfWork = _objVendorUserRegistration.VendorNatureOfWork;
            _objProcessRequestDetailsByRequestID.NoOfVendors = _objAllRequestProcessModel.NoOfVendors;
            _objProcessRequestDetailsByRequestID.VendorVisitResons = _objAllRequestProcessModel.VendorVisitResons;
            _objProcessRequestDetailsByRequestID.EmployeeId = _objAllRequestProcessModel.EmployeeId;
            _objProcessRequestDetailsByRequestID.VendorSrNo = _objAllRequestProcessModel.VendorSrNo;
            _objProcessRequestDetailsByRequestID.EmployeeDepartmentID = _objAllRequestProcessModel.EmployeeDepartmentID;
            _objProcessRequestDetailsByRequestID.VendorAccessories = _objAllRequestProcessModel.VendorAccessories;
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
                var model = _DbWorkPermitSystemEntities.tbl_RequestProcess.Where(a => a.RequestProcessSrNo == id).FirstOrDefault();
                _DbWorkPermitSystemEntities.tbl_RequestProcess.Remove(model);
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
