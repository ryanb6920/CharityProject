using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System;
using RestSharp;//Adding reference of RestSharp will be explained in next section.
using RestSharp.Authenticators;


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

        public int DonationUpdateDAL(Donation objDonation)
        {
            int output = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = string.Format(@"UPDATE [Donation]
                                SET Category='{0}', PickupAddress='{1}', PickupDate='{2}', Recipient='{3}',
                                DropOffDate = CONVERT(DATETIME,'{4}',103), NoItems = '{5}', NoRecycledItems = '{6}', Status = '{7}'
                                WHERE Id = '{8}'",
                                objDonation.Category, objDonation.PickupAddress, objDonation.PickupDate, objDonation.Recipient,
                                objDonation.DropOffDate, objDonation.NoItems, objDonation.NoRecycledItems, objDonation.Status, objDonation.Id);
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
                objCharity.CharityName, objCharity.Email, objCharity.URL, objCharity.PhoneNo, objCharity.OpenHours, objCharity.Address, objCharity.Password);
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
                                        objUser.Email, objUser.Password, objUser.UserType);
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

        public int RequestPickupDAL(Donation objDonation)
        {
            int output = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = string.Format(@"INSERT INTO [Donation] (DonorId, Category, PickupAddress, PickupDate, Recipient, Status)
                                        VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')",
                                        objDonation.DonorId, objDonation.Category, objDonation.PickupAddress, objDonation.PickupDate, objDonation.Recipient, objDonation.Status);
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

        public DataSet GetDonations()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = "select * from Donation";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "Donation");
            return ds;
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

        public Donation FindDonation(int id)
        {
            Donation objDonation = new Donation();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = string.Format(@"SELECT * FROM [Donation] WHERE Id = '{0}'", id);
            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        objDonation.Id = Convert.ToInt32(GetColumnValue(dr, "Id"));
                        objDonation.DonorId = Convert.ToInt32(GetColumnValue(dr, "DonorId"));
                        objDonation.Category = GetColumnValue(dr, "Category");
                        objDonation.PickupAddress = GetColumnValue(dr, "PickupAddress");
                        objDonation.PickupDate = Convert.ToDateTime(GetColumnValue(dr, "PickupDate"));
                        objDonation.Recipient = Convert.ToInt32(GetColumnValue(dr, "Recipient"));

                        string tempDOD = GetColumnValue(dr, "DropOffDate");
                        if (tempDOD != "")
                        {
                            objDonation.DropOffDate = Convert.ToDateTime(tempDOD);
                        }
                        else { objDonation.DropOffDate = null; }

                        string tempNI = GetColumnValue(dr, "NoItems");
                        if (tempNI != "")
                        {
                            objDonation.NoItems = Convert.ToInt32(tempNI);
                        }
                        else { objDonation.NoItems = null; }

                        string tempRI = GetColumnValue(dr, "NoRecycledItems");
                        if (tempRI != "")
                        {
                            objDonation.NoRecycledItems = Convert.ToInt32(tempRI);
                        }
                        else { objDonation.NoRecycledItems = null; }

                        objDonation.Status = GetColumnValue(dr, "Status");
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
            return objDonation;
        }

        public Donors FindDonor(string email, string password)
        {
            Donors objDonors = null;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = string.Format(@"SELECT TOP 1 * FROM [Donors]
                                            WHERE Email = '{0}' AND Password = '{1}'",
                                            email, password);
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

        public Donors FindDonor(int donorId)
        {
            Donors objDonors = null;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = string.Format(@"SELECT TOP 1 * FROM [Donors]
                                            WHERE Id = '{0}'",
                                            donorId);
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return objCharity;
        }

        public Charities FindCharity(int charityId)
        {
            Charities objCharity = null;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string sql = string.Format(@"SELECT TOP 1 * FROM [Charities]
                                            WHERE Id = '{0}'",
                                            charityId);
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return objCharity;
        }

        public List<Data> GetIndividualChartData(DataTable dt)
        {
            List<Data> dataList = new List<Data>();
            string ColumnName = "";
            int val = 0;
            foreach (DataRow dr in dt.Rows)
            {

                if (dr[0].GetType().Name == "DateTime")
                {
                    DateTime dtTime;
                    DateTime.TryParse(dr[0].ToString(), out dtTime);

                    ColumnName = dtTime.ToShortDateString();
                }
                else
                    ColumnName = dr[0].ToString();

                val = Convert.ToInt32(dr[1]);
                dataList.Add(new Data(ColumnName, val));
            }
            return dataList;
        }
        
        public List<ChartData> GetDataAnalyticsDAL()
        {
            List<ChartData> lstChartData = new List<ChartData>();
            DataSet ds = null;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                string cmd1 = "select Status, count(Id)  'Number of Donations' from Donation group by Status";
                using (SqlCommand cmd = new SqlCommand(cmd1, cn))
                {
                    ds = new DataSet();
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(ds);
                    dt = ds.Tables[0];
                    List<Data> dataList = GetIndividualChartData(dt);
                    lstChartData.Add(new ChartData() { ChartType = "PieChart", lstData = dataList });
                }

                string cmd2 = "select Category, count(Id)  'Number of Donations' from Donation group by Category";//select DonationType, CharityName, count(DonationId)  'Number of Donations' from Donations group by DonationType, CharityName
                using (SqlCommand cmd = new SqlCommand(cmd2, cn))
                {
                    ds = new DataSet();
                    dt.Clear();
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(ds);
                    dt = ds.Tables[0];
                    List<Data> dataList = GetIndividualChartData(dt);
                    lstChartData.Add(new ChartData() { ChartType = "ColumnChart1", lstData = dataList });
                }

                string cmd3 = @"select'Number of Donations', count(Id) from Donation
                                union all
                               select 'Number of Recipients', count(Id) from Charities";
                using (SqlCommand cmd = new SqlCommand(cmd3, cn))
                {
                    ds = new DataSet();
                    dt.Clear();
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(ds);
                    dt = ds.Tables[0];
                    List<Data> dataList = GetIndividualChartData(dt);
                    lstChartData.Add(new ChartData() { ChartType = "ColumnChart2", lstData = dataList });
                }

                string cmd4 = "select CONVERT(date, CreatedDate) 'Dates', count(Id) 'Number of Donations' from Donation group by CONVERT(date, CreatedDate)";
                using (SqlCommand cmd = new SqlCommand(cmd4, cn))
                {
                    ds = new DataSet();
                    dt.Clear();
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(ds);
                    dt = ds.Tables[0];
                    List<Data> dataList = GetIndividualChartData(dt);
                    lstChartData.Add(new ChartData() { ChartType = "ColumnChart3", lstData = dataList });
                }
            }


            return lstChartData;

        }

        public void send(Donors objDonor) //Method for Donor Sign Up Email
        {
            /*
             * Domain: sandbox159fa439dcf34a9eb2ff92d54042540e.mailgun.org
             * Key: key-f1eea887912d47d16655bca93ef5eb76
             * Email: uselessisuseful123@gmail.com
             *  
             */

            try
            {
                RestClient client = new RestClient();
                client.BaseUrl = new Uri("https://api.mailgun.net/v3");
                client.Authenticator = new HttpBasicAuthenticator("api", "key-f1eea887912d47d16655bca93ef5eb76");// replace this key with your key.

                RestRequest req = new RestRequest();
                req.AddParameter("domain", "sandbox159fa439dcf34a9eb2ff92d54042540e.mailgun.org", ParameterType.UrlSegment);//replace it with your sandbox id.                        
                req.Resource = "{domain}/messages";
                req.AddParameter("from", "Admin @ Useless is Useful <postmaster@sandbox159fa439dcf34a9eb2ff92d54042540e.mailgun.org>");//default smtp login from your sandbox  domain details.
                req.AddParameter("to", "Test <uselessisuseful123@gmail.com>");//authorized email only.
                req.AddParameter("subject", "Welcome!");// Subject of your email
                req.AddParameter("html", string.Format(@"
                                        <html>
	                                        <h3>Welcome {0} to Useless is Useful</h3>	
	                                        <p>Thank you for signing up as a Donor!</p>
	                                        <p>Your login details are:
		                                        Email:		{1}<br/>
		                                        Password:	{2}</p>
	                                        <p>We hope to recieve some donations from you soon!</p>	
	                                        <p>Many Thanks,<br/>
		                                        Admin @ Useless is Useful.
	                                        </p>	
                                        </html>                                
                                ",objDonor.FirstName,objDonor.Email,objDonor.Password));// Body of your email.
                req.Method = Method.POST;
                client.Execute(req);

            }
            catch (Exception ex)
            {
                //log exception.
                throw ex;
            }

        }

        public void send(Charities objCharity) //Method for Charity Sign Up Email
        {
            /*
             * Domain: sandbox159fa439dcf34a9eb2ff92d54042540e.mailgun.org
             * Key: key-f1eea887912d47d16655bca93ef5eb76
             * Email: uselessisuseful123@gmail.com
             *  
             */

            try
            {
                RestClient client = new RestClient();
                client.BaseUrl = new Uri("https://api.mailgun.net/v3");
                client.Authenticator = new HttpBasicAuthenticator("api", "key-f1eea887912d47d16655bca93ef5eb76");// replace this key with your key.

                RestRequest req = new RestRequest();
                req.AddParameter("domain", "sandbox159fa439dcf34a9eb2ff92d54042540e.mailgun.org", ParameterType.UrlSegment);//replace it with your sandbox id.                        
                req.Resource = "{domain}/messages";
                req.AddParameter("from", "Admin @ Useless is Useful <postmaster@sandbox159fa439dcf34a9eb2ff92d54042540e.mailgun.org>");//default smtp login from your sandbox  domain details.
                req.AddParameter("to", "Test <uselessisuseful123@gmail.com>");//authorized email only.
                req.AddParameter("subject", "Welcome!");// Subject of your email
                req.AddParameter("html", string.Format(@"
                                        <html>
	                                        <h3>Welcome {0} to Useless is Useful</h3>	
	                                        <p>Thank you for signing up as a Charity!</p>
	                                        <p>Your login details are:
		                                        Email:		{1}<br/>
		                                        Password:	{2}</p>
	                                        <p>We hope to recieve some donations form you soon!</p>	
	                                        <p>Many Thanks,<br/>
		                                        Admin @ Useless is Useful.
	                                        </p>	
                                        </html>                                
                                ", objCharity.CharityName, objCharity.Email, objCharity.Password));// Body of your email.
                req.Method = Method.POST;
                client.Execute(req);

            }
            catch (Exception ex)
            {
                //log exception.
                throw ex;
            }

        }

        public void send(Donation objDonation, Donors objDonor, Charities objCharity) //Method for Donor Update Email
        {
            /*
             * Domain: sandbox159fa439dcf34a9eb2ff92d54042540e.mailgun.org
             * Key: key-f1eea887912d47d16655bca93ef5eb76
             * Email: uselessisuseful123@gmail.com
             *  
             */

            try
            {
                RestClient client = new RestClient();
                client.BaseUrl = new Uri("https://api.mailgun.net/v3");
                client.Authenticator = new HttpBasicAuthenticator("api", "key-f1eea887912d47d16655bca93ef5eb76");// replace this key with your key.

                RestRequest req = new RestRequest();
                req.AddParameter("domain", "sandbox159fa439dcf34a9eb2ff92d54042540e.mailgun.org", ParameterType.UrlSegment);//replace it with your sandbox id.                        
                req.Resource = "{domain}/messages";
                req.AddParameter("from", "Admin @ Useless is Useful <postmaster@sandbox159fa439dcf34a9eb2ff92d54042540e.mailgun.org>");//default smtp login from your sandbox  domain details.
                req.AddParameter("to", "Test <uselessisuseful123@gmail.com>");//authorized email only.
                req.AddParameter("subject", string.Format("Update On your case! - Id: {0}",objDonation.Id));// Subject of your email
                req.AddParameter("html", string.Format(@"
                                        <html>
	                                        <h3>Hello! {0}</h3>
	                                        <p>Here is an update on how your case is going </p>
	                                        <h4>Donation ID: {1}</h4>	
	                                        <p>Your Case details are:<br/><br/>
		                                        Charity Name:	{2}<br/>
		                                        Donation Category: {3}<br/>
		                                        Pickup Date: {4}<br/>
		                                        Pickup Address: {5}<br/>		                                        
		                                        Number of items donated: {6}<br/>
		                                        Number of recycled items: {7}<br/>
		                                        Drop off date: {8}<br/>
                                                Donation Status: {9}<br/>
	                                        </p>
	                                        <p>We will be in touch with further updates!</p>	
	                                        <p>Many Thanks,<br/>
		                                        Admin @ Useless is Useful.
	                                        </p>	
                                        </html>                              
                                ",  objDonor.FirstName, objDonation.Id, objCharity.CharityName,
                                    objDonation.Category, objDonation.PickupDate.ToShortDateString(), objDonation.PickupAddress,
                                    objDonation.NoItems, objDonation.NoRecycledItems, objDonation.DropOffDate.ToString(), objDonation.Status));// Body of your email.
                req.Method = Method.POST;
                client.Execute(req);

            }
            catch (Exception ex)
            {
                //log exception.
                throw ex;
            }

        }

        public void send(Donation objDonation, Charities objCharity, Donors objDonor) //Method for Charity Update Email
        {
            /*
             * Domain: sandbox159fa439dcf34a9eb2ff92d54042540e.mailgun.org
             * Key: key-f1eea887912d47d16655bca93ef5eb76
             * Email: r.s.b@hotmail.co.nz
             *  
             */

            try
            {
                RestClient client = new RestClient();
                client.BaseUrl = new Uri("https://api.mailgun.net/v3");
                client.Authenticator = new HttpBasicAuthenticator("api", "key-f1eea887912d47d16655bca93ef5eb76");// replace this key with your key.

                if(objDonation.DropOffDate != null)
                {
                    
                }

                RestRequest req = new RestRequest();
                req.AddParameter("domain", "sandbox159fa439dcf34a9eb2ff92d54042540e.mailgun.org", ParameterType.UrlSegment);//replace it with your sandbox id.                        
                req.Resource = "{domain}/messages";
                req.AddParameter("from", "Admin @ Useless is Useful <postmaster@sandbox159fa439dcf34a9eb2ff92d54042540e.mailgun.org>");//default smtp login from your sandbox  domain details.
                req.AddParameter("to", "Test <uselessisuseful123@gmail.com>");//authorized email only.
                req.AddParameter("subject", string.Format("Update On your case! - Id: {0}", objDonation.Id));// Subject of your email
                req.AddParameter("html", string.Format(@"
                                        <html>
	                                        <h3>Hello! {0}</h3>
	                                        <p>Here is an update on how your case is going </p>
	                                        <h4>Donation ID: {1}</h4>	
	                                        <p>Your Case details are:<br/><br/>
		                                        Donor Name:		{2}<br/>
		                                        Donation Category: {3}<br/>
		                                        Pickup Date: {4}<br/>
		                                        Pickup Address: {5}<br/>		                                        
		                                        Number of items donated: {6}<br/>
		                                        Number of recycled items: {7}<br/>
		                                        Drop off date: {8}<br/>
                                                Donation Status: {9}<br/>
	                                        </p>
	                                        <p>We will be in touch with further updates!</p>	
	                                        <p>Many Thanks,<br/>
		                                        Admin @ Useless is Useful.
	                                        </p>	
                                        </html>                               
                                ",  objCharity.CharityName, objDonation.Id, objDonor.FirstName + " " + objDonor.LastName,
                                    objDonation.Category, objDonation.PickupDate.ToShortDateString(), objDonation.PickupAddress,
                                    objDonation.NoItems, objDonation.NoRecycledItems, objDonation.DropOffDate.ToString(),objDonation.Status));// Body of your email.
                req.Method = Method.POST;
                client.Execute(req);

            }
            catch (Exception ex)
            {
                //log exception.
                throw ex;
            }

        }

    }
}
