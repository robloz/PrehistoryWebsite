using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrehistoryWebsite.Domain;
using PrehistoryWebsite.Domain.Abstract;
using PrehistoryWebsite.Models;

namespace PrehistoryWebsite.Controllers.Admin
{
    [Authorize(Roles = RolesUsersSystem.roleAdmin + "," + RolesUsersSystem.roleSuperAdmin + "," + RolesUsersSystem.roleEditor)]
    public class MessageController : BaseController
    {
        IRepository _repository;

        public MessageController(IRepository repository)
        {
            this._repository = repository;
        }

        // GET: /Message/
        public ActionResult Index(string SuccessMessage = "")
        {

            ViewBag.Succeeded = SuccessMessage;

            return View(_repository.Messages);
        }

        // GET: /Message/Delete
        public ActionResult Delete(int id)
        {
            _repository.DeleteMessage(id);

            return RedirectToAction("Index", new { SuccessMessage = SystemMessages.SuccessDelete });
        }

        // GET: /Message/Details
        public ActionResult Details(int id)
        {
            Message message = _repository.FindMessage(id);

            if (message != null)
            {
                message.isRead = true;
                _repository.Save(message);

                return View(message);
            }
            else
            {
                ShowErrorModelState(SystemMessages.ErrorElmentNoExist);
                return View(_repository.Messages);
            }

        }

        // Post: /Message/MessageSend
        [HttpPost]
        public ActionResult MessageSend(MessageModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.CheckSpam == "" || model.CheckSpam == null)
                {

                    Message message = new Message
                    {
                        asunto = model.Asunto,
                        email = model.Email,
                        descriptionMessage = model.Message,
                        isRead = false,
                        dateSend = DateTime.Now
                    };

                    _repository.Save(message);

                }

                return PartialView(@"~\Views\Footer\Message.cshtml");
            }
            else
            {
                return PartialView(@"~\Views\Footer\Value", model);
            }
        }

        // GET: /Message/RecentMessages
        public ActionResult RecentMessages()
        {
            // I take up to 3 messages
            IEnumerable<Message> messagesUnread = _repository.Messages.Where(x => x.isRead == false).Take(3);

            return PartialView("_RecentMessages", messagesUnread);
        }

    }
}
