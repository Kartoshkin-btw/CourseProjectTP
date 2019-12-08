using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Course_progect_TP.Models
{
    public class Role
    {
        [Key]
        public int Id_Role { get; set; }
        public string Name { get; set; }
    }
}