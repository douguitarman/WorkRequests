using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using WorkRequests.BO;
using WorkRequests.Models;

namespace WorkRequests.DAL
{
    public class WorkRequests
    {

        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DougDB"].ToString());

        /// <summary>
        /// Check reader values for null before casting to string
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private String GetStringValue(SqlDataReader reader, String columnName)
        {
            return (reader[columnName] != null && reader[columnName] != DBNull.Value) ? Convert.ToString(reader[columnName]) : null;
        }

        /// <summary>
        /// Check reader values for null before casting to int
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private int GetIntValue(SqlDataReader reader, String columnName)
        {
            return (reader[columnName] != null && reader[columnName] != DBNull.Value) ? Convert.ToInt32(reader[columnName]) : 0;
        }

        /// <summary>
        /// Add a new work request
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string AddWorkRequest(WorkRequestViewModel model)
        {          
            using (SqlCommand cmd = new SqlCommand("AddWorkRequest", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WorkRequestTitle", model.WorkRequestTitle);
                cmd.Parameters.AddWithValue("@WorkRequestDescription", model.WorkRequestDescription);
                cmd.Parameters.AddWithValue("@IssueReportedBy", model.IssueReportedBy);
                cmd.Parameters.AddWithValue("@IssueReportedDate", model.IssueReportedDate);
                cmd.Parameters.AddWithValue("@DepartmentId", model.DepartmentId);
                cmd.Parameters.AddWithValue("@PriorityId", model.PriorityId);
                cmd.Parameters.AddWithValue("@RequestTypeId", model.RequestTypeId);
                cmd.Parameters.AddWithValue("@DueDate", model.DueDate);
                cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);

                connection.Open();

                string result = cmd.ExecuteNonQuery().ToString();

                return result;
            }
        }

        public string AddReceipt(Receipt model)
        {

            using (SqlCommand cmd = new SqlCommand("AddReceipt", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReceiptImageName", model.ReceiptImageName);
                cmd.Parameters.AddWithValue("@ReceiptImage", model.ReceiptImage.InputStream);

                connection.Open();

                string result = cmd.ExecuteNonQuery().ToString();

                return result;
            }
        }

        public List<Receipt> GetReceipts()
        {
            List<Receipt> receipts = new List<Receipt>();

            using (var DataWrapper = new DataWrapper())
            {
                var reader = DataWrapper.Query("GetReceipts");

                while (reader.Read())
                {
                    receipts.Add(
                        new Receipt()
                        {
                            ReceiptId = GetIntValue(reader, "ReceiptId"),
                            ReceiptImageName = GetStringValue(reader, "ReceiptImageName"),
                            DisplayReceipt = (Byte[])reader["ReceiptImage"]
                        });
                }
            }
           
            return receipts;
        }

        /// <summary>
        /// Update work request
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string UpdateWorkRequest(WorkRequestViewModel model)
        {
            using (SqlCommand cmd = new SqlCommand("UpdateWorkRequest", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WorkRequestId", model.WorkRequestId);
                cmd.Parameters.AddWithValue("@WorkRequestTitle", model.WorkRequestTitle);
                cmd.Parameters.AddWithValue("@WorkRequestDescription", model.WorkRequestDescription);
                cmd.Parameters.AddWithValue("@DepartmentId", model.DepartmentId);
                cmd.Parameters.AddWithValue("@StatusId", model.StatusId);
                cmd.Parameters.AddWithValue("@PriorityId", model.PriorityId);
                cmd.Parameters.AddWithValue("@RequestTypeId", model.RequestTypeId);
                cmd.Parameters.AddWithValue("@DueDate", model.DueDate);
                cmd.Parameters.AddWithValue("@LastUpdateBy", model.LastUpdateBy);

                connection.Open();

                string result = cmd.ExecuteNonQuery().ToString();

                return result;
            }
        }

        /// <summary>
        /// Get all Work Requests
        /// </summary>
        /// <returns></returns>
        public List<WorkRequest> GetWorkRequests()
        {
            List<WorkRequest> requests = new List<WorkRequest>();

            using (var DataWrapper = new DataWrapper())
            {
                var reader = DataWrapper.Query("GetWorkRequests");

                while (reader.Read())
                {
                    requests.Add(
                        new WorkRequest()
                        {
                            WorkRequestId = GetIntValue(reader, "WorkRequestId"),
                            WorkRequestTitle = GetStringValue(reader, "WorkRequestTitle"),
                            WorkRequestDescription = GetStringValue(reader, "WorkRequestDescription"),
                            IssueReportedBy = GetStringValue(reader, "IssueReportedBy"),
                            IssueReportedDate = Convert.ToDateTime(reader["IssueReportedDate"]),
                            DepartmentId = GetIntValue(reader, "DepartmentId"),
                            DepartmentName = GetStringValue(reader, "DepartmentName"),
                            StatusId = GetIntValue(reader, "StatusId"),
                            StatusName = GetStringValue(reader, "StatusName"),
                            PriorityId = GetIntValue(reader, "PriorityId"),
                            PriorityName = GetStringValue(reader, "PriorityName"),
                            RequestTypeId = GetIntValue(reader, "RequestTypeId"),
                            RequestTypeName = GetStringValue(reader, "RequestTypeName"),
                            DueDate = Convert.ToDateTime(reader["DueDate"]),
                            CreatedBy = GetStringValue(reader, "CreatedBy"),
                            LastUpdateBy = GetStringValue(reader, "LastUpdateBy")
                        });
                }
            }

            return requests;
        }

        /// <summary>
        /// Get single work request
        /// </summary>
        /// <returns></returns>
        public WorkRequestViewModel GetWorkRequest(int id)
        {
            WorkRequestViewModel request = new WorkRequestViewModel();

            using (var DataWrapper = new DataWrapper())
            {
                var reader = DataWrapper.QueryWithParams("GetWorkRequest", "@WorkRequestId", id);

                if (reader.Read())
                {
                    request.WorkRequestId = GetIntValue(reader, "WorkRequestId");
                    request.WorkRequestTitle = GetStringValue(reader, "WorkRequestTitle");
                    request.WorkRequestDescription = GetStringValue(reader, "WorkRequestDescription");
                    request.IssueReportedBy = GetStringValue(reader, "IssueReportedBy");
                    request.IssueReportedDate = Convert.ToDateTime(reader["IssueReportedDate"]);
                    request.DepartmentId = GetIntValue(reader, "DepartmentId");
                    request.DepartmentName = GetStringValue(reader, "DepartmentName");
                    request.StatusId = GetIntValue(reader, "StatusId");
                    request.StatusName = GetStringValue(reader, "StatusName");
                    request.PriorityId = GetIntValue(reader, "PriorityId");
                    request.PriorityName = GetStringValue(reader, "PriorityName");
                    request.RequestTypeId = GetIntValue(reader, "RequestTypeId");
                    request.RequestTypeName = GetStringValue(reader, "RequestTypeName");
                    request.DueDate = Convert.ToDateTime(reader["DueDate"]);
                    request.CreatedBy = GetStringValue(reader, "CreatedBy");
                    request.LastUpdateBy = GetStringValue(reader, "LastUpdateBy");
                    request.Departments = GetDepartments();
                    request.Priorities = GetPriorities();
                    request.RequestTypes = GetRequestTypes();
                    request.Statuses = GetStatuses();
                }
            }

            return request;
        }

        /// <summary>
        /// Delete a work request
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteWorkRequest(int id)
        {
            using (var DataWrapper = new DataWrapper())
            {
                var result = DataWrapper.NonQuery("DeleteWorkRequest", "@WorkRequestId", id);

                return result.ToString();
            }
        }

        /// <summary>
        /// Get Departments
        /// </summary>
        /// <returns></returns>
        public static List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();

            using (var DataWrapper = new DataWrapper())
            {
                var reader = DataWrapper.Query("GetDepartments");

                while (reader.Read())
                {
                    departments.Add(
                        new Department()
                        {
                            DepartmentId = (int)reader["DepartmentId"],
                            DepartmentName = (string)reader["DepartmentName"]
                        });
                }
            }

            return departments;
        }

        /// <summary>
        /// Get Priorities
        /// </summary>
        /// <returns></returns>
        public static List<Priority> GetPriorities()
        {
            List<Priority> priorities = new List<Priority>();

            using (var DataWrapper = new DataWrapper())
            {
                var reader = DataWrapper.Query("GetPriorities");

                while (reader.Read())
                {
                    priorities.Add(
                        new Priority()
                        {
                            PriorityId = (int)reader["PriorityId"],
                            PriorityName = (string)reader["PriorityName"]
                        });
                }
            }

            return priorities;
        }

        /// <summary>
        /// Get all request types
        /// </summary>
        /// <returns></returns>
        public static List<RequestType> GetRequestTypes()
        {
            List<RequestType> requestTypes = new List<RequestType>();

            using (var DataWrapper = new DataWrapper())
            {
                var reader = DataWrapper.Query("GetRequestTypes");

                while (reader.Read())
                {
                    requestTypes.Add(
                        new RequestType()
                        {
                            RequestTypeId = (int)reader["RequestTypeId"],
                            RequestTypeName = (string)reader["RequestTypeName"]
                        });
                }
            }

            return requestTypes;
        }

        /// <summary>
        /// Get Request Statuses
        /// </summary>
        /// <returns></returns>
        public static List<Status> GetStatuses()
        {
            List<Status> statuses = new List<Status>();

            using (var DataWrapper = new DataWrapper())
            {
                var reader = DataWrapper.Query("GetStatuses");

                while (reader.Read())
                {
                    statuses.Add(
                        new Status()
                        {
                            StatusId = (int)reader["StatusId"],
                            StatusName = (string)reader["StatusName"]
                        });
                }
            }

            return statuses;
        }

        // Almost works. It does return multiple result sets but I'm not sure how to differentiate in dropdowns
        //public static List<DropDownData> GetDropDownData()
        //{
        //    List<DropDownData> departments = new List<DropDownData>();
        //    List<DropDownData> priorities = new List<DropDownData>();
        //    List<DropDownData> col = new List<DropDownData>();

        //    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SystemUsers"].ToString()))
        //    {
        //        connection.Open();

        //        SqlCommand cmd = new SqlCommand("GetDropDownData", connection);
        //        cmd.CommandType = CommandType.StoredProcedure;
                
        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {

        //            while (reader.Read())
        //            {
        //                departments.Add(
        //                    new DropDownData()
        //                    {
        //                        DepartmentId = (int)reader["DepartmentId"],
        //                        DepartmentName = (string)reader["DepartmentName"]
        //                    });
        //            }                    

        //            reader.NextResult();

        //            while (reader.Read())
        //            {
        //                priorities.Add(
        //                    new DropDownData()
        //                    {
        //                        PriorityId = (int)reader["PriorityId"],
        //                        PriorityName = (string)reader["PriorityName"]
        //                    });
        //            }
        //        }
        //    }

        //    col.AddRange(departments);
        //    col.AddRange(priorities);
        //    return col;

        //}
    }
}