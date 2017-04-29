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
            string sql = string.Format(@"INSERT INTO [Donation] (DonorId, Category, PickupDate, Recipient, DropOffDate, NoItems, NoRecycledItems")
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

    }
}
