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
        public ActionResult Index()
        {
            return View("Index");
        }
        public ActionResult GetAllRoutes()
        {
            return View(routeDAO.GetAllRoutes());
        }
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
        public ActionResult GetAllTransports()
        {
            return View(transportDAO.GetAllTransports());
        }
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
        public ActionResult GetAllUsers()
        {
            return View(userDAO.GetAllUsers());
        }
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
    }
}