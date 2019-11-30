using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Course_progect_TP.Models.DAO
{
    public class FlightDAO: DAO
    {
        public List<Flight> GetFlights(int id)
        {
            Connect();
            List<Flight> flightList = new List<Flight>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM [Flight] WHERE Id_Route = @Id_Route", Connection);
                command.Parameters.AddWithValue("@Id_Route", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Flight flight = new Flight();
                    flight.Id_Flight = Convert.ToInt32(reader["Id_Flight"]);
                    flight.Flight_date = Convert.ToString(reader["Flight_date"]);
                    flight.Start_time = Convert.ToString(reader["Start_time"]);
                    flight.End_time = Convert.ToString(reader["End_time"]);
                    flight.Id_Route = Convert.ToInt32(reader["Id_Route"]);
                    flight.Id_Driver = Convert.ToInt32(reader["Id_Driver"]);
                    flight.Id_Conductor = Convert.ToInt32(reader["Id_Conductor"]);
                    flight.Id_Transport = Convert.ToInt32(reader["Id_Transport"]);
                    flightList.Add(flight);
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
            return flightList;
        }
        public bool CreateFlight(Flight flight)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Flight] (Flight_date, Start_time, End_time, Id_Route, Id_Driver, Id_Conductor, Id_Transport) VALUES (@Flight_date, @Start_time, @End_time, @Id_Route, @Id_Driver, @Id_Conductor, @Id_Transport)", Connection);
                cmd.Parameters.Add(new SqlParameter("@Flight_date", flight.Flight_date));
                cmd.Parameters.Add(new SqlParameter("@Start_time", flight.Start_time));
                cmd.Parameters.Add(new SqlParameter("@End_time", flight.End_time));
                cmd.Parameters.Add(new SqlParameter("@Id_Route", flight.Id_Route));
                cmd.Parameters.Add(new SqlParameter("@Id_Driver", flight.Id_Driver));
                cmd.Parameters.Add(new SqlParameter("@Id_Conductor", flight.Id_Conductor));
                cmd.Parameters.Add(new SqlParameter("@Id_Transport", flight.Id_Transport));
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
        public bool EditFlight(int id, Flight flight)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Flight] SET Flight_date = @Flight_date, Start_time = @Start_time, End_time = @End_time, Id_Route = @Id_Route, Id_Driver = @Id_Driver, Id_Conductor = @Id_Conductor, Id_Transport = @Id_Transport WHERE Id_Flight = @Id_Flight", Connection);
                cmd.Parameters.Add(new SqlParameter("@Flight_date", flight.Flight_date));
                cmd.Parameters.Add(new SqlParameter("@Start_time", flight.Start_time));
                cmd.Parameters.Add(new SqlParameter("@End_time", flight.End_time));
                cmd.Parameters.Add(new SqlParameter("@Id_Route", flight.Id_Route));
                cmd.Parameters.Add(new SqlParameter("@Id_Driver", flight.Id_Driver));
                cmd.Parameters.Add(new SqlParameter("@Id_Conductor", flight.Id_Conductor));
                cmd.Parameters.Add(new SqlParameter("@Id_Transport", flight.Id_Transport));
                cmd.Parameters.Add(new SqlParameter("@Id_Flight", id));
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
        public bool DeleteFlight(int id)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [Flight] WHERE Id_Flight = @Id_Flight", Connection);
                cmd.Parameters.Add(new SqlParameter("@Id_Flight", id));
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
        public List<Flight> GetDriversFlights(string login)
             {
            Connect();
        List<Flight> flightList = new List<Flight>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM [Flight] WHERE Id_Driver = (SELECT Id_User FROM [User] WHERE login = @login)", Connection);
                command.Parameters.AddWithValue("@Login", login);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Flight flight = new Flight();
        flight.Id_Flight = Convert.ToInt32(reader["Id_Flight"]);
                    flight.Flight_date = Convert.ToString(reader["Flight_date"]);
                    flight.Start_time = Convert.ToString(reader["Start_time"]);
                    flight.End_time = Convert.ToString(reader["End_time"]);
                    flight.Id_Route = Convert.ToInt32(reader["Id_Route"]);
                    flight.Id_Driver = Convert.ToInt32(reader["Id_Driver"]);
                    flight.Id_Conductor = Convert.ToInt32(reader["Id_Conductor"]);
                    flight.Id_Transport = Convert.ToInt32(reader["Id_Transport"]);
                    flightList.Add(flight);
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
            return flightList;
        }
        public List<Flight> GetConductorsFlights(string login)
        {
            Connect();
            List<Flight> flightList = new List<Flight>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM [Flight] WHERE Id_Conductor = (SELECT Id_User FROM [User] WHERE login = @login)", Connection);
                command.Parameters.AddWithValue("@Login", login);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Flight flight = new Flight();
                    flight.Id_Flight = Convert.ToInt32(reader["Id_Flight"]);
                    flight.Flight_date = Convert.ToString(reader["Flight_date"]);
                    flight.Start_time = Convert.ToString(reader["Start_time"]);
                    flight.End_time = Convert.ToString(reader["End_time"]);
                    flight.Id_Route = Convert.ToInt32(reader["Id_Route"]);
                    flight.Id_Driver = Convert.ToInt32(reader["Id_Driver"]);
                    flight.Id_Conductor = Convert.ToInt32(reader["Id_Conductor"]);
                    flight.Id_Transport = Convert.ToInt32(reader["Id_Transport"]);
                    flightList.Add(flight);
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
            return flightList;
        }
    }
}