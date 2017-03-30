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
            @ViewBag.ContractorMaster = false;
            @ViewBag.RequestDetails = false;
        }
        // GET: VisitorRegistration
        public ActionResult Index()
        {
            CheckViewBagData();
           List<VisitorUserRegistrationModel> _objVisitorUserRegistrationModel = new List<VisitorUserRegistrationModel>();
            var VisitorUserRegistration = _DbManageVisitorsEntities.tbl_VisitorUserRegistration.ToList();

            foreach (var item in VisitorUserRegistration)
            {
                var _objContractor = _DbManageVisitorsEntities.tbl_ContractorMaster.Where(p => p.ContractorSrNo == item.VisitorContractorSrNo).FirstOrDefault();

                VisitorUserRegistrationModel _objVisitorUserRegistrationModelItem = new VisitorUserRegistrationModel();
                _objVisitorUserRegistrationModelItem.VisitorSrNo = item.VisitorSrNo;
                _objVisitorUserRegistrationModelItem.VisitorUserID = item.VisitorUserID;
                _objVisitorUserRegistrationModelItem.VisitorName = item.VisitorName;
                _objVisitorUserRegistrationModelItem.VisitorAddress = item.VisitorAddress;
                _objVisitorUserRegistrationModelItem.VisitorContactNo = item.VisitorContactNo;
                _objVisitorUserRegistrationModelItem.VisitorEmailID = item.VisitorEmailID;
                _objVisitorUserRegistrationModelItem.VisitorNatureOfWork = item.VisitorNatureOfWork;
                _objVisitorUserRegistrationModelItem.VisitorContractorName = _objContractor.ContractorName;
                _objVisitorUserRegistrationModelItem.VisitorContractorCoNo = item.VisitorContractorCoNo;
                _objVisitorUserRegistrationModelItem.VisitorPassword = item.VisitorPassword;
                _objVisitorUserRegistrationModelItem.VisitorRegistrationDate = item.VisitorRegistrationDate;
                _objVisitorUserRegistrationModel.Add(_objVisitorUserRegistrationModelItem);
            }
            return View(_objVisitorUserRegistrationModel.ToList());
        }
     
        // GET: VisitorRegistration/Details/5
        public ActionResult Details(int id)
        {
            CheckViewBagData();
            VisitorUserRegistrationModel _objVisitorUserRegistrationModel = new VisitorUserRegistrationModel();
            var data = _DbManageVisitorsEntities.tbl_VisitorUserRegistration.Where(p => p.VisitorSrNo == id).FirstOrDefault();
            {
                var _objContractor = _DbManageVisitorsEntities.tbl_ContractorMaster.Where(p => p.ContractorSrNo == data.VisitorContractorSrNo).FirstOrDefault();
                _objVisitorUserRegistrationModel.VisitorSrNo = data.VisitorSrNo;
                _objVisitorUserRegistrationModel.VisitorUserID = data.VisitorUserID;
                _objVisitorUserRegistrationModel.VisitorName = data.VisitorName;
                _objVisitorUserRegistrationModel.VisitorContactNo = data.VisitorContactNo;
                _objVisitorUserRegistrationModel.VisitorAddress = data.VisitorAddress;
                _objVisitorUserRegistrationModel.VisitorContractorName = _objContractor.ContractorName;
                _objVisitorUserRegistrationModel.VisitorContractorCoNo = data.VisitorContractorCoNo;
                _objVisitorUserRegistrationModel.VisitorEmailID = data.VisitorEmailID;
                _objVisitorUserRegistrationModel.VisitorNatureOfWork = data.VisitorNatureOfWork;
                _objVisitorUserRegistrationModel.VisitorPassword = data.VisitorPassword;
                _objVisitorUserRegistrationModel.VisitorRegistrationDate = data.VisitorRegistrationDate;

            };
            return View(_objVisitorUserRegistrationModel);
        }
        //Visitor UserID
        public JsonResult GetVisitorUserMaxSrNo()
        {
            try
            {
                VisitorUserRegistrationModel VisitorUserMaxSrNo = new VisitorUserRegistrationModel();
                var _objVisitorUserRegistration = _DbManageVisitorsEntities.tbl_VisitorUserRegistration.Max(p => p.VisitorSrNo);
                VisitorUserMaxSrNo.VisitorSrNo = _objVisitorUserRegistration + 1;
                return Json(VisitorUserMaxSrNo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }

        }
         
        // GET: VisitorRegistration/Create
        public ActionResult Create()
        {
            CheckViewBagData();
            VisitorUserRegistrationModel VisitorUserMaxSrNo = new VisitorUserRegistrationModel();
            var _objVisitorUserRegistration = _DbManageVisitorsEntities.tbl_VisitorUserRegistration.Max(p => p.VisitorSrNo);
            ViewBag.VisitorSrNo = _objVisitorUserRegistration + 1;
            ViewBag.UserID = "M&M" + ViewBag.VisitorSrNo;
            return View();
        }

        // POST: VisitorRegistration/Create
        [HttpPost]
        public ActionResult Create(VisitorUserRegistrationModel collection)
        {
            try
            {
                CheckViewBagData();

                var data = new tbl_VisitorUserRegistration
                {

                    VisitorUserID = collection.VisitorUserID,
                    VisitorName = collection.VisitorName,
                    VisitorAddress = collection.VisitorAddress,
                    VisitorContactNo = collection.VisitorContactNo,
                    VisitorEmailID = collection.VisitorEmailID,
                    VisitorNatureOfWork = collection.VisitorNatureOfWork,
                    VisitorContractorSrNo = collection.VisitorContractorSrNo,
                    VisitorContractorCoNo = collection.VisitorContractorCoNo,
                    VisitorPassword = collection.VisitorPassword,
                    //VisitorRegistrationDate = DateTime.Now
                };


                _DbManageVisitorsEntities.tbl_VisitorUserRegistration.Add(data);
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
            VisitorUserRegistrationModel _objVisitorUserRegistrationModel = new VisitorUserRegistrationModel();
            var data = _DbManageVisitorsEntities.tbl_VisitorUserRegistration.Where(p => p.VisitorSrNo == id).FirstOrDefault();
            {
                var _objContractor = _DbManageVisitorsEntities.tbl_ContractorMaster.Where(p => p.ContractorSrNo == data.VisitorContractorSrNo).FirstOrDefault();
                _objVisitorUserRegistrationModel.VisitorSrNo = data.VisitorSrNo;
                _objVisitorUserRegistrationModel.VisitorUserID = data.VisitorUserID;
                _objVisitorUserRegistrationModel.VisitorName = data.VisitorName;
                _objVisitorUserRegistrationModel.VisitorContactNo = data.VisitorContactNo;
                _objVisitorUserRegistrationModel.VisitorAddress = data.VisitorAddress;
                _objVisitorUserRegistrationModel.VisitorContractorName = _objContractor.ContractorName;
                _objVisitorUserRegistrationModel.VisitorContractorCoNo = data.VisitorContractorCoNo;
                _objVisitorUserRegistrationModel.VisitorEmailID = data.VisitorEmailID;
                _objVisitorUserRegistrationModel.VisitorNatureOfWork = data.VisitorNatureOfWork;
                _objVisitorUserRegistrationModel.VisitorPassword = data.VisitorPassword;
                //_objVisitorUserRegistrationModel.VisitorRegistrationDate = data.VisitorRegistrationDate;

            };

            return View(_objVisitorUserRegistrationModel);
        }

        // POST: VisitorRegistration/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VisitorUserRegistrationModel collection)
        {
            try
            {
                // TODO: Add update logic here
                CheckViewBagData();
                var data = _DbManageVisitorsEntities.tbl_VisitorUserRegistration.Where(b => b.VisitorSrNo == id).FirstOrDefault();
                var _objContractor = _DbManageVisitorsEntities.tbl_ContractorMaster.Where(p => p.ContractorSrNo == data.VisitorContractorSrNo).FirstOrDefault();
                //data.EmployeeSrNo = collection.EmployeeSrNo;
                data.VisitorUserID = collection.VisitorUserID;
                data.VisitorName = collection.VisitorName;
                data.VisitorAddress = collection.VisitorAddress;
                data.VisitorContactNo = collection.VisitorContactNo;
                data.VisitorEmailID = collection.VisitorEmailID;
                data.VisitorNatureOfWork = collection.VisitorNatureOfWork;
                data.VisitorContractorSrNo = _objContractor.ContractorSrNo;
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
            VisitorUserRegistrationModel _objVisitorUserRegistrationModel = new VisitorUserRegistrationModel();
            var data = _DbManageVisitorsEntities.tbl_VisitorUserRegistration.Where(p => p.VisitorSrNo == id).FirstOrDefault();
            {

                var _objContractor = _DbManageVisitorsEntities.tbl_ContractorMaster.Where(p => p.ContractorSrNo == data.VisitorContractorSrNo).FirstOrDefault();
                _objVisitorUserRegistrationModel.VisitorSrNo = data.VisitorSrNo;
                _objVisitorUserRegistrationModel.VisitorUserID = data.VisitorUserID;
                _objVisitorUserRegistrationModel.VisitorName = data.VisitorName;
                _objVisitorUserRegistrationModel.VisitorContactNo = data.VisitorContactNo;
                _objVisitorUserRegistrationModel.VisitorAddress = data.VisitorAddress;
                _objVisitorUserRegistrationModel.VisitorContractorName = _objContractor.ContractorName;
                _objVisitorUserRegistrationModel.VisitorContractorCoNo = data.VisitorContractorCoNo;
                _objVisitorUserRegistrationModel.VisitorEmailID = data.VisitorEmailID;
                _objVisitorUserRegistrationModel.VisitorNatureOfWork = data.VisitorNatureOfWork;
                _objVisitorUserRegistrationModel.VisitorPassword = data.VisitorPassword;
                _objVisitorUserRegistrationModel.VisitorRegistrationDate = data.VisitorRegistrationDate;

            };
            return View(_objVisitorUserRegistrationModel);
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
