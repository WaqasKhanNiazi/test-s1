using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace office360.Models.General
{
    public class ListConditionsForDB
    {
        public enum ListCondition
        {
            GET_ALL_COUNTRIES,
            GET_COUNTRY_CODE,
            GET_COMPANY_ACTIVE_EMAIL_SETTINGS,
            GET_COMPANY_ACTIVE_MODULES,
            GET_USER_CONFIRMATION,
            GET_ALL_ALLOWED_RIGHTS_TO_LOGIN_USER_FOR_SIDE_MENUE,
            GET_ALLOWED_RIGHTS_TO_LOGIN_USER,
            GET_ACTIVE_ENROLLMENT_SETTINGS,
            GET_APPCLASS_LIST_TO_RUN_ENROLLMENT,
        }
        public enum InsCondition
        {
            INS_NEW_STUDENT,
            INS_PROMOTE_STUDENT,
        }
    }
}