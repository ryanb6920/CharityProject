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

        public DataSet GetCharities()
        {
            DAL objDal = new DAL();
            return objDal.GetCharities();
        }


    }
}
