using System;
using System.Data;
using CMSData;

namespace CMSLogic
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        // الخصائص الخاصة بجدول المستخدمين
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public int RoleID { get; set; }
        public bool IsActive { get; set; }

        // الـ Composition: كائن كامل من كلاس الأشخاص مركب داخل كلاس المستخدم
        public clsPerson PersonInfo { get; set; }

        // 1. المشيد الافتراضي - لحالة إضافة مستخدم جديد
        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.Username = "";
            this.PasswordHash = "";
            this.RoleID = -1;
            this.IsActive = true;

            // تهيئة كائن الشخص ليكون جاهزاً لاستقبال البيانات الشخصية من واجهة المستخدم
            this.PersonInfo = new clsPerson();

            Mode = enMode.AddNew;
        }

        // 2. المشيد الخاص - لحالة جلب بيانات مستخدم موجود مسبقاً
        private clsUser(int UserID, int PersonID, string Username, string PasswordHash, int RoleID, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.Username = Username;
            this.PasswordHash = PasswordHash;
            this.RoleID = RoleID;
            this.IsActive = IsActive;

            // جلب بيانات الشخص التابع لهذا المستخدم بذكاء من كلاس البزنس الخاص بالأشخاص
            this.PersonInfo = clsPerson.Find(PersonID);

            Mode = enMode.Update;
        }

        // دالة داخلية لإضافة المستخدم فقط لجدول Users
        private bool _AddNewUser()
        {
            this.UserID = clsUsersData.AddNewUser(this.PersonID, this.Username, this.PasswordHash, this.RoleID, this.IsActive);
            return (this.UserID != -1);
        }

        // دالة داخلية لتعديل المستخدم فقط في جدول Users
        private bool _UpdateUser()
        {
            return clsUsersData.UpdateUser(this.UserID, this.PersonID, this.Username, this.PasswordHash, this.RoleID, this.IsActive);
        }

        // البحث عن مستخدم بواسطة الـ ID
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

        // حفظ البيانات (حفظ الشخص أولاً، ثم ربطه بالمستخدم وحفظه)
        public bool Save()
        {
            // الخطوة 1: حفظ بيانات الشخص التابع للمستخدم أولاً
            // كائن الـ PersonInfo سيتولى داخلياً معرفة حالته (إضافة أم تعديل) ويقوم بالحفظ
            if (!this.PersonInfo.Save())
            {
                return false; // إذا حدثت مشكلة في حفظ بيانات الشخص، يتوقف أمر الحفظ فوراً حمايةً للبيانات
            }

            // الخطوة 2: بعد نجاح حفظ الشخص، نأخذ الـ PersonID المولد تلقائياً ونربطه بالمستخدم
            this.PersonID = this.PersonInfo.PersonID;

            // الخطوة 3: حفظ بيانات المستخدم الآن بناءً على الـ Mode
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

        // حذف المستخدم
        public static bool Delete(int UserID)
        {
            return clsUsersData.DeleteUser(UserID);
        }

        // جلب قائمة المستخدمين الشاملة بالأسماء من الـ View
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
