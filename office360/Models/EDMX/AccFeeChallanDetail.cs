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
    
    public partial class AccFeeChallanDetail
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> FeeChallanId { get; set; }
        public Nullable<System.Guid> FeeTypeId { get; set; }
        public Nullable<decimal> ActualAmount { get; set; }
        public Nullable<decimal> ChargedAmount { get; set; }
        public Nullable<decimal> Difference { get; set; }
    }
}
