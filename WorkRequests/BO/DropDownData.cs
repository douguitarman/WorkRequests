using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkRequests.BO
{
    public class DropDownData
    {
        public int PriorityId { get; set; }

        public string PriorityName { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public List<Department> departments { get; set; }

    }
}