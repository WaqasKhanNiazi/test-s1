using office360.Common.CommonHelper;
using office360.Extensions;
using office360.Models.EDMX;
using office360.Models.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static office360.Models.General.DocumentStatus;
using static office360.Models.General.HttpStatus;
using static office360.Models.General.ListConditionsForDB;


namespace office360.Common.DataBaseProcedures.AAccounts
{
    public class GetDataFromDB
    {
        SESEntities db = new SESEntities();

        public static List<_SqlParameters> GetFeeStructureDetailsByParam(_SqlParameters PostedData)
        {
            using (SESEntities db = new SESEntities())
            {
                var Data = from FSD in db.AccFeeStructureDetail
                           join SFT in db.StructureFeeType on FSD.FeeTypeId equals SFT.Id
                           join FS in db.AccFeeStructure on FSD.FeeStructureId equals FS.Id
                           where
                                 FSD.FeeStructureId == PostedData.FeeStructureId
                             && SFT.CompanyId == Session_Manager.CompanyId
                             && SFT.BranchId == Session_Manager.BranchId
                             && FSD.Status == true
                             &&(SFT.Recurring ==true || SFT.OnAdmissionOnly==true || SFT.Security==true)
                           select new _SqlParameters
                           {
                               FeeName = SFT.Description,
                               ChargingMethod = db.ChargingMethods.FirstOrDefault(cm => cm.Id == SFT.ChargingMethodId).Description,
                               AssetAccount = db.StructureCOAAccounts.FirstOrDefault(coa => coa.Id == FSD.AssetAccountId).Description,
                               LiabilityAccount = db.StructureCOAAccounts.FirstOrDefault(coa => coa.Id == FSD.LiabilityAccountId).Description,
                               RevenueAccount = db.StructureCOAAccounts.FirstOrDefault(coa => coa.Id == FSD.RevenueAccountId).Description,
                               FeeAmount = FSD.Amount,
                               StructureId = FSD.Id,
                               FeeTypeId = FSD.FeeTypeId,
                               AssetAccountId = FSD.AssetAccountId, // Assuming nullable int
                               LiabilityAccountId = FSD.LiabilityAccountId, // Assuming nullable int
                               RevenueAccountId = FSD.RevenueAccountId, // Assuming nullable int
                               ChargingMethodId = SFT.ChargingMethodId,
                               OnAdmissionOnly= SFT.OnAdmissionOnly,
                               Recurring = SFT.Recurring,
                               Refundable = SFT.Refundable,
                               Security = SFT.Security,
                           };
                return Data.ToList();
            };
        }

        public static List<_SqlParameters> GetFeeStructureInformationByParam(_SqlParameters PostedData)
        {
            using (SESEntities db = new SESEntities())
            {
                var Data = from AFS in db.AccFeeStructure
                           join CM in db.ChallanMethods on AFS.ChallanMethodId equals CM.Id
                           where AFS.Status == true
                               && AFS.SessionId == PostedData.SessionId
                               && AFS.ClassId == PostedData.ClassId
                               && AFS.CompanyId == Session_Manager.CompanyId
                               && AFS.BranchId == Session_Manager.BranchId
                           select new _SqlParameters
                           {
                               Id = AFS.Id,
                               Description = AFS.Description,
                               Code = AFS.Code,
                               NumberOfChallan = CM.NumberOfChallan,
                               TransactionMonth = CM.TransactionMonth
                           };
                return Data.ToList();
            }
        }
    }
}