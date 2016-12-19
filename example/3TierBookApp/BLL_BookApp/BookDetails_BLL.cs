using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using BEL_BookApp;
using DAL_BookApp;

namespace BLL_BookApp
{
   public class BookDetails_BLL
    {
        public Int32 SaveBookDetails(BooksDetails_BEL objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveBookDetails(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }

        public DataSet GetBookRecords()
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetBookRecords();            
            }             
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }

        public Int32 DeleteBookRecord(BooksDetails_BEL objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteBookRecord(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }

        public Int32 UpdateBookRecord(BooksDetails_BEL objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateBookRecord(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
    }
}

