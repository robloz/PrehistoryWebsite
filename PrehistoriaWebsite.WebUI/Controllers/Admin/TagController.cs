using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PrehistoryWebsite.Domain.Abstract;
using PrehistoryWebsite.Domain;
using PrehistoryWebsite.Domain.Concrete;
using PrehistoryWebsite.Models;
using PrehistoryWebsite.ViewModels.Admin;
using PrehistoryWebsite.Common;

namespace PrehistoryWebsite.Controllers
{
    [Authorize(Roles=RolesUsersSystem.roleAdmin+","+RolesUsersSystem.roleSuperAdmin+","+RolesUsersSystem.roleEditor)]
    public class TagController : Controller
    {
        IRepository _repository;

        public TagController(IRepository repository)
        {
            this._repository = repository;
        }

        // GET: /Tag/
        public ActionResult Index()
        {
            var error = TempData[TempDataStrings.errors] as string;
            var exitsMessage = TempData[TempDataStrings.exitsMessage] as string;

            if (exitsMessage != null && exitsMessage != null)
            {
                ViewBag.Succeeded = exitsMessage;
            }

            if (error != null && error!="")
            {
                ModelState.AddModelError("", error);
            }

            return View(_repository.Tags);
        }

        // GET: /Tag/slugTag
        public ActionResult Edit(string tagSlug)
        {
           var tag = _repository.Find(tagSlug);

           if (tag == null)
           {
               TempData[TempDataStrings.errors] = SystemMessages.ErrorElmentNoExist;
                return RedirectToAction("Index");
           }

            return View(tag);
        }

        [HttpPost]
        public ActionResult Edit(Tag model)
        {
            if (_repository.Find(model.id) != null)
            {
                // update his slug
                model.urlSlug = UrlSluggerGenerator.ToUrlSlug(model.nameTag);

                _repository.Save(model);

                TempData[TempDataStrings.exitsMessage] = SystemMessages.SuccessChange;
            }
            else
            {
                TempData[TempDataStrings.errors] = SystemMessages.ErrorElmentNoExist;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(string tagSlug)
        {
            var tag = _repository.Find(tagSlug);

            if (tag != null)
            {
                _repository.Delete(tag);
                TempData[TempDataStrings.exitsMessage] = SystemMessages.SuccessDelete;
            }
            else
            {
                TempData[TempDataStrings.errors] = SystemMessages.ErrorElmentNoExist;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Add(StringModel model)
        {
            var nameTag = model.St;
            var slug = UrlSluggerGenerator.ToUrlSlug(nameTag);
            var tag = _repository.Find(slug);

            if (tag == null)
            {
                var newTag = new Tag { nameTag = nameTag, urlSlug = slug };
                _repository.Save(newTag);

                TempData[TempDataStrings.exitsMessage] = SystemMessages.SuccessAdd;
            }
            else
            {
                TempData[TempDataStrings.errors] = SystemMessages.ErrorAddTagRepeat; // TempData keep the data durint the RedirectToAction
            }

            return RedirectToAction("Index");
        }
    }
}
