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
using System.Globalization;
using System.Data.Entity.Core.Objects;

namespace office360.Common.DataBaseProcedures.AAccounts
{
    public class InsertIntoDB
    {
        public static int? AccFeeChallan_Insert(_SqlParameters PostedData, List<_SqlParameters> PostedDataDetail)
        {
            using (var db = new SESEntities())
            {
                using (System.Data.Entity.DbContextTransaction dbTran = db.Database.BeginTransaction())
                {
                    try
                    {
                        #region CHECK IF 1ST FEE INSTALLMENT ALREADY EXIST
                        var IsAlreadyExist = Common.DataBaseProcedures.AAccounts.CheckDuplicateRecord.AccFeeChallan_CheckFeeChallanExist_FirstTime(PostedData);
                        #endregion

                        #region IF DATA DOES NOT EXIST PROCEED
                        if (IsAlreadyExist == 0)
                        {
                            #region GET MONTHS ON RANGE BASIS FOR ISSUING FEE CHALLAN
                            var TransactionMonthNo = Common.DataBaseProcedures.AAccounts.GetDataFromDB.GetFeeStructureInformationByParam(PostedData);
                            PostedData.TransactionMonth = TransactionMonthNo.FirstOrDefault().TransactionMonth;
                            #endregion


                            #region DECLARATION OF VARIABLES FOR FEE CHALLAN PARENT
                            Guid? FeeChallanId = Uttility.GetHashGuid();
                            string Description = "Fee Challan For Month of " + Uttility.GetMonthRange(PostedData);
                            Guid? SessionId = PostedData.SessionId;
                            Guid? ClassId = PostedData.ClassId;
                            int? RegistrationTypeId = PostedData.RegistrationTypeId;
                            Guid? ClassRegistrationId = PostedData.ClassRegistrationId;
                            DateTime? TransactionDate = PostedData.TransactionDate;
                            DateTime? DueDate = PostedData.DueDate;
                            DateTime? ExpiryDate = PostedData.DueDate;
                            Guid? FeeStructureId = PostedData.FeeStructureId;
                            decimal? GrossRecievable = PostedData.GrossRecievable;
                            decimal? LateFee = PostedData.LateFee;
                            decimal? Discount = PostedData.Discount;
                            decimal? NetRecievable = PostedData.NetRecievable;
                            #endregion
                            #region OUTPUT PARAMETER
                            ObjectParameter Response = new ObjectParameter("Response", typeof(int));
                            #endregion
                            #region INSERT INTO DATA BASE AccFeeChallan
                            var Data = db.AccFeeChallan_Insert(
                                                                FeeChallanId,
                                                                Description,
                                                                SessionId,
                                                                ClassId,
                                                                RegistrationTypeId,
                                                                ClassRegistrationId,
                                                                TransactionDate,//CHALLAN ISSUE DATE
                                                                DueDate,
                                                                ExpiryDate,
                                                                FeeStructureId,
                                                                GrossRecievable,
                                                                LateFee,
                                                                Discount,
                                                                NetRecievable,
                                                                Session_Manager.UserId,
                                                                (int?)Models.General.DocumentStatus.FileStatus.UnPaid_FEE_CHALLAN,
                                                                (int?)Models.General.DocumentStatus.DocType.Fee_Challan,
                                                                Session_Manager.BranchId,
                                                                Session_Manager.CompanyId,
                                                                Response
                                                              );
                            #endregion
                            #region INSERT INTO DATA BASE AccFeeChallanDetail
                            foreach (var Item in PostedDataDetail)
                            {
                                decimal? DifferenceCharge = Item.ActualFeeAmount - Item.ChargedFeeAmount;
                                db.AccFeeChallanDetail_Insert(
                                                                  FeeChallanId,
                                                                  Item.FeeTypeId,
                                                                  Item.ActualFeeAmount,
                                                                  Item.ChargedFeeAmount,
                                                                  DifferenceCharge
                                                                );
                            }
                            #endregion
                            #region INSERT INTO DATA BASE FEE LEDGER
                            #endregion
                            #region INSERT INTO DATA BASE GENERAL JOURNAL
                            foreach (var Item in PostedDataDetail)
                            {
                                if (Item.AssetAccountId != null)
                                {

                                }
                                else if (Item.LiabilityAccountId != null)
                                {

                                }
                            }
                            #endregion

                            dbTran.Commit();
                            return HttpStatus.HttpResponseByReturnValue((int?)Response.Value);
                        }
                        #endregion
                        else
                        {
                            return HttpStatus.HttpResponses.CODE_DATA_ALREADY_EXIST.ToInt();
                        }

                    }
                    catch (Exception Ex)
                    {
                        dbTran.Rollback();
                        return HttpStatus.HttpResponses.CODE_INTERNAL_SERVER_ERROR.ToInt();
                    }
                }
            }
        }
    }
}