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
    
    public partial class AccFeeStructureDetail
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> FeeStructureId { get; set; }
        public Nullable<System.Guid> FeeTypeId { get; set; }
        public Nullable<System.Guid> AssetAccountId { get; set; }
        public Nullable<System.Guid> LiabilityAccountId { get; set; }
        public Nullable<System.Guid> RevenueAccountId { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}