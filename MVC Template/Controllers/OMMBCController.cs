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
            
            return View("StudentQuestionBank");
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
                DeletedBy = null, DeletedDate = null
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
                //Drop

                
             
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
                string query = "INSERT INTO Problems VALUES(@ProblemID, @TopicID, @Name, @Description, @CreatedBy, @CreatedDate, @UpdatedBy, @UpdatedDate, @DeletedBy, @DeletedDate, @Solution, @Level)";
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
