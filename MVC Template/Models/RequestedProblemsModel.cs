using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Template.Models
{
    public class RequestedProblemsModel
    {
        public List<Problem> SelectedProblems { get; set; }

        //public List<ProblemAnswer> RequestList { get; set; }
        public RequestedProblemsModel()
        {
            this.SelectedProblems = new List<Problem>();
            //this.RequestList = new List<ProblemAnswer>();
        }
        public IEnumerable<int> getSelectedProblems()
        {
            return (from p in this.SelectedProblems where p.Selected select p.ProblemID).ToList();
        }
    }
}