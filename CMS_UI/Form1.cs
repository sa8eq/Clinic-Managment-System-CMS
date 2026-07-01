using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
namespace CMS_UI
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
            // 1. إنشاء كائن إدارة الألوان
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            // 2. اختيار النمط (فاتح Light أو داكن Dark)
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // 3. تحديد درجات الألوان (تغيير اللون الأزرق هنا)
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Green800,       // لون الشريط العلوي الأساسي (Header)
                Primary.Green900,       // لون شريط الحالة العلوي الصغير (Status Bar)
                Primary.Green500,       // لون الشريط عند الضغط أو التحديد
                Accent.Green400,        // لون الأزرار التفاعلية العائمة والـ Actions
                TextShade.WHITE         // لون نصوص العناوين (أبيض)
                );
        }

        
    }
}
