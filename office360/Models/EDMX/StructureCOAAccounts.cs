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
    
    public partial class StructureCOAAccounts
    {
        public System.Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public Nullable<int> CoaCatagoryId { get; set; }
        public Nullable<int> DocType { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.Guid> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<System.Guid> BranchId { get; set; }
        public Nullable<System.Guid> CompanyId { get; set; }
    }
}