using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using office360.Models.General;
using office360.Models.EDMX;
using office360.Extensions;
using static office360.Models.General.ListConditionsForDB;
using static office360.Models.General.HttpStatus;

namespace office360.CommonHelper
{
    public class GetAllListFromDB
    {

        #region COMMONS LIST FUNCTIONS


        public static List<GeneralRightSetting_GetByParam_Result> GetRightsByParameter(_SqlParameters Parameter)
        {
            using (var db = new SESEntities())
            {
                var data = db.GeneralRightSetting_GetByParam(
                                                              Session_Manager.CompanyId
                                                            , ASPManagRoles.URLTYPEID_FORM
                                                            , true
                                                            , ListCondition.GET_ALL_ALLOWED_RIGHTS_TO_LOGIN_USER_FOR_SIDE_MENUE.ToSafeString()
                                                            , Parameter.Menu
                                                            , Session_Manager.UserId
                                                            , null
                                                            , Parameter.RightPath.ToSafeString()
                                                            ).ToList();
                return data;
            }
        }
        public static int? GetAllowedUsersRightsByParameter(Guid? RightId)
        {
            using (var db = new SESEntities())
            {
                var data = db.GeneralRightSetting_GetByParam(
                                                              Session_Manager.CompanyId
                                                            , ASPManagRoles.URLTYPEID_FORM
                                                            , true
                                                            , ListCondition.GET_ALLOWED_RIGHTS_TO_LOGIN_USER.ToSafeString()
                                                            , null
                                                            , Session_Manager.UserId
                                                            , RightId
                                                            , null
                                                            ).ToList();
                if (data.Count > 0)
                {
                    return (int?)HttpResponses.CODE_SUCCESS;


                }
                else
                {
                    return (int?)HttpResponses.CODE_UNAUTHORIZED;
                }
            }
        }
        #endregion


        public static List<GeneralEnrollmentSetting_GetDetailsByParam_Result> GetBranchEnrollmentSettingList()
        {
            using (var db = new SESEntities())
            {
                var data = db.GeneralEnrollmentSetting_GetDetailsByParam(ListCondition.GET_ACTIVE_ENROLLMENT_SETTINGS.ToSafeString(), Session_Manager.CompanyId, Session_Manager.BranchId).ToList();
                return data;
            }
        }
    }
}