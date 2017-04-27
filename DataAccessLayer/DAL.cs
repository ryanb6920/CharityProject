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
            string sql = string.Format(@"INSERT INTO [Donors] (FirstName, LastName, Email, Password, CreatedDate)
                                        VALUES ('{0}','{1}','{2}','{3}', '{4}'",
                                        objDonor.FirstName, objDonor.LastName, objDonor.Email, objDonor.Password, objDonor.CreatedDate);
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return output;
        }

    }
}
