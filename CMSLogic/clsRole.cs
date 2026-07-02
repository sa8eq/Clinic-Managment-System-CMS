using CMSData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLogic
{
    public class clsRole
    {
        public string RoleName { get; set; }
        public int RoleID { set; get; }
        public enum enRole
        {
            Administrator = 1,
            Receptionist = 2,
            Doctor = 3
        }
        public enRole Role
        {
            get
            {
                return (enRole)RoleID;
            }
        }
        public clsRole()
        {
            RoleName = "";
            RoleID = -1;
        }
        public clsRole(string rolename, int roleid)
        {
            RoleName = rolename;
            RoleID = roleid;
        }

        public static clsRole Find(int id)
        {
            string rolename = "";

            bool IsFound = clsRolesData.GetRoleByID(id, ref rolename);

            if(IsFound)
            {
                return new clsRole(rolename, id);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllRoles()
        {
            return clsRolesData.GetAllRoles();
        }

    }
}
