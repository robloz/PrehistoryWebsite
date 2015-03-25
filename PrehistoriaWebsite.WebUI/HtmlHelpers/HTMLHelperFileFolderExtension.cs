using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PrehistoryWebsite.HtmlHelpers
{
    public static class HTMLHelperFileFolderExtension
    {
        
        public static String GetImageFile(this HtmlHelper html, string file)
        {

            return Helpers.Tools.GetViewFile(file);

        }
        
    }
}