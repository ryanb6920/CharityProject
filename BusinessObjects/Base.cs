using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Base
    {
        
    }

    public class Users
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class Donors
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class Charities
    {
        public int Id { get; set; }
        public string CharityName { get; set; }
        public string Email { get; set; }
        public string URL { get; set; }
        public string PhoneNo { get; set; }
        public string OpenHours { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class Donation
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public string Category { get; set; }
        public string PickupAddress { get; set; }
        public DateTime PickupDate { get; set; }
        public int Recipient { get; set; }
        public DateTime? DropOffDate { get; set; }
        public int? NoItems { get; set; }
        public int? NoRecycledItems { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class Data
    {
        public string ColumnName = "";
        public int Value = 0;

        public Data() { }

        public Data(string columnName, int value)
        {
            ColumnName = columnName;
            Value = value;
        }
    }

    public class ChartData
    {
        public string ChartType = "";
        public List<Data> lstData;
    }

}
