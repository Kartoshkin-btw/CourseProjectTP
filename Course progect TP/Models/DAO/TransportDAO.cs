using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Course_progect_TP.Models.DAO
{
    public class TransportDAO : DAO
    {
        public List<Transport> GetAllTransports()
        {
            Connect();
            List<Transport> transportList = new List<Transport>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM [Transport]", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Transport transport = new Transport();
                    transport.Id_Transport = Convert.ToInt32(reader["Id_Transport"]);
                    transport.Model = Convert.ToString(reader["Model"]);
                    transport.Number = Convert.ToString(reader["Number"]);
                    transport.Release_year= Convert.ToString(reader["Release_Year"]);
                    transport.Transport_state = Convert.ToInt32(reader["Transport_state"]);
                    transportList.Add(transport);
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
            return transportList;
        }
        public bool CreateTransport(Transport transport)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Transport] (Model, Number, Release_Year, Transport_state) VALUES (@Model, @Number, @Release_Year, @Transport_state)", Connection);
                cmd.Parameters.Add(new SqlParameter("@Model", transport.Model));
                cmd.Parameters.Add(new SqlParameter("@Number", transport.Number));
                cmd.Parameters.Add(new SqlParameter("@Release_Year", transport.Release_year));
                cmd.Parameters.Add(new SqlParameter("@Transport_state", 1));
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
        public bool EditTransport(int id, Transport transport)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Transport] SET Model = @Model, Number = @Number, Release_Year = @Release_Year WHERE Id_Transport = @Id_Transport", Connection);
                cmd.Parameters.Add(new SqlParameter("@Model", transport.Model));
                cmd.Parameters.Add(new SqlParameter("@Number", transport.Number));
                cmd.Parameters.Add(new SqlParameter("@Release_Year", transport.Release_year));
                cmd.Parameters.Add(new SqlParameter("@Id_Transport", id));
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
        public bool DeleteTransport(int id)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [Transport] WHERE Id_Transport = @Id_Transport", Connection);
                cmd.Parameters.Add(new SqlParameter("@Id_Transport", id));
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
        public String GetTransport(int id)
        {
            String TransportInf = "";
            Connect();
            try
            {
                SqlCommand command = new SqlCommand("SELECT [Number], [Model] FROM [Transport] WHERE Id_Transport = @Id_Transport;", Connection);
                command.Parameters.AddWithValue("@Id_Transport", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TransportInf = Convert.ToString(reader["Model"]) + "( " +
                        Convert.ToString(reader["Number"]) + ")";

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
            return TransportInf;
        }
        public List<Transport> GetReadyTransports()
        {
            Connect();
            List<Transport> transportList = new List<Transport>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM [Transport] WHERE Transport_state = 1", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Transport transport = new Transport();
                    transport.Id_Transport = Convert.ToInt32(reader["Id_Transport"]);
                    transport.Model = Convert.ToString(reader["Model"]) + "( " + Convert.ToString(reader["Number"]) + ")";
                    transportList.Add(transport);
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
            return transportList;
        }
        public void ChangeState(int id, int state)
        {
            Connect();
            try
            {
                SqlCommand command = new SqlCommand("UPDATE [Transport] SET Transport_state = @Transport_state WHERE Id_Transport = @Id_Transport", Connection);
                command.Parameters.Add(new SqlParameter("@Transport_state", state));
                command.Parameters.Add(new SqlParameter("@Id_Transport", id));
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                Disconnect();
            }
        }
    }
}