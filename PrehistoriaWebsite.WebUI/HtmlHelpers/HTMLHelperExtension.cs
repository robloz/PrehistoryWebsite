using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PrehistoryWebsite.Domain;
using PrehistoryWebsite.Infrastructure.Identity;
using PrehistoryWebsite.Models;




namespace PrehistoryWebsite.HtmlHelpers
{
    public static class HTMLHelperExtension
    {

        public static MvcHtmlString DisplayNewsSearchSummary(this HtmlHelper htmlHelper, string input, int requiredLength, string ending = "...")
        {
            string outputtext = input;

            // Validate and sanity check first...
            if (input.Length > requiredLength)
            {
                var requiredtext = input.Substring(0, requiredLength - 1);

                outputtext = string.Concat(requiredtext.Substring(0, requiredtext.LastIndexOf(' ')), ending);
            }

            return new MvcHtmlString(outputtext);
        }

        public static HtmlString LoopWithSeparator(this HtmlHelper helper, string separator, IEnumerable<object> items)
        {
            return new HtmlString
                  (helper.Raw(string.Join(separator, items)).ToHtmlString());
        }

        public static MvcHtmlString SetTitleAdminSection(this HtmlHelper html, string title)
        {
            StringBuilder result = new StringBuilder();

            result.Append("<div class='row'>");
            result.Append("<div class='col-lg-12'>");
            result.Append("<h1 class='page-header'>"+title+"</h1>");
            result.Append("</div></div>");


            return MvcHtmlString.Create(result.ToString());
        }

        public static String GetStyleMenu(this HtmlHelper html, IEnumerable<PrehistoryWebsite.Domain.Menu> menu)
        {
            MenuProperties menuProperties;
            String style;

            if (menu.Count() != 0)
            {
                menuProperties = menu.ToList()[0].tbl_menuProperties;
            }
            else
            {
                menuProperties = new MenuProperties();
            }

            style = "style=\"font-size:" + menuProperties.fontSize + "px; padding:" + menuProperties.height + "px " + menuProperties.width + "px;\"";

            return style;
        }

        public static String SetImgPost(this HtmlHelper html, Post post)
        {
            StringBuilder result = new StringBuilder();

            if (post.urlImg != null && post.urlImg!="")
            {
                return post.urlImg;
            }
            else
            {
                return @"~\Content\themes\htmlprehistory\images\post.png";
            }

        }

        public static MvcHtmlString SetSubTitleAdminSection(this HtmlHelper html, string title)
        {
            StringBuilder result = new StringBuilder();

            result.Append("<div class='row'>");
            result.Append("<div class='col-lg-12'>");
            result.Append("<h3 class='page-header'>" + title + "</h3>");
            result.Append("</div></div>");


            return MvcHtmlString.Create(result.ToString());
        }



        public static MvcHtmlString GetDate(this HtmlHelper html, DateTime? date){

            StringBuilder result = new StringBuilder();

            if(date.HasValue)
                result.Append( date.Value.ToString("dd/MM/yyyy") );

            return MvcHtmlString.Create(result.ToString());

        }



        public static MvcHtmlString ShowTag(this HtmlHelper html, ICollection<Tag> tags, int lengthString)
        {

            StringBuilder result = new StringBuilder();
            bool finish=false;
            
            for (int i = 0; i < tags.Count && finish == false; i++)
            {
                if (result.Length + tags.ElementAt(i).nameTag.Length < lengthString)
                {
                    result.Append("<span>" + tags.ElementAt(i).nameTag + "</span>");
                }
                else
                {
                    finish = true;
                }

            }

            return MvcHtmlString.Create(result.ToString());

        }

        public static MvcHtmlString ShowMessages(this HtmlHelper html, bool isValid, string SucceededMessage)
        {
            StringBuilder result = new StringBuilder();
            
            

                            if(isValid==false){

                                result.Append("<div class='alert alert-danger'>");
                                result.Append(System.Web.Mvc.Html.ValidationExtensions.ValidationSummary(html).ToString());
                                result.Append("</div>");

                            }
                            if (SucceededMessage !=null && SucceededMessage != "")
                            {
                                result.Append("<div class='alert alert-success'>");
                                result.Append(SucceededMessage);
                                result.Append("</div>");
                            }
            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString PageLinks(this HtmlHelper html, PostInfo postInfo, int limit, Func<int, string>PageUrl)
        {

            if (postInfo.TotalItems <= postInfo.ItemPerPage)
            {
                return MvcHtmlString.Empty;
            }
            else 
            {
                StringBuilder result = new StringBuilder();
                TagBuilder tagPrevious = new TagBuilder("span");
                TagBuilder tagPreviousName = new TagBuilder("a");
                TagBuilder tagNext = new TagBuilder("span");
                TagBuilder tagNextName = new TagBuilder("a");

                tagPreviousName.MergeAttribute("href", PageUrl(postInfo.CurrentPage-1));
                tagNextName.MergeAttribute("href", PageUrl(postInfo.CurrentPage + 1));

                tagPreviousName.InnerHtml = "<";
                tagNextName.InnerHtml = ">";

                result.Append("<div class='pagination'>");

                // first
                TagBuilder tagFirs = new TagBuilder("a");
                tagFirs.MergeAttribute("href", PageUrl(1));
                tagFirs.InnerHtml = "Primero";
                result.Append(tagFirs.ToString());

                // previous
                if (postInfo.CurrentPage == 1)
                {
                    tagPrevious.AddCssClass("disabled");
                    tagPrevious.InnerHtml = "<";
                }
                else
                {
                    tagPrevious.InnerHtml = tagPreviousName.ToString();
                   
                }
                result.Append(tagPrevious.ToString());

                // loop post

                if (postInfo.TotalPages <= limit)
                {
                    for (int i = 1; i <= postInfo.TotalPages; i++)
                    {
                        TagBuilder tagNumberPage;

                        if (postInfo.CurrentPage != i)
                        {
                            tagNumberPage = new TagBuilder("a");
                            tagNumberPage.MergeAttribute("href", PageUrl(i));
                        }
                        else
                        {
                            tagNumberPage = new TagBuilder("span");
                            tagNumberPage.AddCssClass("current");
                        }
                        tagNumberPage.InnerHtml = i.ToString();
                        result.Append(tagNumberPage.ToString());
                        //if (postInfo.TotalPages <= limit)

                    }
                }
                else
                {
                    int limit_min, limit_max;

                    if (postInfo.CurrentPage < limit)
                    {
                        limit_min = 1;
                        limit_max = limit;
                    }
                    else if (postInfo.CurrentPage + limit / 2 > postInfo.TotalPages)
                    {
                        limit_min = postInfo.CurrentPage - limit;
                        limit_max = postInfo.TotalPages;
                    }
                    else
                    {
                        limit_min = postInfo.CurrentPage - limit / 2;
                        limit_max = postInfo.CurrentPage + limit / 2;
                    }

                    for (int i = limit_min; i <= limit_max; i++)
                    {
                        TagBuilder tagNumberPage;

                        if (postInfo.CurrentPage != i)
                        {
                            tagNumberPage = new TagBuilder("a");
                            tagNumberPage.MergeAttribute("href", PageUrl(i));
                        }
                        else
                        {
                            tagNumberPage = new TagBuilder("span");
                            tagNumberPage.AddCssClass("current");
                        }
                        tagNumberPage.InnerHtml = i.ToString();
                        result.Append(tagNumberPage.ToString());
                        //if (postInfo.TotalPages <= limit)

                    }
                }


                    // next
                    if (postInfo.CurrentPage == postInfo.TotalPages)
                    {
                        tagNext.AddCssClass("disabled");
                        tagNext.InnerHtml = ">";
                    }
                    else
                    {
                        tagNext.InnerHtml = tagNextName.ToString();
                    }
                result.Append(tagNext.ToString());

                // last
                TagBuilder tagLast = new TagBuilder("a");
                tagLast.MergeAttribute("href", PageUrl(postInfo.TotalPages));
                tagLast.InnerHtml = "Ultimo";
                result.Append(tagLast.ToString());


                result.Append("</div>");

                return MvcHtmlString.Create(result.ToString());
            }
            /*
<div class="megas512">
    <span class="disabled">« Previous</span>
    <span class="current">1</span>
    <a href="?page=2">2</a>
    <a href="?page=3">3</a>
    <a href="?page=4">4</a>
    <a href="?page=5">5</a>
    <a href="?page=6">6</a>
    <a href="?page=7">7</a>
    ...
    <a href="?page=199">199</a>
    <a href="?page=200">200</a>
    <a class="next" href="?page=2">Next »</a>
</div>
             * */
            

            

        }

    }
}