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
    public class CheckDuplicateRecord
    {
        SESEntities db = new SESEntities();
        public static int? AccFeeChallan_CheckFeeChallanExist_FirstTime(_SqlParameters PostedData)
        {
            using (var db = new SESEntities())
            {
                using (System.Data.Entity.DbContextTransaction dbTran = db.Database.BeginTransaction())
                {
                    try
                    {


                        var IsAlreadyExist = db.AccFeeChallan.Where(AFC => AFC.SessionId == PostedData.SessionId && AFC.ClassId == PostedData.ClassId
                                                                       && AFC.RegistrationTypeId == PostedData.RegistrationTypeId && AFC.ClassRegistrationId == PostedData.ClassRegistrationId
                                                                       && AFC.FeeStructureId == PostedData.FeeStructureId && AFC.BranchId == Session_Manager.BranchId
                                                                       && AFC.CompanyId == Session_Manager.CompanyId
                                                         ).Select(x => new { Id = x.Guid, Description = x.Description }).ToList();
                        int? Count = IsAlreadyExist.Count();
                        return Count;
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