using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;

namespace HelloWorld.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Load()
        {
            Customer customer = new Customer()
            {
                CustomerCode = "1001",
                CustomerName = "mrinal"
            };

            return View("Customer",customer);
        }

        public ActionResult Enter()
        {
            return View("EnterCustomer");
        }

        public ActionResult Submit([ModelBinder(typeof(CustomerBinder))] Customer customer)
        {
            // first way
            //Customer customer = new Customer()
            //{
            //    CustomerCode = Request.Form["CustomerCode"],
            //    CustomerName = Request.Form["CustomerName"]
            //};
            // second way to pass as parameter data will be filled auto if name same in input tag and model property.
            return View("Customer", customer);
        }
    }

    public class CustomerBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpContextBase httpContext = controllerContext.HttpContext;
            string CustCode = httpContext.Request.Form["txtCustomerCode"];
            string CustName = httpContext.Request.Form["txtCustomerName"];

            Customer customer = new Customer()
            {
                CustomerCode = CustCode,
                CustomerName = CustName
            };

            return customer;
        }
    }
}