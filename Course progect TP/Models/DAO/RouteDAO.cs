using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Course_progect_TP.Models.DAO
{
    public class RouteDAO : DAO
    {
        public List<Route> GetAllRoutes()
        {
            Connect();
            List<Route> routeList = new List<Route>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM [Route]", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Route route = new Route();
                    route.Id_Route = Convert.ToInt32(reader["Id_Route"]);
                    route.RouteNumber = Convert.ToString(reader["RouteNumber"]);
                    route.Start_stop = Convert.ToString(reader["Start_stop"]);
                    route.Final_stop = Convert.ToString(reader["Final_stop"]);
                    route.Price = Convert.ToInt32(reader["Price"]);
                    route.Travel_time = Convert.ToString(reader["Travel_time"]);
                    route.Route_state = Convert.ToInt32(reader["Route_state"]);
                    routeList.Add(route);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                Disconnect();
            }
            return routeList;
        }
        public bool CreateRoute(Route route)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Route] (RouteNumber, Start_stop, Final_stop, Price, Travel_time, Route_state) VALUES (@RouteNumber, @Start_stop, @Final_stop, @Price, @Travel_time, @Route_state)", Connection);
                cmd.Parameters.Add(new SqlParameter("@RouteNumber", route.RouteNumber));
                cmd.Parameters.Add(new SqlParameter("@Start_stop", route.Start_stop));
                cmd.Parameters.Add(new SqlParameter("@Final_stop", route.Final_stop));
                cmd.Parameters.Add(new SqlParameter("@Price", route.Price));
                cmd.Parameters.Add(new SqlParameter("@Travel_time", route.Travel_time));
                cmd.Parameters.Add(new SqlParameter("@Route_state", route.Route_state));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }
        public bool EditRoute(int id, Route route)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Route] SET RouteNumber = @RouteNumber, Start_stop = @Start_stop, Final_stop = @Final_stop, @Price = Price, @Travel_time = Travel_time, @Route_state = Route_state WHERE Id_Route = @Id_Route", Connection);
                cmd.Parameters.Add(new SqlParameter("@RouteNumber", route.RouteNumber));
                cmd.Parameters.Add(new SqlParameter("@Start_stop", route.Start_stop));
                cmd.Parameters.Add(new SqlParameter("@Final_stop", route.Final_stop));
                cmd.Parameters.Add(new SqlParameter("@Price", route.Price));
                cmd.Parameters.Add(new SqlParameter("@Travel_time", route.Travel_time));
                cmd.Parameters.Add(new SqlParameter("@Route_state", route.Route_state));
                cmd.Parameters.Add(new SqlParameter("@Id_Route", id));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }
        public bool DeleteRoute(int id)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [Route] WHERE Id_Route = @Id_Route", Connection);
                cmd.Parameters.Add(new SqlParameter("@Id_Route", id));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }

    }
}