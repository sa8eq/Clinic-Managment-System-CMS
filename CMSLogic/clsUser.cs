using System;
using System.Data;
using CMSData;

namespace CMSLogic
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public int RoleID { get; set; }
        public bool IsActive { get; set; }

        public clsPerson PersonInfo { get; set; }
        public clsRole UserRole { get; private set; }
     
        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.Username = "";
            this.PasswordHash = "";
            this.RoleID = -1;
            this.IsActive = true;

            this.PersonInfo = new clsPerson();
            this.UserRole = new clsRole();
            Mode = enMode.AddNew;
        }

        private clsUser(int UserID, int PersonID, string Username, string PasswordHash, int RoleID, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.Username = Username;
            this.PasswordHash = PasswordHash;
            this.RoleID = RoleID;
            this.IsActive = IsActive;

            this.PersonInfo = clsPerson.Find(PersonID);
            this.UserRole = clsRole.Find(RoleID);
            Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUsersData.AddNewUser(this.PersonID, this.Username, this.PasswordHash, this.RoleID, this.IsActive);
            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUsersData.UpdateUser(this.UserID, this.PersonID, this.Username, this.PasswordHash, this.RoleID, this.IsActive);
        }

        public static clsUser Find(int UserID)
        {
            int PersonID = -1, RoleID = -1;
            string Username = "", PasswordHash = "";
            bool IsActive = true;

            bool isFound = clsUsersData.GetUserByID(UserID, ref PersonID, ref Username, ref PasswordHash, ref RoleID, ref IsActive);

            if (isFound)
                return new clsUser(UserID, PersonID, Username, PasswordHash, RoleID, IsActive);
            else
                return null;
        }

        public bool Save()
        {
            if (!this.PersonInfo.Save())
            {
                return false; 
            }

            this.PersonID = this.PersonInfo.PersonID;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateUser();
            }
            return false;
        }

        public static bool Delete(int UserID)
        {
            return clsUsersData.DeleteUser(UserID);
        }

        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
        }

        public static clsUser FindByUsername(string Username)
        {
            int UserID = -1;
            int PersonID = -1;
            int RoleID = -1;
            string PasswordHash = "";
            bool IsActive = true;

            bool IsFound = clsUsersData.GetUserByUsername(Username,
                                                          ref UserID,
                                                          ref PersonID,
                                                          ref PasswordHash,
                                                          ref RoleID,
                                                          ref IsActive);

            if (IsFound)
                return new clsUser(UserID,
                                   PersonID,
                                   Username,
                                   PasswordHash,
                                   RoleID,
                                   IsActive);
            else
                return null;
        }

        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1;
            int RoleID = -1;
            string Username = "";
            string PasswordHash = "";
            bool IsActive = true;

            bool IsFound = clsUsersData.GetUserByPersonID(PersonID,
                                                          ref UserID,
                                                          ref Username,
                                                          ref PasswordHash,
                                                          ref RoleID,
                                                          ref IsActive);

            if (IsFound)
                return new clsUser(UserID,
                                   PersonID,
                                   Username,
                                   PasswordHash,
                                   RoleID,
                                   IsActive);
            else
                return null;
        }

        public static bool ExistsByUsername(string Username)
        {
            return clsUsersData.IsUserExistsByUsername(Username);
        }

        public static bool ExistsByPersonID(int PersonID)
        {
            return clsUsersData.IsUserExistsByPersonID(PersonID);
        }
    }
}
