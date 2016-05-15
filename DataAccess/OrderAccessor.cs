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
    public class OrderAccessor
    {
        public static int AddOrder(Order order)
        {
            int count = 0;
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_add_order";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            string sqlFormattedDate = order.OrderDate.ToString("MM-dd-yyyy HH:mm:ss");

            cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);
            cmd.Parameters.AddWithValue("@CookID", order.CookID);
            cmd.Parameters.AddWithValue("@OrderDate", sqlFormattedDate);

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

        public static int SelectLastOrder(Order order)
        {
            int orderID = 0;

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_last_order";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            string sqlFormattedDate = order.OrderDate.ToString("MM-dd-yyyy HH:mm:ss");
            cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);
            cmd.Parameters.AddWithValue("@CookID", order.CookID);
            cmd.Parameters.AddWithValue("@OrderDate", sqlFormattedDate);

            try
            {
                conn.Open();
                orderID = (Int32)cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                
                throw;
            }

            return orderID;
        }

        public static int EditOrder(Order order)
        {
            int count = 0;
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_edit_order";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            string sqlFormattedDate = order.OrderDate.ToString("MM-dd-yyyy HH:mm:ss");

            cmd.Parameters.AddWithValue("@OrderID", order.OrderID);
            cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);
            cmd.Parameters.AddWithValue("@CookID", order.CookID);
            cmd.Parameters.AddWithValue("@OrderDate", sqlFormattedDate);
            cmd.Parameters.AddWithValue("@Completed", order.Completed);
            cmd.Parameters.AddWithValue("@Paid", order.Paid);
            cmd.Parameters.AddWithValue("@Traded", order.Traded);
            cmd.Parameters.AddWithValue("@Active", order.Active);

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

        public static int DeleteOrder(Order order)
        {
            int count = 0;
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_delete_order";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderID", order.OrderID);
            cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);
            cmd.Parameters.AddWithValue("@Active", order.Active);

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

        public static int AdminDeleteOrder(Order order)
        {
            int count = 0;
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_admin_delete_order";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderID", order.OrderID);
            cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);

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

        public static int AdminSaveDeletedOrder(Order order)
        {
            int count = 0;
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_admin_save_deleted_order";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            string sqlFormattedDate = order.OrderDate.ToString("MM-dd-yyyy HH:mm:ss");

            cmd.Parameters.AddWithValue("@OrderID", order.OrderID);
            cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);
            cmd.Parameters.AddWithValue("@CookID", order.CookID);
            cmd.Parameters.AddWithValue("@OrderDate", sqlFormattedDate);
            cmd.Parameters.AddWithValue("@Completed", order.Active);
            cmd.Parameters.AddWithValue("@Paid", order.Paid);
            cmd.Parameters.AddWithValue("@Traded", order.Traded);
            cmd.Parameters.AddWithValue("@Active", order.Active);
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

        public static List<Order> GetOrderList_SearchAll(string searchTerm, bool active)
        {
            var orderList = new List<Order>();

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_order_all";
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
                        Order currentOrder = new Order()
                        {
                            OrderID = reader.GetInt32(0),
                            CustomerID = reader.GetInt32(1),
                            CookID = reader.GetInt32(2),
                            OrderDate = reader.GetDateTime(3),
                            Completed = reader.GetBoolean(4),
                            Paid = reader.GetBoolean(5),
                            Traded = reader.GetBoolean(6),
                            Active = reader.GetBoolean(7)
                        };

                        orderList.Add(currentOrder);

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

            return orderList;
        }

        public static List<Order> GetOrderList(bool active)
        {
            var orderList = new List<Order>();

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_all_orders";
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
                        Order currentOrder = new Order()
                        {
                            OrderID = reader.GetInt32(0),
                            CustomerID = reader.GetInt32(1),
                            CookID = reader.GetInt32(2),
                            OrderDate = reader.GetDateTime(3),
                            Completed = reader.GetBoolean(4),
                            Paid = reader.GetBoolean(5),
                            Traded = reader.GetBoolean(6),
                            Active = reader.GetBoolean(7)
                        };

                        orderList.Add(currentOrder);

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

            return orderList;
        }

        public static List<Order> GetOrderListByID(int orderID)
        {
            var orderList = new List<Order>();

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_order_by_id";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderID", orderID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Order currentOrder = new Order()
                        {
                            OrderID = reader.GetInt32(0),
                            CustomerID = reader.GetInt32(1),
                            CookID = reader.GetInt32(2),
                            OrderDate = reader.GetDateTime(3),
                            Completed = reader.GetBoolean(4),
                            Paid = reader.GetBoolean(5),
                            Traded = reader.GetBoolean(6),
                            Active = reader.GetBoolean(7)
                        };

                        orderList.Add(currentOrder);

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

            return orderList;
        }

        public static List<Order> GetOrderListByCookID(int cookID)
        {
            var orderList = new List<Order>();

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_order_by_cook";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CookID", cookID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Order currentOrder = new Order()
                        {
                            OrderID = reader.GetInt32(0),
                            CustomerID = reader.GetInt32(1),
                            CookID = reader.GetInt32(2),
                            OrderDate = reader.GetDateTime(3),
                            Completed = reader.GetBoolean(4),
                            Paid = reader.GetBoolean(5),
                            Traded = reader.GetBoolean(6),
                            Active = reader.GetBoolean(7)
                        };

                        orderList.Add(currentOrder);

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

            return orderList;
        }

        public static List<Order> GetOrderListByDateRange(DateTime beginDate, DateTime endDate)
        {
            var orderList = new List<Order>();

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_order_by_date_range";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            string sqlFormattedDateBeginDate = beginDate.ToString("MM-dd-yyyy HH:mm:ss");
            string sqlFormattedDateEndDate = endDate.ToString("MM-dd-yyyy HH:mm:ss");

            cmd.Parameters.AddWithValue("@BeginDate", sqlFormattedDateBeginDate);
            cmd.Parameters.AddWithValue("@EndDate", sqlFormattedDateEndDate);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Order currentOrder = new Order()
                        {
                            OrderID = reader.GetInt32(0),
                            CustomerID = reader.GetInt32(1),
                            CookID = reader.GetInt32(2),
                            OrderDate = reader.GetDateTime(3),
                            Completed = reader.GetBoolean(4),
                            Paid = reader.GetBoolean(5),
                            Traded = reader.GetBoolean(6),
                            Active = reader.GetBoolean(7)
                        };

                        orderList.Add(currentOrder);

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

            return orderList;
        }

        public static int AddNewOrderLine(OrderLine orderLine)
        {
            int count = 0;
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_add_order_lines";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderID", orderLine.OrderID);
            cmd.Parameters.AddWithValue("@RecipeID", orderLine.RecipeID);
            cmd.Parameters.AddWithValue("@Price", orderLine.Price);
            cmd.Parameters.AddWithValue("@Quantity", orderLine.Quantity);

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

        public static int EditOrderLine(OrderLine orderLine)
        {
            int count = 0;
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_edit_order_lines";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderID", orderLine.OrderID);
            cmd.Parameters.AddWithValue("@RecipeID", orderLine.RecipeID);
            cmd.Parameters.AddWithValue("@Price", orderLine.Price);
            cmd.Parameters.AddWithValue("@Quantity", orderLine.Quantity);
            cmd.Parameters.AddWithValue("@Active", orderLine.Active);
            cmd.Parameters.AddWithValue("@Completed", orderLine.Completed);

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

        public static int DeleteOrderLine(OrderLine orderLine)
        {
            int count = 0;
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_delete_order_lines";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderID", orderLine.OrderID);
            cmd.Parameters.AddWithValue("@RecipeID", orderLine.RecipeID);

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

        public static List<OrderLine> SelectOrderLines_CurrentOrder(OrderLine orderLine, bool active)
        {
            var orderList = new List<OrderLine>();

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_current_order_and_items";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderID", orderLine.OrderID);
            cmd.Parameters.AddWithValue("@Active", active);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderLine currentOrderLine = new OrderLine()
                        {
                            OrderID = reader.GetInt32(0),
                            RecipeID = reader.GetString(1),
                            Price = reader.GetInt32(2),
                            Quantity = reader.GetInt32(3),
                            Total = reader.GetInt32(4),
                            Active = reader.GetBoolean(5),
                            Completed = reader.GetBoolean(6)
                        };

                        orderList.Add(currentOrderLine);

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

            return orderList;
        }

        public static List<OrderLine> SelectOrderLines_CurrentOrderByID(int orderID)
        {
            var orderList = new List<OrderLine>();

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_current_order_and_items";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderID", orderID);
            cmd.Parameters.AddWithValue("@Active", true);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderLine currentOrderLine = new OrderLine()
                        {
                            OrderID = reader.GetInt32(0),
                            RecipeID = reader.GetString(1),
                            Price = reader.GetInt32(2),
                            Quantity = reader.GetInt32(3),
                            Total = reader.GetInt32(4),
                            Active = reader.GetBoolean(5),
                            Completed = reader.GetBoolean(6)
                        };

                        orderList.Add(currentOrderLine);

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

            return orderList;
        }

        public static int CompleteOrderLine()
        {
            int count = 0;

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_complete_order_lines";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@OrderID", 8);
            cmd.Parameters.AddWithValue("@RecipeID", "Black Truffle Risotto");
            cmd.Parameters.AddWithValue("@Completed", true);

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
