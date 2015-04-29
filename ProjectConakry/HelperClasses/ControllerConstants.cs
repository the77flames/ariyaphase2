using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ProjectConakry.Web.Ariya
{
    public class ControllerConstants
    {
        private static string imagePath;
        public static string ImagePath
        {
            get
            {
                if (imagePath == null)
                    imagePath = ConfigurationManager.AppSettings["baseImagePath"].ToString();
                return imagePath;
            }
            set { imagePath = value; }
        }

        public const string sender = "tracyporter@ariyaunlimited.com";
        public const string senderName = "Tracy Porter";
        public static string content = "Welcome";
        public static string emailSubject= "Welcome";
    }
}