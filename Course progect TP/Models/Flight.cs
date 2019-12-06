using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Course_progect_TP.Models.DAO;

namespace Course_progect_TP.Models
{
    public class Flight
    {
        RouteDAO routeDAO = new RouteDAO();
        UserDAO userDAO = new UserDAO();
        TransportDAO transportDAO = new TransportDAO();
        [Key]
        public int Id_Flight { get; set; }
        public string Flight_date { get; set; }
        public string Start_time { get; set; }
        public string End_time { get; set; }
        public int Id_Route { get; set; }
        public int Id_Driver { get; set; }
        public int Id_Conductor { get; set; }
        public int Id_Transport { get; set; }
        public string GetRouteNumber
        {
            get
            {
                string RouteNumber = routeDAO.GetRouteNumber(Id_Route);
                return RouteNumber;
            }
            set { }
        }
        public string GetConductorName
        {
            get
            {
                string Name = userDAO.GetUserName(Id_Conductor);
                return Name;
            }
            set { }
        }
        public string GetDriverName
        {
            get
            {
                string Name = userDAO.GetUserName(Id_Driver);
                return Name;
            }
            set { }
        }
        public string GetTransport
        {
            get
            {
                string TransportNumber = transportDAO.GetTransport(Id_Transport);
                return TransportNumber;
            }
            set { 
            }
        }
    }
}