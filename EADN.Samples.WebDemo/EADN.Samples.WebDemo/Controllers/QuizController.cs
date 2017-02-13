using EADN.Samples.WebDemo.Filters;
using EADN.Samples.WebDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EADN.Samples.WebDemo.Controllers
{
    [MyActionFilter]
    public class QuizController : Controller
    {
        private static List<QuizViewModel> QuizCollection = new List<QuizViewModel>()
        {
            new QuizViewModel {Id= Guid.NewGuid(), Name ="Quiz A", Description = "Quiz A Description" },
            new QuizViewModel {Id= Guid.NewGuid(), Name ="Quiz B", Description = "Quiz B Description" },
            new QuizViewModel {Id= Guid.NewGuid(), Name ="Quiz C", Description = "Quiz C Description" },
            new QuizViewModel {Id= Guid.NewGuid(), Name ="Quiz D", Description = "Quiz D Description" }
        };

        // GET: Quiz
        public ActionResult Index()
        {
            // WebViewPage Elemente auslesen
            string serverPath = Server.MapPath("App_Data");
            var httpRequest = Request;

            return View(QuizCollection);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(QuizViewModel quiz) // FormCollection data)
        {
            quiz.Id = Guid.NewGuid();
            QuizCollection.Add(quiz);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            Guid quizId;
            if(Guid.TryParse(id, out quizId))
            {
                QuizViewModel quiz = QuizCollection.Single(quizItem => quizItem.Id == quizId);
                return View(quiz);
            }
            else
            {
                try
                {
                    HttpContext.Application.Lock();
                    HttpContext.Application["Test1"] = "Data1";
                    HttpContext.Application["Test2"] = "Data2";

                    // Do something...
                    // HttpContext.Session. -> Extension Method schreiben

                    return View("");
                }
                finally
                {
                    HttpContext.Application.UnLock(); // Unlock nach Lock nie vergessen !
                }
            }
        }

        [HttpPost]
        public ActionResult Edit(QuizViewModel quiz) // FormCollection data)
        {
            QuizViewModel quizUpdate = QuizCollection.Single(quizItem => quizItem.Id == quiz.Id);
            quizUpdate.Name = quiz.Name;
            quizUpdate.Description = quiz.Description;

            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            // TODO
            throw new NotImplementedException();
        }

        //In die Verarbeitung des Controllers eingreifen
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }
        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
    }
}