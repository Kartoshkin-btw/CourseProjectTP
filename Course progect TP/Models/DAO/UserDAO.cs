using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;

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
                    user.Id_Role = Convert.ToInt32(reader["Id_Role"]);
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [User] (Surname, Name, Patronymic, Date_of_birth, Experience, Id_Role, Login) VALUES (@Surname, @Name, @Patronymic, @Date_of_birth, @Experience, @Id_Role, @Login)", Connection);
                cmd.Parameters.Add(new SqlParameter("@Surname", user.Surname));
                cmd.Parameters.Add(new SqlParameter("@Name", user.Name));
                cmd.Parameters.Add(new SqlParameter("@Patronymic", user.Name));
                cmd.Parameters.Add(new SqlParameter("@Date_of_birth", user.Date_of_birth));
                cmd.Parameters.Add(new SqlParameter("@Experience", user.Experience));
                cmd.Parameters.Add(new SqlParameter("@Id_Role", 5));
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
                SqlCommand cmd = new SqlCommand("UPDATE [User] SET Surname = @Surname, Name = @Name, Patronymic = @Patronymic, Date_of_birth = @Date_of_birth, Experience = @Experience, Login = @Login WHERE Id_User = @Id_User", Connection);
                cmd.Parameters.Add(new SqlParameter("@Surname", user.Surname));
                cmd.Parameters.Add(new SqlParameter("@Name", user.Name));
                cmd.Parameters.Add(new SqlParameter("@Patronymic", user.Patronymic));
                cmd.Parameters.Add(new SqlParameter("@Date_of_birth", user.Date_of_birth));
                cmd.Parameters.Add(new SqlParameter("@Experience", user.Experience));
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
        public String GetUserName(int id) 
        {
            String Name = "";
            Connect();
            try
            {
                SqlCommand command = new SqlCommand("SELECT [Surname], [Name], [Patronymic] FROM [User] WHERE Id_User = @Id_User;", Connection);
                command.Parameters.AddWithValue("@Id_User", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Name = Convert.ToString(reader["Surname"]) + " " +
                        Convert.ToString(reader["Name"]) + " " +
                        Convert.ToString(reader["Patronymic"]);

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
            return Name;
        }
        public bool SetRoleUser(int id, User user)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand command = new SqlCommand("UPDATE [User] SET Id_Role = @Id_Role WHERE Id_User = @Id_User", Connection);
                command.Parameters.Add(new SqlParameter("@Id_Role", user.Id_Role));
                command.Parameters.Add(new SqlParameter("@Id_User", id));
                command.ExecuteNonQuery();
                SqlCommand command1 = new SqlCommand("SELECT [login] FROM [User] WHERE Id_User = @Id_User", Connection);
                command1.Parameters.Add(new SqlParameter("@Id_User", id));
                String login = Convert.ToString(command1.ExecuteScalar());
                RoleDAO roleDAO = new RoleDAO();
                roleDAO.SetRoleUser(login, user.Id_Role);
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
        public List<User> GetDrivers()
        {
            Connect();
            List<User> userList = new List<User>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM [User] WHERE Id_Role = 2", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.Id_User = Convert.ToInt32(reader["Id_User"]);
                    user.Name = Convert.ToString(reader["Surname"]) + " " + Convert.ToString(reader["name"]) + " " + Convert.ToString(reader["Patronymic"]);
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
        public List<User> GetConductors()
        {
            Connect();
            List<User> userList = new List<User>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM [User] WHERE Id_Role = 3", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.Id_User = Convert.ToInt32(reader["Id_User"]);
                    user.Name = Convert.ToString(reader["Surname"]) + " " + Convert.ToString(reader["name"]) + " " + Convert.ToString(reader["Patronymic"]);
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
        public List<Role> GetAllRoles()
        {
            Connect();
            List<Role> roleList = new List<Role>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM [Role]", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Role role = new Role();
                    role.Id_Role = Convert.ToInt32(reader["Id_Role"]);
                    role.Name = Convert.ToString(reader["Name"]);
                    roleList.Add(role);
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
            return roleList;
        }
    }
}