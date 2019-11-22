using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Course_progect_TP.Models
{
    public class Flight
    {
        [Key]
        public int Id_Flight { get; set; }
        public string Flight_date { get; set; }
        public string Start_time { get; set; }
        public string End_time { get; set; }
        public int Id_Route { get; set; }
        public int Id_Driver { get; set; }
        public int Id_Conductor { get; set; }
        public int Id_Transport { get; set; }
    }
}