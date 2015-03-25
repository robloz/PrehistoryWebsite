using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PrehistoryWebsite.Helpers
{
    static public class Tools
    {
        public static string GetViewFile(string file)
        {
            string src = "";
            string ext = System.IO.Path.GetExtension(file);

            ext = ext.ToLower();

            if (ext == ".jpg" || ext == ".jegp" || ext == ".png" || ext == ".bmp" || ext == ".gif")
            {
                src = file;
            }
            else
            {
                src = @"~\Content\themes\htmlprehistory\images\unknowFile.png";
            }

            return src;

        }

        public static string GetDirectory(string file)
        {
            return Path.GetDirectoryName(file).Replace(@"~\Uploads\", "");
        }

    }
}