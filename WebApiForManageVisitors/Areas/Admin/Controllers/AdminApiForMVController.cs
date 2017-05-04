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
using WebApiForManageVisitors.Models;

namespace WebApiForManageVisitors.Areas.Admin.Controllers
{
    public class AdminApiForMVController : Controller
    {
        ManageVisitorsEntities _DbManageVisitorsEntities = new ManageVisitorsEntities();
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

                _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Add(data);

                if (!_DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Any(p => p.EmployeeTokenNo == collection.EmployeeTokenNo))
                {

                    _DbManageVisitorsEntities.SaveChanges();
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
                var _objDepartmentEmployeeRegistration = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.ToList();
                foreach (var item in _objDepartmentEmployeeRegistration)
                {

                    GetAllDepartmentEmployeeNameModel _class = new GetAllDepartmentEmployeeNameModel();

                    var _objDepartmentMasterModel = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == item.EmployeeDepartmentID).FirstOrDefault();
                    var _objDesignationMasterModel = _DbManageVisitorsEntities.tbl_DesignationMaster.Where(p => p.DesignationID == item.EmployeeDesignationID).FirstOrDefault();


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


        [HttpPost]
        public JsonResult AddVisitorUserRegistration(VisitorUserRegistrationModel collection)
        {
            try
            {
                var data = new tbl_VisitorUserRegistration
                {
                    DeviceTokenId = collection.DeviceTokenId,
                    VisitorUserID = collection.VisitorUserID,
                    VisitorName = collection.VisitorName,
                    VisitorAddress = collection.VisitorAddress,
                    VisitorContactNo = collection.VisitorContactNo,
                    VisitorEmailID = collection.VisitorEmailID,
                    VisitorNatureOfWork = collection.VisitorNatureOfWork,
                    VisitorContractorSrNo = collection.VisitorContractorSrNo,
                    VisitorContractorCoNo = collection.VisitorContractorCoNo,
                    VisitorPassword = collection.VisitorPassword,
                    VisitorRegistrationDate = DateTime.Now
                };


                _DbManageVisitorsEntities.tbl_VisitorUserRegistration.Add(data);
                _DbManageVisitorsEntities.SaveChanges();
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
                _DbManageVisitorsEntities.tbl_DepartmentMaster.Add(collection);
                _DbManageVisitorsEntities.SaveChanges();
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
                _DbManageVisitorsEntities.tbl_DesignationMaster.Add(collection);
                _DbManageVisitorsEntities.SaveChanges();
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
                    _objRequestProcess.VisitorSrNo = collection.VisitorSrNo;
                    _objRequestProcess.EmployeeDepartmentID = collection.EmployeeDepartmentID;

                    _objRequestProcess.VisitStartTime = collection.VisitStartTime;

                    _objRequestProcess.VisitorAccessories = collection.VisitorAccessories;
                    _objRequestProcess.NoOfVisitors = collection.NoOfVisitors;
                    _objRequestProcess.VisitorVisitResons = collection.VisitorVisitResons;
                    _objRequestProcess.RequestProcessDate = collection.RequestProcessDate;
                    _objRequestProcess.ActivityOwnerStatus = collection.ActivityOwnerStatus;
                    _objRequestProcess.AreaOwnerStatus = collection.AreaOwnerStatus;
                    _objRequestProcess.SafetyStatus = collection.SafetyStatus;
                    _objRequestProcess.ContractorStatus = collection.ContractorStatus;
                    _objRequestProcess.VisitEndTime = collection.VisitEndTime;



                    _DbManageVisitorsEntities.tbl_RequestProcess.Add(_objRequestProcess);
                    _DbManageVisitorsEntities.SaveChanges();
                    ResultModel _objResult = new ResultModel();
                    _objResult.success = 1;
                    _objResult.msg = "Save Successfully";

                    var _owneractivitylist = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.ToList().Where(a => a.tbl_DepartmentMaster.DepartmentID == collection.EmployeeDepartmentID && a.tbl_DesignationMaster.DesignationName == "Activity Owner");

                    //Notification Activity Owner

                    foreach (var item in _owneractivitylist)
                    {
                        SendPushNotification(item.DeviceTokenId, "New Visitor Request", "Manage Visitors");
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
                var _objDepartmentMaster = _DbManageVisitorsEntities.tbl_DepartmentMaster.ToList();
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
                var _objDesignationMaster = _DbManageVisitorsEntities.tbl_DesignationMaster.ToList();
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
                var _objDesignationMaster = _DbManageVisitorsEntities.tbl_DesignationMaster.Where(p => p.DepartmentID == collection.DepartmentID).ToList();
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
                var _objDesignationMaster = _DbManageVisitorsEntities.tbl_ContractorMaster.ToList();

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
                var DepartmentEmployeeRegistration = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeTokenNo == collection.EmployeeTokenNo).FirstOrDefault();

                var _objDesignationMaster = _DbManageVisitorsEntities.tbl_DesignationMaster.Where(p => p.DesignationID == DepartmentEmployeeRegistration.EmployeeDesignationID).FirstOrDefault();
                var _objDepartmentMaster = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == DepartmentEmployeeRegistration.EmployeeDepartmentID).FirstOrDefault();

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
        public JsonResult GetVisitorUserInformationByVisitorUserID(VisitorUserRegistrationModel collection)
        {
            try
            {
                VisitorUserRegistrationModel _list = new VisitorUserRegistrationModel();
                var _objVisitorUserRegistration = _DbManageVisitorsEntities.tbl_VisitorUserRegistration.Where(p => p.VisitorUserID == collection.VisitorUserID).FirstOrDefault();
                var _objContractor = _DbManageVisitorsEntities.tbl_ContractorMaster.Where(p => p.ContractorSrNo == _objVisitorUserRegistration.VisitorContractorSrNo).FirstOrDefault();

                _list.VisitorSrNo = _objVisitorUserRegistration.VisitorSrNo;
                _list.VisitorUserID = _objVisitorUserRegistration.VisitorUserID;
                _list.VisitorName = _objVisitorUserRegistration.VisitorName;
                _list.VisitorAddress = _objVisitorUserRegistration.VisitorAddress;
                _list.VisitorContactNo = _objVisitorUserRegistration.VisitorContactNo;
                _list.VisitorEmailID = _objVisitorUserRegistration.VisitorEmailID;
                _list.VisitorNatureOfWork = _objVisitorUserRegistration.VisitorNatureOfWork;
                _list.VisitorContractorSrNo = _objContractor.ContractorSrNo;
                _list.VisitorContractorName = _objContractor.ContractorName;
                _list.VisitorContractorCoNo = _objVisitorUserRegistration.VisitorContractorCoNo;
                _list.VisitorPassword = _objVisitorUserRegistration.VisitorPassword;
                _list.VisitorRegistrationDate = _objVisitorUserRegistration.VisitorRegistrationDate;

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


                var _objAllRequestProcessModel = _DbManageVisitorsEntities.tbl_RequestProcess.ToList();

                foreach (var item in _objAllRequestProcessModel)
                {
                    if (collection.EmployeeDesignationName == "Activity Owner" && item.EmployeeDepartmentID == collection.EmployeeDepartmentID)
                    {
                        ListProcessRequestByDepartmentEmployeeModel _class = new ListProcessRequestByDepartmentEmployeeModel();

                        var _objDepartmentEmployeeRegistration = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeSrNo == item.EmployeeId).FirstOrDefault();

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

                        var _objDepartmentEmployeeRegistration = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeSrNo == item.EmployeeId).FirstOrDefault();

                        _class.RequestProcessSrNo = item.RequestProcessSrNo;
                        _class.EmployeeTokenNo = _objDepartmentEmployeeRegistration.EmployeeTokenNo;
                        _class.EmployeeName = _objDepartmentEmployeeRegistration.EmployeeName;
                        _class.VisitStartTime = Convert.ToDateTime(item.VisitStartTime);
                        _class.VisitEndTime = Convert.ToDateTime(item.VisitEndTime);
                        _class.RequestStatus = item.AreaOwnerStatus;
                        _objListRequestProcessModel.Add(_class);
                    }

                    else if (collection.EmployeeDesignationName == "Safety" && item.EmployeeDepartmentID == collection.EmployeeDepartmentID && item.ActivityOwnerStatus == "Accepted" && item.AreaOwnerStatus == "Accepted")
                    {
                        ListProcessRequestByDepartmentEmployeeModel _class = new ListProcessRequestByDepartmentEmployeeModel();

                        var _objDepartmentEmployeeRegistration = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeSrNo == item.EmployeeId).FirstOrDefault();

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
        public JsonResult GetProcessRequestByVisitorUserSrNo(ListProcessRequestByVisitorUserModel collection)
        {
            try
            {
                List<ListProcessRequestByVisitorUserModel> _objListRequestProcessModel = new List<ListProcessRequestByVisitorUserModel>();


                var _objAllRequestProcessModel = _DbManageVisitorsEntities.tbl_RequestProcess.Where(P => P.VisitorSrNo == collection.VisitorSrNo).ToList();

                foreach (var item in _objAllRequestProcessModel)
                {
                    ListProcessRequestByVisitorUserModel _class = new ListProcessRequestByVisitorUserModel();

                    var _objDepartmentEmployeeRegistration = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeSrNo == item.EmployeeId).FirstOrDefault();

                    _class.RequestProcessSrNo = item.RequestProcessSrNo;
                    _class.EmployeeTokenNo = _objDepartmentEmployeeRegistration.EmployeeTokenNo;
                    _class.EmployeeName = _objDepartmentEmployeeRegistration.EmployeeName;
                    _class.VisitStartTime = Convert.ToDateTime(item.VisitStartTime);
                    _class.VisitEndTime = Convert.ToDateTime(item.VisitEndTime);
                    _class.VisitorVisitResons = item.VisitorVisitResons;
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


                var _objAllRequestProcessModel = _DbManageVisitorsEntities.tbl_RequestProcess.Where(p => p.RequestProcessSrNo == collection.RequestProcessSrNo).FirstOrDefault();

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

                var _objAllRequestProcessModel = _DbManageVisitorsEntities.tbl_RequestProcess.Where(p => p.RequestProcessSrNo == collection.RequestProcessSrNo).FirstOrDefault();

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
                var _objAllRequestProcessModel = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Where(a => a.EmployeeTokenNo == collection.EmployeeTokenNo).FirstOrDefault();

                _objAllRequestProcessModel.DeviceTokenId = collection.DeviceTokenId;
                _DbManageVisitorsEntities.Entry(_objAllRequestProcessModel).State = EntityState.Modified;
                _DbManageVisitorsEntities.SaveChanges();
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
        public JsonResult UpdateVisitorDeviceTokenNumber(VisitorUserRegistrationModel collection)
        {
            try
            {
                var _objAllRequestProcessModel = _DbManageVisitorsEntities.tbl_VisitorUserRegistration.Where(a => a.VisitorUserID == collection.VisitorUserID).FirstOrDefault();

                _objAllRequestProcessModel.DeviceTokenId = collection.DeviceTokenId;
                _DbManageVisitorsEntities.Entry(_objAllRequestProcessModel).State = EntityState.Modified;
                _DbManageVisitorsEntities.SaveChanges();
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
                 var _objAllRequestProcessModel = _DbManageVisitorsEntities.tbl_RequestProcess.Where(a => a.RequestProcessSrNo == collection.RequestProcessSrNo).FirstOrDefault();

                _objAllRequestProcessModel.SafetyStatus = collection.SafetyStatus;
                _objAllRequestProcessModel.AreaOwnerStatus = collection.AreaOwnerStatus;
                _objAllRequestProcessModel.ActivityOwnerStatus = collection.ActivityOwnerStatus;
                _objAllRequestProcessModel.ContractorStatus = collection.ContractorStatus;
                _DbManageVisitorsEntities.Entry(_objAllRequestProcessModel).State = EntityState.Modified;
                _DbManageVisitorsEntities.SaveChanges();
                ResultModel _objResult = new ResultModel();
                _objResult.success = 1;
                _objResult.msg = "Save Successfully";

                var _objAllRequestProcessNewModel = _DbManageVisitorsEntities.tbl_RequestProcess.Where(a => a.RequestProcessSrNo == collection.RequestProcessSrNo).FirstOrDefault();

                if (_objAllRequestProcessNewModel.EmployeeDepartmentID == collection.EmployeeDepartmentID && _objAllRequestProcessNewModel.ActivityOwnerStatus == "Accepted" && _objAllRequestProcessNewModel.AreaOwnerStatus == "None" && _objAllRequestProcessNewModel.SafetyStatus == "None" && _objAllRequestProcessNewModel.ContractorStatus == "None")
                {
                    var _owneractivitylist = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.ToList().Where(a => a.tbl_DepartmentMaster.DepartmentID == collection.EmployeeDepartmentID && a.tbl_DesignationMaster.DesignationName == "Area Owner");

                    //Notification Area Owner

                    foreach (var item in _owneractivitylist)
                    {
                        SendPushNotification(item.DeviceTokenId, "Activity Owner", "Activity Owner");
                    }
                }

                else if (_objAllRequestProcessNewModel.EmployeeDepartmentID == collection.EmployeeDepartmentID && _objAllRequestProcessNewModel.ActivityOwnerStatus == "Accepted" && _objAllRequestProcessNewModel.AreaOwnerStatus == "Accepted" && _objAllRequestProcessNewModel.SafetyStatus == "None" && _objAllRequestProcessNewModel.ContractorStatus == "None")
                {
                    var _owneractivitylist = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.ToList().Where(a => a.tbl_DepartmentMaster.DepartmentID == collection.EmployeeDepartmentID && a.tbl_DesignationMaster.DesignationName == "Safety");

                    //Notification Safety

                    foreach (var item in _owneractivitylist)
                    {
                        SendPushNotification(item.DeviceTokenId, "Area Owner", "Manage Visitors");
                    }
                }

                else if (_objAllRequestProcessNewModel.EmployeeDepartmentID == collection.EmployeeDepartmentID && _objAllRequestProcessNewModel.ActivityOwnerStatus == "Accepted" && _objAllRequestProcessNewModel.AreaOwnerStatus == "Accepted" && _objAllRequestProcessNewModel.SafetyStatus == "Accepted" && _objAllRequestProcessNewModel.ContractorStatus == "None")
                {
                    var _owneractivitylist = _DbManageVisitorsEntities.tbl_VisitorUserRegistration.ToList().Where(a => a.VisitorSrNo == collection.VisitorSrNo);

                    //Notification VisitorUser

                    foreach (var item in _owneractivitylist)
                    {
                        SendPushNotification(item.DeviceTokenId, "Safety", "Manage Visitors");
                    }
                }

                else if (_objAllRequestProcessNewModel.EmployeeDepartmentID == collection.EmployeeDepartmentID && _objAllRequestProcessNewModel.ActivityOwnerStatus == "Accepted" && _objAllRequestProcessNewModel.AreaOwnerStatus == "Accepted" && _objAllRequestProcessNewModel.SafetyStatus == "Accepted" && _objAllRequestProcessNewModel.ContractorStatus == "Accepted")
                {
                    var _owneractivitylist = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.ToList().Where(a => a.tbl_DesignationMaster.DesignationName == "Activity Owner" || a.tbl_DesignationMaster.DesignationName == "Area Owner" || a.tbl_DesignationMaster.DesignationName == "Safety");

                    //Notification All Department

                    foreach (var item in _owneractivitylist)
                    {
                        SendPushNotification(item.DeviceTokenId, "Contractor Submit Request", "Manage Visitors");
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
        public JsonResult VisitorLogIn(UserLoginModel collection)
        {
            try
            {
                var _objVisitorLogIn = _DbManageVisitorsEntities.tbl_VisitorUserRegistration.Where(p => p.VisitorUserID == collection.UserName && p.VisitorPassword == collection.Password).FirstOrDefault();

                ResultModel _objResult = new ResultModel();
                if (_objVisitorLogIn != null)
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
                var _objEmployeeLogIn = _DbManageVisitorsEntities.tbl_DepartmentEmployeeRegistration.Where(p => p.EmployeeTokenNo == collection.UserName && p.EmployeePassword == collection.Password).FirstOrDefault();

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
