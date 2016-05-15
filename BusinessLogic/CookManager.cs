using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using BusinessObjects;
using DataAccess;

namespace BusinessLogic
{
    public class CookManager
    {
        public List<Cook> GetCookList(bool active)
        {
            var cookList = new List<Cook>();

            try
            {
                cookList = CookAccessor.GetCookList(active);

                if(cookList.Count > 0)
                {
                    return cookList;
                }
                else
                {
                    throw new ApplicationException("Could not retrieve records.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Cook> GetCookListByTerm(string searchTerm, bool active)
        {
            var cookList = new List<Cook>();

            try
            {
                cookList = CookAccessor.GetCookListBySearchTerm(searchTerm, active);
                if(cookList.Count > 0)
                {
                    return cookList;
                }
                else
                {
                    throw new ApplicationException("Could not retrieve records.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EditCook(Cook c)
        {
            try
            {
                if(CookAccessor.EditCook(c) == 1)
                {
                    return true;
                }
                else
                {
                    throw new ApplicationException("Could not edit cook.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AddCook(Cook c)
        {
            try
            {
                if(CookAccessor.AddCook(c) == 1)
                {
                    return true;
                }
                else
                {
                    throw new ApplicationException("Could not add cook.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteCook(Cook c)
        {
            try
            {
                if (CookAccessor.DeleteCook(c) == 1)
                {
                    return true;
                }
                else
                {
                    throw new ApplicationException("Could not delete cook.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool SaveDeletedCook(Cook c)
        {
            try
            {
                if (CookAccessor.SaveDeletedCook(c) == 1)
                {
                    return true;
                }
                else
                {
                    throw new ApplicationException("Could not save cook.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AdminDeleteCook(Cook c)
        {
            try
            {
                if(CookAccessor.AdminDeleteCook(c) == 1)
                {
                    return true;
                }
                else
                {
                    throw new ApplicationException("Could not delete cook.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int LastAddedCook(Cook c)
        {
            int cookID = 0;

            try
            {
                cookID = CookAccessor.LastAddedCook(c);
            }
            catch (Exception)
            {
                
                throw;
            }

            return cookID;
        }

        public bool AddCookPermission(Cook c, Assignment a)
        {
            try
            {
                if (CookAccessor.AddCookPermission(c, a) == 1)
                {
                    return true;
                }
                else
                {
                    throw new ApplicationException("Could not add permissions for cook.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool SendCookMessage(Message m)
        {
            try
            {
                if (CookAccessor.SendCookMessage(m) == 1)
                {
                    return true;
                }
                else
                {
                    throw new ApplicationException("Could not send message. Please try again.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EditMessage(Message m)
        {
            try
            {
                if (CookAccessor.EditMessage(m) == 1)
                {
                    return true;
                }
                else
                {
                    throw new ApplicationException("Could not edit message. Please try again.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Message> GetCookMessages(int cookID)
        {
            var messageList = new List<Message>();

            try
            {
                messageList = CookAccessor.GetCookMessages(cookID);

                if (messageList.Count > 0)
                {
                    return messageList;
                }
                else
                {
                    throw new ApplicationException("Could not retrieve messages.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool LogCookLogin(int cookID)
        {
            try
            {
                if (CookAccessor.LogCookLogin(cookID) == 1)
                {
                    return true;
                }
                else
                {
                    throw new ApplicationException("Could not log this session. Please contact your administrator.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
