﻿using BEL_BookApp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL_BookApp
{
    public class BooksDetails_DAL
    {
        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        public Int32 SaveBookDetails(BooksDetails_BEL objBEL)
        {
            int BookDetailsID = 0;

            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    try
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand("InsertBookDetails_SP", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("BookName", objBEL.BookName);
                            cmd.Parameters.AddWithValue("Author", objBEL.Author);
                            cmd.Parameters.AddWithValue("Price", objBEL.Price);

                            BookDetailsID = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }

                scope.Complete();
            }

            return BookDetailsID;
        }

        public BooksDetails_BEL GetBookRecord(int id)
        {
            BooksDetails_BEL book = null;

            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("FetchBookRecord_Sp", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("BookId", id);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                //todo probar linq
                                while (reader.Read())
                                {
                                    book = new BooksDetails_BEL(
                                                                reader["BookName"].ToString(),
                                                                reader["Author"].ToString(),
                                                                decimal.Parse(reader["Price"].ToString()));
                                    book.BookId = Convert.ToInt32(reader["BookId"]);
                                    book.Active = Convert.ToBoolean(reader["Active"]);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }

                scope.Complete();
            }

            return book;
        }

        public IEnumerable<BooksDetails_BEL> GetBookRecords()
        {
            List<BooksDetails_BEL> books = new List<BooksDetails_BEL>();

            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("FetchBookRecords_Sp", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                //todo probar linq
                                while (reader.Read())
                                {
                                    BooksDetails_BEL book = new BooksDetails_BEL(
                                        reader["BookName"].ToString(),
                                        reader["Author"].ToString(),
                                        decimal.Parse(reader["Price"].ToString()));
                                    book.BookId = Convert.ToInt32(reader["BookId"]);
                                    book.Active = Convert.ToBoolean(reader["Active"]);

                                    books.Add(book);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }

                scope.Complete();
            }

            return books;
        }

        public Int32 DeleteBookRecord(int id)
        {
            int result = 0;

            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    try
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand("DeleteBookRecords_Sp", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("BookId", id);

                            result = cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }

                scope.Complete();
            }

            return result > 0 ? result : 0;
        }

        public Int32 UpdateBookRecord(BooksDetails_BEL objBEL)
        {
            int result = 0;

            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("UpdateBookRecord_SP", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("BookId", objBEL.BookId);
                            cmd.Parameters.AddWithValue("BookName", objBEL.BookName);
                            cmd.Parameters.AddWithValue("Author", objBEL.Author);
                            cmd.Parameters.AddWithValue("Price", objBEL.Price);

                            result = cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }

                scope.Complete();
            }

            return result > 0 ? result : 0;
        }
    }
}
