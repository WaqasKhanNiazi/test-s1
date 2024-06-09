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
    
    public partial class AccFeeStructure_GetDetailsByParam_Result
    {
        public string FeeName { get; set; }
        public string ChargingMethod { get; set; }
        public string AssetAccount { get; set; }
        public string LiabilityAccount { get; set; }
        public string RevenueAccount { get; set; }
        public Nullable<decimal> FeeAmount { get; set; }
        public System.Guid StructureId { get; set; }
        public Nullable<System.Guid> FeeTypeId { get; set; }
        public Nullable<System.Guid> AssetAccountId { get; set; }
        public Nullable<System.Guid> LiabilityAccountId { get; set; }
        public Nullable<System.Guid> RevenueAccountId { get; set; }
        public Nullable<System.Guid> ChargingMethodId { get; set; }
        public Nullable<bool> OnAdmissionOnly { get; set; }
        public Nullable<bool> Recurring { get; set; }
        public Nullable<bool> Refundable { get; set; }
        public Nullable<bool> Security { get; set; }
    }
}
