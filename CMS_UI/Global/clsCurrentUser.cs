using CMSLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_UI.Global
{
    public class clsCurrentUser
    {
        public static clsUser CurrentUser { get; set; } = new clsUser();
        
    }
}
