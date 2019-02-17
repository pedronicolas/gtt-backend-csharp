using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GttApiWeb.Models
{
     public class Control
    {
         public int status { get; set; }
         public string comment { get; set; }
         public string jwt { get; set; }
        public long id_user { get; set; }
        public int role { get; set; }

        public Control(int status, string comment,string jwt,long id_user,int role)
        {
            this.status = status;
            this.comment = comment;
            this.jwt = jwt;
            this.id_user = id_user;
            this.role = role;
          
        }
        public Control(int status,string comment)
        {
            this.status = status;
            this.comment = comment;
        }
    }
    
}
