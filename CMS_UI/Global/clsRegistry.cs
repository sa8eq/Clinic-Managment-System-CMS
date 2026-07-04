using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CMS_UI.Global
{
    public class clsRegistry
    {
        public static void SaveCredentialsToRegistry(string username, string password)
        {
            try
            {
                string registryPath = @"SOFTWARE\CMS";

                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(registryPath))
                {
                    if (key != null)
                    {
                        key.SetValue("SavedUsername", username);
                        key.SetValue("SavedPassword", password); // ⚠️ انظر النصيحة الأمنية بالأسفل
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static Dictionary<string, string> GetCredentialFromRegistry()
        {
            Dictionary<string, string> credentials = new Dictionary<string, string>();
            string registryPath = @"SOFTWARE\CMS";
            try
            {
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(registryPath))
                {
                    if (key != null)
                    {
                        string username = key.GetValue("SavedUsername")?.ToString() ?? "";
                        string password = key.GetValue("SavedPassword")?.ToString() ?? "";
                        credentials.Add("Username", username);
                        credentials.Add("Password", password);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("حدث خطأ أثناء قراءة البيانات من الريجستري: " + ex.Message);
            }
            return credentials;
        }
        public static void ClearCredentialsFromRegistry()
        {
            string registryPath = @"SOFTWARE\CMS";

            try
            {
                // فتح المسار مع تمرير true للسماح بالكتابة والتعديل (Writable)
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(registryPath, true))
                {
                    if (key != null)
                    {
                        // مسح القيم المحددة
                        // البارامتر الثاني (false) يمنع حدوث خطأ إذا لم تكن القيم موجودة أصلاً في الريجستري
                        key.DeleteValue("SavedUsername", false);
                        key.DeleteValue("SavedPassword", false);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("حدث خطأ أثناء مسح البيانات من الريجستري: " + ex.Message);
            }
        }
    }
}
