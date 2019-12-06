using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Course_progect_TP.Models
{
    public class Route
    {
        [Key]
        public int Id_Route { get; set; }
        public string RouteNumber { get; set; }
        public string Start_stop { get; set; }
        public string Final_stop { get; set; }
        public int Price { get; set; }
        public string Travel_time { get; set; }
        public int Route_state { get; set; }
        public string GetState
        {
            get
            {
                String State;
                if (Route_state == 1)
                {
                    State = "Accepted";
                }
                else
                {
                    State = "Not accepted";
                }
                return State;
            }
            set { }
        }
    }
}