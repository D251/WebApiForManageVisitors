using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    public class DepartmentEmployeeRegistrationModel
    {
        [Display(Name = "Sr/No.")]
        public long EmployeeSrNo { get; set; }
        [Display(Name = "Token No.")]
        public string EmployeeTokenNo { get; set; }
        [Display(Name = "Name")]
        public string EmployeeName { get; set; }
        [Display(Name = "Address")]
        public string EmployeeAddress { get; set; }
        [Display(Name = "Contact No.")]
        public string EmployeeContactNo { get; set; }
        [Display(Name = "Email ID")]
        public string EmployeeEmailID { get; set; }
        [Display(Name = "Department Name")]
        public Nullable<long> EmployeeDepartmentID { get; set; }
        [Display(Name = "Designation Name")]
        public Nullable<long> EmployeeDesignationID { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Display(Name = "Designation Name")]
        public string DesignationName { get; set; }
        [Display(Name = "Password")]
        public string EmployeePassword { get; set; }
        [Display(Name = "Create Date")]
        public Nullable<System.DateTime> Date { get; set; }
    }

    public class VisitorUserRegistrationModel
    {
        [Display(Name = "Sr/No.")]
        public long VisitorSrNo { get; set; }
        [Display(Name = "User ID")]
        public string VisitorUserID { get; set; }
        [Display(Name = "Visitor Name")]
        public string VisitorName { get; set; }
        [Display(Name = "Address")]
        public string VisitorAddress { get; set; }
        [Display(Name = "Contact No.")]
        public string VisitorContactNo { get; set; }
        [Display(Name = "Email ID")]
        public string VisitorEmailID { get; set; }
        [Display(Name = "Visitor Nature Of Work")]
        public string VisitorNatureOfWork { get; set; }
        [Display(Name = "Visitor Contractor SrNo")]
        public Nullable<long> VisitorContractorSrNo { get; set; }
        [Display(Name = "Contractor Contact No")]
        public string VisitorContractorCoNo { get; set; }
        [Display(Name = "Visitor Contractor Name")]
        public string VisitorContractorName { get; set; }
        [Display(Name = "Password")]
        public string VisitorPassword { get; set; }
         [Display(Name = "Date")]
        public Nullable<System.DateTime> VisitorRegistrationDate { get; set; }
    }

    public class RequestProcessModel
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
        [Display(Name = "Department ID")]
        public long DepartmentID { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Display(Name = "Date")]
        public Nullable<System.DateTime> DepartmentCreateDate { get; set; }
    }

    public class DesignationMasterModel
    {

        public long DesignationID { get; set; }
        public long DepartmentID { get; set; }
        [Display(Name = "Designation Name")]
        public string DesignationName { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Display(Name = "Date")]
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
        [Display(Name = "Request Process SrNo")]
        public long RequestProcessSrNo { get; set; }
        [Display(Name = "Employee Token No")]
        public string EmployeeTokenNo { get; set; }
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        [Display(Name = "Department Name")]
        public string EmployeeDepartmentName { get; set; }
        [Display(Name = "Visitor Name")]
        public string VisitorName { get; set; }
        [Display(Name = "Contractor Name")]
        public string ContractorName { get; set; }
        [Display(Name = "Nature Of Work")]
        public string NatureOfWork { get; set; }
        [Display(Name = "Visit Start Time")]
        public Nullable<System.DateTime> VisitStartTime { get; set; }
        [Display(Name = "Visit End Time")]
        public Nullable<System.DateTime> VisitEndTime { get; set; }
        [Display(Name = "N.O.V")]
        public Nullable<long> NoOfVisitors { get; set; }
        [Display(Name = "Visitor Visit Resons")]
        public string VisitorVisitResons { get; set; }
        [Display(Name = "Request Status")]
        public string RequestStatus { get; set; }
        [Display(Name = "Employee Id")]
        public Nullable<long> EmployeeId { get; set; }
        [Display(Name = "Visitor SrNo")]
        public Nullable<long> VisitorSrNo { get; set; }
        [Display(Name = "Employee Department ID")]
        public Nullable<long> EmployeeDepartmentID { get; set; }
        [Display(Name = "Visitor Accessories")]
        public string VisitorAccessories { get; set; }
        [Display(Name = "Request Process Date")]
        public Nullable<System.DateTime> RequestProcessDate { get; set; }
        [Display(Name = "Activity Owner Status")]
        public string ActivityOwnerStatus { get; set; }
        [Display(Name = "AreaOwner Status")]
        public string AreaOwnerStatus { get; set; }
        [Display(Name = "Safety Status")]
        public string SafetyStatus { get; set; }
        [Display(Name = "Contractor Status")]
        public string ContractorStatus { get; set; }
    }


    public class ContractorMasterModel
    {
        [Display(Name = "Contractor SrNo")]
        public long ContractorSrNo { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Contractor Name")]
        public string ContractorName { get; set; }
        [Display(Name = "Contractor Contact No")]
        public string ContractorContactNo { get; set; }
        [Display(Name = "Contractor Create Date")]
        public Nullable<System.DateTime> ContractorCreateDate { get; set; }
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