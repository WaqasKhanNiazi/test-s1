using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace office360.Models.General
{
    public class AsideMenu_
    {
        public string ParentDisplay { get; set; }
        public string ModuleName { get; set; }
        public string Form { get; set; }
        public string URL { get; set; }
    }

    public class MenuViewModel
    {
        public string Menu { get; set; }
        public List<ModuleViewModel> Modules { get; set; } = new List<ModuleViewModel>();
    }

    public class ModuleViewModel
    {
        public string Module { get; set; }
        public List<string> Displays { get; set; } = new List<string>();
        public List<string> URL { get; set; } = new List<string>();
    }

    public class _SqlParameters
    {
        // Guid or Nullable<Guid>
        public string Name { get; set; }
        public string Action { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public Nullable<System.Guid> RoleId { get; set; }
        public Nullable<bool> IsLogIn { get; set; }
        public string AllowedBranchIds { get; set; }
        public Nullable<bool> IsDeveloper { get; set; }
        public Nullable<System.Guid> EmployeeId { get; set; }
        public Nullable<System.Guid> BranchId { get; set; }
        public string RoleName { get; set; }
        public string ParentDisplay { get; set; }
        public string ModuleName { get; set; }
        public string Form { get; set; }
        public string URL { get; set; }
        public string VendorCode { get; set; }
        public string Title { get; set; }
        public string VendorId { get; set; }


        public Guid? Id { get; set; }
        public int? Id_ { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid? AdmissionId { get; set; }
        public Guid? SessionId { get; set; }
        public Guid? ClassId { get; set; }
        public Guid? CampusTypeId { get; set; }
        public Guid? OrganizationTypeId { get; set; }
        public Guid? EnrollmentTypeId { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? CityId { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public Guid? EffectiveFrom { get; set; }
        public Guid? ExpiredOn { get; set; }
        public Guid? StudyGroupId { get; set; }
        public Guid? StudyLevelId { get; set; }
        public Guid? EducationLevelId { get; set; }
        public Guid? GenderId { get; set; }
        public Guid? MartialStatusId { get; set; }
        public Guid? ReligionId { get; set; }
        public Guid? NationalityId { get; set; }
        public Guid? ParentStudyLevelId { get; set; }
        public Guid? OccupationId { get; set; }
        public Guid? RelationshipId { get; set; }
        public Guid? StructureId { get; set; }
        public Guid? FeeTypeId { get; set; }
        public Guid? AssetAccountId { get; set; }
        public Guid? LiabilityAccountId { get; set; }
        public Guid? RevenueAccountId { get; set; }
        public Guid? ChargingMethodId { get; set; }
        public Guid? FeeStructureId { get; set; }
        public Guid? ClassRegistrationId { get; set; }
        // String
        public string Menu { get; set; }
        public string RightPath { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string OpenClassIds { get; set; }
        public string NTNNo { get; set; }
        public string Remarks { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CnicNo_FormBNo { get; set; }
        public string ResedenitalAddress { get; set; }
        public string ParentName { get; set; }
        public string ParentNICNo { get; set; }
        public string ParentCnic { get; set; }

        public string FeeName { get; set; }
        public string ChargingMethod { get; set; }
        public string AssetAccount { get; set; }
        public string LiabilityAccount { get; set; }
        public string RevenueAccount { get; set; }
        public string Session { get; set; }
        public string Class { get; set; }
        public string ReportType { get; set; }
        public string ReportTitle { get; set; }



        // DateTime or Nullable<DateTime>
        public DateTime? SessionStartDate { get; set; }
        public DateTime? SessionEndDate { get; set; }
        public DateTime? ClassStartDate { get; set; }
        public DateTime? ClassEndDate { get; set; }
        public DateTime DateofBirth { get; set; }
        public DateTime? TransactionDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }

        // Nullable<int>
        public Nullable<int> DocType { get; set; }

        // bool
        public Nullable<bool> IsDiscountAllowed { get; set; }
        public Nullable<bool> IsReportsAllowed { get; set; }
        public bool Status { get; set; }
        public bool? OnAdmissionOnly { get; set; }
        public bool? Recurring { get; set; }
        public bool? Refundable { get; set; }
        public bool? Security { get; set; }

        // decimal or Nullable<decimal>
        public decimal? MonthlyIncome { get; set; }
        public decimal? FeeAmount { get; set; }
        public decimal? GrossRecievable { get; set; }
        public decimal? LateFee { get; set; }
        public decimal? Discount { get; set; }
        public decimal? NetRecievable { get; set; }
        public decimal? ActualFeeAmount { get; set; }
        public decimal? ChargedFeeAmount { get; set; }

        // Nullable<int>
        public int? DocumentStatus { get; set; }
        public int? RegistrationTypeId { get; set; }
        public int? NumberOfChallan { get; set; }
        public int? AllowedChallanNo { get; set; }
        public int? TransactionMonth { get; set; }
        public int? ExportType { get; set; }

        public string CompanyName { get; set; }
        public string AddressLine { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyWebsite { get; set; }
        public string UploadLogo { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
    }
}