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
    
    public partial class StructureFeeType
    {
        public System.Guid Id { get; set; }
        public string Description { get; set; }
        public Nullable<System.Guid> ChargingMethodId { get; set; }
        public Nullable<bool> OnAdmissionOnly { get; set; }
        public Nullable<bool> Recurring { get; set; }
        public Nullable<bool> Refundable { get; set; }
        public Nullable<bool> Security { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<System.Guid> UpdatedBy { get; set; }
        public Nullable<System.Guid> BranchId { get; set; }
        public Nullable<System.Guid> CompanyId { get; set; }
        public Nullable<int> DocType { get; set; }
    }
}
