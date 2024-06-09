using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace office360.Models.General
{
    public class DocumentStatus
    {
        public enum FileStatus
        {
            Working_BRANCHES = 1,
            NonOperation_BRANCHES = 2,
            Working_CLASSES = 3,
            NonOperation_CLASSES = 4,
            Open_ADMISSION = 5,
            Closed_ADMISSION = 6,
            Cancelled_ADMISSION = 7,
            Active_STUDENT = 8,
            InActive_STUDENT = 9,
            NewEnrollment_CLASS_REGISTRATION = 10,
            Promoted_CLASS_REGISTRATION = 11,
            Demoted_CLASS_REGISTRATION = 12,
            Left_CLASS_REGISTRATION = 13,
            Active_FEE_STRUCTURE = 14,
            InActive_FEE_STRUCTURE = 15,
            UnPaid_FEE_CHALLAN = 16,
            Cancelled_FEE_CHALLAN = 17,
            Revised_FEE_CHALLAN = 18,
            Paid_FEE_CHALLAN = 19,


        }
        public enum DocType
        {
            Branch=1,
            Class=2,
            Admission=3,
            Students=4,
            ClassEnrollment=5,
            FeeStructure=6,
            Chart_Of_Account=7,
            Fee_Challan=8,
        }
        public enum ChallanType
        {
            Trimester = 4,
            Monthly = 12,
            Quarterly = 3,
            Annual = 1,
            BiAnnual = 2
        }

    }
}