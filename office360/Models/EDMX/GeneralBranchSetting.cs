//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace office360.Models.EDMX
{
    using System;
    using System.Collections.Generic;
    
    public partial class GeneralBranchSetting
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> BranchId { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public Nullable<System.Guid> EducationBoardId { get; set; }
        public Nullable<System.Guid> CompanyId { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<System.Guid> UpdatedBy { get; set; }
        public Nullable<System.DateTime> EffectiveFrom { get; set; }
        public Nullable<System.DateTime> ExpiredOn { get; set; }
        public Nullable<bool> Status { get; set; }
        public string AllowedStudyGroupIds { get; set; }
        public Nullable<int> RollCallISystemId { get; set; }
        public Nullable<int> BillingMethodId { get; set; }
    }
}