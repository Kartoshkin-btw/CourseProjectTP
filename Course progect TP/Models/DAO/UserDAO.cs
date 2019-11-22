﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Course_progect_TP.Models.DAO
{
    public class UserDAO: DAO
    {
        public List<User> GetAllUsers()
        {
            Connect();
            List<User> userList = new List<User>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM [User]", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.Id_User = Convert.ToInt32(reader["Id_User"]);
                    user.Surname = Convert.ToString(reader["Surname"]);
                    user.Name = Convert.ToString(reader["Name"]);
                    user.Patronymic = Convert.ToString(reader["Patronymic"]);
                    user.Date_of_birth = Convert.ToString(reader["Date_of_birth"]);
                    user.Experience = Convert.ToInt32(reader["Experience"]);
                    user.Role = Convert.ToString(reader["Role"]);
                    user.Login = Convert.ToString(reader["Login"]);
                    userList.Add(user);
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
            return userList;
        }
        public bool CreateUser(User user)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [User] (Surname, Name, Patronymic, Date_of_birth, Experience, Role, Login) VALUES (@Surname, @Name, @Patronymic, @Date_of_birth, @Experience, @Role, @Login)", Connection);
                cmd.Parameters.Add(new SqlParameter("@Surname", user.Surname));
                cmd.Parameters.Add(new SqlParameter("@Name", user.Name));
                cmd.Parameters.Add(new SqlParameter("@Patronymic", user.Name));
                cmd.Parameters.Add(new SqlParameter("@Date_of_birth", user.Date_of_birth));
                cmd.Parameters.Add(new SqlParameter("@Experience", user.Experience));
                cmd.Parameters.Add(new SqlParameter("@Role", user.Role));
                cmd.Parameters.Add(new SqlParameter("@Login", user.Login));
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
        public bool EditUser(int id, User user)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE [User] SET Surname = @Surname, Name = @Name, Patronomic = @Patronomic, Date_of_birth = @Date_of_birth, Experience = @Experience, Role = @Role, Login = @Login WHERE Id_User = @Id_User", Connection);
                cmd.Parameters.Add(new SqlParameter("@Surname", user.Surname));
                cmd.Parameters.Add(new SqlParameter("@Name", user.Name));
                cmd.Parameters.Add(new SqlParameter("@Patronymic", user.Name));
                cmd.Parameters.Add(new SqlParameter("@Date_of_birth", user.Date_of_birth));
                cmd.Parameters.Add(new SqlParameter("@Experience", user.Experience));
                cmd.Parameters.Add(new SqlParameter("@Role", user.Role));
                cmd.Parameters.Add(new SqlParameter("@Login", user.Login));
                cmd.Parameters.Add(new SqlParameter("@Id_User", id));
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
        public bool DeleteUser(int id)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [User] WHERE Id_User = @Id_User", Connection);
                cmd.Parameters.Add(new SqlParameter("@Id_User", id));
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