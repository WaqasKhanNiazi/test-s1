using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using office360.Common.CommonHelper;
using office360.Common.DataBaseProcedures;
using office360.Common.DataBaseProcedures.Reports;
using office360.CommonHelper;
using office360.Extensions;
using office360.Models.EDMX;
using office360.Models.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static office360.Common.CommonHelper.ReportsUttility;
using static office360.Common.DataBaseProcedures.Reports.Reports;
using static office360.Models.General.HttpStatus;

namespace office360.Areas.AReports.Controllers
{
    public class FeeViewerController : Controller
    {
        DataSet ds = null;
        public ActionResult Rp_FeeStructureByClassId(_SqlParameters PostedData)
        {
            ds = new DataSet();
            try
            {
                ds.Tables.Add(Common.DataBaseProcedures.Reports.Reports.FeeStructure_Rp(PostedData).ToList().ToDataTable("Table"));
                ds.Tables.Add(Common.DataBaseProcedures.Reports.Reports.FeeStructurDetail_Rp(PostedData).ToList().ToDataTable("TableDetail"));

                PostedData.ReportTitle = "Class Fee Report";
                CreateReport(ReportPath.ClassFeeReport, ds, PostedData, this);

                // Assuming the report is saved as a PDF file
                var ReportPath_ = ReportPath.ClassFeeReport;

                // Return the file
                return File(ReportPath_, "application/pdf", Uttility.GetHashGuid()+"/pdf");
            }
            catch (Exception ex)
            {
                string exce = ex.InnerException.ToString();
                // Log the exception and handle the error appropriately
                // You may want to return an error response or a different kind of file/message
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred");
            }
        }




    }
}
