using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Test.Models;

namespace MVC_Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CustDistrModel objCustDistrModel = new CustDistrModel();
            objCustDistrModel.CustomerModel = new List<Customer>();
            objCustDistrModel.CustomerModel = GetCustomers();

            return View(objCustDistrModel);
        }

        [HttpPost]
        public ActionResult GetDistrByCustId(int id)
        {
            List<Distributor> objdistr = new List<Distributor>();
            objdistr = GetDistributors().Where(m => m.Id == id).ToList();
            SelectList objlistdistr = new SelectList(objdistr, "Id", "DistributorName");
            string distrs = objlistdistr.First().Text;
            string[] names = distrs.Split(',');
            objlistdistr = null;
            List<Distributor> distrslist = new List<Distributor>();
           
            for (int i = 0; i < names.Length; i++)
            {
                distrslist.Add(new Distributor { Id = i, DistributorName = names[i].ToString() });
            }

            SelectList listdistr = new SelectList(distrslist, "Id", "DistributorName");

            return Json(listdistr);
        }


        [HttpPost]
        public ActionResult GetLocalesByTerritory(int id)
        {
            string code = "";

            switch (id)
            {
                case 1:
                    code = "US";
                    break;

                case 2:
                    code = "FR";
                    break;

                case 3:
                    code = "CA";
                    break;

                case 4:
                    code = "SE";
                    break;

                case 5:
                    code = "MX";
                    break;
            }

            List<Locales> objlocales = new List<Locales>();
            objlocales = GetLocales().Where(m => m.LocaleName.Contains(code)).ToList();

            List<Locales> objlocaleslist = new List<Locales>();

            for (int i = 0; i < objlocales.Count; i++)
            {
                objlocaleslist.Add(new Locales { Id = i, LocaleName = objlocales[i].ToString() });
            }

            SelectList listlocales = new SelectList(objlocales, "Id", "LocaleName");

            return Json(listlocales);
        }



        public List<Customer> GetCustomers()
        {
            List<Customer> objcust = new List<Customer>();
            objcust.Add(new Customer { Id = 0, CustomerName = "--- Select ---" });
            objcust.Add(new Customer { Id = 1, CustomerName = "Sony Pictures Entertainment" });
            objcust.Add(new Customer { Id = 2, CustomerName = "BBCW" });
            objcust.Add(new Customer { Id = 3, CustomerName = "Warner Bros." });
            objcust.Add(new Customer { Id = 4, CustomerName = "Paramount Pictures" });
            objcust.Add(new Customer { Id = 5, CustomerName = "Village Roadshow" });
            return objcust;
        }

        public List<Distributor> GetDistributors()
        {
            List<Distributor> objdist = new List<Distributor>();
            objdist.Add(new Distributor { Id = 1, DistributorName = "Netflix,Hulu,Amazon" });
            objdist.Add(new Distributor { Id = 2, DistributorName = "TV Azteca,AB Svensk,Netflix" });
            objdist.Add(new Distributor { Id = 3, DistributorName = "Amazon,Hulu,Netflix" });
            objdist.Add(new Distributor { Id = 4, DistributorName = "Amazon,TV Azteca,Hulu" });
            objdist.Add(new Distributor { Id = 5, DistributorName = "Amazon,Hulu,AB Svensk" });

            return objdist;
        }

        public List<Locales> GetLocales()
        {
            List<Locales> objlocales = new List<Locales>();
            objlocales.Add(new Locales { Id = 1, LocaleName = "en-US"});
            objlocales.Add(new Locales { Id = 2, LocaleName = "fr-FR"});
            objlocales.Add(new Locales { Id = 3, LocaleName = "fr-CA"});
            objlocales.Add(new Locales { Id = 4, LocaleName = "es-MX"});
            objlocales.Add(new Locales { Id = 5, LocaleName = "en-CA"});
            objlocales.Add(new Locales { Id = 6, LocaleName = "sv-SE"});

            return objlocales;
        }
    }
}