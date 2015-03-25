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
    public static class HTMLHelperExtensionUsersRoles
    {

        public static MvcHtmlString GetUserName(this HtmlHelper html, string id)
        {
            string userName = "";
            AppUserManager mgr = HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();

            try
            {
                userName = mgr.FindById(id).UserName;
            }
            catch
            {
                userName = SystemMessages.ErrorUnknowUser;
            }


            return new MvcHtmlString(userName);
        }

        public static List<string> ListAllRoles(this HtmlHelper html)
        {
            List<string> roles = new System.Collections.Generic.List<string>();

            AppRoleManager rolManager = HttpContext.Current.GetOwinContext().GetUserManager<AppRoleManager>();

            foreach (AppRole rol in rolManager.Roles)
            {

                roles.Add(rol.Name);
            }

            return roles;
        }

        public static MvcHtmlString OptionEditProfile(this HtmlHelper html, string userName, string idUser)
        {
            StringBuilder result = new StringBuilder();

            if (!(userName != HttpContext.Current.User.Identity.Name && HttpContext.Current.User.IsInRole(RolesUsersSystem.roleEditor)))
            {

                result.Append("<div class='row'>");
                result.Append("<div class='col-lg-12'>");
                result.Append("<p>");



                result.Append(System.Web.Mvc.Html.LinkExtensions.ActionLink(html, "Mi Perfil", "Profile", "Account", new { nameUser = userName }, new { @class = "btn btn-primary" }).ToHtmlString());
                result.Append(" ");
                result.Append(System.Web.Mvc.Html.LinkExtensions.ActionLink(html, "Editar", "ChangeProfile", "Account", new { id = idUser }, new { @class = "btn btn-primary" }).ToHtmlString());
                result.Append(" ");
                result.Append(System.Web.Mvc.Html.LinkExtensions.ActionLink(html, "Cambiar Contraseña", "ChangePassword", "Account", new { id = idUser }, new { @class = "btn btn-primary" }).ToHtmlString());

                if (HttpContext.Current.User.IsInRole(RolesUsersSystem.roleAdmin) || HttpContext.Current.User.IsInRole(RolesUsersSystem.roleSuperAdmin))
                {
                    result.Append(" ");
                    result.Append(System.Web.Mvc.Html.LinkExtensions.ActionLink(html, "Reset Contraseña", "ResetPassword", "Account", new { id = idUser }, new { @class = "btn btn-primary", onclick = "return confirm('" + SystemMessages.WarnningDelete + "');" }));
                    result.Append(" ");
                    result.Append(System.Web.Mvc.Html.LinkExtensions.ActionLink(html, "Cambiar Rol", "Change", "RoleAdmin", new { idUser = idUser }, new { @class = "btn btn-primary" }));
                    // you can not delete yourself
                    if (userName != HttpContext.Current.User.Identity.Name)
                    {
                        result.Append(" ");
                        result.Append(System.Web.Mvc.Html.LinkExtensions.ActionLink(html, "Eliminar", "Delete", "Account", new { id = idUser }, new { @class = "btn btn-primary", onclick = "return confirm('" + SystemMessages.WarnningDelete + "');" }));
                    }
                }

                result.Append("</p>");
                result.Append("</div>");
                result.Append("</div>");
            }


            return MvcHtmlString.Create(result.ToString());
        }

        public static bool IsCurrentUserAdminOrSuperAdmin(this HtmlHelper html)
        {
            if (HttpContext.Current.GetOwinContext().Authentication.User.IsInRole(RolesUsersSystem.roleAdmin) || HttpContext.Current.GetOwinContext().Authentication.User.IsInRole(RolesUsersSystem.roleSuperAdmin))
                return true;
            else
                return false;
        }

        public static bool IsCurrentUserVisitor(this HtmlHelper html)
        {
            if (HttpContext.Current.GetOwinContext().Authentication.User.IsInRole(RolesUsersSystem.roleVisitor))
                return true;
            else
                return false;
        }

        public static MvcHtmlString ShowRolesByUser(this HtmlHelper html, AppUser user)
        {

            StringBuilder result = new StringBuilder();

            AppUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();

            IList<string> roles = userManager.GetRoles(user.Id);

            foreach (string role in roles)
            {
                result.Append(role.ToString());
            }

            return MvcHtmlString.Create(result.ToString());

        }

        public static String ShowUrlImgUser(this HtmlHelper html)
        {
            AppUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            AppUser currentUser = userManager.FindByName(HttpContext.Current.User.Identity.Name);

            if(currentUser==null)
                return @"~/Content/themes/htmlprehistory/images/52.png";

            if (currentUser.urlNick != null && currentUser.urlNick != "")
                return currentUser.urlNick;
            else
                return @"~/Content/themes/htmlprehistory/images/52.png";
        }

        public static String ShowUrlImgUser(this HtmlHelper html, string IdUser)
        {
            AppUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            AppUser currentUser = userManager.FindById(IdUser);

            if (currentUser == null)
                return @"~/Content/themes/htmlprehistory/images/52.png";

            if (currentUser.urlNick != null && currentUser.urlNick != "")
                return currentUser.urlNick;
            else
                return @"~/Content/themes/htmlprehistory/images/52.png";
        }
    }
}