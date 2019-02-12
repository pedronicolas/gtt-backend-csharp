using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GttApiWeb.Models
{
    public enum Issue { explotacion};
    public class Jira
    {
        public long id { get; set; }
        public string username { get; set; }
        public string pass { get; set; }
        public string url { get; set; }
        public string proyect { get; set; }
        public string component { get; set; }
        public long user_id { get; set; }
        public string description { get; set; }
        public Issue issue_type { get; set; }




    }
}
