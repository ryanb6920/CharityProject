using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class BLL
    {
        public BLL()
        {
            //
        }

        public int DonorSignUpBLL(Donors objDonor)
        {
            int output;
            DAL objDAL = new DAL();
            output = objDAL.DonorSignUpDAL(objDonor);
            return output;
        }

        public int CharitySignUpBLL(Charities objCharity)
        {
            int output;
            DAL objDal = new DAL();
            output = objDal.CharitySignUpDAL(objCharity);
            return output;
        }

        public int AddUserBLL(Users objUser)
        {
            int output;
            DAL objDal = new DAL();
            output = objDal.AddUserDAL(objUser);
            return output;
        }

        public Users SignInBLL(Users objUserMaster)
        {
            Users objUser = new Users();
            DAL objDAL = new DAL();
            objUser = objDAL.SignInDal(objUserMaster);
            return objUser;
        }

        public Donors FindDonor(string email, string password)
        {
            Donors objDonor = new Donors();
            DAL objDAL = new DAL();
            objDonor = objDAL.FindDonor(email,password);
            return objDonor;
        }
        public Donors FindDonor(int donorId)
        {
            Donors objDonor = new Donors();
            DAL objDAL = new DAL();
            objDonor = objDAL.FindDonor(donorId);
            return objDonor;
        }

        public int RequestPickupBLL(Donation objDonation)
        {
            int output;
            DAL objDal = new DAL();
            output = objDal.RequestPickupDAL(objDonation);
            return output;
        }

        public int DonationUpdateBLL(Donation objDonation)
        {
            int output;
            DAL objDAL = new DAL();
            output = objDAL.DonationUpdateDAL(objDonation);
            return output;
        }

        public Charities FindCharity(string email, string password)
        {
            Charities objCharity = new Charities();
            DAL objDAL = new DAL();
            objCharity = objDAL.FindCharity(email, password);
            return objCharity;
        }

        public Charities FindCharity(int charityId)
        {
            Charities objCharity = new Charities();
            DAL objDAL = new DAL();
            objCharity = objDAL.FindCharity(charityId);
            return objCharity;
        }

        public DataSet GetCharities()
        {
            DAL objDal = new DAL();
            return objDal.GetCharities();
        }

        public DataSet GetDonations()
        {
            DAL objDal = new DAL();
            return objDal.GetDonations();
        }

        public Donation FindDonation(int id)
        {
            Donation objDonation = new Donation();
            DAL objDal = new DAL();
            objDonation = objDal.FindDonation(id);
            return objDonation;
        }

        public List<ChartData> GetDataAnalyticsBLL()
        {
            List<ChartData> output;
            DAL objDal = new DAL();
            output = objDal.GetDataAnalyticsDAL();// call DeleteDonationDAL method of DAL
            return output;

        }

        public void send(Donors objDonor)
        {
            DAL objDAL = new DAL();
            objDAL.send(objDonor);
        }
        public void send(Charities objCharity)
        {
            DAL objDAL = new DAL();
            objDAL.send(objCharity);
        }
        public void send(Donation objDonation,Charities objCharity,Donors objDonor)
        {
            DAL objDAL = new DAL();
            objDAL.send(objDonation,objCharity,objDonor);
        }
        public void send(Donation objDonation, Donors objDonor, Charities objCharity)
        {
            DAL objDAL = new DAL();
            objDAL.send(objDonation, objDonor, objCharity);
        }



    }
}
