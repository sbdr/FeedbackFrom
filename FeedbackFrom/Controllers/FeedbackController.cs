using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FeedbackFrom.Models;
using FeedbackFrom.Modules;

namespace FeedbackFrom.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Feedback
        public ActionResult Index()
        {
            FeedbackModels feedbackModels = new FeedbackModels();
            feedbackModels.Departments = new FeedbackFormModules().GetAllDepartment();
            return View(feedbackModels);
        }

        public ActionResult CreateFrom()
        {
            FeedbackModels feedbackModels = new FeedbackModels();
            feedbackModels.Departments = new FeedbackFormModules().GetAllDepartment();
            feedbackModels.Questions = new FeedbackFormModules().GetQuestionList();
            ViewBag.Title = "Create FeedBack From";
            return View(feedbackModels);
        }

        [HttpPost]
        public ActionResult CreateFrom(FeedbackModels feedbackModels)
        {
            if (!ModelState.IsValid)
            {
                feedbackModels.Departments = new FeedbackFormModules().GetAllDepartment();
                feedbackModels.Questions = new FeedbackFormModules().GetQuestionList();

            }
            else
            {
                int resultud = new FeedbackFormModules().SaveFeedBackFromCreation(feedbackModels);
            }

            return View(feedbackModels);
        }
    }
}