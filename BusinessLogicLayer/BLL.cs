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

        public int RequestPickupBLL(Donation objDonation)
        {
            int output;
            DAL objDal = new DAL();
            output = objDal.RequestPickupDAL(objDonation);
            return output;
        }

        public Charities FindCharity(string email, string password)
        {
            Charities objCharity = new Charities();
            DAL objDAL = new DAL();
            objCharity = objDAL.FindCharity(email, password);
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


    }
}
