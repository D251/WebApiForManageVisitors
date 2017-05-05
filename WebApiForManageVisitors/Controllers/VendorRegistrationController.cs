using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApiForWorkPermitSystem.Models;
using WebApiForWorkPermitSystem.Models;

namespace WebApiForWorkPermitSystem.Controllers
{
    public class VendorRegistrationController : Controller
    {
        WorkPermitSystemEntities _DbWorkPermitSystemEntities = new WorkPermitSystemEntities();
        public void CheckViewBagData()
        {
            @ViewBag.Account = false;
            @ViewBag.EmployeeRegistration = false;
            @ViewBag.VendorRegistration = true;
            @ViewBag.EmployeeDepartment = false;
            @ViewBag.EmployeeDesignation = false;
            @ViewBag.ContractorMaster = false;
            @ViewBag.RequestDetails = false;
        }
        // GET: VendorRegistration
        public ActionResult Index()
        {
            CheckViewBagData();
           List<VendorUserRegistrationModel> _objVendorUserRegistrationModel = new List<VendorUserRegistrationModel>();
            var VendorUserRegistration = _DbWorkPermitSystemEntities.tbl_VendorUserRegistration.ToList();

            foreach (var item in VendorUserRegistration)
            {
                var _objContractor = _DbWorkPermitSystemEntities.tbl_ContractorMaster.Where(p => p.ContractorSrNo == item.VendorContractorSrNo).FirstOrDefault();

                VendorUserRegistrationModel _objVendorUserRegistrationModelItem = new VendorUserRegistrationModel();
                _objVendorUserRegistrationModelItem.VendorSrNo = item.VendorSrNo;
                _objVendorUserRegistrationModelItem.VendorUserID = item.VendorUserID;
                _objVendorUserRegistrationModelItem.VendorName = item.VendorName;
                _objVendorUserRegistrationModelItem.VendorAddress = item.VendorAddress;
                _objVendorUserRegistrationModelItem.VendorContactNo = item.VendorContactNo;
                _objVendorUserRegistrationModelItem.VendorEmailID = item.VendorEmailID;
                _objVendorUserRegistrationModelItem.VendorNatureOfWork = item.VendorNatureOfWork;
                _objVendorUserRegistrationModelItem.VendorContractorName = _objContractor.ContractorName;
                _objVendorUserRegistrationModelItem.VendorContractorCoNo = item.VendorContractorCoNo;
                _objVendorUserRegistrationModelItem.VendorPassword = item.VendorPassword;
                _objVendorUserRegistrationModelItem.VendorRegistrationDate = item.VendorRegistrationDate;
                _objVendorUserRegistrationModel.Add(_objVendorUserRegistrationModelItem);
            }
            return View(_objVendorUserRegistrationModel.ToList());
        }
     
        // GET: VendorRegistration/Details/5
        public ActionResult Details(int id)
        {
            CheckViewBagData();
            VendorUserRegistrationModel _objVendorUserRegistrationModel = new VendorUserRegistrationModel();
            var data = _DbWorkPermitSystemEntities.tbl_VendorUserRegistration.Where(p => p.VendorSrNo == id).FirstOrDefault();
            {
                var _objContractor = _DbWorkPermitSystemEntities.tbl_ContractorMaster.Where(p => p.ContractorSrNo == data.VendorContractorSrNo).FirstOrDefault();
                _objVendorUserRegistrationModel.VendorSrNo = data.VendorSrNo;
                _objVendorUserRegistrationModel.VendorUserID = data.VendorUserID;
                _objVendorUserRegistrationModel.VendorName = data.VendorName;
                _objVendorUserRegistrationModel.VendorContactNo = data.VendorContactNo;
                _objVendorUserRegistrationModel.VendorAddress = data.VendorAddress;
                _objVendorUserRegistrationModel.VendorContractorName = _objContractor.ContractorName;
                _objVendorUserRegistrationModel.VendorContractorCoNo = data.VendorContractorCoNo;
                _objVendorUserRegistrationModel.VendorEmailID = data.VendorEmailID;
                _objVendorUserRegistrationModel.VendorNatureOfWork = data.VendorNatureOfWork;
                _objVendorUserRegistrationModel.VendorPassword = data.VendorPassword;
                _objVendorUserRegistrationModel.VendorRegistrationDate = data.VendorRegistrationDate;

            };
            return View(_objVendorUserRegistrationModel);
        }
        //Vendor UserID
        public JsonResult GetVendorUserMaxSrNo()
        {
            try
            {
                VendorUserRegistrationModel VendorUserMaxSrNo = new VendorUserRegistrationModel();
                var _objVendorUserRegistration = _DbWorkPermitSystemEntities.tbl_VendorUserRegistration.Max(p => p.VendorSrNo);
                VendorUserMaxSrNo.VendorSrNo = _objVendorUserRegistration + 1;
                return Json(VendorUserMaxSrNo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }

        }

        public string GetContractorContactNo(int id)
        {
            CheckViewBagData();
            _DbWorkPermitSystemEntities.Configuration.ProxyCreationEnabled = false;
             string ContractorNo = _DbWorkPermitSystemEntities.tbl_ContractorMaster.Where(P => P.ContractorSrNo == id).Select(p=>p.ContractorContactNo).FirstOrDefault();
             return ContractorNo;
        }




        // GET: VendorRegistration/Create
        public ActionResult Create()
        {
            CheckViewBagData();
            VendorUserRegistrationModel VendorUserMaxSrNo = new VendorUserRegistrationModel();
            var _objVendorUserRegistration = _DbWorkPermitSystemEntities.tbl_VendorUserRegistration.DefaultIfEmpty().Max(p =>p==null?0: p.VendorSrNo);
            ViewBag.VendorSrNo = _objVendorUserRegistration + 1;
            ViewBag.UserID = "M&M" + ViewBag.VendorSrNo;
            ViewBag.ContractorNameCombo = new SelectList(_DbWorkPermitSystemEntities.tbl_ContractorMaster, "ContractorSrNo", "ContractorName");
            return View();
        }

        // POST: VendorRegistration/Create
        [HttpPost]
        public ActionResult Create(VendorUserRegistrationModel collection)
        {
            try
            {
                CheckViewBagData();
                var _objVendorUserRegistration = _DbWorkPermitSystemEntities.tbl_VendorUserRegistration.DefaultIfEmpty().Max(p => p == null ? 0 : p.VendorSrNo);
                ViewBag.VendorSrNo = _objVendorUserRegistration + 1;
                ViewBag.UserID = "M&M" + ViewBag.VendorSrNo;
               
                if (ModelState.IsValid)
                {
                    var data = new tbl_VendorUserRegistration
                    {

                        VendorUserID = collection.VendorUserID,
                        VendorName = collection.VendorName,
                        VendorAddress = collection.VendorAddress,
                        VendorContactNo = collection.VendorContactNo,
                        VendorEmailID = collection.VendorEmailID,
                        VendorNatureOfWork = collection.VendorNatureOfWork,
                        VendorContractorSrNo = collection.VendorContractorSrNo,
                        VendorContractorCoNo = collection.VendorContractorCoNo,
                        VendorPassword = collection.VendorPassword,
                        VendorRegistrationDate = DateTime.Now
                    };


                    _DbWorkPermitSystemEntities.tbl_VendorUserRegistration.Add(data);
                    _DbWorkPermitSystemEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ContractorNameCombo = new SelectList(_DbWorkPermitSystemEntities.tbl_ContractorMaster, "ContractorSrNo", "ContractorName");
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

        // GET: VendorRegistration/Edit/5
        public ActionResult Edit(int id)
        {
            CheckViewBagData();
            
            VendorUserRegistrationModel _objVendorUserRegistrationModel = new VendorUserRegistrationModel();
            var data = _DbWorkPermitSystemEntities.tbl_VendorUserRegistration.Where(p => p.VendorSrNo == id).FirstOrDefault();
            {
                var _objContractor = _DbWorkPermitSystemEntities.tbl_ContractorMaster.Where(p => p.ContractorSrNo == data.VendorContractorSrNo).FirstOrDefault();
                _objVendorUserRegistrationModel.VendorSrNo = data.VendorSrNo;
                _objVendorUserRegistrationModel.VendorUserID = data.VendorUserID;
                _objVendorUserRegistrationModel.VendorName = data.VendorName;
                _objVendorUserRegistrationModel.VendorContactNo = data.VendorContactNo;
                _objVendorUserRegistrationModel.VendorAddress = data.VendorAddress;
                _objVendorUserRegistrationModel.VendorContractorName = _objContractor.ContractorName;
                _objVendorUserRegistrationModel.VendorContractorCoNo = data.VendorContractorCoNo;
                _objVendorUserRegistrationModel.VendorEmailID = data.VendorEmailID;
                _objVendorUserRegistrationModel.VendorNatureOfWork = data.VendorNatureOfWork;
                _objVendorUserRegistrationModel.VendorPassword = data.VendorPassword;
                _objVendorUserRegistrationModel.VendorContractorSrNo = data.VendorContractorSrNo;
                //_objVendorUserRegistrationModel.VendorRegistrationDate = data.VendorRegistrationDate;
              
            };
            ViewBag.ContractorNameCombo = new SelectList(_DbWorkPermitSystemEntities.tbl_ContractorMaster, "ContractorSrNo", "ContractorName", _objVendorUserRegistrationModel.VendorContractorSrNo);
            return View(_objVendorUserRegistrationModel);
        }

        // POST: VendorRegistration/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VendorUserRegistrationModel collection)
        {
            try
            {
                // TODO: Add update logic here
                CheckViewBagData();
                if (ModelState.IsValid)
                {
                    var data = _DbWorkPermitSystemEntities.tbl_VendorUserRegistration.Where(b => b.VendorSrNo == id).FirstOrDefault();
                    var _objContractor = _DbWorkPermitSystemEntities.tbl_ContractorMaster.Where(p => p.ContractorSrNo == collection.VendorContractorSrNo).FirstOrDefault();
                    //data.EmployeeSrNo = collection.EmployeeSrNo;
                    data.VendorUserID = collection.VendorUserID;
                    data.VendorName = collection.VendorName;
                    data.VendorAddress = collection.VendorAddress;
                    data.VendorContactNo = collection.VendorContactNo;
                    data.VendorEmailID = collection.VendorEmailID;
                    data.VendorNatureOfWork = collection.VendorNatureOfWork;
                    data.VendorContractorSrNo = _objContractor.ContractorSrNo;
                    data.VendorContractorCoNo = collection.VendorContractorCoNo;
                    data.VendorPassword = collection.VendorPassword;
                   // data.viitorcon
                    _DbWorkPermitSystemEntities.Entry(data).State = EntityState.Modified;
                    _DbWorkPermitSystemEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ContractorNameCombo = new SelectList(_DbWorkPermitSystemEntities.tbl_ContractorMaster, "ContractorSrNo", "ContractorName", collection.VendorContractorSrNo);
                return View();

            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: VendorRegistration/Delete/5
        public ActionResult Delete(int id)
        {
            CheckViewBagData();
            VendorUserRegistrationModel _objVendorUserRegistrationModel = new VendorUserRegistrationModel();
            var data = _DbWorkPermitSystemEntities.tbl_VendorUserRegistration.Where(p => p.VendorSrNo == id).FirstOrDefault();
            {

                var _objContractor = _DbWorkPermitSystemEntities.tbl_ContractorMaster.Where(p => p.ContractorSrNo == data.VendorContractorSrNo).FirstOrDefault();
                _objVendorUserRegistrationModel.VendorSrNo = data.VendorSrNo;
                _objVendorUserRegistrationModel.VendorUserID = data.VendorUserID;
                _objVendorUserRegistrationModel.VendorName = data.VendorName;
                _objVendorUserRegistrationModel.VendorContactNo = data.VendorContactNo;
                _objVendorUserRegistrationModel.VendorAddress = data.VendorAddress;
                _objVendorUserRegistrationModel.VendorContractorName = _objContractor.ContractorName;
                _objVendorUserRegistrationModel.VendorContractorCoNo = data.VendorContractorCoNo;
                _objVendorUserRegistrationModel.VendorEmailID = data.VendorEmailID;
                _objVendorUserRegistrationModel.VendorNatureOfWork = data.VendorNatureOfWork;
                _objVendorUserRegistrationModel.VendorPassword = data.VendorPassword;
                _objVendorUserRegistrationModel.VendorRegistrationDate = data.VendorRegistrationDate;

            };
            return View(_objVendorUserRegistrationModel);
        }

        // POST: VendorRegistration/Delete/5

        public ActionResult DeleteNow(int id)
        {
            try
            {
                CheckViewBagData();
                var model = _DbWorkPermitSystemEntities.tbl_VendorUserRegistration.Where(a => a.VendorSrNo == id).FirstOrDefault();
                _DbWorkPermitSystemEntities.tbl_VendorUserRegistration.Remove(model);
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
