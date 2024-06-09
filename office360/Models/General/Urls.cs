using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace office360.Models.General
{

    public static class _Managment
    {
        public static string RoleId { get; set; }
    }
    public static class _Controller
    {
        public static string Home = "Authentication";
        public static string Authentication = "Authentication";
        public static string InstituteClassesUI = "InstituteClassesUI";
        public static string BranchesUI = "BranchesUI";
        public static string SettingsUI = "SettingsUI";
        public static string AdmissionUI = "AdmissionUI";
    }
    public static class _Areas
    {
        public static string Branches = "Branches";
        public static string Acadmics = "Acadmics";
        public static string SettingsUI = "Settings";
    }
    public class _ActionsURL
    {
        #region CONSUMABLE PAGE 
        public static string InternalServerError = "GetInternalServerError";
        public static string DataDoesNotExist = "DataDoesNotExist";
        public static string LogIn = "LogIn_FE";
        public static string Logout = "/Home/Logout";
        public static string ViewListAppClass = "ViewListAppClass";
        public static string UpdateAppClassById = "UpdateAppClassById";
        public static string CreateNewAdmission = "CreateNewAdmission";
        public static string CreateNewAppClass = "CreateNewAppClass";
        public static string CreateGeneralBranch = "CreateGeneralBranch";
        #endregion
        #region DASH BOARD
        public static string GetDashBoard = "GetDashBoard";
        public static string GetDashBoard_DEO = "GetDashBoard_DEO";
        public static string GetDashBoard_MANAGER = "GetDashBoard_MANAGER";
        public static string GetDashBoard_DEVELOPER = "GetDashBoard_DEVELOPER";
        public static string GetDashBoard_ADMIN = "GetDashBoard_ADMIN";
        #endregion


    }
    public class Scripts
    {
        #region COMPANY SETUPS  SCRIPTS
        public static string AddCompanyScriptsUrl = "/Areas/Setup/SetupScripts/AddCompany.js";
        #endregion
    }

    public static class UiUrls
    {
        #region AREAS
        public static string _BranchUI = "/Branches/BranchesUI/";

        #endregion


        public static string CreateNewBranch = _BranchUI + "/CreateNewBranch".ToString();
        public static string ListBranch = _BranchUI + "/BranchList".ToString();
    }
    public static class Action
    {
        public const long Insert = 9141951820;
        public const long Update = 211641205;
        public const long View = 229523;
        public const long Delete = 45125205;
    }

    public class _URL
    {
        public static string LogInPage = "~/Views/LogInPage";
    }
}
