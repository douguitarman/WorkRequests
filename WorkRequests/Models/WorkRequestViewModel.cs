using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WorkRequests.BO;

namespace WorkRequests.Models
{
    public class WorkRequestViewModel
    {
        [Key]
        public int WorkRequestId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Display(Name = "Title")]
        public string WorkRequestTitle { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        public string WorkRequestDescription { get; set; }

        [Required(ErrorMessage = "Please enter the person that reported the issue")]
        [Display(Name = "Issue Reported By")]
        public string IssueReportedBy { get; set; }

        [Required(ErrorMessage = "Please enter the date the issue was reported")]
        [Display(Name = "Issue Reported Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime IssueReportedDate { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Display(Name = "Department")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public int StatusId { get; set; }

        [Display(Name = "Status")]
        public string StatusName { get; set; }

        [Required(ErrorMessage = "Priority is required")]
        [Display(Name = "Priority")]
        public int PriorityId { get; set; }

        [Display(Name = "Priority")]
        public string PriorityName { get; set; }

        [Required(ErrorMessage = "Request Type is required")]
        [Display(Name = "Request Type")]
        public int RequestTypeId { get; set; }

        [Display(Name = "Request Type")]
        public string RequestTypeName { get; set; }

        [Required(ErrorMessage = "Due Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Last Update By")]
        public string LastUpdateBy { get; set; }

        public List<WorkRequest> GetAllWorkRequests { get; set; }

        public List<Department> Departments { get; set; }

        public List<Priority> Priorities { get; set; }

        public List<RequestType> RequestTypes { get; set; }

        public List<Status> Statuses { get; set; }

        //public List<DropDownData> DropDownData { get; set; }
    }
}