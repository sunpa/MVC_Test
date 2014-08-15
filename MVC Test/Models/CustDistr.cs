using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Test.Models
{
    public class CustDistrModel
    {
        public List<Customer> CustomerModel { get; set; }

        //public List<Locale> LocaleModel { get; set; }

        public SelectList FilteredCustomer { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
    }

    public class Distributor
    {
        public int Id { get; set; }

        //public int CustId { get; set; }
        public string DistributorName { get; set; }
    }

    //public class Locale
    //{
    //    public int Id { get; set; }
    //    public string LocaleName { get; set; }
    //}
}