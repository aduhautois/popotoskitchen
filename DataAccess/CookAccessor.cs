using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccess;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess
{
    public class CookAccessor
    {
        public static List<Cook> GetCookList(bool active)
        {
            var cookList = new List<Cook>();

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_all_cooks";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Active", active);

            try
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        var c = new Cook()
                        {
                            CookID = rdr.GetInt32(0),
                            FirstName = rdr.GetString(1),
                            LastName = rdr.GetString(2),
                            UserName = rdr.GetString(3),
                            LocalPhone = rdr.GetString(4),
                            EmailAddress = rdr.GetString(5),
                            Active = rdr.GetBoolean(6)
                        };

                        cookList.Add(c);
                    }

                    return cookList;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return cookList;
        }

        public static List<Cook> GetCookListBySearchTerm(string searchTerm, bool active)
        {
            var cookList = new List<Cook>();

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_search_cook_all";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SearchTerm", searchTerm);
            cmd.Parameters.AddWithValue("@Active", active);

            try
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        var c = new Cook()
                        {
                            CookID = rdr.GetInt32(0),
                            FirstName = rdr.GetString(1),
                            LastName = rdr.GetString(2),
                            UserName = rdr.GetString(3),
                            LocalPhone = rdr.GetString(4),
                            EmailAddress = rdr.GetString(5),
                            Active = rdr.GetBoolean(6)
                        };

                        cookList.Add(c);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return cookList;
        }

        public static int EditCook(Cook c)
        {
            int count = 0;

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_edit_cook";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CookID", c.CookID);
            cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
            cmd.Parameters.AddWithValue("@LastName", c.LastName);
            cmd.Parameters.AddWithValue("@Username", c.UserName);
            cmd.Parameters.AddWithValue("@LocalPhone", c.LocalPhone);
            cmd.Parameters.AddWithValue("@EmailAddress", c.EmailAddress);
            cmd.Parameters.AddWithValue("@Active", c.Active);

            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return count;
        }

        public static int AddCook(Cook c)
        {
            int count = 0;

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_add_cook";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
            cmd.Parameters.AddWithValue("@LastName", c.LastName);
            cmd.Parameters.AddWithValue("@UserName", c.UserName);
            cmd.Parameters.AddWithValue("@LocalPhone", c.LocalPhone);
            cmd.Parameters.AddWithValue("@EmailAddress", c.EmailAddress);

            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return count;
        }

        public static int DeleteCook(Cook c)
        {
            int count = 0;
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_delete_cook";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CookID", c.CookID);
            cmd.Parameters.AddWithValue("@Active", c.Active);

            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return count;
        }

        public static int SaveDeletedCook(Cook c)
        {
            int count = 0;

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_admin_save_deleted_cook";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CookID", c.CookID);
            cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
            cmd.Parameters.AddWithValue("@LastName", c.LastName);
            cmd.Parameters.AddWithValue("@Username", c.UserName);
            cmd.Parameters.AddWithValue("@LocalPhone", c.LocalPhone);
            cmd.Parameters.AddWithValue("@EmailAddress", c.EmailAddress);
            cmd.Parameters.AddWithValue("@PasswordHash", c.PasswordHash);
            cmd.Parameters.AddWithValue("@Active", c.Active);
            cmd.Parameters.AddWithValue("@DateDeleted", DateTime.Now);

            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return count;
        }

        public static int AdminDeleteCook(Cook c)
        {
            int count = 0;

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_admin_delete_cook";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CookID", c.CookID);

            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return count;
        }

        public static int LastAddedCook(Cook c)
        {
            int cookID = 0;

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_last_added_cook";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
            cmd.Parameters.AddWithValue("@LastName", c.LastName);
            cmd.Parameters.AddWithValue("@Username", c.UserName);
            cmd.Parameters.AddWithValue("@LocalPhone", c.LocalPhone);
            cmd.Parameters.AddWithValue("@EmailAddress", c.EmailAddress);

            try
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        cookID = rdr.GetInt32(0);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return cookID;
        }

        public static int AddCookPermission(Cook c, Assignment a)
        {
            int count = 0;

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_admin_add_assignment";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CookID", c.CookID);
            cmd.Parameters.AddWithValue("@RoleID", a.RoleID);
            cmd.Parameters.AddWithValue("@Active", a.Active);

            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return count;
        }

        public static List<Role> RetrieveRolesByCookID(int cookID)
        {
            var roles = new List<Role>();
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_roles_by_cook";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CookID", cookID);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        roles.Add(new Role()
                        {
                            RoleID = reader.GetString(0),
                            Description = reader.GetString(1)
                        });
                    }
                }
                else
                {
                    throw new ApplicationException("Data not found.");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return roles;
        }

        public static Cook RetrieveUserByUsername(string username)
        {
            Cook c;
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_cook_by_username";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@username", username);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    c = new Cook()
                    {
                        CookID = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        LocalPhone = reader.GetString(3),
                        EmailAddress = reader.GetString(4),
                        UserName = reader.GetString(5),
                        PasswordHash = reader.GetString(6),
                        Active = reader.GetBoolean(7)
                    };
                }
                else
                {
                    throw new ApplicationException("Data not found - select by username failed.");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return c;
        }

        public static int SetPasswordForUsername(string username, string oldPassword, string newPassword)
        {
            int count = 0;
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_update_password_for_username";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@OldPassword", oldPassword);
            cmd.Parameters.AddWithValue("@NewPassword", newPassword);

            try
            {
                conn.Open();
                count = (int)cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return count;
        }

        public static int FindUserByUsernameAndPassword(string username, string password)
        {
            int count = 0;
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_validate_active_username_and_password";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);

            try
            {
                conn.Open();
                count = (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return count;
        }

        public static int SendCookMessage(Message m)
        {
            int count = 0;

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_send_message";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CookID", m.CookID);
            cmd.Parameters.AddWithValue("@MessageSubject", m.MessageSubject);
            cmd.Parameters.AddWithValue("@Message", m.MessageText);
            cmd.Parameters.AddWithValue("@MessageDate", DateTime.Now);

            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return count;
        }

        public static List<Message> GetCookMessages(int cookID)
        {
            var messageList = new List<Message>();

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_get_message_list";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CookID", cookID);

            try
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        messageList.Add(new Message()
                        {
                            MessageID = rdr.GetInt32(0),
                            MessageSubject = rdr.GetString(1),
                            MessageText = rdr.GetString(2),
                            MessageDate = rdr.GetDateTime(3),
                            Active = rdr.GetBoolean(4),
                            HasRead = rdr.GetBoolean(5),
                            CookID = rdr.GetInt32(6)
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return messageList;
        }

        public static int EditMessage(Message m)
        {
            int count = 0;

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_edit_message";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CookID", m.CookID);
            cmd.Parameters.AddWithValue("@MessageID", m.MessageID);
            cmd.Parameters.AddWithValue("@Active", m.Active);
            cmd.Parameters.AddWithValue("@HasRead", m.HasRead);


            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return count;
        }

        public static int LogCookLogin(int cookID)
        {
            int count = 0;

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_log_login";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CookID", cookID);
            cmd.Parameters.AddWithValue("@LoginDate", DateTime.Now);

            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return count;
        }
    }
}
