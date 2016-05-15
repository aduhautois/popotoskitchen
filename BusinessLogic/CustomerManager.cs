using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using DataAccess;
using BusinessObjects;
using System.Windows;

namespace BusinessLogic
{
    public class CustomerManager
    {
        public bool AddNewCustomer(Customer cust)
        {
            try
            {
                if (CustomerAccessor.AddNewCustomer(cust) == 1)
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

        public bool EditCustomer(Customer cust)
        {
            try
            {
                var customer = cust;

                if (CustomerAccessor.EditCustomer(cust) == 1)
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

        public bool DeleteCustomer(Customer cust)
        {
            try
            {
                var customer = cust;

                if (CustomerAccessor.DeleteCustomer(cust) == 1)
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

        public bool ReactivateCustomer(int customerID)
        {
            try
            {
                if (CustomerAccessor.ReactivateCustomer(customerID) == 1)
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

        public bool AdminDeleteCustomer(int customerID)
        {
            try
            {
                if (CustomerAccessor.AdminDeleteCustomer(customerID) == 1)
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

        public bool AdminSaveDeletedCustomer(Customer customer)
        {
            try
            {
                if (CustomerAccessor.AdminRecordDeletedCustomer(customer) == 1)
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

        public List<Customer> GetCustomerList(int active)
        {
            int _active = active;
            try
            {
                var customerList = CustomerAccessor.GetCustomerList(_active);

                if (customerList.Count > 0)
                {
                    return customerList;
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

        public List<Customer> GetCustomerList_SearchAll(string searchTerm, int active)
        {
            string _searchTerm = searchTerm;

            try
            {
                var customerList = CustomerAccessor.GetCustomerList_SearchAll(_searchTerm, active);

                if (customerList.Count > 0)
                {
                    return customerList;
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

        public List<Customer> GetCustomerList_SearchCustomerID(string searchTerm, int active)
        {
            string _searchTerm = searchTerm;

            try
            {
                var customerList = CustomerAccessor.GetCustomerList_SearchCustomerID(_searchTerm, active);

                if (customerList.Count > 0)
                {
                    return customerList;
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

        public List<Customer> GetCustomerList_SearchName(string searchTerm, int active)
        {
            string _searchTerm = searchTerm;

            try
            {
                var customerList = CustomerAccessor.GetCustomerList_SearchName(_searchTerm, active);

                if (customerList.Count > 0)
                {
                    return customerList;
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

        public List<Customer> GetCustomerList_SearchFreeCompany(string searchTerm, int active)
        {
            string _searchTerm = searchTerm;

            try
            {
                var customerList = CustomerAccessor.GetCustomerList_SearchFreeCompany(_searchTerm, active);

                if (customerList.Count > 0)
                {
                    return customerList;
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
    }
}
