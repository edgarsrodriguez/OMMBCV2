using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Template.Models
{
    public class ProblemRepository
    {
        private OMMBCdb db = new OMMBCdb();

        // Query Methods
        public IQueryable<Problem> FindAllProblems()
        {
            return db.Problems;
        }
        public Problem GetProblem(int id)
        {
            return db.Problems.SingleOrDefault(p => p.ProblemID == id);
        }

        // Insert/Delete
        public void Add(Problem problem)
        {
            db.Problems.Add(problem);
        }
        public void Delete(Problem problem)
        {
            db.Problems.Remove(problem);
        }

        // Persistence
        public void Save()
        {
            db.SaveChanges();
        }
    }
}