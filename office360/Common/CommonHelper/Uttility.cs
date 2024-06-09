using Microsoft.Reporting.WebForms;
using office360.Common.CommonHelper;
using office360.CommonHelper;
using office360.Extensions;
using office360.Models.EDMX;
using office360.Models.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using static office360.Models.General.Constants;
using static office360.Models.General.DocumentStatus;
using static office360.Models.General.HttpStatus;

namespace office360.Common.CommonHelper
{
    public class Uttility
    {
        SESEntities db = new SESEntities();
        public static string GetCodeFormat(string ShortCode)
        {
            return ShortCode + "-" + DateTime.Now.ToString("yyyyMMdd");
        }
        public static Guid GetHashGuid()
        {
            return Guid.NewGuid();
        }
        public static bool InsertHistory(string TableName, string ColumnNames, string Values, out int? StatusCode)
        {
            using (var db = new SESEntities())
            {
                try
                {
                    var _Status = new SqlParameter("@Status", SqlDbType.Int);
                    _Status.Direction = ParameterDirection.Output;
                    db.Database.ExecuteSqlCommand(
                        "EXEC @Status = dbo.DEV_InsertHistory @TableName, @ColumnNames, @ColumnValues",
                        _Status,
                        new SqlParameter("@TableName", TableName),
                        new SqlParameter("@ColumnNames", ColumnNames),
                        new SqlParameter("@ColumnValues", Values)
                    );
                    StatusCode = _Status.Value.ToInt();
                    return true;
                }
                catch (Exception Ex)
                {
                    StatusCode = HttpResponses.CODE_INTERNAL_SERVER_ERROR.ToInt();
                    return false;
                }
            }
        }
        public static int? IsDuplicateAlreadyExist(string TableName, string ColumnNames, string Condition)
        {
            int? StatusCode = 0;
            using (var db = new SESEntities())
            {
                try
                {
                    var _Exe = db.DevCheckDuplicateRecord(TableName, ColumnNames, Condition).ToList();
                    var _Response = _Exe.FirstOrDefault();
                    StatusCode = _Response.Value.ToInt();
                    return StatusCode;
                }
                catch (Exception Ex)
                {
                    StatusCode = HttpResponses.CODE_INTERNAL_SERVER_ERROR.ToInt();
                    return StatusCode;
                }
            }
        }
        public static string fn_GetDateConv(DateTime? DateTime)
        {
            if (DateTime.HasValue)
            {
                return DateTime.Value.ToString("MMMM yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                return "In Valid Request";
            }
        }
        public static string GetMonthRange(_SqlParameters PostedData)
        {
            using (var db = new SESEntities())
            {
                #region CHECK IF PARAMETERS ARE NOT VALID
                if (!PostedData.TransactionDate.HasValue || !PostedData.TransactionMonth.HasValue || PostedData.TransactionMonth.Value <= 0)
                {
                    return "Invalid Request";
                }
                #endregion
                #region SETTING VARIABLES
                DateTime StartDate, EndDate;
                int? BillingMethodId = BranchSettings.BillingMethodId;
                #endregion
                #region CHECK FOR BILLING METHOD 
                switch (BillingMethodId)
                {
                    #region PRE PAID BILLING
                    case 1:
                        StartDate = PostedData.TransactionDate.Value;
                        EndDate = StartDate.AddMonths((int)PostedData.TransactionMonth - 1);
                        break;
                    #endregion
                    #region POST PAID BILLING
                    case 2:
                        EndDate = PostedData.TransactionDate.Value;
                        StartDate = EndDate.AddMonths(-(int)PostedData.TransactionMonth + 1);
                        break;
                    #endregion
                    default:
                        return "Invalid Billing Method";
                }
                #endregion

                #region  RETURNING VALUE
                string StartMonthYear = StartDate.ToString("MMMM yyyy", CultureInfo.InvariantCulture);
                string EndMonthYear = EndDate.ToString("MMMM yyyy", CultureInfo.InvariantCulture);
                #endregion
                return $"{StartMonthYear} - {EndMonthYear}";
            }
        }
        public static string _RigthPath(string _Area, string _Controller, string _Action)
        {
            return ("/" + _Area + "/" + _Controller + "/" + _Action).ToSafeString();
        }






    }
}
