using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using BusinessObjects;
using DataAccess;
using System.Windows;

namespace BusinessLogic
{
    public class OrderManager
    {
        public bool AddOrder(Order order)
        {
            try
            {
                
                if (OrderAccessor.AddOrder(order) == 1)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            return false;
        }

        public bool EditOrder(Order order)
        {
            try
            {

                if (OrderAccessor.EditOrder(order) == 1)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public bool DeleteOrder(Order order)
        {
            try
            {

                if (OrderAccessor.DeleteOrder(order) == 1)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public bool AdminDeleteOrder(Order order)
        {
            try
            {

                if (OrderAccessor.AdminDeleteOrder(order) == 1)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public bool AdminSaveDeletedOrder(Order order)
        {
            try
            {

                if (OrderAccessor.AdminSaveDeletedOrder(order) == 1)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public int SelectLastOrder(Order order)
        {
            int orderID = 0;
            try
            {
                orderID = OrderAccessor.SelectLastOrder(order);
            }
            catch (Exception)
            {

                throw;
            }
            return orderID;
        }

        public List<Order> GetOrderList_SearchAll(string searchTerm, bool active)
        {
            string _searchTerm = searchTerm;

            try
            {
                var orderList = OrderAccessor.GetOrderList_SearchAll(_searchTerm, active);

                if (orderList.Count > 0)
                {
                    return orderList;
                }
                else
                {
                    throw new ApplicationException("No records found.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Order> GetOrderList(bool active)
        {
            try
            {
                var orderList = OrderAccessor.GetOrderList(active);

                if (orderList.Count > 0)
                {
                    return orderList;
                }
                else
                {
                    throw new ApplicationException("No records found.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Order> GetOrderListByID(int orderID)
        {
            try
            {
                var orderList = OrderAccessor.GetOrderListByID(orderID);

                if (orderList.Count > 0)
                {
                    return orderList;
                }
                else
                {
                    throw new ApplicationException("No records found.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Order> GetOrderListByCookID(int cookID)
        {
            try
            {
                var orderList = OrderAccessor.GetOrderListByCookID(cookID);

                if (orderList.Count > 0)
                {
                    return orderList;
                }
                else
                {
                    throw new ApplicationException("No records found.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Order> GetOrderListByDateRange(DateTime beginDate, DateTime endDate)
        {
            try
            {
                var orderList = OrderAccessor.GetOrderListByDateRange(beginDate, endDate);

                if (orderList.Count > 0)
                {
                    return orderList;
                }
                else
                {
                    throw new ApplicationException("No records found.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AddOrderLine(OrderLine orderLine)
        {

            try
            {

                if (OrderAccessor.AddNewOrderLine(orderLine) == 1)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public bool EditOrderLine(OrderLine orderLine)
        {
            try
            {

                if (OrderAccessor.EditOrderLine(orderLine) == 1)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public bool DeleteOrderLine(OrderLine orderLine)
        {
            try
            {

                if (OrderAccessor.EditOrderLine(orderLine) == 1)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public List<OrderLine> SelectOrderLines_CurrentOrder(OrderLine orderLine, bool active)
        {
            try
            {
                var orderLineList = OrderAccessor.SelectOrderLines_CurrentOrder(orderLine, active);

                if (orderLineList.Count > 0)
                {
                    return orderLineList;
                }
                else
                {
                    throw new ApplicationException("No records found.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<OrderLine> SelectOrderLines_CurrentOrderByID(int orderID)
        {
            try
            {
                var orderLineList = OrderAccessor.SelectOrderLines_CurrentOrderByID(orderID);

                if (orderLineList.Count > 0)
                {
                    return orderLineList;
                }
                else
                {
                    throw new ApplicationException("No records found.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CompleteOrderLine()
        {
            try
            {
                if(OrderAccessor.CompleteOrderLine() == 1)
                {
                    return true;
                }
                else
                {
                    throw new ApplicationException("Could not retrieve records from database.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
