using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkRequests.BO;
using WorkRequests.Models;

namespace WorkRequests.DAL
{
    public class UserRoles
    {        

        public static List<UserRole> GetUserRoles()
        {
            List<UserRole> roles = new List<UserRole>();

            using (var DataWrapper = new DataWrapper())
            {
                var reader = DataWrapper.Query("GetUserRoles");

                while (reader.Read())
                {
                    roles.Add(
                        new UserRole()
                        {
                            UserRoleId = (string)reader["id"],
                            UserRoleName = (string)reader["Name"]
                        });
                }
            }

            return roles;

        }
    }
}