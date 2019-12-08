using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Course_progect_TP.Models.DAO;
using Course_progect_TP.Models;

namespace Course_progect_TP.Controllers
{
    public class HomeController : Controller
    {
        RouteDAO routeDAO = new RouteDAO();
        TransportDAO transportDAO = new TransportDAO();
        UserDAO userDAO = new UserDAO();
        FlightDAO flightDAO = new FlightDAO();
        RoleDAO roleDAO = new RoleDAO();
        public ActionResult Index()
        {
            return View("Index");
        }
        public ActionResult GetAllRoutes()
        {
            return View(routeDAO.GetAllRoutes());
        }
        [Authorize(Roles ="Admin")]
        public ActionResult CreateRoute()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRoute([Bind(Exclude = "Id_Route")] Route route)
        {
            try
            {
                if (routeDAO.CreateRoute(route))
                    return Redirect("GetAllRoutes");
                else
                    return View("CreateRoute");
            }
            catch
            {
                return View("CreateRoute");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult EditRoute(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditRoute(int id, Route route)
        {
            try
            {
                if (routeDAO.EditRoute(id, route))
                    return RedirectToAction("GetAllRoutes");
                else
                    return View("EditRoute");
            }
            catch 
            {
                return View("EditRoute");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteRoute(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteRoute(int id, Route route)
        {
            try
            {
                if (routeDAO.DeleteRoute(id))
                    return RedirectToAction("GetAllRoutes");
                else 
                    return View("DeleteRoute");
            }
            catch
            {
                return View("DeleteRoute");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult GetAllTransports()
        {
            return View(transportDAO.GetAllTransports());
        }
        [Authorize(Roles = "Admin")]
        public ActionResult CreateTransport()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTransport([Bind(Exclude = "Id_Transport")] Transport transport)
        {
            try
            {
                if (transportDAO.CreateTransport(transport))
                    return Redirect("GetAllTransports");
                else
                    return View("CreateTransport");
            }
            catch
            {
                return View("CreateTransport");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult EditTransport(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditTransport(int id, Transport transport)
        {
            try
            {
                if (transportDAO.EditTransport(id, transport))
                    return RedirectToAction("GetAllTransports");
                else
                    return View("EditTransport");
            }
            catch
            {
                return View("EditTransport");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteTransport(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteTransport(int id, Transport transport)
        {
            try
            {
                if (transportDAO.DeleteTransport(id))
                    return RedirectToAction("GetAllTransports");
                else
                    return View("DeleteTransport");
            }
            catch
            {
                return View("DeleteTransport");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult GetAllUsers()
        {
            return View(userDAO.GetAllUsers());
        }
        [Authorize(Roles = "Admin")]
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser([Bind(Exclude = "Id_User")] User user)
        {
            try
            {
                if (userDAO.CreateUser(user))
                    return Redirect("GetAllUsers");
                else
                    return View("CreateUser");
            }
            catch
            {
                return View("CreateUser");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult EditUser(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditUser(int id, User user)
        {
            try
            {
                if (userDAO.EditUser(id, user))
                    return RedirectToAction("GetAllUsers");
                else
                    return View("EditUser");
            }
            catch
            {
                return View("EditUser");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteUser(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteUser(int id, User user)
        {
            try
            {
                if (userDAO.DeleteUser(id))
                    return RedirectToAction("GetAllUsers");
                else
                    return View("DeleteUser");
            }
            catch
            {
                return View("DeleteUser");
            }
        }
        public ActionResult GetFlights(int id)
        {
            return View(flightDAO.GetFlights(id));
        }
        [Authorize(Roles = "Admin")]
        public ActionResult CreateFlight()
        {
            SelectList routelist = new SelectList(routeDAO.GetAllRoutes(), "Id_Route", "RouteNumber");
            SelectList driverlist = new SelectList(userDAO.GetDrivers(), "Id_User", "Name");
            SelectList conductorlist = new SelectList(userDAO.GetConductors(), "Id_User", "Name");
            SelectList transportlist = new SelectList(transportDAO.GetReadyTransports(), "Id_Transport", "Model");
            ViewBag.RouteList = routelist;
            ViewBag.DriverList = driverlist;
            ViewBag.ConductorList = conductorlist;
            ViewBag.TransportList = transportlist;
            return View();
        }
        [HttpPost]
        public ActionResult CreateFlight([Bind(Exclude = "Id_Flight")] Flight flight)
        {
            try
            {
                if (flightDAO.CreateFlight(flight))
                    return Redirect("GetAllRoutes");
                else
                    return View("CreateFlight");
            }
            catch
            {
                return View("CreateFlight");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult EditFlight(int id)
        {
            SelectList routelist = new SelectList(routeDAO.GetAllRoutes(), "Id_Route", "RouteNumber");
            SelectList driverlist = new SelectList(userDAO.GetDrivers(), "Id_User", "Name");
            SelectList conductorlist = new SelectList(userDAO.GetConductors(), "Id_User", "Name");
            SelectList transportlist = new SelectList(transportDAO.GetReadyTransports(), "Id_Transport", "Model");
            ViewBag.RouteList = routelist;
            ViewBag.DriverList = driverlist;
            ViewBag.ConductorList = conductorlist;
            ViewBag.TransportList = transportlist;
            return View();
        }
        [HttpPost]
        public ActionResult EditFlight(int id, Flight flight)
        {
            try
            {
                if (flightDAO.EditFlight(id, flight))
                    return RedirectToAction("GetAllRoutes");
                else
                    return View("EditFlight");
            }
            catch
            {
                return View("EditFlight");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteFlight(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteFlight(int id, Flight flight)
        {
            try
            {
                if (flightDAO.DeleteFlight(id))
                    return RedirectToAction("GetAllRoutes");
                else
                    return View("DeleteFlight");
            }
            catch
            {
                return View("DeleteFlight");
            }
        }
        [Authorize(Roles = "Driver")]
        public ActionResult GetDriversFlights() 
        {
            return View(flightDAO.GetDriversFlights(User.Identity.Name));
        }
        [Authorize(Roles = "Conductor")]
        public ActionResult GetConductorsFlights()
        {
            return View(flightDAO.GetConductorsFlights(User.Identity.Name));
        }
        [Authorize(Roles = "Admin")]
        public ActionResult ChangeStateRoute(int id, int state)
        {
            routeDAO.ChangeState(id, state);
            return RedirectToAction("GetAllRoutes", new { Route_State = state });
        }
        public ActionResult ChangeStateTransport(int id, int state)
        {
            transportDAO.ChangeState(id, state);
            return RedirectToAction("GetAllTransports", new { Transport_state = state});
        }
        public ActionResult SetRoleUser(int id)
        {
            SelectList rolelist = new SelectList(userDAO.GetAllRoles(), "Id_Role", "Name");
            ViewBag.RoleList = rolelist;
            return View();
        }
        [HttpPost]
        public ActionResult SetRoleUser(int id, User user)
        {
            try
            {
                if (userDAO.SetRoleUser(id, user))
                    return RedirectToAction("GetAllUsers");
                else
                    return View("SetRoleUser");
            }
            catch
            {
                return View("SetRoleUser");
            }
        }
    }
}