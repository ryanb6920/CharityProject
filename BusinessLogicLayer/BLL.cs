using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

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

    }
}
