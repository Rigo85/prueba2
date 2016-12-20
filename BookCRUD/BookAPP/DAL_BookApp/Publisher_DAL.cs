using BEL_BookApp;
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
    public class Publisher_DAL
    {
        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

        public Int32 SavePublishers(Publisher_BEL objBEL)
        {
            int PublisherID = 0;

            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    try
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand("InsertPublishers_SP", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("PublisherName", objBEL.PublisherName);

                            PublisherID = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }

                scope.Complete();
            }

            return PublisherID;
        }

        public Publisher_BEL GetPublisherRecord(int id)
        {
            Publisher_BEL publisher = null;

            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("FetchPublisher_Sp", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("PublisherId", id);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                //todo probar linq
                                while (reader.Read())
                                {
                                    publisher = new Publisher_BEL(
                                       reader["PublisherName"].ToString());
                                    publisher.PublisherId = Convert.ToInt32(reader["PublisherId"]);
                                    publisher.Active = Convert.ToBoolean(reader["Active"]);
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

            return publisher;
        }

        public IEnumerable<Publisher_BEL> GetPublisherRecords()
        {
            List<Publisher_BEL> publishers = new List<Publisher_BEL>();

            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("FetchPublishers_Sp", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                //todo probar linq
                                while (reader.Read())
                                {
                                    Publisher_BEL publisher = new Publisher_BEL(
                                        reader["PublisherName"].ToString());
                                    publisher.PublisherId = Convert.ToInt32(reader["PublisherId"]);
                                    publisher.Active = Convert.ToBoolean(reader["Active"]);

                                    publishers.Add(publisher);
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

            return publishers;
        }

        public Int32 DeletePublisherRecord(int id)
        {
            int result = 0;

            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    try
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand("DeletePublishers_Sp", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("PublisherId", id);

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

        public Int32 UpdatePublisherRecord(Publisher_BEL objBEL)
        {
            int result = 0;

            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("UpdatePublishers_SP", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("PublisherId", objBEL.PublisherId);
                            cmd.Parameters.AddWithValue("PublisherName", objBEL.PublisherName);

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
