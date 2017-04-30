using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DAL
    {
        public string ConnectionString = string.Empty;

        public DAL()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["CharityProjectDB"].ConnectionString;
        }

        
        public string GetColumnValue(SqlDataReader dr, string columnName)
        {
            string columnValue = string.Empty;
            if (dr[columnName] != null && dr[columnName] != DBNull.Value)
            {
                columnValue = dr[columnName].ToString();
            }
            return columnValue;
        }

        public int DonorSignUpDAL(Donors objDonor)
        {
            int output = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = string.Format(@"INSERT INTO [Donors] (FirstName, LastName, Email, Password)
                                        VALUES ('{0}','{1}','{2}','{3}')",
                                        objDonor.FirstName, objDonor.LastName, objDonor.Email, objDonor.Password, objDonor.CreatedDate);
            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                output = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return output;
        }

        public int CharitySignUpDAL(Charities objCharity)
        {
            int output = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = string.Format(@"INSERT INTO [Charities] (CharityName, Email, URL, PhoneNo, OpenHours, Address, Password)
                                        VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                objCharity.CharityName,objCharity.Email,objCharity.URL,objCharity.PhoneNo,objCharity.OpenHours,objCharity.Address,objCharity.Password);
            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                output = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return output;
        }

        public int AddUserDAL(Users objUser)
        {
            int output = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = string.Format(@"INSERT INTO [Users] (Email, Password, UserType)
                                        VALUES ('{0}','{1}','{2}')",
                                        objUser.Email,objUser.Password,objUser.UserType);
            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                output = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return output;
        }

        public int RequestPickupDAL(Donation objDonation)
        {
            int output = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = string.Format(@"INSERT INTO [Donation] (DonorId, Category, PickupDate, Recipient, Status)
                                        VALUES ('{0}','{1}','{2}','{3}','{4}')",
                                        objDonation.DonorId, objDonation.Category, objDonation.PickupDate, objDonation.Recipient,objDonation.Status);
            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                output = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return output;
        }

        public DataSet GetCharities()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = "select * from Charities";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "Charities");
            return ds;
        }

        public Users SignInDal(Users objUserMaster)
        {
            Users objUser = null;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = string.Format(@"SELECT TOP 1 * FROM [Users]
                                            WHERE Email = '{0}' AND Password = '{1}'",
                                            objUserMaster.Email, objUserMaster.Password);
            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    objUser = new Users();
                    if (dr.Read())
                    {
                        objUser.Email = GetColumnValue(dr, "Email");
                        objUser.Password = GetColumnValue(dr, "Password");
                        objUser.UserType = GetColumnValue(dr, "UserType");
                    }                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return objUser;
        }

        public Donors FindDonor(string email, string password)
        {
            Donors objDonors = null;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = string.Format(@"SELECT TOP 1 * FROM [Donors]
                                            WHERE Email = '{0}' AND Password = '{1}'",
                                            email,password);
            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    objDonors = new Donors();
                    if (dr.Read())
                    {
                        objDonors.Id = Convert.ToInt32(GetColumnValue(dr, "Id"));
                        objDonors.FirstName = GetColumnValue(dr, "FirstName");
                        objDonors.LastName = GetColumnValue(dr, "LastName");
                        objDonors.Email = GetColumnValue(dr, "Email");
                        objDonors.Password = GetColumnValue(dr, "Password");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return objDonors;
        }

        public Charities FindCharity(string email, string password)
        {
            Charities objCharity = null;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = string.Format(@"SELECT TOP 1 * FROM [Charities]
                                            WHERE Email = '{0}' AND Password = '{1}'",
                                            email, password);
            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    objCharity = new Charities();
                    if (dr.Read())
                    {
                        objCharity.Id = Convert.ToInt32(GetColumnValue(dr, "Id"));
                        objCharity.CharityName = GetColumnValue(dr, "CharityName");
                        objCharity.Email = GetColumnValue(dr, "Email");
                        objCharity.URL = GetColumnValue(dr, "URL");
                        objCharity.PhoneNo = GetColumnValue(dr, "PhoneNo");
                        objCharity.OpenHours = GetColumnValue(dr, "OpenHours");
                        objCharity.Address = GetColumnValue(dr, "Address");
                        objCharity.Password = GetColumnValue(dr, "Password");
                    }

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return objCharity;
        }
        

    }
}
