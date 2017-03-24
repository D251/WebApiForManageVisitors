using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiForManageVisitors.Models
{
    public class ManageVisitorsModels
    {
    }

    public static class StatusModel
    {
        public static long LoginUserStatus = 0;
        public static string Url = "http://localhost:55633/Admin/AdminApiForMV/";
    }

    public class ResultModel
    {
        public long success { get; set; }
        public string msg { get; set; }
    }

    public class tbl_DepartmentEmployeeRegistrationModel
    {
        public long EmployeeSrNo { get; set; }
        public string EmployeeTokenNo { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeContactNo { get; set; }
        public string EmployeeEmailID { get; set; }
        public Nullable<long> EmployeeDepartmentID { get; set; }
        public Nullable<long> EmployeeDesignationID { get; set; }
        public string EmployeePassword { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    }

    public class tbl_VisitorUserRegistrationModel
    {
        public long VisitorSrNo { get; set; }
        public string VisitorUserID { get; set; }
        public string VisitorName { get; set; }
        public string VisitorAddress { get; set; }
        public string VisitorContactNo { get; set; }
        public string VisitorEmailID { get; set; }
        public string VisitorNatureOfWork { get; set; }
        public string VisitorContractor { get; set; }
        public string VisitorContractorCoNo { get; set; }
        public string VisitorPassword { get; set; }
        public Nullable<System.DateTime> VisitorRegistrationDate { get; set; }
    }

    public class tbl_RequestProcessModel
    {
        public Nullable<long> EmployeeId { get; set; }
        public long RequestProcessSrNo { get; set; }
        public Nullable<long> VisitorSrNo { get; set; }
        public Nullable<long> EmployeeDepartmentID { get; set; }
        public Nullable<System.DateTime> VisitStartTime { get; set; }
        public Nullable<System.DateTime> VisitEndTime { get; set; }
        public string VisitorAccessories { get; set; }
        public Nullable<long> NoOfVisitors { get; set; }
        public string VisitorVisitResons { get; set; }
        public Nullable<System.DateTime> RequestProcessDate { get; set; }
        public string ActivityOwnerStatus { get; set; }
        public string AreaOwnerStatus { get; set; }
        public string SafetyStatus { get; set; }
        public string ContractorStatus { get; set; }
    }

    public class DepartmentMasterModel
    {
        public long DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public Nullable<System.DateTime> DepartmentCreateDate { get; set; }
    }

    public class tbl_DesignationMasterModel
    {
        public long DesignationID { get; set; }
        public long DepartmentID { get; set; }
        public string DesignationName { get; set; }
        public string DepartmentName { get; set; }
        public Nullable<System.DateTime> DesignationCreateDate { get; set; }
    }

    public class GetAllDepartmentEmployeeNameModel
    {
        public long EmployeeSrNo { get; set; }
        public string EmployeeTokenNo { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<long> EmployeeDepartmentID { get; set; }
        public Nullable<long> EmployeeDesignationID { get; set; }
        public string EmployeeDepartmentName { get; set; }
        public string EmployeeDesignationName { get; set; }
    }


    public class ListProcessRequestByDepartmentEmployeeModel
    {
        public long RequestProcessSrNo { get; set; }
        public string EmployeeTokenNo { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<System.DateTime> VisitStartTime { get; set; }
        public Nullable<System.DateTime> VisitEndTime { get; set; }
        public string RequestStatus { get; set; }
    }


    public class ListProcessRequestByVisitorUserModel
    {
        public Nullable<long> VisitorSrNo { get; set; }
        public long RequestProcessSrNo { get; set; }
        public string EmployeeTokenNo { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<System.DateTime> VisitStartTime { get; set; }
        public Nullable<System.DateTime> VisitEndTime { get; set; }
        public string VisitorVisitResons { get; set; }
    }



    public class ProcessRequestDetailsByRequestIDModel
    {
        public long RequestProcessSrNo { get; set; }
        public string EmployeeTokenNo { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeDepartmentName { get; set; }
        public string VisitorName { get; set; }
        public string ContractorName { get; set; }
        public string NatureOfWork { get; set; }
        public Nullable<System.DateTime> VisitStartTime { get; set; }
        public Nullable<System.DateTime> VisitEndTime { get; set; }
        public Nullable<long> NoOfVisitors { get; set; }
        public string VisitorVisitResons { get; set; }
        public string RequestStatus { get; set; }
        public Nullable<long> EmployeeId { get; set; }
        public Nullable<long> VisitorSrNo { get; set; }
        public Nullable<long> EmployeeDepartmentID { get; set; }
        public string VisitorAccessories { get; set; }
        public Nullable<System.DateTime> RequestProcessDate { get; set; }
        public string ActivityOwnerStatus { get; set; }
        public string AreaOwnerStatus { get; set; }
        public string SafetyStatus { get; set; }
        public string ContractorStatus { get; set; }
    }

    public class UserLoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class ProcessRequestStatusUpdateModel
    {
        public long RequestProcessSrNo { get; set; }
        public string EmployeeDesignationName { get; set; }
        public string RequestStatus { get; set; }
    }
}