using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApiForWorkPermitSystem.Models;
using WebApiForWorkPermitSystem.Models;

namespace WebApiForWorkPermitSystem.Areas.Admin.Controllers
{
    public class AdminApiForMVController : Controller
    {
        WorkPermitSystemEntities _DbWorkPermitSystemEntities = new WorkPermitSystemEntities();
        // GET: Admin/AdminApiForMV
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/AdminApiForMV/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/AdminApiForMV/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminApiForMV/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult AddDepartmentEmployeeRegistration(DepartmentEmployeeRegistrationModel collection)
        {
            try
            {
                ResultModel _objResult = new ResultModel();

                var data = new tbl_DepartmentEmployeeRegistration()
                {
                    DeviceTokenId = collection.DeviceTokenId,
                    EmployeeTokenNo = collection.EmployeeTokenNo,
                    EmployeeAddress = collection.EmployeeAddress,
                    EmployeeContactNo = collection.EmployeeContactNo,
                    EmployeeDepartmentID = collection.EmployeeDepartmentID,
                    EmployeeDesignationID = collection.EmployeeDesignationID,
                    EmployeeEmailID = collection.EmployeeEmailID,
                    EmployeeName = collection.EmployeeName,
                    EmployeePassword = collection.EmployeePassword,
                    Date = DateTime.Now
                };

                _DbWorkPermitSystemEntities.tbl_DepartmentEmployeeRegistration.Add(data);

                if (!_DbWorkPermitSystemEntities.tbl_DepartmentEmployeeRegistration.Any(p => p.EmployeeTokenNo == collection.EmployeeTokenNo))
                {

                    _DbWorkPermitSystemEntities.SaveChanges();
                    _objResult.success = 1;
                    _objResult.msg = "Save Successfully";
                    return Json(_objResult, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    _objResult.success = 0;
                    _objResult.msg = "Token No. Already Present !!!";
                    return Json(_objResult, JsonRequestBehavior.AllowGet);
                }


            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetAllDepartmentEmployeeName()
        {
            try
            {
                List<GetAllDepartmentEmployeeNameModel> _list = new List<GetAllDepartmentEmployeeNameModel>();
                var _objDepartmentEmployeeRegistration = _DbWorkPermitSystemEntities.tbl_DepartmentEmployeeRegistration.ToList();
                foreach (var item in _objDepartmentEmployeeRegistration)
                {

                    GetAllDepartmentEmployeeNameModel _class = new GetAllDepartmentEmployeeNameModel();

                    var _objDepartmentMasterModel = _DbWorkPermitSystemEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == item.EmployeeDepartmentID).FirstOrDefault();
                    var _objDesignationMasterModel = _DbWorkPermitSystemEntities.tbl_DesignationMaster.Where(p => p.DesignationID == item.EmployeeDesignationID).FirstOrDefault();


                    _class.EmployeeSrNo = item.EmployeeSrNo;
                    _class.EmployeeTokenNo = item.EmployeeTokenNo;
                    _class.EmployeeName = item.EmployeeName;
                    _class.EmployeeDepartmentID = item.EmployeeDepartmentID;
                    _class.EmployeeDesignationID = item.EmployeeDesignationID;
                    _class.EmployeeDepartmentName = _objDepartmentMasterModel.DepartmentName;
                    _class.EmployeeDesignationName = _objDesignationMasterModel.DesignationName;

                    _list.Add(_class);
                }

                return Json(_list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public JsonResult GetVendorUserMaxSrNo()
        {
            try
            {

                VendorUserRegistrationModel VendorUserMaxSrNo = new VendorUserRegistrationModel();
                var _objVendorUserRegistration = _DbWorkPermitSystemEntities.tbl_VendorUserRegistration.ToList();
                var max = _objVendorUserRegistration.Max(x => (int?)x.VendorContractorSrNo) ?? 0;

                VendorUserMaxSrNo.VendorSrNo = max + 1;

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


        [HttpPost]
        public JsonResult AddVendorUserRegistration(VendorUserRegistrationModel collection)
        {
            try
            {
                var data = new tbl_VendorUserRegistration
                {
                    DeviceTokenId = collection.DeviceTokenId,
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
                ResultModel _objResult = new ResultModel();
                _objResult.success = 1;
                _objResult.msg = "Save Successfully";
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult AddDepartmentMaster(tbl_DepartmentMaster collection)
        {
            try
            {
                _DbWorkPermitSystemEntities.tbl_DepartmentMaster.Add(collection);
                _DbWorkPermitSystemEntities.SaveChanges();
                ResultModel _objResult = new ResultModel();
                _objResult.success = 1;
                _objResult.msg = "Save Successfully";
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AddDesignationMaster(tbl_DesignationMaster collection)
        {
            try
            {
                _DbWorkPermitSystemEntities.tbl_DesignationMaster.Add(collection);
                _DbWorkPermitSystemEntities.SaveChanges();
                ResultModel _objResult = new ResultModel();
                _objResult.success = 1;
                _objResult.msg = "Save Successfully";
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }
        }
        public void SendPushNotification(string deviceidToken, string body, string title)
        {
            try
            {
                string applicationID = "AAAAUbmTWw0:APA91bFmQkyZl2KbXyW1uOQTrJ0QLFXY0DDZIbsgFE6ZODnEsLPjDLwuqDe8tqafiPYR1gjfN4Vcglm8GK-DIJLG36sFvtVJk-IZ-3IwK-GjWw7jIt69NiOzd_cfP3CJLvuDwiRn-aw_";

                string senderId = "351005793037";

                string deviceId = deviceidToken;

                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";

                tRequest.Credentials = CredentialCache.DefaultCredentials;
                var data = new
                {
                    to = deviceId,
                    notification = new
                    {
                        body = body,
                        title = title,
                        sound = "Enabled"

                    }
                };

                var json = JsonConvert.SerializeObject(data);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                string str = sResponseFromServer;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        [HttpPost]
        public JsonResult AddRequestProcess(RequestProcessModel collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbl_RequestProcess _objRequestProcess = new tbl_RequestProcess();
                    _objRequestProcess.EmployeeId = collection.EmployeeId;
                    _objRequestProcess.RequestProcessSrNo = collection.RequestProcessSrNo;
                    _objRequestProcess.VendorSrNo = collection.VendorSrNo;
                    _objRequestProcess.EmployeeDepartmentID = collection.EmployeeDepartmentID;

                    _objRequestProcess.VisitStartTime = collection.VisitStartTime;

                    _objRequestProcess.VendorAccessories = collection.VendorAccessories;
                    _objRequestProcess.NoOfVendors = collection.NoOfVendors;
                    _objRequestProcess.VendorVisitResons = collection.VendorVisitResons;
                    _objRequestProcess.RequestProcessDate = collection.RequestProcessDate;
                    _objRequestProcess.ActivityOwnerStatus = collection.ActivityOwnerStatus;
                    _objRequestProcess.AreaOwnerStatus = collection.AreaOwnerStatus;
                    _objRequestProcess.SafetyStatus = collection.SafetyStatus;
                    _objRequestProcess.ContractorStatus = collection.ContractorStatus;
                    _objRequestProcess.VisitEndTime = collection.VisitEndTime;



                    _DbWorkPermitSystemEntities.tbl_RequestProcess.Add(_objRequestProcess);
                    _DbWorkPermitSystemEntities.SaveChanges();
                    ResultModel _objResult = new ResultModel();
                    _objResult.success = 1;
                    _objResult.msg = "Save Successfully";

                    var _owneractivitylist = _DbWorkPermitSystemEntities.tbl_DepartmentEmployeeRegistration.ToList().Where(a => a.tbl_DepartmentMaster.DepartmentID == collection.EmployeeDepartmentID && a.tbl_DesignationMaster.DesignationName == "Activity Owner");

                    //Notification Activity Owner

                    foreach (var item in _owneractivitylist)
                    {
                        SendPushNotification(item.DeviceTokenId, "New Vendor Request", "Manage Vendors");
                    }

                    return Json(_objResult, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    List<ErrorList> Errors = new List<ErrorList>();


                    //test errors.
                    var modelStateErrors = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors);

                    foreach (var x in modelStateErrors)
                    {
                        var errorInfo = new ErrorList()
                        {
                            ErrorMessage = x.ErrorMessage
                        };
                        Errors.Add(errorInfo);

                    }
                    return Json(Errors, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }
        }
        public class ErrorList
        {
            public string ErrorMessage;
        }

        [HttpGet]
        public JsonResult GetDepartmentMaster()
        {
            try
            {
                List<DepartmentMasterModel> _list = new List<Models.DepartmentMasterModel>();
                var _objDepartmentMaster = _DbWorkPermitSystemEntities.tbl_DepartmentMaster.ToList();
                foreach (var item in _objDepartmentMaster)
                {
                    DepartmentMasterModel _class = new Models.DepartmentMasterModel();

                    _class.DepartmentID = item.DepartmentID;
                    _class.DepartmentName = item.DepartmentName;
                    _class.DepartmentCreateDate = item.DepartmentCreateDate;
                    _list.Add(_class);
                }

                return Json(_list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpGet]
        public JsonResult GetDesignationMaster()
        {
            try
            {
                List<DesignationMasterModel> _list = new List<DesignationMasterModel>();
                var _objDesignationMaster = _DbWorkPermitSystemEntities.tbl_DesignationMaster.ToList();
                foreach (var item in _objDesignationMaster)
                {
                    DesignationMasterModel _class = new Models.DesignationMasterModel();

                    _class.DesignationID = item.DesignationID;
                    _class.DepartmentID = item.DepartmentID;
                    _class.DesignationName = item.DesignationName;
                    _list.Add(_class);
                }

                return Json(_list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpPost]
        public JsonResult GetDesignationMasterByDepartment(DepartmentMasterModel collection)
        {
            try
            {
                List<DesignationMasterModel> _list = new List<DesignationMasterModel>();
                var _objDesignationMaster = _DbWorkPermitSystemEntities.tbl_DesignationMaster.Where(p => p.DepartmentID == collection.DepartmentID).ToList();
                foreach (var item in _objDesignationMaster)
                {
                    DesignationMasterModel _class = new Models.DesignationMasterModel();

                    _class.DesignationID = item.DesignationID;
                    _class.DepartmentID = item.DepartmentID;
                    _class.DesignationName = item.DesignationName;
                    _list.Add(_class);
                }

                return Json(_list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpGet]
        public JsonResult GetContractorMaster()
        {
            try
            {
                List<ContractorMasterModel> _list = new List<ContractorMasterModel>();
                var _objDesignationMaster = _DbWorkPermitSystemEntities.tbl_ContractorMaster.ToList();

                foreach (var item in _objDesignationMaster)
                {
                    ContractorMasterModel _class = new Models.ContractorMasterModel();

                    _class.ContractorSrNo = item.ContractorSrNo;
                    _class.CompanyName = item.CompanyName;
                    _class.ContractorName = item.ContractorName;
                    _class.ContractorContactNo = item.ContractorContactNo;
                    _class.ContractorCreateDate = item.ContractorCreateDate;

                    _list.Add(_class);
                }

                return Json(_list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpPost]
        public JsonResult GetDepartmentEmployeeInformationByTokenNo(GetAllDepartmentEmployeeNameModel collection)
        {
            try
            {
                GetAllDepartmentEmployeeNameModel _list = new GetAllDepartmentEmployeeNameModel();
                var DepartmentEmployeeRegistration = _DbWorkPermitSystemEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeTokenNo == collection.EmployeeTokenNo).FirstOrDefault();

                var _objDesignationMaster = _DbWorkPermitSystemEntities.tbl_DesignationMaster.Where(p => p.DesignationID == DepartmentEmployeeRegistration.EmployeeDesignationID).FirstOrDefault();
                var _objDepartmentMaster = _DbWorkPermitSystemEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == DepartmentEmployeeRegistration.EmployeeDepartmentID).FirstOrDefault();

                _list.EmployeeSrNo = DepartmentEmployeeRegistration.EmployeeSrNo;
                _list.EmployeeTokenNo = DepartmentEmployeeRegistration.EmployeeTokenNo;
                _list.EmployeeName = DepartmentEmployeeRegistration.EmployeeName;
                _list.EmployeeDepartmentID = DepartmentEmployeeRegistration.EmployeeDepartmentID;
                _list.EmployeeDesignationID = DepartmentEmployeeRegistration.EmployeeDesignationID;
                _list.EmployeeDepartmentName = _objDepartmentMaster.DepartmentName;
                _list.EmployeeDesignationName = _objDesignationMaster.DesignationName;


                return Json(_list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpPost]
        public JsonResult GetVendorUserInformationByVendorUserID(VendorUserRegistrationModel collection)
        {
            try
            {
                VendorUserRegistrationModel _list = new VendorUserRegistrationModel();
                var _objVendorUserRegistration = _DbWorkPermitSystemEntities.tbl_VendorUserRegistration.Where(p => p.VendorUserID == collection.VendorUserID).FirstOrDefault();
                var _objContractor = _DbWorkPermitSystemEntities.tbl_ContractorMaster.Where(p => p.ContractorSrNo == _objVendorUserRegistration.VendorContractorSrNo).FirstOrDefault();

                _list.VendorSrNo = _objVendorUserRegistration.VendorSrNo;
                _list.VendorUserID = _objVendorUserRegistration.VendorUserID;
                _list.VendorName = _objVendorUserRegistration.VendorName;
                _list.VendorAddress = _objVendorUserRegistration.VendorAddress;
                _list.VendorContactNo = _objVendorUserRegistration.VendorContactNo;
                _list.VendorEmailID = _objVendorUserRegistration.VendorEmailID;
                _list.VendorNatureOfWork = _objVendorUserRegistration.VendorNatureOfWork;
                _list.VendorContractorSrNo = _objContractor.ContractorSrNo;
                _list.VendorContractorName = _objContractor.ContractorName;
                _list.VendorContractorCoNo = _objVendorUserRegistration.VendorContractorCoNo;
                _list.VendorPassword = _objVendorUserRegistration.VendorPassword;
                _list.VendorRegistrationDate = _objVendorUserRegistration.VendorRegistrationDate;

                return Json(_list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpPost]
        public JsonResult GetProcessRequestByUser(GetAllDepartmentEmployeeNameModel collection)
        {
            try
            {
                List<ListProcessRequestByDepartmentEmployeeModel> _objListRequestProcessModel = new List<ListProcessRequestByDepartmentEmployeeModel>();


                var _objAllRequestProcessModel = _DbWorkPermitSystemEntities.tbl_RequestProcess.ToList();

                foreach (var item in _objAllRequestProcessModel)
                {
                    if (collection.EmployeeDesignationName == "Activity Owner" && item.EmployeeDepartmentID == collection.EmployeeDepartmentID)
                    {
                        ListProcessRequestByDepartmentEmployeeModel _class = new ListProcessRequestByDepartmentEmployeeModel();

                        var _objDepartmentEmployeeRegistration = _DbWorkPermitSystemEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeSrNo == item.EmployeeId).FirstOrDefault();

                        _class.RequestProcessSrNo = item.RequestProcessSrNo;
                        _class.EmployeeTokenNo = _objDepartmentEmployeeRegistration.EmployeeTokenNo;
                        _class.EmployeeName = _objDepartmentEmployeeRegistration.EmployeeName;
                        _class.VisitStartTime = Convert.ToDateTime(item.VisitStartTime);
                        _class.VisitEndTime = Convert.ToDateTime(item.VisitEndTime);
                        _class.RequestStatus = item.ActivityOwnerStatus;
                        _objListRequestProcessModel.Add(_class);

                    }

                    else if (collection.EmployeeDesignationName == "Area Owner" && item.EmployeeDepartmentID == collection.EmployeeDepartmentID && item.ActivityOwnerStatus == "Accepted")
                    {
                        ListProcessRequestByDepartmentEmployeeModel _class = new ListProcessRequestByDepartmentEmployeeModel();

                        var _objDepartmentEmployeeRegistration = _DbWorkPermitSystemEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeSrNo == item.EmployeeId).FirstOrDefault();

                        _class.RequestProcessSrNo = item.RequestProcessSrNo;
                        _class.EmployeeTokenNo = _objDepartmentEmployeeRegistration.EmployeeTokenNo;
                        _class.EmployeeName = _objDepartmentEmployeeRegistration.EmployeeName;
                        _class.VisitStartTime = Convert.ToDateTime(item.VisitStartTime);
                        _class.VisitEndTime = Convert.ToDateTime(item.VisitEndTime);
                        _class.RequestStatus = item.AreaOwnerStatus;
                        _objListRequestProcessModel.Add(_class);
                    }

                    else if (collection.EmployeeDesignationName == "Safety"  && item.ActivityOwnerStatus == "Accepted" && item.AreaOwnerStatus == "Accepted")
                    {
                        ListProcessRequestByDepartmentEmployeeModel _class = new ListProcessRequestByDepartmentEmployeeModel();

                        var _objDepartmentEmployeeRegistration = _DbWorkPermitSystemEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeSrNo == item.EmployeeId).FirstOrDefault();

                        _class.RequestProcessSrNo = item.RequestProcessSrNo;
                        _class.EmployeeTokenNo = _objDepartmentEmployeeRegistration.EmployeeTokenNo;
                        _class.EmployeeName = _objDepartmentEmployeeRegistration.EmployeeName;
                        _class.VisitStartTime = Convert.ToDateTime(item.VisitStartTime);
                        _class.VisitEndTime = Convert.ToDateTime(item.VisitEndTime);
                        _class.RequestStatus = item.SafetyStatus;
                        _objListRequestProcessModel.Add(_class);
                    }
                }

                return Json(_objListRequestProcessModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult GetProcessRequestByVendorUserSrNo(ListProcessRequestByVendorUserModel collection)
        {
            try
            {
                List<ListProcessRequestByVendorUserModel> _objListRequestProcessModel = new List<ListProcessRequestByVendorUserModel>();


                var _objAllRequestProcessModel = _DbWorkPermitSystemEntities.tbl_RequestProcess.Where(P => P.VendorSrNo == collection.VendorSrNo).ToList();

                foreach (var item in _objAllRequestProcessModel)
                {
                    ListProcessRequestByVendorUserModel _class = new ListProcessRequestByVendorUserModel();

                    var _objDepartmentEmployeeRegistration = _DbWorkPermitSystemEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeSrNo == item.EmployeeId).FirstOrDefault();

                    _class.RequestProcessSrNo = item.RequestProcessSrNo;
                    _class.EmployeeTokenNo = _objDepartmentEmployeeRegistration.EmployeeTokenNo;
                    _class.EmployeeName = _objDepartmentEmployeeRegistration.EmployeeName;
                    _class.VisitStartTime = Convert.ToDateTime(item.VisitStartTime);
                    _class.VisitEndTime = Convert.ToDateTime(item.VisitEndTime);
                    _class.VendorVisitResons = item.VendorVisitResons;
                    _objListRequestProcessModel.Add(_class);
                }

                return Json(_objListRequestProcessModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpPost]
        public JsonResult GetProcessRequestDetailsByRequestID(ProcessRequestDetailsByRequestIDModel collection)
        {
            try
            {
                ProcessRequestDetailsByRequestIDModel _objProcessRequestDetailsByRequestID = new ProcessRequestDetailsByRequestIDModel();


                var _objAllRequestProcessModel = _DbWorkPermitSystemEntities.tbl_RequestProcess.Where(p => p.RequestProcessSrNo == collection.RequestProcessSrNo).FirstOrDefault();

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

                return Json(_objProcessRequestDetailsByRequestID, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }

        }



        [HttpPost]
        public JsonResult ContractorSubmitProcessRequest(ProcessRequestDetailsByRequestIDModel collection)
        {
            try
            {
                ProcessRequestDetailsByRequestIDModel _objProcessRequestDetailsByRequestID = new ProcessRequestDetailsByRequestIDModel();

                var _objAllRequestProcessModel = _DbWorkPermitSystemEntities.tbl_RequestProcess.Where(p => p.RequestProcessSrNo == collection.RequestProcessSrNo).FirstOrDefault();

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

                return Json(_objProcessRequestDetailsByRequestID, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }

        }



        [HttpPost]
        public JsonResult UpdateEmployeeDeviceTokenNumber(DepartmentEmployeeRegistrationModel collection)
        {
            try
            {
                var _objAllRequestProcessModel = _DbWorkPermitSystemEntities.tbl_DepartmentEmployeeRegistration.Where(a => a.EmployeeTokenNo == collection.EmployeeTokenNo).FirstOrDefault();

                _objAllRequestProcessModel.DeviceTokenId = collection.DeviceTokenId;
                _DbWorkPermitSystemEntities.Entry(_objAllRequestProcessModel).State = EntityState.Modified;
                _DbWorkPermitSystemEntities.SaveChanges();
                ResultModel _objResult = new ResultModel();
                _objResult.success = 1;
                _objResult.msg = "Save Successfully";

                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpPost]
        public JsonResult UpdateVendorDeviceTokenNumber(VendorUserRegistrationModel collection)
        {
            try
            {
                var _objAllRequestProcessModel = _DbWorkPermitSystemEntities.tbl_VendorUserRegistration.Where(a => a.VendorUserID == collection.VendorUserID).FirstOrDefault();

                _objAllRequestProcessModel.DeviceTokenId = collection.DeviceTokenId;
                _DbWorkPermitSystemEntities.Entry(_objAllRequestProcessModel).State = EntityState.Modified;
                _DbWorkPermitSystemEntities.SaveChanges();
                ResultModel _objResult = new ResultModel();
                _objResult.success = 1;
                _objResult.msg = "Save Successfully";

                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpPost]
        public JsonResult ManageProcessRequestStatusUpdate(tbl_RequestProcess collection)
        {
            try
            {
                var _objAllRequestProcessModel = _DbWorkPermitSystemEntities.tbl_RequestProcess.Where(a => a.RequestProcessSrNo == collection.RequestProcessSrNo).FirstOrDefault();

                _objAllRequestProcessModel.SafetyStatus = collection.SafetyStatus;
                _objAllRequestProcessModel.AreaOwnerStatus = collection.AreaOwnerStatus;
                _objAllRequestProcessModel.ActivityOwnerStatus = collection.ActivityOwnerStatus;
                _objAllRequestProcessModel.ContractorStatus = collection.ContractorStatus;
                _DbWorkPermitSystemEntities.Entry(_objAllRequestProcessModel).State = EntityState.Modified;
                _DbWorkPermitSystemEntities.SaveChanges();
                ResultModel _objResult = new ResultModel();
                _objResult.success = 1;
                _objResult.msg = "Save Successfully";

                var _objAllRequestProcessNewModel = _DbWorkPermitSystemEntities.tbl_RequestProcess.Where(a => a.RequestProcessSrNo == collection.RequestProcessSrNo).FirstOrDefault();

                if (_objAllRequestProcessNewModel.EmployeeDepartmentID == collection.EmployeeDepartmentID && _objAllRequestProcessNewModel.ActivityOwnerStatus == "Accepted" && _objAllRequestProcessNewModel.AreaOwnerStatus == "None" && _objAllRequestProcessNewModel.SafetyStatus == "None" && _objAllRequestProcessNewModel.ContractorStatus == "None")
                {
                    var _departmentlist = _DbWorkPermitSystemEntities.tbl_DepartmentEmployeeRegistration.ToList().Where(a => a.tbl_DepartmentMaster.DepartmentID == collection.EmployeeDepartmentID && a.tbl_DesignationMaster.DesignationName == "Area Owner");

                    //Notification Area Owner

                    foreach (var item in _departmentlist)
                    {
                        SendPushNotification(item.DeviceTokenId, "Activity Owner", "Activity Owner");
                    }
                }

                else if (_objAllRequestProcessNewModel.ActivityOwnerStatus == "Accepted" && _objAllRequestProcessNewModel.AreaOwnerStatus == "Accepted" && _objAllRequestProcessNewModel.SafetyStatus == "None" && _objAllRequestProcessNewModel.ContractorStatus == "None")
                {
                    var _departmentlist = _DbWorkPermitSystemEntities.tbl_DepartmentEmployeeRegistration.ToList().Where(a => a.tbl_DesignationMaster.DesignationName == "Safety");

                    //Notification Safety

                    foreach (var item in _departmentlist)
                    {
                        SendPushNotification(item.DeviceTokenId, "Area Owner", "Manage Vendors");
                    }
                }

                else if (_objAllRequestProcessNewModel.EmployeeDepartmentID == collection.EmployeeDepartmentID && _objAllRequestProcessNewModel.ActivityOwnerStatus == "Accepted" && _objAllRequestProcessNewModel.AreaOwnerStatus == "Accepted" && _objAllRequestProcessNewModel.SafetyStatus == "Accepted" && _objAllRequestProcessNewModel.ContractorStatus == "None")
                {
                    var _departmentlist = _DbWorkPermitSystemEntities.tbl_VendorUserRegistration.ToList().Where(a => a.VendorSrNo == collection.VendorSrNo);

                    //Notification VendorUser

                    foreach (var item in _departmentlist)
                    {
                        SendPushNotification(item.DeviceTokenId, "Safety", "Manage Vendors");
                    }
                }

                else if (_objAllRequestProcessNewModel.ActivityOwnerStatus == "Accepted" && _objAllRequestProcessNewModel.AreaOwnerStatus == "Accepted" && _objAllRequestProcessNewModel.SafetyStatus == "Accepted" && _objAllRequestProcessNewModel.ContractorStatus == "Accepted")
                {
                    var _departmentlist = _DbWorkPermitSystemEntities.tbl_DepartmentEmployeeRegistration.ToList().Where(a => _objAllRequestProcessNewModel.EmployeeDepartmentID == collection.EmployeeDepartmentID && a.tbl_DesignationMaster.DesignationName == "Activity Owner" || a.tbl_DesignationMaster.DesignationName == "Area Owner");
                    var _safetylist = _DbWorkPermitSystemEntities.tbl_DepartmentEmployeeRegistration.ToList().Where(a =>  a.tbl_DesignationMaster.DesignationName == "Safety");
                    var AllList = _departmentlist.Union(_safetylist);
                    //Notification All Department

                    foreach (var item in AllList)
                    {
                        SendPushNotification(item.DeviceTokenId, "Contractor Submit Request", "Manage Vendors");
                    }
                }

                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpPost]
        public JsonResult VendorLogIn(UserLoginModel collection)
        {
            try
            {
                var _objVendorLogIn = _DbWorkPermitSystemEntities.tbl_VendorUserRegistration.Where(p => p.VendorUserID == collection.UserName && p.VendorPassword == collection.Password).FirstOrDefault();

                ResultModel _objResult = new ResultModel();
                if (_objVendorLogIn != null)
                {
                    _objResult.success = 1;
                    _objResult.msg = "LogIn Successfull";
                }
                else
                {
                    _objResult.success = 0;
                    _objResult.msg = "Incorrect UserName Or Password";
                }

                return Json(_objResult, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult EmployeeLogIn(UserLoginModel collection)
        {
            try
            {
                var _objEmployeeLogIn = _DbWorkPermitSystemEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeTokenNo == collection.UserName && p.EmployeePassword == collection.Password).FirstOrDefault();

                ResultModel _objResult = new ResultModel();
                if (_objEmployeeLogIn != null)
                {
                    _objResult.success = 1;
                    _objResult.msg = "LogIn Successfull";
                }
                else
                {
                    _objResult.success = 0;
                    _objResult.msg = "Incorrect UserName Or Password";
                }

                return Json(_objResult, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                ResultModel _objResult = new ResultModel();
                _objResult.success = 0;
                _objResult.msg = ex.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }

        }


        // GET: Admin/AdminApiForMV/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/AdminApiForMV/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdminApiForMV/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/AdminApiForMV/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
