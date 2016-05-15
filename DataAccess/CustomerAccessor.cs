using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class CustomerAccessor
    {
        public static int AddNewCustomer(Customer customer)
        {
            int count = 0;
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_add_customer";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmd.Parameters.AddWithValue("@LocalPhone", customer.LocalPhone);
            cmd.Parameters.AddWithValue("@EmailAddress", customer.EmailAddress);
            cmd.Parameters.AddWithValue("@FreeCompany", customer.FreeCompany);

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

        public static int EditCustomer(Customer customer)
        {
            int count = 0;
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_edit_customer";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
            cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmd.Parameters.AddWithValue("@LocalPhone", customer.LocalPhone);
            cmd.Parameters.AddWithValue("@EmailAddress", customer.EmailAddress);
            cmd.Parameters.AddWithValue("@FreeCompany", customer.FreeCompany);

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

        public static int DeleteCustomer(Customer customer)
        {
            int count = 0;
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_delete_customer";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);

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

        public static int ReactivateCustomer(int customerID)
        {
            int count = 0;
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_reactivate_customer";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CustomerID", customerID);

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

        public static int AdminDeleteCustomer(int customerID)
        {
            int count = 0;
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_admin_delete_customer";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CustomerID", customerID);

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

        public static int AdminRecordDeletedCustomer(Customer customer)
        {
            int count = 0;
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_admin_save_deleted_customer";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
            cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmd.Parameters.AddWithValue("@LocalPhone", customer.LocalPhone);
            cmd.Parameters.AddWithValue("@EmailAddress", customer.EmailAddress);
            cmd.Parameters.AddWithValue("@FreeCompany", customer.FreeCompany);
            cmd.Parameters.AddWithValue("@Active", customer.Active);
            cmd.Parameters.AddWithValue("@DateDeleted", DateTime.Today
                );

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

        public static List<Customer> GetCustomerList(int active)
        {
            int _active = active;

            var customerList = new List<Customer>();

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_customers";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Active", active);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Customer currentCustomer = new Customer()
                        {
                            CustomerID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            LocalPhone = reader.GetString(3),
                            EmailAddress = reader.GetString(4),
                            FreeCompany = reader.GetString(5),
                            Active = reader.GetBoolean(6)
                        };

                        customerList.Add(currentCustomer);
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

            return customerList;
        }

        public static List<Customer> GetCustomerList_SearchAll(string searchTerm, int active)
        {
            var customerList = new List<Customer>();

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_customer_all";
            var cmd = new SqlCommand(query, conn);

            string _searchTerm = searchTerm;

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SearchTerm", _searchTerm);
            cmd.Parameters.AddWithValue("@Active", active);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Customer currentCustomer = new Customer()
                        {
                            CustomerID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            LocalPhone = reader.GetString(3),
                            EmailAddress = reader.GetString(4),
                            FreeCompany = reader.GetString(5),
                            Active = reader.GetBoolean(6)
                        };

                        customerList.Add(currentCustomer);

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

            return customerList;
        }

        public static List<Customer> GetCustomerList_SearchCustomerID(string searchTerm, int active)
        {
            var customerList = new List<Customer>();

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_customer_customerID";
            var cmd = new SqlCommand(query, conn);

            string _searchTerm = searchTerm;

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SearchTerm", _searchTerm);
            cmd.Parameters.AddWithValue("@Active", active);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Customer currentCustomer = new Customer()
                        {
                            CustomerID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            LocalPhone = reader.GetString(3),
                            EmailAddress = reader.GetString(4),
                            FreeCompany = reader.GetString(5),
                            Active = reader.GetBoolean(6)
                        };

                        customerList.Add(currentCustomer);

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

            return customerList;
        }

        public static List<Customer> GetCustomerList_SearchName(string searchTerm, int active)
        {
            var customerList = new List<Customer>();

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_customer_fullname";
            var cmd = new SqlCommand(query, conn);

            string _searchTerm = searchTerm;

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SearchTerm", _searchTerm);
            cmd.Parameters.AddWithValue("@Active", active);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Customer currentCustomer = new Customer()
                        {
                            CustomerID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            LocalPhone = reader.GetString(3),
                            EmailAddress = reader.GetString(4),
                            FreeCompany = reader.GetString(5),
                            Active = reader.GetBoolean(6)
                        };

                        customerList.Add(currentCustomer);

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

            return customerList;
        }

        public static List<Customer> GetCustomerList_SearchFreeCompany(string searchTerm, int active)
        {
            var customerList = new List<Customer>();

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_customer_freecompany";
            var cmd = new SqlCommand(query, conn);

            string _searchTerm = searchTerm;

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SearchTerm", _searchTerm);
            cmd.Parameters.AddWithValue("@Active", active);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Customer currentCustomer = new Customer()
                        {
                            CustomerID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            LocalPhone = reader.GetString(3),
                            EmailAddress = reader.GetString(4),
                            FreeCompany = reader.GetString(5),
                            Active = reader.GetBoolean(6)
                        };

                        customerList.Add(currentCustomer);

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

            return customerList;
        }

    }
}