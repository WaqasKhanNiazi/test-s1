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
using static office360.Models.General.ListConditionsForDB;

namespace office360.Common.DataBaseProcedures.ABranches
{
    public class GetDataFromDB
    {
        public static List<AppClass_GetListByParam_Result> PopulateAllowedAppClassBySessionId(_SqlParameters PostedData)
        {
            using (SESEntities db = new SESEntities())
            {
                SqlParameter param1 = new SqlParameter("@CompanyId", Session_Manager.CompanyId ?? (object)DBNull.Value);
                SqlParameter param2 = new SqlParameter("@BranchId", Session_Manager.BranchId ?? (object)DBNull.Value);
                SqlParameter param3 = new SqlParameter("@SessionId", PostedData.SessionId ?? (object)DBNull.Value);
                SqlParameter param4 = new SqlParameter("@ClassId", PostedData.ClassId ?? (object)DBNull.Value);
                SqlParameter param5 = new SqlParameter("@ListCondition", ListCondition.GET_APPCLASS_LIST_TO_RUN_ENROLLMENT.ToSafeString());

                List<AppClass_GetListByParam_Result> data = db.Database.SqlQuery<AppClass_GetListByParam_Result>(
                    "AppClass_GetListByParam @CompanyId, @BranchId, @SessionId, @ClassId, @ListCondition",
                    param1, param2, param3, param4, param5).ToList();
                return data;

            }
        }
    }
}