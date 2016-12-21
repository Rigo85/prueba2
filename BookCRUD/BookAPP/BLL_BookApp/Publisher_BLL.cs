using BEL_BookApp;
using DAL_BookApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_BookApp
{
    public class Publisher_BLL
    {
        public Int32 SavePublisher(Publisher_BEL objBel)
        {
            Publisher_DAL objDal = new Publisher_DAL();
            try
            {
                return objDal.SavePublishers(objBel);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objDal = null;
            }
        }

        public Publisher_BEL GetPublisherRecord(int id)
        {
            Publisher_DAL objDal = new Publisher_DAL();
            try
            {
                return objDal.GetPublisherRecord(id);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objDal = null;
            }
        }

        public IEnumerable<Publisher_BEL> GetPublisherRecords()
        {
            Publisher_DAL objDal = new Publisher_DAL();
            try
            {
                return objDal.GetPublisherRecords();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objDal = null;
            }
        }

        public IEnumerable<BooksDetails_BEL> GetPublisherBooks(int id)
        {
            Publisher_DAL objDal = new Publisher_DAL();
            try
            {
                return objDal.GetPublisherBooks(id);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objDal = null;
            }
        }

        public Int32 DeletePublisherRecord(int id)
        {
            Publisher_DAL objDal = new Publisher_DAL();
            try
            {
                return objDal.DeletePublisherRecord(id);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objDal = null;
            }
        }

        public Int32 UpdatePublisherRecord(Publisher_BEL objBel)
        {
            Publisher_DAL objDal = new Publisher_DAL();
            try
            {
                return objDal.UpdatePublisherRecord(objBel);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objDal = null;
            }
        }

        public Int32 SavePublisherBooks(Publisher_BEL Publisher, IEnumerable<BooksDetails_BEL> Books)
        {
            Publisher_DAL objDal = new Publisher_DAL();
            try
            {
                return objDal.SavePublisherBooks(Publisher, Books);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objDal = null;
            }
        }
    }
}
