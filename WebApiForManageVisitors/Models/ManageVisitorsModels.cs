using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiForWorkPermitSystem.Models
{
  
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

        [Required]
        [Display(Name = "Token No.")]
        public string EmployeeTokenNo { get; set; }

        [Display(Name = "Name")]
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use Alphabets only ")]
        public string EmployeeName { get; set; }

        [Display(Name = "Address")]
        [Required]
        public string EmployeeAddress { get; set; }

        [Display(Name = "Contact No.")]
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string EmployeeContactNo { get; set; }

        [Display(Name = "Email ID")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string EmployeeEmailID { get; set; }

        [Display(Name = "Department Name")]
        [Required]
        public Nullable<long> EmployeeDepartmentID { get; set; }

        [Display(Name = "Designation Name")]
      
        public Nullable<long> EmployeeDesignationID { get; set; }

        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Display(Name = "Designation Name")]
        public string DesignationName { get; set; }

        [Display(Name = "Designation Name")]
        [Required]
        //[Required(ErrorMessage ="Designation Name is Required")]
        public string DesignationCombo1 { get; set; }

        [Display(Name = "Password")]
        [Required]
        public string EmployeePassword { get; set; }

        [Display(Name = "Create Date")]
        public Nullable<System.DateTime> Date { get; set; }
        public string DeviceTokenId { get; set; }
    }

    public class VendorUserRegistrationModel
    {
        [Display(Name = "Sr/No.")]
        public long VendorSrNo { get; set; }

        [Display(Name = "User ID")]
        [Required]
        public string VendorUserID { get; set; }

        [Required]
        [Display(Name = "Vendor Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use Alphabets only ")]
        public string VendorName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string VendorAddress { get; set; }

        [Required]
        [Display(Name = "Contact No.")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string VendorContactNo { get; set; }

       
        [Display(Name = "Email ID")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string VendorEmailID { get; set; }


        [Display(Name = "Vendor Nature Of Work")]
        public string VendorNatureOfWork { get; set; }


        [Display(Name = "Vendor Contractor Name")]
        [Required]
        public Nullable<long> VendorContractorSrNo { get; set; }

        [Required]
        [Display(Name = "Contractor Contact No")]
        public string VendorContractorCoNo { get; set; }

    
        [Display(Name = "Vendor Contractor Name")]
        public string VendorContractorName { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string VendorPassword { get; set; }

         [Display(Name = "Date")]
        public Nullable<System.DateTime> VendorRegistrationDate { get; set; }

        public string DeviceTokenId { get; set; }
    }

    public class RequestProcessModel
    {
        [Required]
        
        public Nullable<long> EmployeeId { get; set; }
        [Required]
        public long RequestProcessSrNo { get; set; }
        [Required]
        public Nullable<long> VendorSrNo { get; set; }
        [Required]
        public Nullable<long> EmployeeDepartmentID { get; set; }
        [Required]
        public Nullable<System.DateTime> VisitStartTime { get; set; }
        [Required]
        public Nullable<System.DateTime> VisitEndTime { get; set; }
        [Required]
        public string VendorAccessories { get; set; }
        [Required]
        public Nullable<long> NoOfVendors { get; set; }
        [Required]
        public string VendorVisitResons { get; set; }
        [Required]
        public Nullable<System.DateTime> RequestProcessDate { get; set; }
        [Required]
        public string ActivityOwnerStatus { get; set; }
        [Required]
        public string AreaOwnerStatus { get; set; }
        [Required]
        public string SafetyStatus { get; set; }
        [Required]
        public string ContractorStatus { get; set; }

    }

    public class DepartmentMasterModel
    {
        [Display(Name = "Department ID")]
        public long DepartmentID { get; set; }
        [Display(Name = "Department Name")]
        [Required]
        public string DepartmentName { get; set; }
        [Display(Name = "Date")]
        public Nullable<System.DateTime> DepartmentCreateDate { get; set; }
    }

    public class DesignationMasterModel
    {

        public long DesignationID { get; set; }
        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "Department Name is Required")]
        public long DepartmentID { get; set; }
        [Display(Name = "Designation Name")]
        [Required]
        public string DesignationName { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "Department Name is Required")]
        public string DepartmentCombo { get; set; }
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


    public class ListProcessRequestByVendorUserModel
    {
        public Nullable<long> VendorSrNo { get; set; }
        public long RequestProcessSrNo { get; set; }
        public string EmployeeTokenNo { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<System.DateTime> VisitStartTime { get; set; }
        public Nullable<System.DateTime> VisitEndTime { get; set; }
        public string VendorVisitResons { get; set; }
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
        [Display(Name = "Vendor Name")]
        public string VendorName { get; set; }
        [Display(Name = "Contractor Name")]
        public string ContractorName { get; set; }
        [Display(Name = "Nature Of Work")]
        public string NatureOfWork { get; set; }
        [Display(Name = "Visit Start Time")]
        public Nullable<System.DateTime> VisitStartTime { get; set; }
        [Display(Name = "Visit End Time")]
        public Nullable<System.DateTime> VisitEndTime { get; set; }
        [Display(Name = "N.O.V")]
        public Nullable<long> NoOfVendors { get; set; }
        [Display(Name = "Vendor Visit Resons")]
        public string VendorVisitResons { get; set; }
        [Display(Name = "Request Status")]
        public string RequestStatus { get; set; }
        [Display(Name = "Employee Id")]
        public Nullable<long> EmployeeId { get; set; }
        [Display(Name = "Vendor SrNo")]
        public Nullable<long> VendorSrNo { get; set; }
        [Display(Name = "Employee Department ID")]
        public Nullable<long> EmployeeDepartmentID { get; set; }
        [Display(Name = "Vendor Accessories")]
        public string VendorAccessories { get; set; }
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

        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Contractor Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use Alphabets only ")]
        public string ContractorName { get; set; }

        [Required]
        [Display(Name = "Contractor Contact No")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
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