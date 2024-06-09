using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace office360.Models.General
{
    using System;
    using System.Collections.Generic;
    public class ASPManagRoles
    {
        public static readonly Dictionary<Guid?, string> RoleGuids = new Dictionary<Guid?, string>
        {
                { new Guid("BA6FCEAB-3760-4C27-A795-411310744658"), "ROLE_ADMIN" },
                { new Guid("62B47B1A-036A-481E-A891-73A1AA8A7051"), "ROLE_DEVELOPER" },
                { new Guid("8957F870-63D1-4FCC-A265-97CD4FF6713A"), "ROLE_MANAGER" },
                { new Guid("49FE7CA6-DA9D-46D8-A538-ECEEE83C01E3"), "ROLE_DEO" },
        };
        public static readonly Guid URLTYPEID_FORM = new Guid("66AA2CA7-EE0F-4C09-B7B0-9803519B887D");
        public static readonly Guid URLTYPEID_REPORT_RDLC = new Guid("748CB801-D565-4363-8DA2-720AED7B3263");
    }
}