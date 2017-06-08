using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyUtubeApp.Models
{
    public class CurrentSession
    {
        public static User CurrentUser
        {
            get
            {
                if(HttpContext.Current.Session["CurrentUser"]==null)
                {
                    Controllers.AccountsController.ResetCurrentSession();
                }
                return (User)HttpContext.Current.Session["CurrentUser"];
                        
            }
            set
            {
                HttpContext.Current.Session["CurrentUser"] = value;
            }
        }
    }
}