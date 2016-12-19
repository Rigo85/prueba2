using BEL_BookApp;
using DAL_BookApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                throw;
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
                throw;
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
                throw;
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
                throw;
            }
            finally
            {
                objDal = null;
            }
        }
    }
}
