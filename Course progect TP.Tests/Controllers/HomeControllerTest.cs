using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Course_progect_TP;
using Course_progect_TP.Controllers;
using Course_progect_TP.Models;
using Course_progect_TP.Models.DAO;

namespace Course_progect_TP.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        // Проверка перевода маршрута из статуса "Принят" в статус "Не принят"
        public void ChangeRouteStatus()
        {
            int count = 0; // кол-во эл-в списка
            RouteDAO routeDAO = new RouteDAO();
            List<Route> routelist = routeDAO.GetReadyRoutes(); // получаем все маршруты со статусом "Принят" 
            foreach (Route route in routelist)
            {
                routeDAO.ChangeState(route.Id_Route, 2); // меняем статус на "Не принят" 
                count++;
            }
            List<Route> routelist2 = routeDAO.GetAllRoutes(); // получаем все маршруты

            //что ожидается:
            List<Route> expected = new List<Route>();
            for (int i = 0; i < count; i++)
            {
                Route route = new Route();
                route.Route_state = 2;
                expected.Add(route);
            }

            // Assert
            for (int i = 0; i < count; i++)
            {
                Assert.AreEqual(expected[i].Route_state, routelist2[i].Route_state);
            }

            // Откат данных 
            foreach (Route route in routelist)
            {
                routeDAO.ChangeState((route.Id_Route), 1); // меняем статус на "черновик" 
            }
        }
        [TestMethod]
        // Проверка перевода транспорта из статуса "Исправен" в статус "На тех. обслуживании"
        public void ChangeTransportStatus()
        {
            int count = 0; // кол-во эл-в списка
            TransportDAO transportDAO = new TransportDAO();
            List<Transport> transportlist = transportDAO.GetReadyTransports(); // получаем все маршруты со статусом "Принят" 
            foreach (Transport transport in transportlist)
            {
                transportDAO.ChangeState(transport.Id_Transport, 2); // меняем статус на "На тех. обслуживании" 
                count++;
            }
            List<Transport> transportlist2 = transportDAO.GetAllTransports(); // получаем весь транспорт

            //что ожидается:
            List<Transport> expected = new List<Transport>();
            for (int i = 0; i < count; i++)
            {
                Transport transport = new Transport();
                transport.Transport_state = 2;
                expected.Add(transport);
            }

            // Assert
            for (int i = 0; i < count; i++)
            {
                Assert.AreEqual(expected[i].Transport_state, transportlist2[i].Transport_state);
            }

            // Откат данных 
            foreach (Transport transport in transportlist)
            {
                transportDAO.ChangeState((transport.Id_Transport), 1); // меняем статус на "черновик" 
            }
        }
    }    
}
