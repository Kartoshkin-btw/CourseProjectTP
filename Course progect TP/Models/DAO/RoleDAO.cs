using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Course_progect_TP.Models.DAO
{
    public class RoleDAO: DefaultDAO
    {
        public void SetRoleUser(string login, int Role)
        {
            Connect();
            try
            {
                SqlCommand command = new SqlCommand("SELECT [Id] FROM [AspNetUsers] WHERE UserName = @UserName", Connection);
                command.Parameters.Add(new SqlParameter("@UserName", login));
                String UserId = Convert.ToString(command.ExecuteScalar());
                SqlCommand command1 = new SqlCommand("SELECT [UserId] FROM [AspNetUserRoles] WHERE UserId = @UserId", Connection);
                command1.Parameters.Add(new SqlParameter("@UserId", UserId));
                String check = Convert.ToString(command1.ExecuteScalar());
                if (UserId == check)
                {
                    SqlCommand command2 = new SqlCommand("UPDATE [AspNetUserRoles] SET RoleId = @RoleId WHERE UserId = @UserId", Connection);
                    command2.Parameters.Add(new SqlParameter("@RoleId", Role));
                    command2.Parameters.Add(new SqlParameter("@UserId", UserId));
                    command2.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand command3 = new SqlCommand("INSERT INTO [AspNetUserRoles] (UserId, RoleId) VALUES (@UserId, @RoleId)", Connection);
                    command3.Parameters.Add(new SqlParameter("@UserId", UserId));
                    command3.Parameters.Add(new SqlParameter("@RoleId", Role));
                    command3.ExecuteNonQuery();
                }
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