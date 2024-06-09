using office360.Extensions;
using office360.Models.EDMX;
using office360.Models.General;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using static office360.Models.General.HttpStatus;
using System.Collections.Generic;

namespace office360.CommonHelper
{

    public class LogInAuthentication
    {
        SESEntities db = new SESEntities();
        public static bool CheckUserAuthorization(_SqlParameters Users, out Guid? RoleId, out int? StatusCode)
        {
            try
            {
                #region CHECK IF USER EXIST
                var UserName = Users.UserName.ToString();
                var Password = Users.Password.ToString();
                var Condition = ListConditionsForDB.ListCondition.GET_USER_CONFIRMATION.ToSafeString();
                if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
                {
                    using (var db = new SESEntities())
                    {
                        var ListCondition_ = new SqlParameter("@ListCondition", (object)Condition ?? DBNull.Value);
                        var CompanyId_ = new SqlParameter("@CompanyId", (object)null ?? DBNull.Value);
                        var IsLogIn_ = new SqlParameter("@IsLogIn", (object)true ?? DBNull.Value);
                        var UserName_ = new SqlParameter("@UserName", (object)Users.UserName ?? DBNull.Value);
                        var Password_ = new SqlParameter("@Password", (object)Users.Password ?? DBNull.Value);
                        var Id_ = new SqlParameter("@Id", (object)null ?? DBNull.Value);
                        var data = db.Database.SqlQuery<GeneralUser_GetDetailByParameter_Result>("GeneralUser_GetDetailByParameter @ListCondition,@CompanyId,@IsLogIn,@UserName,@Password,@Id", ListCondition_,CompanyId_, IsLogIn_,UserName_,Password_,Id_).ToList();

                        if (data != null && data.Count > 0)
                        {
                #endregion
                            #region GETTING USER INFORMATION INTO SESSION
                            var List = data.FirstOrDefault();
                            RoleId =  List.RoleId;
                            StatusCode = (int?)HttpResponses.CODE_SUCCESS;
                            HttpContext.Current.Session["Name"] = List.Name;
                            HttpContext.Current.Session["UserName"] = List.UserName;
                            HttpContext.Current.Session["Password"] = List.Password;
                            HttpContext.Current.Session["EmailAddress"] = List.EmailAddress;
                            HttpContext.Current.Session["MobileNumber"] = List.MobileNumber;
                            HttpContext.Current.Session["RoleId"] = List.RoleId;
                            HttpContext.Current.Session["IsLogIn"] = List.IsLogIn;
                            HttpContext.Current.Session["AllowedBranchIds"] = List.AllowedBranchIds;
                            HttpContext.Current.Session["CreatedOn"] = List.CreatedOn;
                            HttpContext.Current.Session["CreatedBy"] = List.CreatedBy;
                            HttpContext.Current.Session["UpdatedOn"] = List.UpdatedOn;
                            HttpContext.Current.Session["UpdatedBy"] = List.UpdatedBy;
                            HttpContext.Current.Session["EmployeeId"] = List.EmployeeId;
                            HttpContext.Current.Session["IsDeveloper"] = List.IsDeveloper;
                            HttpContext.Current.Session["CompanyId"] = List.CompanyId;
                            HttpContext.Current.Session["UserId"] = List.Id;
                            HttpContext.Current.Session["BranchId"] = List.BranchId;
                            #endregion
                            #region GET COMPANY INFORMATION BY LOG_IN USER
                            var CompanyId = new SqlParameter("@Id", (object)List.CompanyId ?? DBNull.Value);
                            var Coy = db.Database.SqlQuery<_SqlParameters>("GeneralCompany_GetDetailById @Id", CompanyId).ToList();
                            var Lst = Coy.FirstOrDefault();

                            HttpContext.Current.Session["CoyId"] = Lst.Id;
                            HttpContext.Current.Session["CompanyName"] = Lst.CompanyName;
                            HttpContext.Current.Session["CityId"] = Lst.CityId;
                            HttpContext.Current.Session["CountryId"] = Lst.CountryId;
                            HttpContext.Current.Session["AddressLine"] = Lst.AddressLine;
                            HttpContext.Current.Session["PhoneNumber"] = Lst.PhoneNumber;
                            HttpContext.Current.Session["CoyEmailAddress"] = Lst.EmailAddress;
                            HttpContext.Current.Session["CompanyWebsite"] = Lst.CompanyWebsite;
                            HttpContext.Current.Session["UploadLogo"] = Lst.UploadLogo;
                            HttpContext.Current.Session["Status"] = Lst.Status;
                            HttpContext.Current.Session["CityName"] = Lst.CityName;
                            HttpContext.Current.Session["CountryName"] = Lst.CountryName;

                            #region BRANCH INFO
                            //var _Lst = db.LK_Country_GetListByParameter(Lst.CountryId,SP_Conditions.GET_COUNTRY_CODE.ToSafeString()).FirstOrDefault();
                            //HttpContext.Current.Session["CallingCode"] = "+92".ToSafeString();
                            //var AGB = from GBR in db.GeneralBranch
                            //          where GBR.Id == List.BranchId && GBR.CompanyId == Lst.Id
                            //          select new { BranchName = GBR.Description, BranchAdress = GBR.Address,BranchCityId=GBR.CityId };
                            //HttpContext.Current.Session["BranchName"] = AGB.FirstOrDefault().BranchName;
                            //HttpContext.Current.Session["BranchAddress"] = AGB.FirstOrDefault().BranchAdress;
                            //var C = from CI in db.City
                            //          where CI.Id == AGB.FirstOrDefault().BranchCityId
                            //          select new { BranchCity = CI.Description };

                            //HttpContext.Current.Session["BranchCity"] = C.FirstOrDefault().BranchCity;

                            #endregion
                            #endregion
                            #region GET COMPANY SETTING DETAILS
                            var CompanyId1 = new SqlParameter("@CompanyId", (object)Session_Manager.CompanyId ?? DBNull.Value);
                            var _data = db.Database.SqlQuery<_SqlParameters>("GeneralCompany_GetDetailById @CompanyId", CompanyId1).ToList();
                            HttpContext.Current.Session["IsDiscountApplicable"] = _data.FirstOrDefault().IsDiscountAllowed;
                            HttpContext.Current.Session["IsReportsApplicable"] = _data.FirstOrDefault().IsReportsAllowed;


                            var rawData = db.Database.SqlQuery<AsideMenu_>("SideMenu_GetList").ToList();

                            var menus = rawData
                                .GroupBy(item => item.ParentDisplay)
                                .Select(g => new MenuViewModel
                                {
                                    Menu = g.Key,
                                    Modules = g.GroupBy(x => x.ParentDisplay)
                                               .Select(mg => new ModuleViewModel
                                               {
                                                   Module = mg.Key,
                                                   Displays = mg.Select(x => x.Form).Distinct().ToList(),
                                                   URL = mg.Select(x => x.URL).Distinct().ToList(),
                                               }).ToList()
                                }).ToList();

                            HttpContext.Current.Session["AsideMenuList"] = menus;
                            #endregion
                            #region GET BRANCH SETTING DETAILS
                            //var GBS = from ACR in db.GeneralBranchSetting
                            //          where
                            //          ACR.CompanyId == List.CompanyId && ACR.BranchId == List.BranchId && ACR.Status == true
                            //          select new
                            //          { ACR.RollCallISystemId, ACR.BillingMethodId };
                            //HttpContext.Current.Session["RollCallSystemId"] = GBS.FirstOrDefault().RollCallISystemId;
                            //HttpContext.Current.Session["BillingMethodId"] = GBS.FirstOrDefault().BillingMethodId;
                            #endregion
                            return true;
                     }
                    }
                }
            }
            catch (Exception ex)
            {
                StatusCode = (int?)HttpResponses.CODE_INTERNAL_SERVER_ERROR;
            }
            StatusCode = (int?)HttpResponses.CODE_DATA_DOES_NOT_EXIST;
            RoleId = null; 
            return false;
        }

    }




}



