using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using PrehistoryWebsite.Domain;
using PrehistoryWebsite.Domain.Abstract;
using PrehistoryWebsite.Models;
using PrehistoryWebsite.Models.Admin;

namespace PrehistoryWebsite.Controllers.Admin
{
    [Authorize(Roles = RolesUsersSystem.roleAdmin + "," + RolesUsersSystem.roleSuperAdmin + "," + RolesUsersSystem.roleEditor)]
    public class FooterController : Controller
    {
        IRepository _repository;

        public FooterController(IRepository repository)
        {
            this._repository = repository;
        }

        // GET /Footer/
        public ActionResult Index(string SuccessMessage = "")
        {
            var model = new FooterModel();

            model.SetFooter(_repository.footer);

            ViewBag.Succeeded = SuccessMessage;

            return View(model);
        }

        // POST /Footer/Save
        [HttpPost]
        public ActionResult Save(FooterModel model)
        {
            var SuccessMessage = "";

            if (ModelState.IsValid)
            {
                _repository.Save(model.GetFooter());

                SuccessMessage = SystemMessages.SuccessAdd;
            }

            return RedirectToAction("Index", new { SuccessMessage = SuccessMessage });
        }

        // Partial View
        [AllowAnonymous]
        public ActionResult ShowFooter()
        {
            return PartialView(_repository.footer);
        }
    }
}
