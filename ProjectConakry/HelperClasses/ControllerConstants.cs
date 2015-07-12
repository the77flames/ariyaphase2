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
        public const string sender = "olufunmi@ariyaunlimited.com";
        public const string senderName = "Olufunmilayo Abidemi";
        public static string content = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'> <html xmlns='http://www.w3.org/1999/xhtml'> <head> <meta name='viewport' content='width=device-width' /> <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /> <title>Welcome to Ariya Email</title> <link href='styles.css' media='all' rel='stylesheet' type='text/css' /> </head>  <body itemscope itemtype='http://schema.org/EmailMessage'>  <table class='body-wrap'> 	<tr> 		<td></td> 		<td class='container' width='600'> 			<div class='content'> 				<table class='main' width='100%' cellpadding='0' cellspacing='0' itemprop='action' itemscope itemtype='http://schema.org/ConfirmAction'> 					<tr> 						<td class='content-wrap'> 							<meta itemprop='name' content='Confirm Email'/> 							<table width='100%' cellpadding='0' cellspacing='0'> 								<tr> 									<td class='content-block'>                                         <img src='http://ariyaunlimited.com/images/logo-md-clr.png' style='border:0px; max-width: 406px;' />                                     </td> 								</tr> 								<tr> 									<td class='content-block'> 										Welcome to Ariya ";
        public static string emailSubject= "Welcome to Ariya Unlimited!";
        public const string emailInUse = "Email is already in use.";
        public const string missingRequiredFields = "Fill in all fields and agree to terms";
        public const string mailGunApiKey = "key-3a59b9f5b97d1b982cc32c2e2ea7e5c7";
        public static string content2 = "! 									</td> 								</tr> 								<tr>                                     <td class='content-block'>                                         Ariya is the African entertainment hub that showcases exciting movies and web series.                                         Relax and enjoy !                                         <p style='Margin-top:0;color:#565656;font-family:Georgia,serif;font-size:16px;line-height:25px;Margin-bottom:25px;'>Don't forget to&nbsp;<a style='text-decoration:underline;transition:all .2s;color:#41637e;' href='http://ariya.cmail1.com/t/i-fb-jtlhtry-l-y/' rel='cs_facebox' target='_blank' class=''><img style='border:0;-ms-interpolation-mode:bicubic;' src='https://img.createsend1.com/img/social/fblike.png' border='0' title='Like this on Facebook' alt='Facebook Like   Button' width='51' height='20' /></a>&nbsp;us on facebook !</p>                                     </td> 								</tr> 								<tr> 									<td class='content-block'> 										&mdash; Olufunmilayo Abidemi 									</td> 								</tr> 							</table> 						</td> 					</tr> 				</table> 				<div class='footer'> 					<table width='100%'> 						<tr> 							<td class='aligncenter content-block'>Follow <a href='http://twitter.com/ariyafrica'>@ariyafrica</a> on Twitter.</td> 						</tr> 					</table> 				</div></div> 		</td> 		<td></td> 	</tr> </table>  </body> </html>";
}
}