using MVC_Template.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

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

        // GET: OMMBC Problems ADMIN
        public ActionResult IndexQuestionBank()
        {
            var db = new OMMBCdb();
            User User = new User();
            //ViewBag.UserType = User.AccountTypeID;
            ViewBag.UserType = 1;
            return View(db.Problems);
        }

        // GET: OMMBC Problems STUDENT
        public ActionResult StudentQuestionBank()
        {
            var db = new OMMBCdb();
            User User = new User();
            //ViewBag.UserType = User.AccountTypeID;
            ViewBag.UserType = 1;
            return View(db.Problems);
        }

        // GET: OMMBC Request Problems STUDENT
        public ActionResult RequestProblem()
        {
            var db = new OMMBCdb();
            //var db = new OMMBCdb();
            //var mod = new ProblemRequested();
            foreach (var p in db.Problems)
            {
                var prob = new ProblemAnswer()
                {
                    ProblemAnswerID = db.ProblemAnswers.Count() + 1,
                    ProblemID = p.ProblemID,
                    StudentID = ViewBag.User,
                    Answer = null,
                    Attempt = 0,
                    TutorID = null,
                    Score = 0
                };
                db.ProblemAnswers.Add(prob);
            }
            return View(db.ProblemAnswers);
            //return View("StudentQuestionBank");
        }

        public ActionResult RequestProblem2()
        {
            var db = new OMMBCdb();
            //var db = new OMMBCdb();
            //var mod = new ProblemRequested();
            var selectedID = RequestedProblemsModel.getSelectedProblems();
            var selectedProbs = from x in db.Problems
                                where selectedID.Contains(x.ProblemID)
                                select x;
            foreach (var p in db.Problems)
            {
                var prob = new ProblemAnswer()
                {
                    ProblemAnswerID = db.ProblemAnswers.Count() + 1,
                    ProblemID = p.ProblemID,
                    StudentID = ViewBag.User,
                    Answer = null,
                    Attempt = 0,
                    TutorID = null,
                    Score = 0
                };
                db.ProblemAnswers.Add(prob);
            }
            return View(db.ProblemAnswers);
            //return View("StudentQuestionBank");
        }

        // POST: OMMBC View Requested Problems STUDENT
        [HttpPost]
        public ActionResult RequestProblem(ProblemAnswer pa)
        {
            var db = new OMMBCdb();
            ViewBag.UserType = 1;
      
            string OMMBCdbC = "Data Source=BRTZ-DESKTOP\\SQLEXPRESS;Initial Catalog=OMMBC2;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection sqlCon = new SqlConnection(OMMBCdbC))
            {
                sqlCon.Open();
                string query = "INSERT INTO Problems VALUES(@ProblemAnswerID, @ProblemID, @StudentID, @Answer, @Attempt, @TutorID, @Score)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ProblemAnswerID", pa.ProblemAnswerID);
                sqlCmd.Parameters.AddWithValue("@ProblemID", pa.ProblemID);
                sqlCmd.Parameters.AddWithValue("@StudentID", pa.StudentID);
                sqlCmd.Parameters.AddWithValue("@Answer", pa.Answer);
                sqlCmd.Parameters.AddWithValue("@Attempt", pa.Attempt);
                sqlCmd.Parameters.AddWithValue("@TutorID", pa.TutorID);
                sqlCmd.Parameters.AddWithValue("@Score", pa.Score);
       
                sqlCmd.ExecuteNonQuery();
            }

  //          return RedirectToAction("IndexQuestionBank");
            return View();
        }


        // GET: OMMBC/Details/5 ADMIN
        public ActionResult ProblemDetails(int id)
        {
            Problem problem = problemRepository.GetProblem(id);
            return View(problem);
        }

        // GET: OMMBC/Details/5 STUDENT
        public ActionResult StudentProblemDetails(int id)
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
                DeletedBy = null, DeletedDate = null, Selected = false
            };
            string OMMBCdbC = "Data Source=BRTZ-DESKTOP\\SQLEXPRESS;Initial Catalog=OMMBC2;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection sqlCon = new SqlConnection(OMMBCdbC))
            {
                sqlCon.Open();
                string query = "SELECT * FROM Topics";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                
                sqlCmd.ExecuteNonQuery();


            }

            return View(prob);
        }

        public static List<SelectListItem> GetDropDown()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            var db = new OMMBCdb();
            List<Topic> lm = db.Topics.ToList();
            foreach (var temp in lm)
            {
                ls.Add(new SelectListItem() { Text = temp.Name, Value = temp.AreaID.ToString() });
            }
            return ls;
        }

        // POST: OMMBC/Create
        [HttpPost]
        public ActionResult CreateProblem(Problem problm)
        {
            string OMMBCdbC ="Data Source=BRTZ-DESKTOP\\SQLEXPRESS;Initial Catalog=OMMBC2;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection sqlCon = new SqlConnection(OMMBCdbC))
            {
                sqlCon.Open();
                string query = "INSERT INTO Problems VALUES(@ProblemID, @TopicID, @Name, @Description, @CreatedBy, @CreatedDate, @UpdatedBy, @UpdatedDate, @DeletedBy, @DeletedDate, @Solution, @Level, @Selected)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ProblemID", problm.ProblemID);
                sqlCmd.Parameters.AddWithValue("@TopicID", problm.TopicID);
                sqlCmd.Parameters.AddWithValue("@Name", problm.Name);
                sqlCmd.Parameters.AddWithValue("@Description", problm.Description);
                sqlCmd.Parameters.AddWithValue("@CreatedBy", problm.CreatedBy);
                sqlCmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                sqlCmd.Parameters.AddWithValue("@UpdatedBy", problm.CreatedBy);
                sqlCmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
                sqlCmd.Parameters.AddWithValue("@DeletedBy", DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@DeletedDate", DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@Solution", problm.Solution);
                sqlCmd.Parameters.AddWithValue("@Level", problm.Level);
                sqlCmd.Parameters.AddWithValue("@Selected", false);
                sqlCmd.ExecuteNonQuery();


            }

            return RedirectToAction("IndexQuestionBank");

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
                problem.Solution = Request.Form["Solution"];
                problem.Level = Convert.ToInt32(Request.Form["Level"]);
                problem.Selected = false;
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
