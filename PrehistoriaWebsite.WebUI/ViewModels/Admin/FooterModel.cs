using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrehistoryWebsite.Domain;

namespace PrehistoryWebsite.Models.Admin
{
    public class FooterModel
    {
        public int Id { get; set; }
        public string title1 { get; set; }
        public string title2 { get; set; }
        public string title3 { get; set; }
        [AllowHtml]
        public string content1 { get; set; }
        [AllowHtml]
        public string content2 { get; set; }

        public void SetFooter(Footer footer)
        {
            this.Id = footer.Id;
            this.title1 = footer.title1;
            this.title2 = footer.title2;
            this.title3 = footer.title3;
            this.content1 = footer.content1;
            this.content2 = footer.content2;
        }

		// get domain footer model from view footer model
        public Footer GetFooter()
        {
            Footer footer = new Footer
            {
                Id = this.Id,
                title1 = this.title1,
                title2 = this.title2,
                title3 = this.title3,
                content1 = this.content1,
                content2 = this.content2
            };

            return footer;
        }
    }
}