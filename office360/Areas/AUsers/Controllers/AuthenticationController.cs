using office360.CommonHelper;
using office360.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static office360.Models.General.HttpStatus;

namespace office360.Areas.AUsers.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: AUsers/Authentication
        public ActionResult LogIn_FE()
        {
            return View();
        }
      
        public ActionResult LogIn_CredentialVerification(_SqlParameters Users)
        {
            Guid? RoleId = null;
            if (Users != null)
            {
                int? StatusCode = 0;
                var CheckData = LogInAuthentication.CheckUserAuthorization(Users, out RoleId, out StatusCode);
                switch (StatusCode)
                {
                    case (int?)HttpResponses.CODE_SUCCESS:
                        return RedirectToAction(_ActionsURL.GetDashBoard, _Controller.Authentication);
                    case (int?)HttpResponses.CODE_INTERNAL_SERVER_ERROR:
                        return RedirectToAction(_ActionsURL.InternalServerError, _Controller.Authentication);
                    case (int?)HttpResponses.CODE_DATA_DOES_NOT_EXIST:
                        return RedirectToAction(_ActionsURL.LogIn, _Controller.Authentication);
                    default:
                        return RedirectToAction(_ActionsURL.LogIn, _Controller.Authentication);
                }
            }
            else
            {
                return RedirectToAction(_ActionsURL.LogIn, _Controller.Authentication);
            }

        }
        public ActionResult GetDashboard()
        {
            Session["BasePath"] = "https://localhost:44368/";
            string roleKey;
            if (ASPManagRoles.RoleGuids.TryGetValue(Session_Manager.RoleId, out roleKey))
            {
                switch (roleKey)
                {
                    case "ROLE_ADMIN":
                        return View(_ActionsURL.GetDashBoard_ADMIN);
                    case "ROLE_DEVELOPER":
                        return View(_ActionsURL.GetDashBoard_DEVELOPER);
                    case "ROLE_MANAGER":
                        return View(_ActionsURL.GetDashBoard_MANAGER);
                    case "ROLE_DEO":
                        return View(_ActionsURL.GetDashBoard_DEO);
                    default:
                        return View(_ActionsURL.LogIn);
                }
            }
            else
            {
            }
            return View();
        }

    }
}