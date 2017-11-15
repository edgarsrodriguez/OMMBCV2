using MVC_Template.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace MVC_Template.Controllers
{
    public class OMMBCController : Controller
    { 
        ProblemRepository problemRepository = new ProblemRepository();
        // GET: OMMBC
        public ActionResult Index()
        {
            return View();
        }

        // GET: OMMBC Problems
        public ActionResult IndexQuestionBank()
        {
            var db = new OMMBCdb();
            User User = new User();
            //ViewBag.UserType = User.AccountTypeID;
            ViewBag.UserType = 1;
            return View(db.Problems);
        }

        // GET: OMMBC/Details/5
        public ActionResult ProblemDetails(int id)
        {
            Problem problem = problemRepository.GetProblem(id);
            return View(problem);
        }

        // GET: OMMBC/CreateProblem
        public ActionResult CreateProblem()
        {
            var db = new OMMBCdb();
            Problem prob = new Problem()
            {
                ProblemID = db.Problems.Count() + 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DeletedBy = null, DeletedDate = null
            };
            
            return View(prob);
        }

        // POST: OMMBC/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateProblem(Problem problm)
        {
            //Problem problem = new Problem();
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    UpdateModel(problm);
                    problemRepository.Add(problm);
                    problemRepository.Save();
                    return RedirectToAction("IndexQuestionBank");
                }
                catch
                {
                    return View(problm);
                }

            }

            return View(problm);
        }

        // GET: OMMBC/Edit/5
        public ActionResult EditProblem(int id)
        {
            Problem problem = problemRepository.GetProblem(id);
            return View(problem);
        }

        // POST: OMMBC/Edit/5
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditProblem(int id, FormCollection collection)
        { 
            Problem problem = problemRepository.GetProblem(id);
            try
            {
                // TODO: Add update logic here
                problem.ProblemID = problem.ProblemID;
                problem.TopicID = Convert.ToInt32(Request.Form["TopicId"]);
                problem.Name = Request.Form["Name"];
                problem.Description = Request.Form["Description"];
                problem.CreatedBy = problem.CreatedBy;
                problem.CreatedDate = problem.CreatedDate;
                problem.UpdatedBy = Convert.ToInt32(Request.Form["UpdatedBy"]);
                problem.UpdatedDate = DateTime.Now;
                problem.DeletedBy = null;
                problem.DeletedDate = null;
                problemRepository.Save();
                return RedirectToAction("IndexQuestionBank");
            }
            catch
            {
                return View();
            }
        }

        // GET: OMMBC/Delete/5
        public ActionResult DeleteProblem(int id)
        {
            Problem problem = problemRepository.GetProblem(id);
            if (problem == null)
                return View("NotFound");
            else
                return View(problem);
        }

        // POST: OMMBC/Delete/5
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteProblem(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Problem problem = problemRepository.GetProblem(id);
                if (problem == null)
                    return View("NotFound");

                problemRepository.Delete(problem);
                problemRepository.Save();
           
                return RedirectToAction("IndexQuestionBank");
            }
            catch
            {
                return View();
            }
        }
    }
}
