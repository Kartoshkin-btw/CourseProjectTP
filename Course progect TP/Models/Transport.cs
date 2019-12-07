using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Course_progect_TP.Models
{
    public class Transport
    {
        [Key]
        public int Id_Transport { get; set; }
        public string Model { get; set; }
        public string Number { get; set; }
        public string Release_year { get; set; }
        public int Transport_state { get; set; }
        public string GetTransportState
        {
            get
            {
                String state;
                if (Transport_state == 1)
                {
                    state = "Исправен";
                }
                else
                {
                    state = "На тех. обслуживании";
                }
                return state;
            }
            set { }
        }
    }
}