using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
namespace WebApp.Models
{
    public class UsersRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
       public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        public override string[] GetRolesForUser(string username)
        {
            using (ProductDBContext db = new ProductDBContext())
            {
                var userRoles = (from user in db.User_Web
                                 join roleMaping in db.UserRolesMappings
                                 on user.id_user equals roleMaping.UserID
                                 join role in db.RoleMasters
                                 on roleMaping.RoleID equals role.ID
                                 where user.ten_taikhoan == username
                                 select role.RollName).ToArray();
                return userRoles;
            }
        }
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}