using EADN.Samples.WebDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EADN.Samples.WebDemo.Controllers
{
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
                // TODO: Send error msg to user
                throw new NotImplementedException();
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
    }
}