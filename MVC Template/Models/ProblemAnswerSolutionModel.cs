using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Template.Models
{
    public partial class ProblemAnswerSolutionModel
    {
        public Problem Problem { get; set; }
        public ProblemAnswer ProblemAnswer { get; set; }
    }
}