using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkRequests.BO
{
    public class WorkRequest
    {
        public int WorkRequestId { get; set; }

        public string WorkRequestTitle { get; set; }

        public string WorkRequestDescription { get; set; }

        public string IssueReportedBy { get; set; }

        public DateTime IssueReportedDate { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public int StatusId { get; set; }

        public string StatusName { get; set; }

        public int PriorityId { get; set; }

        public string PriorityName { get; set; }

        public int RequestTypeId { get; set; }

        public string RequestTypeName { get; set; }

        public DateTime DueDate { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdateBy { get; set; }
    }
}